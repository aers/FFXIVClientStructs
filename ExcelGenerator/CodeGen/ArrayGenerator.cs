using System.Text;
using ExcelGenerator.Schema;
using Lumina.Data.Structs.Excel;

namespace ExcelGenerator.CodeGen;

public class ArrayGenerator : BaseGenerator {
    public ArrayGenerator(Field field, List<ExcelColumnDefinition> columns, int startColumnIndex, int startOffset) : base(field, columns, startColumnIndex, startOffset) {
        if (Field is not ArrayField)
            throw new InvalidOperationException($"Array Generator was created with an invalid Field Type: {Field.GetType()}");
    }

    public override void WriteFields(StringBuilder sb) {
        var array = (ArrayField)Field;
        sb.Append($"[FieldOffset(0x{StartOffset:X2}), FixedSizeArray] ");
        sb.AppendLine($"internal FixedSizeArray{array.Count}<{FieldType}> {Util.ToFixedArrayName(FieldName)};");
    }
}
