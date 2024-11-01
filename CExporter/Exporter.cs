using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using FFXIVClientStructs.Attributes;
using InteropGenerator.Runtime.Attributes;
using Pastel;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace CExporter;

public class Exporter {
    private static List<ProcessedEnum> _enums = [];
    private static List<ProcessedStruct> _structs = [];
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
        10 => "Tenth pass",
        11 => "Eleventh pass",
        12 => "Twelfth pass",
        13 => "Thirteenth pass",
        14 => "Fourteenth pass",
        15 => "Fifteenth pass",
        16 => "Sixteenth pass",
        17 => "Seventeenth pass",
        18 => "Eighteenth pass",
        19 => "Nineteenth pass",
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

        var structs = xivStructs.Concat(havokStructs).ToArray();
        var now = DateTime.UtcNow;

        foreach (var sStruct in structs) {
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
            var sizes = processedStruct.Fields.Select(t => new { StartOffset = t.FieldOffset, EndOffset = t.FieldOffset + t.FieldSize, Field = t.FieldName }).ToArray();
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
                    ExporterStatics.ErrorList.Add($"Field name overlap detected in {processedStruct.StructType.FullSanitizeName().Pastel(Color.MediumSlateBlue)} with field {processedStructField.FieldName.Pastel(Color.Red)}");
            }
        }
    }

    public static void ProcessDefinedVTables(DataDefinition def) {
        foreach (var c in def.classes) {
            if (c.Value == null || (c.Value.vfuncs == null || c.Value.vfuncs.Count == 0) && (c.Value.vtbls == null || c.Value.vtbls.Count == 0)) continue;
            var s = _structs.Find(s => s.StructTypeName == c.Key);
            if (s == null) continue;
            s.VirtualFunctions ??= [];
            if (c.Value.vfuncs == null) continue;
            foreach (var (index, name) in c.Value.vfuncs) {
                var offset = (int)index * 8;
                var vf = s.VirtualFunctions.FirstOrDefault(vf => vf.Offset == offset);
                if (vf == null)
                    s.VirtualFunctions = [.. s.VirtualFunctions, new() { VirtualFunctionName = name, Offset = offset }];
                else if (vf.VirtualFunctionName != name)
                    ExporterStatics.WarningList.Add($"Virtual function name mismatch: {c.Key} vf#{index}, '{vf.VirtualFunctionName}' in CS, '{name}' in data.yml");
            }
        }
    }

    public static void Write(DirectoryInfo dir) {
        // make sure we have all the dependencies for each struct before we write them
        {
            var structs = _structs.ToFrozenDictionary(x => x.StructTypeName, x => x);
            var structToFullDeps = new Dictionary<string, HashSet<string>>();
            _structs.Sort((a, b) => {
                var cmp = ResolveFullDependencies(a).Count.CompareTo(ResolveFullDependencies(b).Count);
                return cmp != 0 ? cmp : string.Compare(a.StructTypeName, b.StructTypeName, StringComparison.Ordinal);
            });

#if DEBUG
            for (var i = 0; i < _structs.Count; i++) {
                foreach (var dep in _structs[i].DependencyNames) {
                    if (_structs.FindIndex(0, i, x => x.StructTypeName == dep) == -1)
                        throw new InvalidOperationException();
                }
            }
#endif

            HashSet<string> ResolveFullDependencies(ProcessedStruct s) {
                if (structToFullDeps.TryGetValue(s.StructTypeName, out var deps))
                    return deps;

                var fullDeps = s.DependencyNames.ToHashSet();
                foreach (var dn in s.DependencyNames)
                    fullDeps.UnionWith(ResolveFullDependencies(structs[dn]));
                return structToFullDeps[s.StructTypeName] = fullDeps;
            }
        }

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
            Structs = _structs.Select(t => t.FixOrder()).ToArray()
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
        if (field.FieldType.GetCustomAttribute<InlineArrayAttribute>() != null) {
            var arrLength = field.FieldType.GetCustomAttribute<InlineArrayAttribute>()!.Length;
            var elementType = field.FieldType.GetGenericArguments()[0];
            _processType.Add(elementType);
            return new ProcessedFixedField {
                FieldType = elementType,
                FieldOffset = field.GetFieldOffset() - offset,
                FieldName = field.Name[1].ToString().ToUpper() + field.Name[2..],
                FixedSize = arrLength
            };
        }
        _processType.Add(field.FieldType);
        return new ProcessedField {
            FieldType = field.FieldType,
            FieldOffset = field.GetFieldOffset() - offset,
            FieldName = field.Name,
            IsBase = field.IsDirectBase()
        };
    }

    private static object? PreProcessType(Type type) {
        if (type.IsFixedBuffer() || type.IsBaseType()) return null;
        while (type.IsPointer) type = type.GetElementType()!;
        while (type.IsGenericPointer()) type = type.GenericTypeArguments[0];

        if (type.IsEnum) {
            if (_enums.Any(t => t.EnumType == type)) return null;
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
            if (type.IsInStructList(_structs)) return null;
            var vtable = type.GetField("VirtualTable", ExporterStatics.BindingFlags)?.FieldType;
            ProcessedVirtualFunction[]? virtualFunctions = null;
            if (vtable != null) {
                vtable = vtable.GetElementType()!;
                var memberFunctions = type.GetMethods(ExporterStatics.BindingFlags).Where(t => t.GetCustomAttribute<VirtualFunctionAttribute>() != null).Select(t => new { Name = t.Name, Parameters = t.GetParameters(), ReturnType = t.ReturnType }).ToArray();
                virtualFunctions = vtable.GetFields(ExporterStatics.BindingFlags).Select(f => {
                    var memberFunction = memberFunctions.FirstOrDefault(t => t.Name == f.Name);
                    var returnType = f.FieldType.GetFunctionPointerReturnType();
                    if (memberFunction?.ReturnType != returnType) memberFunction = null;
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
                                FieldName = i == 0 ? "this" : memberFunction?.Parameters[i - 1].Name ?? $"a{i + 1}"
                            };
                        }).ToArray()
                    };
                }).ToArray();
            }

            var memberFunctionClass = type.GetMember("MemberFunctionPointers", ExporterStatics.BindingFlags).FirstOrDefault()?.DeclaringType;
            ProcessedMemberFunction[] memberFunctionsArray = [];
            if (memberFunctionClass != null) {
                var memberFunctions = memberFunctionClass.GetMethods(ExporterStatics.BindingFlags);
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

            var fields = type.GetFields(ExporterStatics.BindingFlags).Where(t => !type.IsInheritance(t)).ToArray();
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
                            StructTypeName = type.FullSanitizeName() + $"{ExporterStatics.Separator}{attr.Union}{(attr.IsStruct ? $"{ExporterStatics.Separator}{attr.Struct}" : "")}",
                            StructSize = 0,
                            Fields = [
                                ProcessField(unionField, unionStartField.GetFieldOffset())
                            ],
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
                foreach (var t1 in unions) {
                    t1.StructSize = t1.Fields.Max(t => t.FieldOffset + t.FieldType.SizeOf());
                }
                var subUnions = unions.Where(t => !t.IsUnion).ToArray();
                foreach (var subStruct in subUnions) {
                    var unionName = subStruct.StructNamespace.Split(ExporterStatics.Separator)[^1];
                    var unionNamespace = subStruct.StructNamespace[..subStruct.StructNamespace.LastIndexOf(ExporterStatics.Separator, StringComparison.Ordinal)];
                    var unionStructIndex = unions.FindIndex(t => t.StructNamespace == unionNamespace && t.StructName == unionName);
                    var unionStruct = unions[unionStructIndex];
                    unionStruct.Fields = [
                        .. unionStruct.Fields,
                        new ProcessedField {
                            FieldTypeOverride = subStruct.StructTypeOverride,
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
                StructTypeName = type.FullSanitizeName(),
                StructSize = type.SizeOf(),
                Fields = fields.Where(t => !ExporterStatics.IgnoredTypeNames.Contains(t.Name) && t.GetCustomAttribute<ObsoleteAttribute>() == null && t.GetCustomAttribute<CExportIgnoreAttribute>() == null && t.GetCustomAttribute<CExporterUnionAttribute>() == null)
                    .Select(f => ProcessField(f, 0)).ToArray(),
                VirtualFunctions = virtualFunctions,
                MemberFunctions = memberFunctionsArray
            };

            foreach (var (unionAttr, fieldInfo) in unionOffsets.Where(t => !t.Key.IsStruct)) {
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
    public bool IsBase;

    public virtual int FieldSize => FieldType.SizeOf();
}

public class ProcessedFixedField : ProcessedField {
    public required int FixedSize;

    public override int FieldSize => FixedSize * FieldType.SizeOf();
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
    public ProcessedVirtualFunction[]? VirtualFunctions; // null if there are no virtual functions, empty if there's a vtable with unknown contents
    public required ProcessedMemberFunction[] MemberFunctions;
    [YamlIgnore]
    public required string StructTypeName;
    [YamlIgnore]
    private string[] _dependencyNames = [];
    [YamlIgnore]
    public string[] DependencyNames {
        get {
            if (_dependencyNames.Length == 0) {
                _dependencyNames = Fields.Where(t => (t.GetType() == typeof(ProcessedField) || t.GetType() == typeof(ProcessedFixedField)) && (!(t.FieldType.IsPointer() || t.FieldType.IsPrimitive || t.FieldType.IsFixedBuffer() || t.FieldType.IsEnum || t.FieldType.IsBaseType()) || t.FieldTypeOverride != null)).Select(t => t.FieldTypeOverride ?? t.FieldType.FullSanitizeName()).Distinct().ToArray();
            }
            return _dependencyNames;
        }
    }
    public ProcessedStruct FixOrder() {
        Fields = [.. Fields.OrderBy(t => t.FieldOffset)];
        return this;
    }
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
    public Type? VirtualFunctionReturnType;
    public ProcessedField[]? VirtualFunctionParameters;
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
            emitter.Emit(new Scalar(AnchorName.Empty, TagName.Empty, key, ScalarStyle.DoubleQuoted, true, false));
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
        if (f.IsBase) {
            emitter.Emit(new Scalar("base"));
            emitter.Emit(new Scalar("true"));
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
        if (s.VirtualFunctions != null) {
            emitter.Emit(new Scalar("virtual_functions"));
            emitter.Emit(new SequenceStart(null, null, true, SequenceStyle.Block));
            foreach (var virtualFunction in s.VirtualFunctions) {
                ProcessedVirtualFunctionConverter.Instance.WriteYaml(emitter, virtualFunction, virtualFunction.GetType());
            }
            emitter.Emit(new SequenceEnd());
        }
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
        if (v.VirtualFunctionReturnType != null) {
            emitter.Emit(new Scalar("return_type"));
            emitter.Emit(new Scalar(v.VirtualFunctionReturnType.FullSanitizeName()));
        }
        if (v.VirtualFunctionParameters != null) {
            emitter.Emit(new Scalar("parameters"));
            emitter.Emit(new SequenceStart(null, null, true, SequenceStyle.Block));
            foreach (var parameter in v.VirtualFunctionParameters) {
                ProcessedFieldConverter.Instance.WriteYaml(emitter, parameter, parameter.GetType());
            }
            emitter.Emit(new SequenceEnd());
        }
        emitter.Emit(new MappingEnd());
    }

    public static readonly IYamlTypeConverter Instance = new ProcessedVirtualFunctionConverter();
}
