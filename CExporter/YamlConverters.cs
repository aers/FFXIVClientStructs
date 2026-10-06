using System;
using System.Linq;
using System.Runtime.InteropServices;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;

namespace CExporter;

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
        }
        else {
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
        if(f.FieldType.IsConstructedGenericType && !f.FieldType.IsStdDefiniton())
        {
            emitter.Emit(new Scalar("template_args"));
            emitter.Emit(new SequenceStart(null, null, true, SequenceStyle.Flow));
            foreach (var templateArg in f.FieldType.GenericTypeArguments){
                emitter.Emit(new Scalar(templateArg.FixTypeName()));
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
        if (s.MemberFunctions.Any()){
            emitter.Emit(new Scalar("member_functions"));
            emitter.Emit(new SequenceStart(null, null, true, SequenceStyle.Block));
            foreach (var memberFunction in s.MemberFunctions) {
                ProcessedMemberFunctionConverter.Instance.WriteYaml(emitter, memberFunction, memberFunction.GetType(), serializer);
            }
            emitter.Emit(new SequenceEnd());
        }
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
        if (s.TemplateTypes.Any()) {
            emitter.Emit(new Scalar("template_types"));
            emitter.Emit(new SequenceStart(null, null, true, SequenceStyle.Flow));
            foreach (var templateType in s.TemplateTypes) {
                emitter.Emit(new Scalar(templateType));
            }
            emitter.Emit(new SequenceEnd());
        }
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
