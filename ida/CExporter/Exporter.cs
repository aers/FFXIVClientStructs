using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FFXIVClientStructs.Interop;
using FFXIVClientStructs.Interop.Attributes;

namespace CExporter;

public class Exporter {
    private static List<ProcessedEnum> _enums = [];
    private static List<ProcessedStruct> _structs = [];
    private static BindingFlags _bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static;

    public static void ProcessTypes() {
        var havokTypes = ExporterStatics.GetHavokTypes();
        var xivTypes = ExporterStatics.GetXIVTypes();

        var havokStructs = havokTypes.Where(t => t.IsStruct()).ToArray();
        var xivStructs = xivTypes.Where(t => t.IsStruct()).ToArray();

        foreach (var sStruct in xivStructs.Concat(havokStructs)) {
            ProcessType(sStruct);
        }

        foreach (var @struct in _structs) {
            foreach (var virtualFunction in @struct.VirtualFunctions) {
                foreach (var field in virtualFunction.VirtualFunctionParameters) {
                    if (!field.FieldType.IsStruct()) continue;
                    if (field.FieldType.SizeOf() > 8 && !field.FieldType.IsPointer) {
                        ExporterStatics.WarningList.Add($"{@struct.StructNamespace}.{@struct.StructName} method {virtualFunction.VirtualFunctionName} has {field.FieldName} parameter with type {field.FieldType} not as a pointer. C# will handle this as a stack pointer reference but correct typing would be `{field.FieldType}* {field.FieldName}`");
                    }
                    if(_structs.Any(t => t.StructType == field.FieldType)) continue;
                    ProcessType(field.FieldType);
                }
            }
            foreach (var memberFunction in @struct.MemberFunctions) {
                foreach (var field in memberFunction.MemberFunctionParameters) {
                    if (!field.FieldType.IsStruct()) continue;
                    if (field.FieldType.SizeOf() > 8 && !field.FieldType.IsPointer && @struct.StructType) {
                        var fullName = string.IsNullOrWhiteSpace(@struct.StructNamespace) ? $"{@struct.StructNamespace}.{@struct.StructName}" : @struct.StructName;
                        ExporterStatics.WarningList.Add($"{fullName} method {memberFunction.MemberFunctionName} has {field.FieldName} parameter with type {field.FieldType} not as a pointer. C# will handle this as a stack pointer reference but correct typing would be `{field.FieldType}* {field.FieldName}`");
                    }
                }
            }
        }
    }

    private static void ProcessType(Type type) {
        if (type.IsEnum) {
            var processedEnum = new ProcessedEnum {
                EnumType = type,
                EnumName = type.Name,
                EnumNamespace = type.GetNamespace(),
                EnumValues = type.GetFields().Where(t => t.GetCustomAttribute<ObsoleteAttribute>() == null).ToDictionary(f => f.Name, f => f.GetRawConstantValue()!.ToString()!)
            };

            _enums.Add(processedEnum);
        } else if (type.IsStruct()) {
            var vtable = type.GetField("VTable", _bindingFlags)?.FieldType;
            ProcessedVirtualFunction[] virtualFunctions = [];
            if (vtable != null) {
                while(vtable.IsPointer)
                    vtable = vtable.GetElementType()!;
                virtualFunctions = vtable.GetFields(_bindingFlags).Select(f => new ProcessedVirtualFunction {
                    VirtualFunctionName = f.Name,
                    VirtualFunctionReturnType = f.FieldType.GetFunctionPointerReturnType(),
                    VirtualFunctionParameters = f.FieldType.GetFunctionPointerParameterTypes().Select(p => new ProcessedField {
                        FieldType = p,
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
                    if(memberFunctionAddress == null) continue;
                    var memberFunctionParameters = memberFunction.GetParameters();
                    var memberFunctionReturnType = memberFunction.ReturnType;
                    memberFunctionsArray = memberFunctionsArray.Append(new ProcessedMemberFunction {
                        MemberFunctionSignature = memberFunctionAddress!.Signature,
                        MemberFunctionName = memberFunction.Name,
                        MemberFunctionReturnType = memberFunctionReturnType,
                        MemberFunctionParameters = memberFunctionParameters.Select(p => new ProcessedField {
                            FieldType = p.ParameterType,
                            FieldName = p.Name
                        }).ToArray()
                    }).ToArray();
                }
            }

            var processedStruct = new ProcessedStruct {
                StructType = type,
                StructName = type.Name,
                StructNamespace = type.GetNamespace(),
                Fields = type.GetFields(_bindingFlags).Where(t => !ExporterStatics.IgnoredTypeNames.Contains(t.Name)).Select(f => new ProcessedField {
                    FieldType = f.FieldType,
                    FieldName = f.Name
                }).ToArray(),
                VirtualFunctions = virtualFunctions,
                MemberFunctions = memberFunctionsArray
            };

            _structs.Add(processedStruct);
        }
    }
}

public interface IProcessedType {
    public string GetCStruct();
    public string GetMembersInfo();
    public string GetCStructForward();
}

public struct ProcessedField : IProcessedType {
    public Type FieldType;
    public string FieldName;
    public int FieldOffset;

    public string GetCStruct() {
        throw new NotImplementedException();
    }

    public string GetMembersInfo() {
        throw new NotImplementedException();
    }

    public string GetCStructForward() {
        throw new NotImplementedException();
    }
}

public struct ProcessedStruct : IProcessedType {
    public Type StructType;
    public string StructName;
    public string StructNamespace;
    public ProcessedField[] Fields;
    public ProcessedVirtualFunction[] VirtualFunctions;
    public ProcessedMemberFunction[] MemberFunctions;

    public string GetCStruct() {
        throw new NotImplementedException();
    }

    public string GetMembersInfo() {
        throw new NotImplementedException();
    }

    public string GetCStructForward() {
        throw new NotImplementedException();
    }
}

public struct ProcessedEnum : IProcessedType {
    public Type EnumType;
    public string EnumName;
    public string EnumNamespace;
    public Dictionary<string, string> EnumValues;

    public string GetCStruct() {
        throw new NotImplementedException();
    }

    public string GetMembersInfo() {
        throw new NotImplementedException();
    }

    public string GetCStructForward() {
        throw new NotImplementedException();
    }
}

public struct ProcessedVirtualFunction : IProcessedType {
    public string VirtualFunctionName;
    public int Offset;
    public Type VirtualFunctionReturnType;
    public ProcessedField[] VirtualFunctionParameters;

    public string GetCStruct() {
        throw new NotImplementedException();
    }

    public string GetMembersInfo() {
        throw new NotImplementedException();
    }

    public string GetCStructForward() {
        throw new NotImplementedException();
    }
}

public struct ProcessedMemberFunction : IProcessedType {
    public string MemberFunctionSignature;
    public string MemberFunctionName;
    public Type MemberFunctionReturnType;
    public ProcessedField[] MemberFunctionParameters;

    public string GetCStruct() {
        throw new NotImplementedException();
    }

    public string GetMembersInfo() {
        throw new NotImplementedException();
    }

    public string GetCStructForward() {
        throw new NotImplementedException();
    }
}
