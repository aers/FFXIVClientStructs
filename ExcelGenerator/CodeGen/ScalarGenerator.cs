using System.Text;
using ExcelGenerator.Schema;
using Lumina.Data.Structs.Excel;

namespace ExcelGenerator.CodeGen;

public class ScalarGenerator : BaseGenerator {
    public ScalarGenerator(Field field, List<ExcelColumnDefinition> columns, int startColumnIndex, int startOffset) : base(field, columns, startColumnIndex, startOffset) { }

    public override void WriteFields(StringBuilder sb) {
        var stringSuffix = Columns[StartColumnIndex].Type != ExcelColumnDataType.String ? string.Empty : "_Offset";
        if (Field.Remarks.Count > 0)
            sb.AppendLine($"/// <remarks>{string.Join(", ", Field.Remarks)}</remarks>");
        sb.AppendLine($"[FieldOffset(0x{StartOffset:X2})] public {FieldType} {FieldName}{stringSuffix};");
    }
}
