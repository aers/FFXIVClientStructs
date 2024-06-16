using System.Text;
using ExcelGenerator.Schema;
using Lumina.Data.Structs.Excel;

namespace ExcelGenerator.CodeGen;

public class BitFieldGenerator : BaseGenerator {
    private readonly List<Field> _fields;
    private readonly string _bitFieldName;
    private readonly string _bitFieldFlagsName;
    
    public BitFieldGenerator(List<Field> fields, List<ExcelColumnDefinition> columns, int startColumnIndex, int startOffset) : base(fields[0], columns, startColumnIndex, startOffset) {
        _fields = fields;
        _bitFieldName = $"BitField{StartOffset:X2}";
        _bitFieldFlagsName = $"{_bitFieldName}Flags";
    }

    public override int ConsumedColumnCount() {
        return _fields.Count;
    }

    public override int ConsumedFieldCount() {
        return _fields.Count;
    }
    
    public override void WriteFields(StringBuilder sb) {
        // if there would only be 1 flag, emit a bool field for it and skip the enum creation
        if (_fields.Count == 1) {
            sb.AppendLine($"[FieldOffset(0x{StartOffset:X2})] public bool {_fields[0].Name};");
        } else {
            sb.AppendLine($"[FieldOffset(0x{StartOffset:X2})] public {_bitFieldFlagsName} {_bitFieldName};");
            foreach (var field in _fields)
                sb.AppendLine($"public bool {field.Name} => {_bitFieldName}.HasFlag({_bitFieldFlagsName}.{field.Name});");   
        }
    }

    public override void WriteStructs(StringBuilder sb) {
        if (_fields.Count == 1) return;
        
        sb.AppendLine("[Flags]");
        sb.AppendLine($"public enum {_bitFieldFlagsName} : byte {{");
        for (var i = 0; i < _fields.Count; i++) {
            var field = _fields[i];
            sb.AppendLine($"\t{field.Name} = 1 << {i},");
        }
        sb.AppendLine("}");
    }
}
