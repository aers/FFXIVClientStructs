using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using FFXIVClientStructs.Attributes;
using FFXIVClientStructs.Interop;
using FFXIVClientStructs.Interop.Attributes;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.RepresentationModel;
using YamlDotNet.Serialization;

namespace CExporter;

public class Exporter {
    private static List<ProcessedEnum> _enums = [];
    private static List<ProcessedStruct> _structs = [];
    private static BindingFlags _bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;

    public static void ProcessTypes() {
        var havokTypes = ExporterStatics.GetHavokTypes();
        var xivTypes = ExporterStatics.GetXIVTypes();

        Console.WriteLine($"Found {havokTypes.Length} havok types");
        Console.WriteLine($"Found {xivTypes.Length} xiv types");

        var havokStructs = havokTypes.Where(t => t.IsStruct() && !t.IsGenericType).ToArray();
        var xivStructs = xivTypes.Where(t => t.IsStruct() && !t.IsGenericType).ToArray();

        Console.WriteLine($"Filtered havok to {havokStructs.Length} structs");
        Console.WriteLine($"Filtered xiv to {xivStructs.Length} structs");

        var now = DateTime.UtcNow;

        foreach (var sStruct in xivStructs.Concat(havokStructs)) {
            ProcessType(sStruct);
        }

        Console.WriteLine($"First pass took {DateTime.UtcNow - now:g}");

        now = DateTime.UtcNow;

        foreach (var @struct in _structs) {
            foreach (var virtualFunction in @struct.VirtualFunctions) {
                foreach (var field in virtualFunction.VirtualFunctionParameters) {
                    if (!field.FieldType.IsStruct()) continue;
                    if (field.FieldType.SizeOf() > 8 && !field.FieldType.IsPointer) {
                        ExporterStatics.WarningList.Add($"{@struct.StructNamespace}.{@struct.StructName} method {virtualFunction.VirtualFunctionName} has parameter `{field.FieldName}` with type {field.FieldType.Name} not as a pointer. C# will handle this as a stack pointer reference but correct typing would be `{field.FieldType.Name}* {field.FieldName}`");
                    }
                    if (_structs.Any(t => t.StructType == field.FieldType)) continue;
                    ProcessType(field.FieldType);
                }
            }
            foreach (var memberFunction in @struct.MemberFunctions) {
                foreach (var field in memberFunction.MemberFunctionParameters) {
                    if (!field.FieldType.IsStruct()) continue;
                    if (field.FieldType.SizeOf() > 8 && !field.FieldType.IsPointer && !@struct.StructType.IsHavok()) {
                        var fullName = string.IsNullOrWhiteSpace(@struct.StructNamespace) ? $"{@struct.StructNamespace}.{@struct.StructName}" : @struct.StructName;
                        ExporterStatics.WarningList.Add($"{fullName} method {memberFunction.MemberFunctionName} has parameter `{field.FieldName}` with type {field.FieldType.Name} not as a pointer. C# will handle this as a stack pointer reference but correct typing would be `{field.FieldType.Name}* {field.FieldName}`");
                    }
                }
            }
        }

        Console.WriteLine($"Second pass took {DateTime.UtcNow - now:g}");

        now = DateTime.UtcNow;

        var remaining = new List<Type>();

        foreach (var processed in _structs.SelectMany(t => t.Fields.Select(f => PreProcessType(f.FieldType))).ToArray()) {
            switch (processed) {
                case null:
                    break;
                case ProcessedStruct s:
                    if (_structs.Any(t => t.StructType == s.StructType)) continue;
                    _structs.Add(s);
                    remaining.AddRange(s.Fields.Select(t => t.FieldType));
                    break;
                case ProcessedEnum e:
                    if (_enums.Any(t => t.EnumType == e.EnumType)) continue;
                    _enums.Add(e);
                    break;
            }
        }

        Console.WriteLine($"Third pass took {DateTime.UtcNow - now:g}");

        now = DateTime.UtcNow;

ProcessRemaining:
        var remainingTypes = remaining.Distinct().ToArray();
        remaining.Clear();
        foreach (var type in remainingTypes) {
            var processed = PreProcessType(type);
            switch (processed) {
                case null:
                    break;
                case ProcessedStruct s:
                    if (_structs.Any(t => t.StructType == s.StructType)) continue;
                    _structs.Add(s);
                    remaining.AddRange(s.Fields.Select(t => t.FieldType));
                    break;
                case ProcessedEnum e:
                    if (_enums.Any(t => t.EnumType == e.EnumType)) continue;
                    _enums.Add(e);
                    break;
            }
        }

        if (remaining.Any()) goto ProcessRemaining;

        Console.WriteLine($"Fourth pass took {DateTime.UtcNow - now:g}");

        Console.WriteLine($"Processed {_enums.Count} enums and {_structs.Count} structs");
    }

    public static void WriteIDA(DirectoryInfo dir) {
        var structsOrdered = Array.Empty<ProcessedStruct>();
// make sure we have all the dependencies for each struct before we write them

ReExport:
        foreach (var @struct in _structs.Where(t => !structsOrdered.Contains(t))) {
            var types = structsOrdered.Select(t => t.StructType).ToArray();
            if (@struct.Dependencies.Any(t => types.Contains(t)) && !@struct.Dependencies.All(t => types.Contains(t))) continue;
            structsOrdered = [.. structsOrdered, @struct];
        }

        if (structsOrdered.Length != _structs.Count) goto ReExport;

        var serializer = new SerializerBuilder()
            .WithTypeConverter(ProcessedStructConverter.Instance)
            .WithTypeConverter(ProcessedEnumConverter.Instance)
            .WithTypeConverter(ProcessedFieldConverter.Instance)
            .WithTypeConverter(ProcessedVirtualFunctionConverter.Instance)
            .WithTypeConverter(ProcessedMemberFunctionConverter.Instance)
            .Build();
        var yaml = serializer.Serialize(new YamlExport {
            Enums = _enums.ToArray(),
            Structs = structsOrdered
        });

        new FileInfo(Path.Join(dir.FullName, "ffxiv_structs.yml")).WriteFile(yaml);
    }

    private static void ProcessType(Type type) {
        var ret = PreProcessType(type);
        switch (ret) {
            case null:
                return;
            case ProcessedStruct s:
                _structs.Add(s);
                break;
            case ProcessedEnum e:
                _enums.Add(e);
                break;
        }
    }

    private static object? PreProcessType(Type type) {
        if (_structs.Any(t => t.StructType == type)) return null;
        if (_enums.Any(t => t.EnumType == type)) return null;
        if (type.IsFixedBuffer()) return null;

        if (type.IsEnum) {
            var processedEnum = new ProcessedEnum {
                EnumType = type,
                EnumName = type.Name,
                EnumNamespace = type.GetNamespace(),
                EnumValues = type.GetFields().Where(t => t.GetCustomAttribute<ObsoleteAttribute>() == null && t.FieldType == type).ToDictionary(f => f.Name, f => f.GetRawConstantValue()!.ToString()!)
            };

            _enums.Add(processedEnum);
        } else if (type.IsStruct()) {
            var vtable = type.GetField("VTable", _bindingFlags)?.FieldType;
            ProcessedVirtualFunction[] virtualFunctions = [];
            if (vtable != null) {
                while (vtable.IsPointer)
                    vtable = vtable.GetElementType()!;
                virtualFunctions = vtable.GetFields(_bindingFlags).Select(f => new ProcessedVirtualFunction {
                    VirtualFunctionName = f.Name,
                    Offset = f.GetFieldOffset(),
                    VirtualFunctionReturnType = f.FieldType.GetFunctionPointerReturnType(),
                    VirtualFunctionParameters = f.FieldType.GetFunctionPointerParameterTypes().Select(p => new ProcessedField {
                        FieldType = p,
                        FieldOffset = 0,
                        FieldName = p.Name
                    }).ToArray()
                }).ToArray();
            }

            var memberFunctionClass = type.GetMember("MemberFunctionPointers", _bindingFlags).FirstOrDefault()?.DeclaringType;
            ProcessedMemberFunction[] memberFunctionsArray = [];
            if (memberFunctionClass != null) {
                var memberFunctions = memberFunctionClass.GetMethods(_bindingFlags);
                foreach (var memberFunction in memberFunctions) {
                    var memberFunctionAddress = memberFunction.GetCustomAttribute<MemberFunctionAttribute>();
                    if (memberFunctionAddress == null) continue;
                    var memberFunctionParameters = memberFunction.GetParameters();
                    var memberFunctionReturnType = memberFunction.ReturnType;
                    memberFunctionsArray =
                    [
                        .. memberFunctionsArray,
                        new ProcessedMemberFunction {
                            MemberFunctionSignature = memberFunctionAddress!.Signature,
                            MemberFunctionName = memberFunction.Name,
                            MemberFunctionReturnType = memberFunctionReturnType,
                            MemberFunctionParameters = memberFunctionParameters.Select(p => new ProcessedField {
                                FieldType = p.ParameterType,
                                FieldOffset = 0,
                                FieldName = p.Name!
                            }).ToArray()
                        },
                    ];
                }
            }

            var processedStruct = new ProcessedStruct {
                StructType = type,
                StructName = type.Name,
                StructNamespace = type.GetNamespace(),
                Fields = type.GetFields(_bindingFlags).Where(t => !ExporterStatics.IgnoredTypeNames.Contains(t.Name) && t.GetCustomAttribute<ObsoleteAttribute>() == null && t.GetCustomAttribute<CExportIgnoreAttribute>() == null).Select(f => new ProcessedField {
                    FieldType = f.FieldType,
                    FieldOffset = f.GetFieldOffset(),
                    FieldName = f.Name
                }).ToArray(),
                VirtualFunctions = virtualFunctions,
                MemberFunctions = memberFunctionsArray
            };

            _structs.Add(processedStruct);
        }
        return null;
    }
}

public class YamlExport {
    public required ProcessedEnum[] Enums;
    public required ProcessedStruct[] Structs;
}

public class ProcessedField {
    public required Type FieldType;
    public required string FieldName;
    public required int FieldOffset;
}

public class ProcessedStruct {
    public required Type StructType;
    public required string StructName;
    public required string StructNamespace;
    public required ProcessedField[] Fields;
    public required ProcessedVirtualFunction[] VirtualFunctions;
    public required ProcessedMemberFunction[] MemberFunctions;
    [YamlIgnore]
    public Type[] Dependencies => Fields.Select(t => t.FieldType).Where(t => !(t.IsPointer() || t.IsPrimitive || t.IsFixedBuffer() || t.IsEnum)).ToArray();
}

public class ProcessedEnum {
    public required Type EnumType;
    public required string EnumName;
    public required string EnumNamespace;
    public required Dictionary<string, string> EnumValues;
}

public class ProcessedVirtualFunction {
    public required string VirtualFunctionName;
    public required int Offset;
    public required Type VirtualFunctionReturnType;
    public required ProcessedField[] VirtualFunctionParameters;
}

public class ProcessedMemberFunction {
    public required string MemberFunctionSignature;
    public required string MemberFunctionName;
    public required Type MemberFunctionReturnType;
    public required ProcessedField[] MemberFunctionParameters;
}

public class ProcessedEnumConverter : IYamlTypeConverter {
    public bool Accepts(Type type) => type == typeof(ProcessedEnum);
    public object? ReadYaml(IParser parser, Type type) => throw new NotImplementedException();
    public void WriteYaml(IEmitter emitter, object? value, Type type) {
        if (value is not ProcessedEnum e) return;
        emitter.Emit(new MappingStart());
        emitter.Emit(new Scalar("type"));
        emitter.Emit(new Scalar(e.EnumType.FixTypeName((t, _) => t.SanitizeName())));
        emitter.Emit(new Scalar("name"));
        emitter.Emit(new Scalar(e.EnumName));
        emitter.Emit(new Scalar("underlying"));
        emitter.Emit(new Scalar(e.EnumType.GetEnumUnderlyingType().FixTypeName((t, _) => t.SanitizeName())));
        emitter.Emit(new Scalar("namespace"));
        emitter.Emit(new Scalar(e.EnumNamespace));
        emitter.Emit(new Scalar("values"));
        emitter.Emit(new MappingStart());
        foreach (var (key, val) in e.EnumValues) {
            emitter.Emit(new Scalar(key));
            emitter.Emit(new Scalar(val));
        }
        emitter.Emit(new MappingEnd());
        emitter.Emit(new MappingEnd());
    }
    public static readonly IYamlTypeConverter Instance = new ProcessedEnumConverter();
}

public class ProcessedFieldConverter : IYamlTypeConverter {
    public bool Accepts(Type type) => type == typeof(ProcessedField);
    public object? ReadYaml(IParser parser, Type type) => throw new NotImplementedException();
    public void WriteYaml(IEmitter emitter, object? value, Type type) {
        if (value is not ProcessedField f) return;
        emitter.Emit(new MappingStart());
        emitter.Emit(new Scalar("type"));
        emitter.Emit(new Scalar(f.FieldType.FixTypeName((t, _) => t.SanitizeName())));
        emitter.Emit(new Scalar("name"));
        emitter.Emit(new Scalar(f.FieldName));
        emitter.Emit(new Scalar("offset"));
        emitter.Emit(new Scalar(f.FieldOffset.ToString()));
        emitter.Emit(new MappingEnd());
    }
    public static readonly IYamlTypeConverter Instance = new ProcessedFieldConverter();
}

public class ProcessedStructConverter : IYamlTypeConverter {
    public bool Accepts(Type type) => type == typeof(ProcessedStruct);
    public object? ReadYaml(IParser parser, Type type) => throw new NotImplementedException();
    public void WriteYaml(IEmitter emitter, object? value, Type type) {
        if (value is not ProcessedStruct s) return;
        emitter.Emit(new MappingStart());
        emitter.Emit(new Scalar("type"));
        emitter.Emit(new Scalar(s.StructType.FixTypeName((t, _) => t.SanitizeName())));
        emitter.Emit(new Scalar("name"));
        emitter.Emit(new Scalar(s.StructName));
        emitter.Emit(new Scalar("namespace"));
        emitter.Emit(new Scalar(s.StructNamespace));
        emitter.Emit(new Scalar("field"));
        emitter.Emit(new SequenceStart(null, null, true, SequenceStyle.Block));
        foreach (var field in s.Fields) {
            ProcessedFieldConverter.Instance.WriteYaml(emitter, field, field.GetType());
        }
        emitter.Emit(new SequenceEnd());
        emitter.Emit(new Scalar("virtual_function"));
        emitter.Emit(new SequenceStart(null, null, true, SequenceStyle.Block));
        foreach (var virtualFunction in s.VirtualFunctions) {
            ProcessedVirtualFunctionConverter.Instance.WriteYaml(emitter, virtualFunction, virtualFunction.GetType());
        }
        emitter.Emit(new SequenceEnd());
        emitter.Emit(new Scalar("member_function"));
        emitter.Emit(new SequenceStart(null, null, true, SequenceStyle.Block));
        foreach (var memberFunction in s.MemberFunctions) {
            ProcessedMemberFunctionConverter.Instance.WriteYaml(emitter, memberFunction, memberFunction.GetType());
        }
        emitter.Emit(new SequenceEnd());
        emitter.Emit(new MappingEnd());
    }
    public static readonly IYamlTypeConverter Instance = new ProcessedStructConverter();
}

public class ProcessedMemberFunctionConverter : IYamlTypeConverter {
        public bool Accepts(Type type) => type == typeof(ProcessedMemberFunction);
    public object? ReadYaml(IParser parser, Type type) => throw new NotImplementedException();
    public void WriteYaml(IEmitter emitter, object? value, Type type) {
        if (value is not ProcessedMemberFunction m) return;
        emitter.Emit(new MappingStart());
        emitter.Emit(new Scalar("signature"));
        emitter.Emit(new Scalar(m.MemberFunctionSignature));
        emitter.Emit(new Scalar("return_type"));
        emitter.Emit(new Scalar(m.MemberFunctionReturnType.FixTypeName((t, _) => t.SanitizeName())));
        emitter.Emit(new Scalar("parameters"));
        emitter.Emit(new SequenceStart(null, null, true, SequenceStyle.Block));
        foreach (var parameter in m.MemberFunctionParameters) {
            ProcessedFieldConverter.Instance.WriteYaml(emitter, parameter, parameter.GetType());
        }
        emitter.Emit(new SequenceEnd());
        emitter.Emit(new MappingEnd());
    }
    public static readonly IYamlTypeConverter Instance = new ProcessedMemberFunctionConverter();
}

public class ProcessedVirtualFunctionConverter : IYamlTypeConverter {

    public bool Accepts(Type type) => type == typeof(ProcessedVirtualFunction);
    public object? ReadYaml(IParser parser, Type type) => throw new NotImplementedException();
    public void WriteYaml(IEmitter emitter, object? value, Type type) {
        if (value is not ProcessedVirtualFunction v) return;
        emitter.Emit(new MappingStart());
        emitter.Emit(new Scalar("name"));
        emitter.Emit(new Scalar(v.VirtualFunctionName));
        emitter.Emit(new Scalar("offset"));
        emitter.Emit(new Scalar(v.Offset.ToString()));
        emitter.Emit(new Scalar("return_type"));
        emitter.Emit(new Scalar(v.VirtualFunctionReturnType.FixTypeName((t, _) => t.SanitizeName())));
        emitter.Emit(new Scalar("parameters"));
        emitter.Emit(new SequenceStart(null, null, true, SequenceStyle.Block));
        foreach (var parameter in v.VirtualFunctionParameters) {
            ProcessedFieldConverter.Instance.WriteYaml(emitter, parameter, parameter.GetType());
        }
        emitter.Emit(new SequenceEnd());
        emitter.Emit(new MappingEnd());
    }

    public static readonly IYamlTypeConverter Instance = new ProcessedVirtualFunctionConverter();
}
