using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using FFXIVClientStructs.Attributes;
using FFXIVClientStructs.Interop.Attributes;
using Pastel;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace CExporter;

public class Exporter {
    private static List<ProcessedEnum> _enums = [];
    private static List<ProcessedStruct> _structs = [];
    private static BindingFlags _bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
    private static HashSet<Type> _processType = [];

    public static string PassString(int i) => i switch {
        1 => "First pass",
        2 => "Second pass",
        3 => "Third pass",
        4 => "Fourth pass",
        5 => "Fifth pass",
        6 => "Sixth pass",
        7 => "Seventh pass",
        8 => "Eighth pass",
        9 => "Ninth pass",
        _ => $"Pass {i}"
    };

    public static void ProcessTypes() {
        var havokTypes = ExporterStatics.GetHavokTypes();
        var xivTypes = ExporterStatics.GetXIVTypes();

        Console.WriteLine("::group::Discovered Info");
        Console.WriteLine($"Found {havokTypes.Length} havok types");
        Console.WriteLine($"Found {xivTypes.Length} xiv types");

        var havokStructs = havokTypes.Where(t => t.IsStruct() && !t.IsGenericType && !t.IsFixedBuffer()).ToArray();
        var xivStructs = xivTypes.Where(t => t.IsStruct() && !t.IsGenericType && !t.IsFixedBuffer()).ToArray();

        Console.WriteLine($"Filtered havok to {havokStructs.Length} structs");
        Console.WriteLine($"Filtered xiv to {xivStructs.Length} structs");
        Console.WriteLine("::endgroup::");

        var now = DateTime.UtcNow;

        foreach (var sStruct in xivStructs.Concat(havokStructs)) {
            ProcessType(sStruct);
        }

        var count = 1;

        Console.WriteLine("::group::Processed Struct");
        Console.WriteLine($"{PassString(count++)} took {DateTime.UtcNow - now:g}");

        now = DateTime.UtcNow;

        while (_processType.Count > 0) {
            Console.WriteLine($"{PassString(count)} with {_processType.Count} structs and enum types");
            var tmp = _processType
                .Where(t => t is { IsUnmanagedFunctionPointer: false, IsFunctionPointer: false })
                .ToArray();
            _processType.Clear();
            foreach (var @struct in tmp) {
                ProcessType(@struct);
            }

            Console.WriteLine($"{PassString(count++)} took {DateTime.UtcNow - now:g}");

            now = DateTime.UtcNow;
        }

        Console.WriteLine("::endgroup::");
        Console.WriteLine($"Processed {_enums.Count} enums and {_structs.Count} structs");
    }

    public static void VerifyNoOverlap() {
        foreach (var processedStruct in _structs.Where(t => !t.IsUnion)) {
            var sizes = processedStruct.Fields.Select(t => new { StartOffset = t.FieldOffset, EndOffset = t.FieldOffset + t.FieldType.SizeOf(), Field = t.FieldName }).ToArray();
            foreach (var size in sizes) {
                var checks = sizes.Where(t => t != size && t.StartOffset <= size.StartOffset).ToArray();
                if (checks.Any(t => t.EndOffset > size.StartOffset && t.StartOffset != size.StartOffset))
                    ExporterStatics.ErrorList.Add($"Field overlap detected in {processedStruct.StructType.FullSanitizeName().Pastel(Color.MediumSlateBlue)} with field {size.Field.Pastel(Color.BlueViolet)}");
                if (checks.Any(t => t.StartOffset == size.StartOffset))
                    ExporterStatics.ErrorList.Add($"Union field detected but not defined in {processedStruct.StructType.FullSanitizeName().Pastel(Color.MediumSlateBlue)} with field {size.Field.Pastel(Color.BlueViolet)}");
                if (size.StartOffset >= processedStruct.StructSize)
                    ExporterStatics.ErrorList.Add($"Field offset exceeds struct size in {processedStruct.StructType.FullSanitizeName().Pastel(Color.MediumSlateBlue)} with field {size.Field.Pastel(Color.BlueViolet)}");
                if (size.EndOffset > processedStruct.StructSize)
                    ExporterStatics.ErrorList.Add($"Field size exceeds struct size in {processedStruct.StructType.FullSanitizeName().Pastel(Color.MediumSlateBlue)} with field {size.Field.Pastel(Color.BlueViolet)}");
            }
        }
    }

    public static void VerifyNoNameOverlap(Dictionary<string, List<string>> check) {
        foreach (var processedStruct in _structs) {
            foreach (var processedStructField in processedStruct.Fields) {
                if (!check.TryGetValue(processedStruct.StructType.FullSanitizeName(), out var checkStrings)) continue;
                if (checkStrings.Contains(processedStructField.FieldName))
                    ExporterStatics.ErrorList.Add($"Field name overlap detected in {processedStruct.StructType.FullSanitizeName().Pastel(Color.Blue)} with field {processedStructField.FieldName.Pastel(Color.BlueViolet)}");
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

    private static ProcessedField ProcessField(FieldInfo field, int offset) {
        if (field.FieldType.IsFunctionPointer || field.FieldType.IsUnmanagedFunctionPointer) {
            _processType.Add(field.FieldType.GetFunctionPointerReturnType());
            return new ProcessedFunctionField {
                FieldType = field.FieldType,
                FieldOffset = field.GetFieldOffset() - offset,
                FieldName = field.Name,
                FunctionReturnType = field.FieldType.GetFunctionPointerReturnType(),
                FunctionParameters = field.FieldType.GetFunctionPointerParameterTypes().Select((p, i) => {
                    _processType.Add(p);
                    return new ProcessedField {
                        FieldType = p,
                        FieldOffset = -1,
                        FieldName = 'a' + (i + 1).ToString()
                    };
                }).ToArray()
            };
        }
        if (field.FieldType.IsFixedBuffer()) {
            var arr = field.GetCustomAttributes().Where(t => t.GetType().Name.Contains("FixedSizeArrayAttribute")).ToArray();
            var size = field.FieldType.StructLayoutAttribute!.Size;
            if (arr.Length != 0) {
                var type = arr[0].GetType();
                size = (int)type.GetProperty("Count")!.GetValue(arr[0])!;
                var elementType = type.GenericTypeArguments[0];
                _processType.Add(elementType);
                return new ProcessedFixedField {
                    FieldType = elementType,
                    FieldOffset = field.GetFieldOffset() - offset,
                    FieldName = field.Name,
                    FixedSize = size
                };
            }
            var fixedType = field.FieldType.GetFields()[0].FieldType;
            _processType.Add(fixedType);
            if (fixedType.IsBaseType())
                size /= fixedType.SizeOf();
            return new ProcessedFixedField {
                FieldType = fixedType,
                FieldOffset = field.GetFieldOffset() - offset,
                FieldName = field.Name,
                FixedSize = size
            };
        }
        _processType.Add(field.FieldType);
        return new ProcessedField {
            FieldType = field.FieldType,
            FieldOffset = field.GetFieldOffset() - offset,
            FieldName = field.Name
        };
    }

    private static object? PreProcessType(Type type) {
        if (type.IsFixedBuffer() || type.IsBaseType()) return null;
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
                                FieldName = i == 0 ? "this" : $"a{i + 1}"
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
                                .. memberFunctionParameters.Select(p => {
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

            var unionOffsets = new Dictionary<CExporterUnionAttribute, FieldInfo>(new CExporterUnionCompare());

            if (unionFields.Any()) {
                var unions = new List<ProcessedStruct>();
                foreach (var unionField in unionFields) {
                    var attr = unionField.GetCustomAttribute<CExporterUnionAttribute>()!;
                    if (!unionOffsets.TryGetValue(attr, out var unionStartField)) {
                        unionOffsets[attr] = unionField;
                        unionStartField = unionField;
                    }
                    var index = attr.IsStruct ? unions.FindIndex(t => t.StructName == attr.Struct) : unions.FindIndex(t => t.StructName == attr.Union);
                    if (index == -1) {
                        unions.Add(new ProcessedStruct {
                            StructType = type,
                            IsUnion = !attr.IsStruct,
                            StructName = attr.IsStruct ? attr.Struct : attr.Union,
                            StructNamespace = type.FullSanitizeName() + (attr.IsStruct ? $"{ExporterStatics.Separator}{attr.Union}" : ""),
                            StructSize = 0,
                            Fields = [
                                ProcessField(unionField, unionStartField.GetFieldOffset())
                            ],
                            VirtualFunctions = [],
                            MemberFunctions = [],
                            StructTypeOverride = type.FullSanitizeName() + $"{ExporterStatics.Separator}{attr.Union}{(attr.IsStruct ? $"{ExporterStatics.Separator}{attr.Struct}" : "")}"
                        });
                    } else
                        unions[index].Fields = [
                            .. unions[index].Fields,
                            ProcessField(unionField, unionStartField.GetFieldOffset())
                        ];
                    _processType.Add(unionField.FieldType);
                }
                foreach (var subStruct in unions.Where(t => !t.IsUnion)) {
                    var unionName = subStruct.StructNamespace.Split(ExporterStatics.Separator)[^1];
                    var unionNamespace = subStruct.StructNamespace[..subStruct.StructNamespace.LastIndexOf(ExporterStatics.Separator, StringComparison.Ordinal)];
                    var unionStructIndex = unions.FindIndex(t => t.StructName == unionNamespace && t.StructName == unionName);
                    var unionStruct = unions[unionStructIndex];
                    unionStruct.Fields = [
                        .. unionStruct.Fields,
                        new ProcessedField {
                            FieldType = type,
                            FieldOffset = 0,
                            FieldName = subStruct.StructName
                        }
                    ];
                    unions[unionStructIndex] = unionStruct;
                }
                _structs.AddRange(unions);
            }

            var processedStruct = new ProcessedStruct {
                StructType = type,
                IsUnion = type.GetCustomAttribute<CExporterStructUnionAttribute>() != null,
                StructName = type.Name,
                StructNamespace = type.GetNamespace(),
                StructSize = type.SizeOf(),
                Fields = fields.Where(t => !ExporterStatics.IgnoredTypeNames.Contains(t.Name) && t.GetCustomAttribute<ObsoleteAttribute>() == null && t.GetCustomAttribute<CExportIgnoreAttribute>() == null && t.GetCustomAttribute<CExporterUnionAttribute>() == null)
                    .Select(f => ProcessField(f, 0)).ToArray(),
                VirtualFunctions = virtualFunctions,
                MemberFunctions = memberFunctionsArray
            };

            foreach (var (unionAttr, fieldInfo) in unionOffsets) {
                processedStruct.Fields = [
                    .. processedStruct.Fields,
                    new ProcessedField {
                        FieldType = fieldInfo.FieldType,
                        FieldOffset = fieldInfo.GetFieldOffset(),
                        FieldName = unionAttr.Union,
                        FieldTypeOverride = type.FullSanitizeName() + $"{ExporterStatics.Separator}{unionAttr.Union}"
                    }
                ];
                processedStruct.Fields = [.. processedStruct.Fields.OrderBy(t => t.FieldOffset)];
            }

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
    public bool IsUnion;
    public required Type StructType;
    public required string StructName;
    public required string StructNamespace;
    public required int StructSize;
    public required ProcessedField[] Fields;
    public required ProcessedVirtualFunction[] VirtualFunctions;
    public required ProcessedMemberFunction[] MemberFunctions;
    [YamlIgnore]
    public Type[] Dependencies => Fields.Select(t => t.FieldType).Where(t => !(t.IsPointer() || t.IsPrimitive || t.IsFixedBuffer() || t.IsEnum || t.IsBaseType())).ToHashSet().ToArray();
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
            case ProcessedFunctionField func: {
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
        emitter.Emit(new Scalar("union"));
        emitter.Emit(new Scalar(s.IsUnion.ToString()));
        if (s.StructType.StructLayoutAttribute?.Value == LayoutKind.Explicit && s.StructSize != 0) {
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
        emitter.Emit(new Scalar("name"));
        emitter.Emit(new Scalar(m.MemberFunctionName));
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
