using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using FFXIVClientStructs.Attributes;
using FFXIVClientStructs.FFXIV.Client.Game.MassivePcContent;
using InteropGenerator.Runtime.Attributes;
using Pastel;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using static FFXIVClientStructs.FFXIV.Client.System.Resource.ResourceGraph;

namespace CExporter;

public class Exporter {
    private static List<ProcessedEnum> _enums = [];
    private static List<ProcessedStruct> _structs = [];
    private static HashSet<ProcessingType> _processType = [];

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

    public static void ProcessTypes(bool quiet) {
        var havokTypes = ExporterStatics.GetHavokTypes();
        var xivTypes = ExporterStatics.GetXIVTypes();

        if (!quiet) {
            Console.WriteLine("::group::Discovered Info");
            Console.WriteLine($"Found {havokTypes.Length} havok types");
            Console.WriteLine($"Found {xivTypes.Length} xiv types");
        }


        var havokStructs = havokTypes.Where(t => t.IsStruct() && !t.IsGenericType && !t.IsFixedBuffer()).ToArray();
        var xivStructs = xivTypes.Where(t => t.IsStruct() && !t.IsGenericType && !t.IsFixedBuffer()).ToArray();

        if (!quiet) {
            Console.WriteLine($"Filtered havok to {havokStructs.Length} structs");
            Console.WriteLine($"Filtered xiv to {xivStructs.Length} structs");
            Console.WriteLine("::endgroup::");
        }


        var structs = xivStructs.Concat(havokStructs).ToArray();
        var now = DateTime.UtcNow;
        var count = 1;
        if (!quiet) {
            Console.WriteLine("::group::Processed Struct");
            Console.WriteLine($"{PassString(count)} with {structs.Length} structs and enum types");
        }


        foreach (var sStruct in structs) {
            ProcessType(sStruct, quiet);
        }

        if (!quiet) Console.WriteLine($"{PassString(count++)} took {DateTime.UtcNow - now:g}");

        now = DateTime.UtcNow;

        while (_processType.Count > 0) {
            if (!quiet) Console.WriteLine($"{PassString(count)} with {_processType.Count} structs and enum types");
            var tmp = _processType
                .Where(t => t.Type is { IsUnmanagedFunctionPointer: false, IsFunctionPointer: false } and not { Namespace: ExporterStatics.StdNamespacePrefix or ExporterStatics.StdHelperNamespacePrefix })
                .ToArray();
            _processType.Clear();
            foreach (var @struct in tmp) {
                ProcessType(@struct, quiet);
            }

            if (!quiet) Console.WriteLine($"{PassString(count++)} took {DateTime.UtcNow - now:g}");

            now = DateTime.UtcNow;
        }

        if (!quiet) {
            Console.WriteLine("::endgroup::");
            Console.WriteLine();
            Console.WriteLine($"Processed {_enums.Count} enums and {_structs.Count} structs");
            Console.WriteLine();
        }

    }

    public static void ProcessStaticFunctions(bool quiet) {
        Type[] types = [.. ExporterStatics.GetHavokTypes(), .. ExporterStatics.GetXIVTypes()];
        types = types.Where(t => t.IsStruct()).Where(type => type.GetMethods(ExporterStatics.StaticBindingFlags).Length != 0).ToArray();
        if (!quiet) Console.WriteLine("::group::Processed Struct Static Members");
        var typeAndMembers = types.Select(t => (t, t.GetMethods(ExporterStatics.StaticBindingFlags))).ToArray();
        foreach (var (type, methods) in typeAndMembers) {
            if (!quiet) Console.WriteLine($"Processing {type} with {methods.Length} methods");
            var sanitizedName = type.FixTypeName();
            var currentStructIndex = _structs.FindIndex(s => s.StructTypeName == sanitizedName);
            if (currentStructIndex == -1) {
                if (!quiet) Console.WriteLine($"Error in struct {type} please fix");
                continue;
            }
            var currentStruct = _structs[currentStructIndex];
            foreach (var methodInfo in methods) {
                var staticAddress = methodInfo.GetCustomAttribute<StaticAddressAttribute>();
                if (staticAddress != null) {
                    currentStruct.StaticMembers ??= [];
                    currentStruct.StaticMembers = [.. currentStruct.StaticMembers,
                        new ProcessedStaticMembers {
                            Signature = staticAddress.Signature,
                            RelativeFollowOffsets = staticAddress.RelativeFollowOffsets,
                            IsPointer = staticAddress.IsPointer,
                            ReturnType = methodInfo.ReturnType.GetPointerType()
                        }];
                }
                var memberFunction = methodInfo.GetCustomAttribute<MemberFunctionAttribute>();
                if (memberFunction != null || staticAddress != null)
                    _processType.Add(methodInfo.ReturnType);
                if (memberFunction == null) continue;
                var returnType = methodInfo.ReturnType;
                var pointerCount = 0;
                while (returnType.IsPointer()) {
                    pointerCount++;
                    returnType = returnType.GetPointerType();
                }
                string? overrideType = null;
                if (returnType is { Namespace: ExporterStatics.StdNamespacePrefix }) {
                    (overrideType, var requiredTypes) = ProcessStdType(returnType);
                    foreach (var requiredType in requiredTypes) {
                        _processType.Add(requiredType);
                    }
                    overrideType += new string('*', pointerCount);
                }
                var memberFunctionReturnType = new ProcessedMemberFunctionReturn(methodInfo.ReturnType, overrideType);
                if (methodInfo.GetCustomAttribute<CExporterExcelAttribute>() is not { } excelAttribute)
                    _processType.Add(memberFunctionReturnType.Type);
                else
                    memberFunctionReturnType.OverrideType = $"Component::Exd::Sheets::{excelAttribute.SheetName}*";
                currentStruct.StaticMemberFunctions ??= [];
                currentStruct.StaticMemberFunctions = [.. currentStruct.StaticMemberFunctions,
                    new ProcessedMemberFunction {
                        MemberFunctionSignature = memberFunction.Signature,
                        MemberFunctionName = methodInfo.Name,
                        MemberFunctionReturnType = memberFunctionReturnType,
                        MemberFunctionParameters = methodInfo.GetParameters().Select(ProcessParameter).ToArray()
                    }];
            }
            _structs[currentStructIndex] = currentStruct;
        }

        if (!quiet) {
            Console.WriteLine("::endgroup::");
            Console.WriteLine("::group::Processed Struct 2nd pass");
        }
        var now = DateTime.UtcNow;
        var count = 1;
        var structsCount = _structs.Count;
        var enumsCount = _enums.Count;

        while (_processType.Count > 0) {
            if (!quiet) Console.WriteLine($"{PassString(count)} with {_processType.Count} structs and enum types");
            var tmp = _processType
                .Where(t => t.Type is { IsUnmanagedFunctionPointer: false, IsFunctionPointer: false })
                .ToArray();
            _processType.Clear();
            foreach (var @struct in tmp) {
                ProcessType(@struct, quiet);
            }

            if (!quiet) Console.WriteLine($"{PassString(count++)} took {DateTime.UtcNow - now:g}");

            now = DateTime.UtcNow;
        }
        if (!quiet) {
            Console.WriteLine("::endgroup::");
            Console.WriteLine();
            Console.WriteLine($"Processed {_enums.Count - enumsCount} enums and {_structs.Count - structsCount} structs");
            Console.WriteLine($"Processed {typeAndMembers.Length} structs with {typeAndMembers.Sum(t => t.Item2.Length)} members");
            Console.WriteLine();
            Console.WriteLine($"Processed total {_enums.Count} enums and {_structs.Count} structs");
        }

    }

    public static void VerifyNoOverlap() {
        foreach (var processedStruct in _structs.Where(t => !t.IsUnion)) {
            var sizes = processedStruct.Fields.Select(t => new { StartOffset = t.FieldOffset, EndOffset = t.FieldOffset + t.FieldSize, Field = t.FieldName }).ToArray();
            foreach (var size in sizes) {
                var checks = sizes.Where(t => t != size && t.StartOffset <= size.StartOffset).ToArray();
                if (checks.Any(t => t.EndOffset > size.StartOffset && t.StartOffset != size.StartOffset))
                    ExporterStatics.ErrorList.Add($"Field overlap detected in {processedStruct.StructType.FixTypeName().Pastel(Color.MediumSlateBlue)} with field {size.Field.Pastel(Color.BlueViolet)}");
                if (size.StartOffset >= processedStruct.StructSize)
                    ExporterStatics.ErrorList.Add($"Field offset exceeds struct size in {processedStruct.StructType.FixTypeName().Pastel(Color.MediumSlateBlue)} with field {size.Field.Pastel(Color.BlueViolet)}");
                if (size.EndOffset > processedStruct.StructSize)
                    ExporterStatics.ErrorList.Add($"Field size exceeds struct size in {processedStruct.StructType.FixTypeName().Pastel(Color.MediumSlateBlue)} with field {size.Field.Pastel(Color.BlueViolet)}");
            }
        }
    }

    public static void VerifyNoNameOverlap(Dictionary<string, List<string>> check) {
        foreach (var processedStruct in _structs) {
            foreach (var processedStructField in processedStruct.Fields) {
                if (!check.TryGetValue(processedStruct.StructType.FixTypeName(), out var checkStrings)) continue;
                if (checkStrings.Contains(processedStructField.FieldName)) {
                    var structName = processedStruct.StructType.FixTypeName();
                    var fieldName = processedStructField.FieldName;
                    ExporterStatics.ErrorList.Add($"Field name overlap detected in {structName.Pastel(Color.MediumSlateBlue)} with field {fieldName.Pastel(Color.Red)} in data.yml {(structName + "_" + fieldName).Pastel(Color.BlueViolet)}");
                }
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
                    s.VirtualFunctions = [.. s.VirtualFunctions, new() { VirtualFunctionName = name, Offset = offset, VirtualFunctionParameters = null, VirtualFunctionReturnType = null, VirtualFunctionReturnTypeOverride = null }];
                else if (vf.VirtualFunctionName != name)
                    ExporterStatics.WarningList.Add($"Virtual function name mismatch: {c.Key} vf#{index}, '{vf.VirtualFunctionName}' in CS, '{name}' in data.yml");
            }
        }
    }

    public static void Write(DirectoryInfo dir) {
        // make sure we have all the dependencies for each struct before we write them
        var structs = _structs.ToFrozenDictionary(x => x.StructTypeName, x => x);
        var structToFullDeps = new Dictionary<string, HashSet<string>>();
        var structDeps = structs.SelectMany(t => ResolveFullDependencies(t.Value)).Distinct().ToArray();
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

    private static void ProcessType(ProcessingType type, bool quiet) {
        var ret = PreProcessType(type, quiet);
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

    private static (string typeOverride, Type[] typeOverrideTemplates) ProcessStdType(Type fieldType) {
        const string basicString = "BasicString";
        string[] pointerValuesType = ["Vector", "Deque", "Span"];
        var pointerCount = 0;
        while (fieldType.IsPointer()) {
            fieldType = fieldType.GetPointerType();
            pointerCount++;
        }
        var readOnlyNameSpan = fieldType.Name.AsSpan()[3..];
        Span<char> stdNameSpan = stackalloc char[readOnlyNameSpan.Length + 5];
        stdNameSpan.Clear();
        ExporterStatics.StdCppNamespace.AsSpan().CopyTo(stdNameSpan);
        if (readOnlyNameSpan[^2] == '`') {
            for (var i = 0; i < readOnlyNameSpan.Length; i++) {
                if (readOnlyNameSpan[i] == '`') break;
                stdNameSpan[5 + i] = char.ToLower(readOnlyNameSpan[i]);
            }
        } else {
            if (readOnlyNameSpan.CompareTo(basicString.AsSpan(), StringComparison.InvariantCultureIgnoreCase) != 0) {
                for (var i = 0; i < readOnlyNameSpan.Length; i++) {
                    if (readOnlyNameSpan[i] == '`') break;
                    stdNameSpan[5 + i] = char.ToLower(readOnlyNameSpan[i]);
                }
            } else {
                throw new NotImplementedException("Yell at me to fix this if it happens.");
            }
        }
        var generics = fieldType.GenericTypeArguments;
        var shouldBePointer = false;
        foreach (var pointerType in pointerValuesType) {
            if (!readOnlyNameSpan.StartsWith(pointerType)) continue;
            shouldBePointer = true;
            break;
        }
        while (stdNameSpan[^1] == '\0') stdNameSpan = stdNameSpan[..^1];
        var genericsDefine = generics.Select(t => {
            var pointerCount = 0;
            while (t.IsPointer()) {
                t = t.GetPointerType();
                pointerCount++;
            }

            if (t is { Namespace: ExporterStatics.StdNamespacePrefix }) {
                var (typeOverride, requiredTypes) = ProcessStdType(t);
                return (typeOverride + new string('*', pointerCount), requiredTypes);
            }

            while (pointerCount > 0) {
                t = t.MakePointerType();
                pointerCount--;
            }

            return (t.FixTypeName(), [shouldBePointer ? t.MakePointerType() : t]);
        }).Cast<(string typeOverride, Type[] typeOverrideTemplates)>().ToArray();
        return ($"{stdNameSpan}<{string.Join(',', genericsDefine.Select(t => t.typeOverride))}>{new string('*', pointerCount)}", genericsDefine.SelectMany(t => t.typeOverrideTemplates).ToArray());
    }

    private static ProcessedField ProcessField(FieldInfo field, int offset) {
        if (field.FieldType is { Namespace: ExporterStatics.StdNamespacePrefix } && !field.FieldType.IsGenericTypeParameterOrPointer()) {
            var (typeOverride, typeOverrideTemplates) = ProcessStdType(field.FieldType);
            return new ProcessedField {
                FieldType = field.FieldType,
                FieldOffset = field.GetFieldOffset() - offset,
                FieldName = field.Name,
                IsBase = field.IsDirectBase(),
                FieldTypeOverride = typeOverride,
                FieldTypeOverrideTemplates = typeOverrideTemplates,
                Bits = [],
                IsUnion = false,
                UnionValues = []
            };
        }
        if (field.FieldType is { Namespace: "FFXIVClientStructs.STD.Helper", Name: "Node*" }) {
            var fieldTypeOverride = $"std::map<{string.Join(',', field.FieldType.GetGenericArguments()[0].GetGenericArguments().Select(t => t.FixTypeName()))}>::iterator";
            return new ProcessedField {
                FieldType = field.FieldType,
                FieldOffset = field.GetFieldOffset() - offset,
                FieldName = field.Name,
                IsBase = field.IsDirectBase(),
                FieldTypeOverride = fieldTypeOverride,
                Bits = [],
                IsUnion = false,
                UnionValues = []
            };
        }
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
                        FieldName = 'a' + (i + 1).ToString(),
                        Bits = [],
                        IsUnion = false,
                        UnionValues = []
                    };
                }).ToArray(),
                Bits = [],
                IsUnion = false,
                UnionValues = []
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
                    FixedSize = size,
                    Bits = [],
                    IsUnion = false,
                    UnionValues = []
                };
            }
            var fixedType = field.FieldType.GetFields()[0].FieldType;
            _processType.Add(fixedType);
            if (fixedType.IsBaseType())
                size /= fixedType.SizeOf();
            var fieldOverrideType = fixedType == typeof(nint) ? field.GetCustomAttribute<CExporterExcelAttribute>()?.SheetName ?? null : null;
            if (fieldOverrideType != null)
                fieldOverrideType = $"Component::Exd::Sheets::{fieldOverrideType}*";
            return new ProcessedFixedField {
                FieldType = fixedType,
                FieldOffset = field.GetFieldOffset() - offset,
                FieldName = field.Name,
                FixedSize = size,
                FieldTypeOverride = fieldOverrideType,
                Bits = [],
                IsUnion = false,
                UnionValues = []
            };
        }
        if (field.FieldType.GetCustomAttribute<InlineArrayAttribute>() != null) {
            var arrLength = field.FieldType.GetCustomAttribute<InlineArrayAttribute>()!.Length;
            var elementType = field.FieldType.GetGenericArguments()[0];
            var isString = field.GetCustomAttribute<FixedSizeArrayAttribute>()?.IsString ?? false;
            var fieldOverrideType = elementType == typeof(nint) ? field.GetCustomAttribute<CExporterExcelAttribute>()?.SheetName ?? null : null;
            Type[] requiredOverrideTypes = [];
            if (fieldOverrideType != null)
                fieldOverrideType = $"Component::Exd::Sheets::{fieldOverrideType}*";
            if (isString && elementType == typeof(byte))
                fieldOverrideType = "char";
            if (elementType.IsPointer() && elementType.GetPointerType() is { Namespace: ExporterStatics.StdNamespacePrefix } || elementType is { Namespace: ExporterStatics.StdNamespacePrefix }) {
                (fieldOverrideType, requiredOverrideTypes) = ProcessStdType(elementType);
                foreach (var requiredType in requiredOverrideTypes) {
                    _processType.Add(requiredType);
                }
            } else
                _processType.Add(elementType);
            return new ProcessedFixedField {
                FieldType = elementType,
                FieldOffset = field.GetFieldOffset() - offset,
                FieldName = field.Name[1].ToString().ToUpper() + field.Name[2..],
                FixedSize = arrLength,
                FixedString = isString,
                FieldTypeOverride = fieldOverrideType,
                Bits = [],
                IsUnion = false,
                UnionValues = [],
                FieldTypeOverrideTemplates = requiredOverrideTypes
            };
        }
        if (field.GetCustomAttribute<CExporterExcelBeginAttribute>() != null) {
            var sheetName = field.GetCustomAttribute<CExporterExcelBeginAttribute>()!.SheetName;
            return new ProcessedField {
                FieldType = field.FieldType,
                FieldOffset = field.GetFieldOffset() - offset,
                FieldName = $"{sheetName}Sheet",
                FieldTypeOverride = $"Component::Exd::Sheets::{sheetName}",
                Bits = [],
                IsUnion = false,
                UnionValues = []
            };
        }
        if (field.GetCustomAttribute<CExporterExcelAttribute>() != null) {
            var sheetName = field.GetCustomAttribute<CExporterExcelAttribute>()!.SheetName;
            return new ProcessedField {
                FieldType = field.FieldType,
                FieldOffset = field.GetFieldOffset() - offset,
                FieldName = field.Name,
                FieldTypeOverride = $"Component::Exd::Sheets::{sheetName}*",
                Bits = [],
                IsUnion = false,
                UnionValues = []
            };
        }
        if (field.GetCustomAttribute<CExporterTypeForceAttribute>() is { } typeForceAttribute) {
            return new ProcessedField {
                FieldType = field.FieldType,
                FieldOffset = field.GetFieldOffset() - offset,
                FieldName = field.Name,
                FieldTypeOverride = typeForceAttribute.TypeName,
                FieldTypeOverrideCheck = typeForceAttribute.DontCheck,
                Bits = [],
                IsUnion = false,
                UnionValues = []
            };
        }
        if (field.IsBitArray()) {
            var bitsDefinition = field.GetCustomAttributes().Where(t => t.GetType().Name.Contains("BitFieldAttribute`1")).Select(t => {
                var attrType = t.GetType();
                var name = (string)attrType.GetProperty("Name")!.GetValue(t)!;
                var offset = (int)attrType.GetProperty("Index")!.GetValue(t)!;
                var size = (int)attrType.GetProperty("Length")!.GetValue(t)!;
                var type = attrType.GenericTypeArguments[0];
                _processType.Add(type);
                return new ProcessedBitField {
                    Name = name,
                    Offset = offset,
                    Size = size,
                    Type = ExporterStatics.GetBestMatchFromSize(size)
                };
            }).ToArray();
            var bits = new List<ProcessedBitField>();
            foreach (var bit in bitsDefinition) {
                if (bits.Count == 0 && bit.Offset != 0)
                    bits.Add(new ProcessedBitField {
                        Name = "UnkBits0",
                        Offset = 0,
                        Size = bit.Offset,
                        Type = ExporterStatics.GetBestMatchFromSize(bit.Offset)
                    });
                else if (bit.Offset == 0) {
                    bits.Add(bit);
                    continue;
                }
                var last = bits.Last();
                if (last.Offset + last.Size != bit.Offset) {
                    var newOffset = last.Offset + last.Size;
                    var size = bit.Offset - newOffset;

                    bits.Add(new ProcessedBitField {
                        Name = $"UnkBits{newOffset}",
                        Offset = newOffset,
                        Size = size,
                        Type = ExporterStatics.GetBestMatchFromSize(size)
                    });
                }
                bits.Add(bit);
            }
            return new ProcessedField {
                FieldType = field.FieldType,
                FieldOffset = field.GetFieldOffset() - offset,
                FieldName = field.Name,
                IsBase = field.IsDirectBase(),
                Bits = bits.ToArray(),
                IsUnion = false,
                UnionValues = []
            };
        }
        _processType.Add(field.FieldType);
        return new ProcessedField {
            FieldType = field.FieldType,
            FieldOffset = field.GetFieldOffset() - offset,
            FieldName = field.Name,
            IsBase = field.IsDirectBase(),
            Bits = [],
            IsUnion = false,
            UnionValues = []
        };
    }

    private static ProcessedField ProcessParameter(ParameterInfo parameter) {
        if (parameter.ParameterType is { Namespace: ExporterStatics.StdNamespacePrefix }) {
            var (typeOverride, typeOverrideTemplates) = ProcessStdType(parameter.ParameterType);
            return new ProcessedField {
                FieldType = parameter.ParameterType,
                FieldOffset = -1,
                FieldName = parameter.Name!,
                FieldTypeOverride = typeOverride,
                FieldTypeOverrideTemplates = typeOverrideTemplates,
                Bits = [],
                IsUnion = false,
                UnionValues = []
            };
        }
        if (parameter.ParameterType is { Namespace: "FFXIVClientStructs.STD.Helper", Name: "Node*" }) {
            var fieldTypeOverride = $"std::map<{string.Join(',', parameter.ParameterType.GetGenericArguments()[0].GetGenericArguments().Select(t => t.FixTypeName()))}>::iterator";
            return new ProcessedField {
                FieldType = parameter.ParameterType,
                FieldOffset = -1,
                FieldName = parameter.Name!,
                FieldTypeOverride = fieldTypeOverride,
                Bits = [],
                IsUnion = false,
                UnionValues = []
            };
        }
        if (parameter.GetCustomAttribute<CExporterExcelAttribute>() != null) {
            var sheetName = parameter.GetCustomAttribute<CExporterExcelAttribute>()!.SheetName;
            return new ProcessedField {
                FieldType = parameter.ParameterType,
                FieldOffset = -1,
                FieldName = parameter.Name!,
                FieldTypeOverride = $"Component::Exd::Sheets::{sheetName}*",
                Bits = [],
                IsUnion = false,
                UnionValues = []
            };
        }
        if (parameter.GetCustomAttribute<CExporterTypeForceAttribute>() != null) {
            return new ProcessedField {
                FieldType = parameter.ParameterType,
                FieldOffset = -1,
                FieldName = parameter.Name!,
                FieldTypeOverride = parameter.GetCustomAttribute<CExporterTypeForceAttribute>()!.TypeName,
                Bits = [],
                IsUnion = false,
                UnionValues = []
            };
        }
        _processType.Add(parameter.ParameterType);
        return new ProcessedField {
            FieldType = parameter.ParameterType,
            FieldOffset = -1,
            FieldName = parameter.Name!,
            Bits = [],
            IsUnion = false,
            UnionValues = []
        };
    }

    private static ProcessedField ProcessVirtualParameter(Type parameter, int i, ParameterInfo[]? parameters) {
        if (parameter is { Namespace: ExporterStatics.StdNamespacePrefix }) {
            var (typeOverride, typeOverrideTemplates) = ProcessStdType(parameter);
            return new ProcessedField {
                FieldType = parameter,
                FieldOffset = -1,
                FieldName = i == 0 ? "this" : parameters?[i - 1].Name ?? $"a{i + 1}",
                FieldTypeOverride = typeOverride,
                FieldTypeOverrideTemplates = typeOverrideTemplates,
                Bits = [],
                IsUnion = false,
                UnionValues = []
            };
        }
        if (parameter is { Namespace: "FFXIVClientStructs.STD.Helper", Name: "Node*" }) {
            var fieldTypeOverride = $"std::map<{string.Join(',', parameter.GetGenericArguments()[0].GetGenericArguments().Select(t => t.FixTypeName()))}>::iterator";
            return new ProcessedField {
                FieldType = parameter,
                FieldOffset = -1,
                FieldName = i == 0 ? "this" : parameters?[i - 1].Name ?? $"a{i + 1}",
                FieldTypeOverride = fieldTypeOverride,
                Bits = [],
                IsUnion = false,
                UnionValues = []
            };
        }
        if (parameter.GetCustomAttribute<CExporterExcelAttribute>() != null) {
            var sheetName = parameter.GetCustomAttribute<CExporterExcelAttribute>()!.SheetName;
            return new ProcessedField {
                FieldType = parameter,
                FieldOffset = -1,
                FieldName = i == 0 ? "this" : parameters?[i - 1].Name ?? $"a{i + 1}",
                FieldTypeOverride = $"Component::Exd::Sheets::{sheetName}*",
                Bits = [],
                IsUnion = false,
                UnionValues = []
            };
        }
        if (i != 0 && parameters?[i - 1] is not null && parameters[i - 1].GetCustomAttribute<CExporterTypeForceAttribute>() != null) {
            return new ProcessedField {
                FieldType = parameter,
                FieldOffset = -1,
                FieldName = parameters[i - 1].Name ?? $"a{i + 1}",
                FieldTypeOverride = parameters[i - 1].GetCustomAttribute<CExporterTypeForceAttribute>()!.TypeName,
                Bits = [],
                IsUnion = false,
                UnionValues = []
            };
        }
        _processType.Add(parameter);
        return new ProcessedField {
            FieldType = parameter,
            FieldOffset = -1,
            FieldName = i == 0 ? "this" : parameters?[i - 1].Name ?? $"a{i + 1}",
            Bits = [],
            IsUnion = false,
            UnionValues = []
        };
    }

    private static object? PreProcessType(ProcessingType processingType, bool quiet) {
        var (type, overrideType) = processingType;
        if (type.IsFixedBuffer() || type.IsBaseType()) return null;
        while (type.IsPointer) type = type.GetElementType()!;
        while (type.IsGenericPointer()) type = type.GenericTypeArguments[0];

        if (type.IsEnum) {
            if (_enums.Any(t => t.EnumType == type)) return null;
            var processedEnum = new ProcessedEnum {
                EnumType = type,
                EnumName = type.Name,
                EnumNamespace = type.GetNamespace(),
                IsFlags = type.GetCustomAttribute<FlagsAttribute>() != null,
                EnumValues = type.GetFields().Where(t => t.GetCustomAttribute<ObsoleteAttribute>() == null && t.FieldType == type).ToDictionary(f => f.Name, f => f.GetRawConstantValue()!.ToString()!)
            };

            if (!quiet) Console.WriteLine($"Processed {processedEnum.EnumNamespace}::{processedEnum.EnumName} with {processedEnum.EnumValues.Count} fields");
            _enums.Add(processedEnum);
        } else if (type.IsStruct()) {
            while (type.IsPointer) type = type.GetElementType()!;
            while (type.IsGenericPointer()) type = type.GenericTypeArguments[0];
            if (type.IsFunctionPointer || type.IsUnmanagedFunctionPointer) {
                foreach (var functionPointerParameterType in type.GetFunctionPointerParameterTypes()) {
                    ProcessType(functionPointerParameterType, quiet);
                    type = type.GetFunctionPointerReturnType();
                }
            }
            if (!type.IsStruct() || type.IsEnum) return null;
            var size = type.SizeOf();
            if (type.Name.Contains('`')) {
                type = type.GetGenericTypeDefinition();
            }
            if (type.IsInStructList(_structs) || (overrideType?.IsInStructList(_structs) ?? false)) return null;
            var vtable = type.GetField("VirtualTable", ExporterStatics.BindingFlags)?.FieldType;
            var vtableSize = 0;
            ProcessedVirtualFunction[]? virtualFunctions = null;
            if (vtable != null) {
                vtable = vtable.GetElementType()!;
                var memberFunctions = type.GetMethods(ExporterStatics.BindingFlags).Select(t => Tuple.Create(t.Name, t.GetParameters(), t.ReturnType)).ToArray();
                virtualFunctions = vtable.GetFields(ExporterStatics.BindingFlags).Where(t => t.GetCustomAttribute<ObsoleteAttribute>() == null && t.GetCustomAttribute<CExporterIgnoreAttribute>() == null).Select(f => {
                    var parameterTypes = f.FieldType.GetFunctionPointerParameterTypes();
                    var memberFunction = memberFunctions.FirstOrDefault(t => t.Item1 == f.Name && t.Item2.Length == parameterTypes.Length - 1);
                    var returnType = f.FieldType.GetFunctionPointerReturnType();
                    string? returnTypeOverride = null;
                    Type[] requiredTypes = [];
                    if (returnType is { Namespace: ExporterStatics.StdNamespacePrefix })
                        (returnTypeOverride, requiredTypes) = ProcessStdType(returnType);
                    if (memberFunction?.Item3 != returnType) memberFunction = null;
                    if (returnTypeOverride != null) {
                        foreach (var requiredType in requiredTypes) {
                            _processType.Add(requiredType);
                        }
                    } else
                        _processType.Add(f.FieldType.GetFunctionPointerReturnType());
                    return new ProcessedVirtualFunction {
                        VirtualFunctionName = f.Name,
                        Offset = f.GetFieldOffset(),
                        VirtualFunctionReturnType = f.FieldType.GetFunctionPointerReturnType(),
                        VirtualFunctionParameters = parameterTypes.Select((p, i) => ProcessVirtualParameter(p, i, memberFunction?.Item2)).ToArray(),
                        VirtualFunctionReturnTypeOverride = returnTypeOverride
                    };
                }).ToArray();
                vtableSize = vtable.StructLayoutAttribute?.Size ?? vtableSize;
            }

            var memberFunctionClass = type.GetMember("MemberFunctionPointers", ExporterStatics.BindingFlags).FirstOrDefault()?.DeclaringType;
            ProcessedMemberFunction[] memberFunctionsArray = [];
            if (memberFunctionClass != null) {
                var memberFunctions = memberFunctionClass.GetMethods(ExporterStatics.BindingFlags).Where(t => t.GetCustomAttribute<ObsoleteAttribute>() == null && t.GetCustomAttribute<CExporterIgnoreAttribute>() == null).ToArray();
                foreach (var memberFunction in memberFunctions) {
                    var memberFunctionAddress = memberFunction.GetCustomAttribute<MemberFunctionAttribute>();
                    if (memberFunctionAddress == null) continue;
                    var memberFunctionParameters = memberFunction.GetParameters();
                    string? memberFunctionOverrideType = null;
                    if (memberFunction.ReturnType.IsFunctionPointer) {
                        memberFunctionOverrideType = "__int64";
                    }
                    var returnType = memberFunction.ReturnType;
                    var pointerCount = 0;
                    while (returnType.IsPointer()) {
                        pointerCount++;
                        returnType = returnType.GetPointerType();
                    }
                    if (returnType is { Namespace: ExporterStatics.StdNamespacePrefix }) {
                        (memberFunctionOverrideType, var requiredTypes) = ProcessStdType(returnType);
                        foreach (var requiredType in requiredTypes) {
                            _processType.Add(requiredType);
                        }
                        memberFunctionOverrideType += new string('*', pointerCount);
                    }
                    var memberFunctionReturnType = new ProcessedMemberFunctionReturn(returnType, memberFunctionOverrideType);
                    if (memberFunction.GetCustomAttribute<CExporterExcelAttribute>() is not { } excelAttribute)
                        _processType.Add(memberFunctionReturnType.Type);
                    else
                        memberFunctionReturnType.OverrideType = $"Component::Exd::Sheets::{excelAttribute.SheetName}*";
                    memberFunctionsArray =
                    [
                        .. memberFunctionsArray,
                        new ProcessedMemberFunction {
                            MemberFunctionSignature = memberFunctionAddress!.Signature,
                            MemberFunctionName = memberFunction.Name,
                            MemberFunctionReturnType = memberFunctionReturnType,
                            MemberFunctionParameters = [
                                new ProcessedField {
                                    FieldTypeOverride = memberFunctionClass.FixTypeName() + "*",
                                    FieldType = memberFunctionClass,
                                    FieldOffset = -1,
                                    FieldName = "this",
                                    Bits = [],
                                    IsUnion = false,
                                    UnionValues = []
                                },
                                .. memberFunctionParameters.Select(ProcessParameter).ToArray()]
                        },
                    ];
                }
            }

            var fields = type.GetFields(ExporterStatics.BindingFlags).Where(t => !type.IsInheritance(t)).ToArray();
            var unionInfoFields = fields.Where(t => t.GetCustomAttribute<ObsoleteAttribute>() == null && t.GetCustomAttribute<CExporterIgnoreAttribute>() == null && t.GetCustomAttribute<CExporterUnionAttribute>() != null)
                .GroupBy(t => t.GetCustomAttribute<CExporterUnionAttribute>()!.Union)
                .ToFrozenDictionary(t => t.Key, t => t.GroupBy(k => k.GetCustomAttribute<CExporterUnionAttribute>()!.Struct).OrderBy(k => k.Key).ToFrozenDictionary(k => k.Key, k => k.ToArray()));

            var processedStruct = new ProcessedStruct {
                StructType = type,
                IsUnion = type.GetCustomAttribute<CExporterStructUnionAttribute>() != null,
                StructName = type.Name,
                StructNamespace = type.GetNamespace(),
                StructSize = size,
                VirtualFunctionSize = vtableSize,
                Fields = ProcessFields(fields),
                VirtualFunctions = virtualFunctions,
                MemberFunctions = memberFunctionsArray,
                StructTypeOverride = overrideType,
                TemplateTypes = type.IsGenericTypeDefinition ? type.GetGenericArguments().Select(t => t.Name).ToArray() : []
            };

            foreach (var (fieldName, unionInfos) in unionInfoFields) {
                var processedUnionStructFields = new List<ProcessedFieldUnion>();
                FieldInfo[] unionFields;
                if (unionInfos.Count > 1) {
                    foreach (var unionStructName in unionInfos.Keys.Where(t => t != "")) {
                        unionFields = unionInfos[unionStructName];
                        var offsetStart = unionFields[0].GetCustomAttribute<FieldOffsetAttribute>()!.Value;
                        var unionStructType = $"{type.GetNamespace().Replace(".", "::")}::{type.Name}_union_{unionStructName}";
                        _structs.Add(new ProcessedStruct {
                            MemberFunctions = [],
                            StructName = $"{type.Name}_union_{unionStructName}",
                            StructNamespace = type.GetNamespace(),
                            StructSize = unionInfos[""][0].FieldType.SizeOf(),
                            StructType = type,
                            TemplateTypes = [],
                            VirtualFunctionSize = 0,
                            StructTypeOverride = unionStructType,
                            Fields = unionFields.Select(t => ProcessField(t, offsetStart)).ToArray(),
                            IsUnion = false
                        });
                        processedUnionStructFields.Add(new ProcessedFieldUnion {
                            FieldType = unionFields[0].FieldType,
                            FieldName = unionStructName,
                            FieldTypeOverride = unionStructType
                        });
                    }
                }

                unionFields = unionInfos[""];

                var unionValues = unionFields.Select(unionField => {
                    (string? typeOverride, Type[] typeOverrideTemplates) = (null, []);
                    if (unionField.FieldType is { Namespace: ExporterStatics.StdNamespacePrefix })
                        (typeOverride, typeOverrideTemplates) = ProcessStdType(unionField.FieldType);

                    return (new ProcessedFieldUnion {
                        FieldName = unionField.Name,
                        FieldType = unionField.FieldType,
                        FieldTypeOverride = typeOverride
                    }, typeOverrideTemplates);
                }).ToArray();

                processedStruct.Fields = [..processedStruct.Fields, new ProcessedField {
                    Bits = [],
                    FieldName = fieldName,
                    FieldOffset = unionFields[0].GetCustomAttribute<FieldOffsetAttribute>()!.Value,
                    FieldType = unionFields[0].FieldType,
                    IsUnion = true,
                    UnionValues = unionValues.Select(t => t.Item1).Concat(processedUnionStructFields).ToArray(),
                    FieldTypeOverrideTemplates = unionValues.SelectMany(t => t.typeOverrideTemplates).ToArray()
                }];
            }

            if (!quiet) Console.WriteLine($"Processed {processedStruct.StructTypeName} with {processedStruct.Fields.Length + (processedStruct.VirtualFunctions?.Length ?? 0) + processedStruct.MemberFunctions.Length} fields and methods");
            _structs.Add(processedStruct);
        }
        return null;
    }

    public static ProcessedField[] ProcessFields(FieldInfo[] fields) {
        FieldInfo[] fieldsToProcess = fields.Where(t => !ExporterStatics.IgnoredTypeNames.Contains(t.Name) && t.GetCustomAttribute<ObsoleteAttribute>() == null && t.GetCustomAttribute<CExporterIgnoreAttribute>() == null && t.GetCustomAttribute<CExporterUnionAttribute>() == null).ToArray();
        int[][] fieldsToUse = [];
        bool isExcel = false;
        int currentField = 0;
        while (fieldsToProcess is [{ Name: "WithOps" }] or [{ Name: "Tree" }]) {
            fieldsToProcess = fieldsToProcess[0].FieldType.GetFields(ExporterStatics.BindingFlags).Where(t => !ExporterStatics.IgnoredTypeNames.Contains(t.Name) && t.GetCustomAttribute<ObsoleteAttribute>() == null && t.GetCustomAttribute<CExporterIgnoreAttribute>() == null && t.GetCustomAttribute<CExporterUnionAttribute>() == null).ToArray();
        }
        for (var i = 0; i < fieldsToProcess.Length; i++) {
            var field = fieldsToProcess[i];
            if (field.GetCustomAttribute<CExporterForceAttribute>() != null)
                _processType.Add(field.FieldType);
            if (field.GetCustomAttribute<CExporterExcelBeginAttribute>() != null) {
                isExcel = true;
                fieldsToUse = [.. fieldsToUse, [currentField, i + 1]];
                continue;
            }
            if (field.GetCustomAttribute<CExporterExcelEndAttribute>() != null) {
                if (isExcel)
                    currentField = i + 1;

                isExcel = false;
                continue;
            }
        }
        if (fieldsToUse.Length == 0) return fieldsToProcess.Select(f => ProcessField(f, 0)).ToArray();
        fieldsToUse = [.. fieldsToUse, [currentField, fieldsToProcess.Length]];
        return fieldsToUse.SelectMany(t => fieldsToProcess[t[0]..t[1]].Select(f => ProcessField(f, 0))).ToArray();
    }
}

public class YamlExport {
    public required ProcessedEnum[] Enums;
    public required ProcessedStruct[] Structs;
}

public class ProcessedBitField {
    public required int Size;
    public required int Offset;
    public required Type Type;
    public required string Name;
}

public class ProcessedFieldUnion {
    public required Type FieldType;
    public required string FieldName;
    public required string? FieldTypeOverride;
}

public class ProcessedField {
    public string? FieldTypeOverride;
    public bool? FieldTypeOverrideCheck;
    public Type[]? FieldTypeOverrideTemplates;
    public required Type FieldType;
    public required string FieldName;
    public required int FieldOffset;
    public required bool IsUnion;
    public required ProcessedFieldUnion[] UnionValues;
    public bool IsBase;
    public required ProcessedBitField[] Bits;
    public virtual int FieldSize => FieldType.SizeOf();
}

public class ProcessedFixedField : ProcessedField {
    public required int FixedSize;
    public bool FixedString;

    public override int FieldSize => FixedSize * FieldType.SizeOf();
}

public class ProcessedFunctionField : ProcessedField {
    public required Type FunctionReturnType;
    public required ProcessedField[] FunctionParameters;
}

public class ProcessedStaticMembers {
    public required string Signature;
    public required ushort[] RelativeFollowOffsets;
    public bool IsPointer;
    public required Type ReturnType;
}

// TODO: Export if struct is generic with types
public class ProcessedStruct {
    public required string? StructTypeOverride;
    public required bool IsUnion;
    public required Type StructType;
    public required string StructName;
    public required string StructNamespace;
    public required int StructSize;
    public required ProcessedField[] Fields;
    public required int VirtualFunctionSize;
    public ProcessedVirtualFunction[]? VirtualFunctions; // null if there are no virtual functions, empty if there's a vtable with unknown contents
    public required ProcessedMemberFunction[] MemberFunctions;
    public ProcessedMemberFunction[]? StaticMemberFunctions;
    public ProcessedStaticMembers[]? StaticMembers;
    public required string[] TemplateTypes;
    [YamlIgnore]
    public string StructTypeName => StructTypeOverride ?? StructType.FixTypeName();
    [YamlIgnore]
    private string[] _dependencyNames = [];
    [YamlIgnore]
    public string[] DependencyNames {
        get {
            if (_dependencyNames.Length == 0) {
                _dependencyNames = Fields
                    .Where(t => {
                        if (t.FieldTypeOverride == null) return (t.GetType() == typeof(ProcessedField) || t.GetType() == typeof(ProcessedFixedField)) && !t.FieldType.ShouldNotExportType() && !t.FieldType.IsConstructedGenericType && !ExporterStatics.BaseTypeNames.Contains(t.FieldType.FixTypeName());
                        if (t.FieldTypeOverride.EndsWith('*') || t.FieldTypeOverride.StartsWith("Component::Exd::Sheets::") || ExporterStatics.BaseTypeNames.Contains(t.FieldTypeOverride)) return false;
                        return !t.FieldTypeOverrideCheck.HasValue || !t.FieldTypeOverrideCheck.Value;
                    })
                    .SelectMany(t => {
                        if (t.FieldTypeOverride?.StartsWith(ExporterStatics.StdCppNamespace) ?? false) return t.FieldTypeOverrideTemplates!.Where(k => !k.ShouldNotExportType()).Select(k => k.FixTypeName()).Where(k => !ExporterStatics.BaseTypeNames.Contains(k));
                        return [t.FieldTypeOverride ?? t.FieldType.FixTypeName()];
                    }).Distinct().ToArray();
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
    public required bool IsFlags;
    public required Dictionary<string, string> EnumValues;
}

public class ProcessedVirtualFunction {
    public required string VirtualFunctionName;
    public required int Offset;
    public required Type? VirtualFunctionReturnType;
    public required ProcessedField[]? VirtualFunctionParameters;
    public required string? VirtualFunctionReturnTypeOverride;
}

public class ProcessedMemberFunction {
    public required string MemberFunctionSignature;
    public required string MemberFunctionName;
    public required ProcessedMemberFunctionReturn MemberFunctionReturnType;
    public required ProcessedField[] MemberFunctionParameters;
}

public class ProcessedMemberFunctionReturn(Type type, string? overrideType) {
    public Type Type = type;
    public string? OverrideType = overrideType;
    public static implicit operator ProcessedMemberFunctionReturn((Type Type, string OverrideType) value) => new(value.Type, value.OverrideType);
    public static implicit operator (Type Type, string? OverrideType)(ProcessedMemberFunctionReturn value) => (value.Type, value.OverrideType);
    public static implicit operator ProcessedMemberFunctionReturn(Type type) => new(type, null);
    public static implicit operator Type(ProcessedMemberFunctionReturn value) => value.Type;
    public static implicit operator string(ProcessedMemberFunctionReturn value) => value.OverrideType ?? value.Type.FixTypeName();
}

public class ProcessedEnumConverter : IYamlTypeConverter {
    public bool Accepts(Type type) => type == typeof(ProcessedEnum);
    public object? ReadYaml(IParser parser, Type type, ObjectDeserializer rootDeserializer) => throw new NotImplementedException();
    public void WriteYaml(IEmitter emitter, object? value, Type type, ObjectSerializer serializer) {
        if (value is not ProcessedEnum e) return;
        emitter.Emit(new MappingStart());
        emitter.Emit(new Scalar("type"));
        emitter.Emit(new Scalar(e.EnumType.FixTypeName()));
        emitter.Emit(new Scalar("name"));
        emitter.Emit(new Scalar(e.EnumName));
        emitter.Emit(new Scalar("underlying"));
        emitter.Emit(new Scalar(e.EnumType.GetEnumUnderlyingType().FixTypeName()));
        emitter.Emit(new Scalar("namespace"));
        emitter.Emit(new Scalar(e.EnumNamespace));
        emitter.Emit(new Scalar("flags"));
        emitter.Emit(e.IsFlags ? new Scalar("True") : new Scalar("False"));
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
    public object? ReadYaml(IParser parser, Type type, ObjectDeserializer rootDeserializer) => throw new NotImplementedException();
    public void WriteYaml(IEmitter emitter, object? value, Type type, ObjectSerializer serializer) {
        if (value is not ProcessedField f) return;
        emitter.Emit(new MappingStart());
        emitter.Emit(new Scalar("type"));
        if (f.FieldType.IsFunctionPointer || f.FieldType.IsUnmanagedFunctionPointer) {
            emitter.Emit(new Scalar("__fastcall"));
        } else {
            emitter.Emit(new Scalar(f.FieldTypeOverride ?? f.FieldType.FixTypeName()));
        }
        emitter.Emit(new Scalar("name"));
        emitter.Emit(new Scalar(f.FieldName));
        if (f.FieldOffset >= 0) {
            emitter.Emit(new Scalar("offset"));
            emitter.Emit(new Scalar(f.FieldOffset.ToString()));
        }
        if (f.Bits.Length > 0) {
            emitter.Emit(new Scalar("bits"));
            emitter.Emit(new SequenceStart(null, null, true, SequenceStyle.Block));
            foreach (var bit in f.Bits) {
                emitter.Emit(new MappingStart());
                emitter.Emit(new Scalar("type"));
                emitter.Emit(new Scalar(bit.Type.FixTypeName()));
                emitter.Emit(new Scalar("offset"));
                emitter.Emit(new Scalar(bit.Offset.ToString()));
                emitter.Emit(new Scalar("size"));
                emitter.Emit(new Scalar(bit.Size.ToString()));
                emitter.Emit(new Scalar("name"));
                emitter.Emit(new Scalar(bit.Name));
                emitter.Emit(new MappingEnd());
            }
            emitter.Emit(new SequenceEnd());
        }
        if (f.IsBase) {
            emitter.Emit(new Scalar("base"));
            emitter.Emit(new Scalar("true"));
        }
        switch (f) {
            case ProcessedFunctionField func: {
                    emitter.Emit(new Scalar("return_type"));
                    emitter.Emit(new Scalar(func.FunctionReturnType.FixTypeName()));
                    emitter.Emit(new Scalar("parameters"));
                    emitter.Emit(new SequenceStart(null, null, true, SequenceStyle.Block));
                    foreach (var p in func.FunctionParameters) {
                        emitter.Emit(new MappingStart());
                        emitter.Emit(new Scalar("type"));
                        emitter.Emit(new Scalar(p.FieldTypeOverride ?? p.FieldType.FixTypeName()));
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
                emitter.Emit(new Scalar("is_string"));
                emitter.Emit(new Scalar(fix.FixedString.ToString()));
                break;
        }
        if (f.IsUnion) {
            emitter.Emit(new Scalar("union_values"));
            emitter.Emit(new SequenceStart(null, null, true, SequenceStyle.Block));
            foreach (var unionValue in f.UnionValues) {
                emitter.Emit(new MappingStart());
                emitter.Emit(new Scalar("type"));
                emitter.Emit(new Scalar(unionValue.FieldTypeOverride ?? unionValue.FieldType.FixTypeName()));
                emitter.Emit(new Scalar("name"));
                emitter.Emit(new Scalar(unionValue.FieldName));
                emitter.Emit(new MappingEnd());
            }
            emitter.Emit(new SequenceEnd());
        }
        emitter.Emit(new MappingEnd());
    }

    public static readonly IYamlTypeConverter Instance = new ProcessedFieldConverter();
}

public class ProcessedStructConverter : IYamlTypeConverter {
    public bool Accepts(Type type) => type == typeof(ProcessedStruct);
    public object? ReadYaml(IParser parser, Type type, ObjectDeserializer rootDeserializer) => throw new NotImplementedException();
    public void WriteYaml(IEmitter emitter, object? value, Type type, ObjectSerializer serializer) {
        if (value is not ProcessedStruct s) return;
        emitter.Emit(new MappingStart());
        emitter.Emit(new Scalar("type"));
        emitter.Emit(new Scalar(!string.IsNullOrWhiteSpace(s.StructTypeOverride) ? s.StructTypeOverride : s.StructType.FixTypeName()));
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
            ProcessedFieldConverter.Instance.WriteYaml(emitter, field, field.GetType(), serializer);
        }
        emitter.Emit(new SequenceEnd());
        if (s.VirtualFunctionSize != 0) {
            emitter.Emit(new Scalar("vtable_size"));
            emitter.Emit(new Scalar(s.VirtualFunctionSize.ToString()));
        }
        if (s.VirtualFunctions != null) {
            emitter.Emit(new Scalar("virtual_functions"));
            emitter.Emit(new SequenceStart(null, null, true, SequenceStyle.Block));
            foreach (var virtualFunction in s.VirtualFunctions) {
                ProcessedVirtualFunctionConverter.Instance.WriteYaml(emitter, virtualFunction, virtualFunction.GetType(), serializer);
            }
            emitter.Emit(new SequenceEnd());
        }
        emitter.Emit(new Scalar("member_functions"));
        emitter.Emit(new SequenceStart(null, null, true, SequenceStyle.Block));
        foreach (var memberFunction in s.MemberFunctions) {
            ProcessedMemberFunctionConverter.Instance.WriteYaml(emitter, memberFunction, memberFunction.GetType(), serializer);
        }
        emitter.Emit(new SequenceEnd());
        if (s.StaticMembers != null) {
            emitter.Emit(new Scalar("static_members"));
            emitter.Emit(new SequenceStart(null, null, true, SequenceStyle.Block));
            foreach (var staticMember in s.StaticMembers) {
                ProcessedStaticMembersConverter.Instance.WriteYaml(emitter, staticMember, staticMember.GetType(), serializer);
            }
            emitter.Emit(new SequenceEnd());
        }
        if (s.StaticMemberFunctions != null) {
            emitter.Emit(new Scalar("static_member_functions"));
            emitter.Emit(new SequenceStart(null, null, true, SequenceStyle.Block));
            foreach (var staticMemberFunction in s.StaticMemberFunctions) {
                ProcessedMemberFunctionConverter.Instance.WriteYaml(emitter, staticMemberFunction, staticMemberFunction.GetType(), serializer);
            }
            emitter.Emit(new SequenceEnd());
        }
        emitter.Emit(new Scalar("template_types"));
        emitter.Emit(new SequenceStart(null, null, true, SequenceStyle.Flow));
        foreach (var templateType in s.TemplateTypes) {
            emitter.Emit(new Scalar(templateType));
        }
        emitter.Emit(new SequenceEnd());
        emitter.Emit(new MappingEnd());
    }

    public static readonly IYamlTypeConverter Instance = new ProcessedStructConverter();
}

public class ProcessedMemberFunctionConverter : IYamlTypeConverter {
    public bool Accepts(Type type) => type == typeof(ProcessedMemberFunction);
    public object? ReadYaml(IParser parser, Type type, ObjectDeserializer rootDeserializer) => throw new NotImplementedException();
    public void WriteYaml(IEmitter emitter, object? value, Type type, ObjectSerializer serializer) {
        if (value is not ProcessedMemberFunction m) return;
        emitter.Emit(new MappingStart());
        emitter.Emit(new Scalar("signature"));
        emitter.Emit(new Scalar(m.MemberFunctionSignature));
        emitter.Emit(new Scalar("return_type"));
        emitter.Emit(new Scalar(m.MemberFunctionReturnType));
        emitter.Emit(new Scalar("name"));
        emitter.Emit(new Scalar(m.MemberFunctionName));
        emitter.Emit(new Scalar("parameters"));
        emitter.Emit(new SequenceStart(null, null, true, SequenceStyle.Block));
        foreach (var parameter in m.MemberFunctionParameters) {
            ProcessedFieldConverter.Instance.WriteYaml(emitter, parameter, parameter.GetType(), serializer);
        }
        emitter.Emit(new SequenceEnd());
        emitter.Emit(new MappingEnd());
    }

    public static readonly IYamlTypeConverter Instance = new ProcessedMemberFunctionConverter();
}

public class ProcessedVirtualFunctionConverter : IYamlTypeConverter {

    public bool Accepts(Type type) => type == typeof(ProcessedVirtualFunction);
    public object? ReadYaml(IParser parser, Type type, ObjectDeserializer rootDeserializer) => throw new NotImplementedException();
    public void WriteYaml(IEmitter emitter, object? value, Type type, ObjectSerializer serializer) {
        if (value is not ProcessedVirtualFunction v) return;
        emitter.Emit(new MappingStart());
        emitter.Emit(new Scalar("name"));
        emitter.Emit(new Scalar(v.VirtualFunctionName));
        emitter.Emit(new Scalar("offset"));
        emitter.Emit(new Scalar(v.Offset.ToString()));
        if (v.VirtualFunctionReturnType != null) {
            emitter.Emit(new Scalar("return_type"));
            emitter.Emit(new Scalar(v.VirtualFunctionReturnTypeOverride ?? v.VirtualFunctionReturnType.FixTypeName()));
        }
        if (v.VirtualFunctionParameters != null) {
            emitter.Emit(new Scalar("parameters"));
            emitter.Emit(new SequenceStart(null, null, true, SequenceStyle.Block));
            foreach (var parameter in v.VirtualFunctionParameters) {
                ProcessedFieldConverter.Instance.WriteYaml(emitter, parameter, parameter.GetType(), serializer);
            }
            emitter.Emit(new SequenceEnd());
        }
        emitter.Emit(new MappingEnd());
    }

    public static readonly IYamlTypeConverter Instance = new ProcessedVirtualFunctionConverter();
}

public class ProcessedStaticMembersConverter : IYamlTypeConverter {
    public bool Accepts(Type type) => type == typeof(ProcessedStaticMembers);
    public object? ReadYaml(IParser parser, Type type, ObjectDeserializer rootDeserializer) => throw new NotImplementedException();
    public void WriteYaml(IEmitter emitter, object? value, Type type, ObjectSerializer serializer) {
        if (value is not ProcessedStaticMembers s) return;
        emitter.Emit(new MappingStart());
        emitter.Emit(new Scalar("signature"));
        emitter.Emit(new Scalar(s.Signature));
        emitter.Emit(new Scalar("relative_follow_offsets"));
        emitter.Emit(new SequenceStart(null, null, true, SequenceStyle.Block));
        foreach (var offset in s.RelativeFollowOffsets) {
            emitter.Emit(new Scalar(offset.ToString()));
        }
        emitter.Emit(new SequenceEnd());
        emitter.Emit(new Scalar("is_pointer"));
        emitter.Emit(new Scalar(s.IsPointer.ToString()));
        emitter.Emit(new Scalar("return_type"));
        emitter.Emit(new Scalar(s.ReturnType.FixTypeName()));
        emitter.Emit(new MappingEnd());
    }

    public static readonly IYamlTypeConverter Instance = new ProcessedStaticMembersConverter();
}

public record ProcessingType(Type Type, string? OverrideTypeName) {
    public static implicit operator Type(ProcessingType t) => t.Type;
    public static implicit operator ProcessingType(Type t) => new(t, null);
}
