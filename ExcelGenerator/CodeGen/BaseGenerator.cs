using System.Text;
using ExcelGenerator.Schema;
using Lumina.Data.Structs.Excel;

namespace ExcelGenerator.CodeGen;

public abstract class BaseGenerator(Field field, List<ExcelColumnDefinition> columns, int startColumnIndex, int startOffset) {
    protected Field Field { get; } = field;
    protected List<ExcelColumnDefinition> Columns { get; } = columns;
    protected int StartColumnIndex { get; } = startColumnIndex;
    protected int StartOffset { get; } = startOffset;

    protected string FieldType => Util.ExcelTypeToManaged(Columns[StartColumnIndex].Type);
    protected string FieldName => Field.Name ?? $"Unknown{StartColumnIndex}";

    public virtual void WriteFields(StringBuilder sb) { }

    public virtual void WriteStructs(StringBuilder sb) { }

    public virtual int ConsumedColumnCount() => Util.GetFieldCount(Field);

    public virtual int ConsumedFieldCount() => 1;

    public int TotalSize() {
        return Util.GetFieldSize(Field, Columns, StartColumnIndex) * ConsumedFieldCount();
    }
}
