using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using FFXIVClientStructs.Attributes;
using InteropGenerator.Runtime.Attributes;
using Pastel;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace CExporter;

public partial class Exporter {
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
                ProcessedField[]? vparams = null;
                Type? vreturnType = null;
                if (name == "dtor") {
                    vreturnType = s.StructType.MakePointerType();
                    vparams = [
                        new ProcessedField{
                            FieldType = vreturnType, 
                            FieldName = "this",
                            Bits = [],
                            IsUnion = false,
                            UnionValues = [],
                            FieldOffset = -1
                        },
                        new ProcessedField{
                            FieldType = typeof(byte),
                            FieldName = "freeFlags",
                            Bits = [],
                            IsUnion = false,
                            UnionValues = [],
                            FieldOffset = -1
                        }
                    ];
                }
                if (vf == null)
                    s.VirtualFunctions = [.. s.VirtualFunctions, new() { VirtualFunctionName = name, Offset = offset, VirtualFunctionParameters = vparams, VirtualFunctionReturnType = vreturnType, VirtualFunctionReturnTypeOverride = null }];
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

}
