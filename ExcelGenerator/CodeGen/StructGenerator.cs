using System.Text;
using ExcelGenerator.Schema;
using Lumina.Data.Structs.Excel;

namespace ExcelGenerator.CodeGen;

public class StructGenerator : BaseGenerator {
    private readonly List<BaseGenerator> _generators = [];
    private readonly int _structSize;

    public StructGenerator(Field field, List<ExcelColumnDefinition> columns, int startColumnIndex, int startOffset) : base(field, columns, startColumnIndex, startOffset) {
        if (field is not StructField structField)
            throw new InvalidOperationException($"Array Generator was created with an invalid Field Type: {Field.GetType()}");

        var colIndex = startColumnIndex;
        var offset = 0;
        for (var fieldIndex = 0; fieldIndex < structField.Fields.Count; fieldIndex++) {
            var fieldGenerator = Generator.CreateGeneratorForField(structField.Fields, fieldIndex, columns, colIndex, offset);
            _generators.Add(fieldGenerator);
            colIndex += fieldGenerator.ConsumedColumnCount();
            offset += fieldGenerator.TotalSize();
            fieldIndex += (fieldGenerator.ConsumedFieldCount() - 1);
        }
        _structSize = columns[colIndex].Offset - startOffset;
    }

    public override void WriteFields(StringBuilder sb) {
        var field = (StructField)Field;
        sb.Append($"[FieldOffset(0x{StartOffset:X2}), FixedSizeArray] ");
        sb.AppendLine($"internal FixedSizeArray{field.Count}<{FieldName}Struct> {Util.ToFixedArrayName(FieldName)};");
    }

    public override void WriteStructs(StringBuilder sb) {
        var field = (StructField)Field;
        if (field.Fields.Any(Util.NeedsInterop))
            sb.AppendLine("[GenerateInterop]");
        sb.AppendLine($"[StructLayout(LayoutKind.Explicit, Size = 0x{_structSize:X2})]");
        sb.AppendLine($"public partial struct {FieldName}Struct {{");

        var fieldsBuilder = new StringBuilder();
        var structsBuilder = new StringBuilder();

        foreach (var generator in _generators) {
            generator.WriteFields(fieldsBuilder);
            generator.WriteStructs(structsBuilder);
        }

        sb.AppendLine(Util.FixIndent(fieldsBuilder, 1).TrimEnd());
        if (structsBuilder.Length > 0) {
            sb.AppendLine();
            sb.AppendLine(Util.FixIndent(structsBuilder, 1).TrimEnd());
        }

        sb.AppendLine("}");
    }
}
