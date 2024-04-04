using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using FFXIVClientStructs.Attributes;
using FFXIVClientStructs.Interop.Attributes;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace CExporter;

public class Exporter {
    private static List<ProcessedEnum> _enums = [];
    private static List<ProcessedStruct> _structs = [];
    private static BindingFlags _bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
    private static List<Type> _processType = [];

    public static void ProcessTypes() {
        var havokTypes = ExporterStatics.GetHavokTypes();
        var xivTypes = ExporterStatics.GetXIVTypes();

        Console.WriteLine($"Found {havokTypes.Length} havok types");
        Console.WriteLine($"Found {xivTypes.Length} xiv types");

        var havokStructs = havokTypes.Where(t => t.IsStruct() && !t.IsGenericType && !t.IsFixedBuffer()).ToArray();
        var xivStructs = xivTypes.Where(t => t.IsStruct() && !t.IsGenericType && !t.IsFixedBuffer()).ToArray();

        Console.WriteLine($"Filtered havok to {havokStructs.Length} structs");
        Console.WriteLine($"Filtered xiv to {xivStructs.Length} structs");

        var now = DateTime.UtcNow;

        foreach (var sStruct in xivStructs.Concat(havokStructs)) {
            ProcessType(sStruct);
        }

        Console.WriteLine($"First pass took {DateTime.UtcNow - now:g}");

        var count = 0;
        now = DateTime.UtcNow;

        while (_processType.Count > 0) {
            var tmp = _processType
                .Where(t => t is { IsUnmanagedFunctionPointer: false, IsFunctionPointer: false })
                .ToArray();
            _processType.Clear();
            foreach (var @struct in tmp) {
                ProcessType(@struct);
            }


            count++;
        }

        Console.WriteLine($"Second pass took {DateTime.UtcNow - now:g} running a total of {count} times");

        Console.WriteLine($"Processed {_enums.Count} enums and {_structs.Count} structs");
    }

    public static void VerifyNoFieldOverlap() {
        foreach (var processedStruct in _structs) {
            var sizes = processedStruct.Fields.Select(t => new { StartOffset = t.FieldOffset, EndOffset = t.FieldOffset + t.FieldType.SizeOf(), Field = t.FieldName }).ToArray();
            foreach (var size in sizes) {
                var checks = sizes.Where(t => t != size && t.StartOffset <= size.StartOffset).ToArray();
                if (checks.Any(t => t.EndOffset > size.StartOffset && t.StartOffset != size.StartOffset))
                    ExporterStatics.ErrorList.Add($"Field overlap detected in {processedStruct.StructType.FullSanitizeName()} with field {size.Field}");
                if(checks.Any(t => t.StartOffset == size.StartOffset))
                    ExporterStatics.ErrorList.Add($"Union field detected but not defined in {processedStruct.StructType.FullSanitizeName()} with field {size.Field}");
            }
        }
    }

    public static void Write(DirectoryInfo dir) {
        var structsOrdered = Array.Empty<ProcessedStruct>();
// make sure we have all the dependencies for each struct before we write them

ReExport:
        foreach (var @struct in _structs.Where(t => !structsOrdered.Contains(t))) {
            var types = structsOrdered.Select(t => t.StructType).ToArray();
            if (!@struct.Dependencies.All(t => types.Contains(t))) continue;
            structsOrdered = [.. structsOrdered, @struct];
        }

        if (structsOrdered.Length != _structs.Count) goto ReExport;

        var serializer = new SerializerBuilder()
            .WithNamingConvention(UnderscoredNamingConvention.Instance)
            .WithTypeConverter(ProcessedStructConverter.Instance)
            .WithTypeConverter(ProcessedEnumConverter.Instance)
            .WithTypeConverter(ProcessedFieldConverter.Instance)
            .WithTypeConverter(ProcessedVirtualFunctionConverter.Instance)
            .WithTypeConverter(ProcessedMemberFunctionConverter.Instance)
            .Build();
        var yaml = serializer.Serialize(new YamlExport {
            Enums = [.. _enums],
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
        if (type.IsFixedBuffer()) return null;
        while (type.IsPointer) type = type.GetElementType()!;
        while (type.IsGenericPointer()) type = type.GenericTypeArguments[0];

        if (type.IsEnum) {
            if (_enums.Any(t => t.EnumType.FullSanitizeName() == type.FullSanitizeName())) return null;
            var processedEnum = new ProcessedEnum {
                EnumType = type,
                EnumName = type.Name,
                EnumNamespace = type.GetNamespace(),
                EnumValues = type.GetFields().Where(t => t.GetCustomAttribute<ObsoleteAttribute>() == null && t.FieldType == type).ToDictionary(f => f.Name, f => f.GetRawConstantValue()!.ToString()!)
            };

            _enums.Add(processedEnum);
        } else if (type.IsStruct()) {
            while (type.IsPointer) type = type.GetElementType()!;
            while (type.IsGenericPointer()) type = type.GenericTypeArguments[0];
            if (type.IsFunctionPointer || type.IsUnmanagedFunctionPointer) {
                foreach (var functionPointerParameterType in type.GetFunctionPointerParameterTypes()) {
                    ProcessType(functionPointerParameterType);
                    type = type.GetFunctionPointerReturnType();
                }
            }
            if (!type.IsStruct() || type.IsEnum) return null;
            if (_structs.Any(t => t.StructType.FullSanitizeName() == type.FullSanitizeName())) return null;
            var vtable = type.GetField("VTable", _bindingFlags)?.FieldType;
            ProcessedVirtualFunction[] virtualFunctions = [];
            if (vtable != null) {
                vtable = vtable.GetElementType()!;
                virtualFunctions = vtable.GetFields(_bindingFlags).Select(f => {
                    _processType.Add(f.FieldType.GetFunctionPointerReturnType());
                    return new ProcessedVirtualFunction {
                        VirtualFunctionName = f.Name,
                        Offset = f.GetFieldOffset(),
                        VirtualFunctionReturnType = f.FieldType.GetFunctionPointerReturnType(),
                        VirtualFunctionParameters = f.FieldType.GetFunctionPointerParameterTypes().Select((p, i) => {
                            _processType.Add(p);
                            return new ProcessedField {
                                FieldType = p,
                                FieldOffset = -1,
                                FieldName = 'a' + (i + 1).ToString()
                            };
                        }).ToArray()
                    };
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
                    _processType.Add(memberFunctionReturnType);
                    memberFunctionsArray =
                    [
                        .. memberFunctionsArray,
                        new ProcessedMemberFunction {
                            MemberFunctionSignature = memberFunctionAddress!.Signature,
                            MemberFunctionName = memberFunction.Name,
                            MemberFunctionReturnType = memberFunctionReturnType,
                            MemberFunctionParameters = [
                                new ProcessedField {
                                    FieldTypeOverride = memberFunctionClass.FullSanitizeName() + "*",
                                    FieldType = memberFunctionClass,
                                    FieldOffset = -1,
                                    FieldName = "this"
                                },
                                ..memberFunctionParameters.Select(p => {
                                _processType.Add(p.ParameterType);
                                return new ProcessedField {
                                    FieldType = p.ParameterType,
                                    FieldOffset = -1,
                                    FieldName = p.Name!
                                };
                            }).ToArray()]
                        },
                    ];
                }
            }

            var fields = type.GetFields(_bindingFlags);
            var unionFields = fields.Where(t => t.GetCustomAttribute<ObsoleteAttribute>() == null && t.GetCustomAttribute<CExportIgnoreAttribute>() == null && t.GetCustomAttribute<CExporterUnionAttribute>() != null).ToArray();

            if (unionFields.Any()) {
                var unions = new List<ProcessedStruct>();
                foreach (var unionField in unionFields) {
                    var attr = unionField.GetCustomAttribute<CExporterUnionAttribute>()!;
                    var index = unions.FindIndex(t => t.StructName == attr.Union);
                    if(index == -1)
                        unions.Add(new ProcessedStruct {
                            StructType = type,
                            StructName = attr.Union,
                            StructNamespace = type.FullSanitizeName(),
                            StructSize = -1,
                            Fields = [
                                new ProcessedField {
                                    FieldType = unionField.FieldType,
                                    FieldOffset = unionField.GetFieldOffset(),
                                    FieldName = unionField.Name
                                }
                            ],
                            VirtualFunctions = [],
                            MemberFunctions = [],
                            StructTypeOverride = type.FullSanitizeName() + $"{ExporterStatics.Separator}{attr.Union}"
                        });
                    else
                        unions[index].Fields = [
                            ..unions[index].Fields,
                            new ProcessedField {
                                FieldType = unionField.FieldType,
                                FieldOffset = unionField.GetFieldOffset(),
                                FieldName = unionField.Name
                            }
                        ];
                }
            }

            var processedStruct = new ProcessedStruct {
                StructType = type,
                StructName = type.Name,
                StructNamespace = type.GetNamespace(),
                StructSize = type.SizeOf(),
                Fields = fields.Where(t => !ExporterStatics.IgnoredTypeNames.Contains(t.Name) && t.GetCustomAttribute<ObsoleteAttribute>() == null && t.GetCustomAttribute<CExportIgnoreAttribute>() == null && t.GetCustomAttribute<CExporterUnionAttribute>() == null).Select(f => {
                    if (f.FieldType.IsFunctionPointer || f.FieldType.IsUnmanagedFunctionPointer) {
                        _processType.Add(f.FieldType.GetFunctionPointerReturnType());
                        return new ProcessedFunctionField {
                            FieldType = f.FieldType,
                            FieldOffset = f.GetFieldOffset(),
                            FieldName = f.Name,
                            FunctionReturnType = f.FieldType.GetFunctionPointerReturnType(),
                            FunctionParameters = f.FieldType.GetFunctionPointerParameterTypes().Select((p, i) => {
                                _processType.Add(p);
                                return new ProcessedField {
                                    FieldType = p,
                                    FieldOffset = -1,
                                    FieldName = 'a' + (i + 1).ToString()
                                };
                            }).ToArray()
                        };
                    }
                    if (f.FieldType.IsFixedBuffer()) {
                        _processType.Add(f.FieldType.GetFields()[0].FieldType);
                        return new ProcessedFixedField {
                            FieldType = f.FieldType.GetFields()[0].FieldType,
                            FieldOffset = f.GetFieldOffset(),
                            FieldName = f.Name,
                            FixedSize = f.FieldType.StructLayoutAttribute!.Size
                        };
                    }
                    _processType.Add(f.FieldType);
                    return new ProcessedField {
                        FieldType = f.FieldType,
                        FieldOffset = f.GetFieldOffset(),
                        FieldName = f.Name
                    };
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
    public string? FieldTypeOverride;
    public required Type FieldType;
    public required string FieldName;
    public required int FieldOffset;
}

public class ProcessedFixedField : ProcessedField {
    public required int FixedSize;
}

public class ProcessedFunctionField : ProcessedField {
    public required Type FunctionReturnType;
    public required ProcessedField[] FunctionParameters;
}

public class ProcessedStruct {
    public string? StructTypeOverride;
    public required Type StructType;
    public required string StructName;
    public required string StructNamespace;
    public required int StructSize;
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
        emitter.Emit(new Scalar(e.EnumType.FullSanitizeName()));
        emitter.Emit(new Scalar("name"));
        emitter.Emit(new Scalar(e.EnumName));
        emitter.Emit(new Scalar("underlying"));
        emitter.Emit(new Scalar(e.EnumType.GetEnumUnderlyingType().FullSanitizeName()));
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
        if (f.FieldType.IsFunctionPointer || f.FieldType.IsUnmanagedFunctionPointer) {
            emitter.Emit(new Scalar("__fastcall"));
        } else {
            emitter.Emit(new Scalar(f.FieldTypeOverride ?? f.FieldType.FullSanitizeName()));
        }
        emitter.Emit(new Scalar("name"));
        emitter.Emit(new Scalar(f.FieldName));
        if (f.FieldOffset >= 0) {
            emitter.Emit(new Scalar("offset"));
            emitter.Emit(new Scalar(f.FieldOffset.ToString()));
        }
        switch (f) {
            case ProcessedFunctionField func:
            {
                emitter.Emit(new Scalar("return_type"));
                emitter.Emit(new Scalar(func.FunctionReturnType.FullSanitizeName()));
                emitter.Emit(new Scalar("parameters"));
                emitter.Emit(new SequenceStart(null, null, true, SequenceStyle.Block));
                foreach (var p in func.FunctionParameters) {
                    emitter.Emit(new MappingStart());
                    emitter.Emit(new Scalar("type"));
                    emitter.Emit(new Scalar(p.FieldTypeOverride ?? p.FieldType.FullSanitizeName()));
                    emitter.Emit(new Scalar("name"));
                    emitter.Emit(new Scalar(p.FieldName));
                    emitter.Emit(new MappingEnd());
                }
                emitter.Emit(new SequenceEnd());
                break;
            }
            case ProcessedFixedField fix:
                emitter.Emit(new Scalar("size"));
                emitter.Emit(new Scalar(fix.FixedSize.ToString()));
                break;
        }
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
        emitter.Emit(new Scalar(!string.IsNullOrWhiteSpace(s.StructTypeOverride) ? s.StructTypeOverride : s.StructType.FullSanitizeName()));
        emitter.Emit(new Scalar("name"));
        emitter.Emit(new Scalar(s.StructName));
        emitter.Emit(new Scalar("namespace"));
        emitter.Emit(new Scalar(s.StructNamespace));
        if (s.StructType.StructLayoutAttribute?.Value == LayoutKind.Explicit) {
            emitter.Emit(new Scalar("size"));
            emitter.Emit(new Scalar(s.StructSize.ToString()));
        }
        emitter.Emit(new Scalar("fields"));
        emitter.Emit(new SequenceStart(null, null, true, SequenceStyle.Block));
        foreach (var field in s.Fields) {
            ProcessedFieldConverter.Instance.WriteYaml(emitter, field, field.GetType());
        }
        emitter.Emit(new SequenceEnd());
        emitter.Emit(new Scalar("virtual_functions"));
        emitter.Emit(new SequenceStart(null, null, true, SequenceStyle.Block));
        foreach (var virtualFunction in s.VirtualFunctions) {
            ProcessedVirtualFunctionConverter.Instance.WriteYaml(emitter, virtualFunction, virtualFunction.GetType());
        }
        emitter.Emit(new SequenceEnd());
        emitter.Emit(new Scalar("member_functions"));
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
        emitter.Emit(new Scalar(m.MemberFunctionReturnType.FullSanitizeName()));
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
        emitter.Emit(new Scalar(v.VirtualFunctionReturnType.FullSanitizeName()));
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
