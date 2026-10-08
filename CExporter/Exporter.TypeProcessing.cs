using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using FFXIVClientStructs.Attributes;
using InteropGenerator.Runtime.Attributes;

namespace CExporter;

public partial class Exporter {
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
        if (stdNameSpan is "std::string") return ($"{stdNameSpan}", []);
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
        return ProcessParameter(
            parameter.ParameterType,
            parameter.Name!,
            parameter.GetCustomAttribute<CExporterExcelAttribute>(),
            parameter.GetCustomAttribute<CExporterTypeForceAttribute>());
    }

    private static ProcessedField ProcessVirtualParameter(Type parameter, int i, ParameterInfo[]? parameters) {
        var parameterInfo = i == 0 ? null : parameters?[i - 1];
        var name = i == 0 ? "self" : parameterInfo?.Name ?? $"a{i + 1}";
        return ProcessParameter(
            parameter,
            name,
            parameter.GetCustomAttribute<CExporterExcelAttribute>(),
            parameterInfo?.GetCustomAttribute<CExporterTypeForceAttribute>());
    }

    private static ProcessedField ProcessParameter(
        Type parameterType,
        string parameterName,
        CExporterExcelAttribute? excelAttribute,
        CExporterTypeForceAttribute? typeForceAttribute) {
        string? typeOverride = null;
        Type[]? typeOverrideTemplates = null;

        if (parameterType is { Namespace: ExporterStatics.StdNamespacePrefix }) {
            (typeOverride, typeOverrideTemplates) = ProcessStdType(parameterType);
        } else if (parameterType is { Namespace: "FFXIVClientStructs.STD.Helper", Name: "Node*" }) {
            typeOverride = $"std::map<{string.Join(',', parameterType.GetGenericArguments()[0].GetGenericArguments().Select(t => t.FixTypeName()))}>::iterator";
        } else if (excelAttribute != null) {
            typeOverride = $"Component::Exd::Sheets::{excelAttribute.SheetName}*";
        } else if (typeForceAttribute != null) {
            typeOverride = typeForceAttribute.TypeName;
        } else {
            _processType.Add(parameterType);
        }

        return new ProcessedField {
            FieldType = parameterType,
            FieldOffset = -1,
            FieldName = parameterName,
            FieldTypeOverride = typeOverride,
            FieldTypeOverrideTemplates = typeOverrideTemplates,
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
                        VirtualFunctionName = f.Name.GetCorrectedName(),
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
                            MemberFunctionName = memberFunction.Name.GetCorrectedName(),
                            MemberFunctionReturnType = memberFunctionReturnType,
                            MemberFunctionParameters = [
                                new ProcessedField {
                                    FieldTypeOverride = memberFunctionClass.FixTypeName() + "*",
                                    FieldType = memberFunctionClass,
                                    FieldOffset = -1,
                                    FieldName = "self",
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
            if (field.FieldType.ContainsGenericParameters) continue;
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
