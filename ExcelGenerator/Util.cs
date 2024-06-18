using System.Text;
using ExcelGenerator.Schema;
using Lumina.Data.Structs.Excel;

namespace ExcelGenerator;

public static class Util {
    public static string ExcelTypeToManaged(ExcelColumnDataType type) {
        return type switch {
            ExcelColumnDataType.String => "int",
            ExcelColumnDataType.Bool => "bool",
            ExcelColumnDataType.Int8 => "sbyte",
            ExcelColumnDataType.UInt8 => "byte",
            ExcelColumnDataType.Int16 => "short",
            ExcelColumnDataType.UInt16 => "ushort",
            ExcelColumnDataType.Int32 => "int",
            ExcelColumnDataType.UInt32 => "uint",
            ExcelColumnDataType.Float32 => "float",
            ExcelColumnDataType.Int64 => "long",
            ExcelColumnDataType.UInt64 => "ulong",
            // these should not end up as type anywhere, if they do make them error and see wtf is up
            ExcelColumnDataType.PackedBool0
                or ExcelColumnDataType.PackedBool1
                or ExcelColumnDataType.PackedBool2
                or ExcelColumnDataType.PackedBool3
                or ExcelColumnDataType.PackedBool4
                or ExcelColumnDataType.PackedBool5
                or ExcelColumnDataType.PackedBool6
                or ExcelColumnDataType.PackedBool7 => $"bit_error_type_{type - ExcelColumnDataType.PackedBool0}",
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, "Undefined Column Type")
        };
    }

    public static int SizeOf(ExcelColumnDataType type) {
        return type switch {
            ExcelColumnDataType.String => 4,
            ExcelColumnDataType.Bool => 1,
            ExcelColumnDataType.Int8 => 1,
            ExcelColumnDataType.UInt8 => 1,
            ExcelColumnDataType.Int16 => 2,
            ExcelColumnDataType.UInt16 => 2,
            ExcelColumnDataType.Int32 => 4,
            ExcelColumnDataType.UInt32 => 4,
            ExcelColumnDataType.Float32 => 4,
            ExcelColumnDataType.Int64 => 8,
            ExcelColumnDataType.UInt64 => 8,
            ExcelColumnDataType.PackedBool0
                or ExcelColumnDataType.PackedBool1
                or ExcelColumnDataType.PackedBool2
                or ExcelColumnDataType.PackedBool3
                or ExcelColumnDataType.PackedBool4
                or ExcelColumnDataType.PackedBool5
                or ExcelColumnDataType.PackedBool6
                or ExcelColumnDataType.PackedBool7 => 1,
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, "Undefined Column Type")
        };
    }

    public static int GetFieldCount(Field field) {
        if (field is ArrayField array)
            return array.Count;

        if (field is StructField str)
            return str.Count * str.Fields.Sum(GetFieldCount);

        return 1;
    }

    public static int GetFieldSize(Field field, List<ExcelColumnDefinition> columns, int columnStartIndex) {
        // don't count any bits except the first of a bitfield
        if (columns[columnStartIndex].Type > ExcelColumnDataType.PackedBool0)
            return 0;

        if (field is ScalarField)
            return SizeOf(columns[columnStartIndex].Type);

        if (field is ArrayField array) {
            var size = SizeOf(columns[columnStartIndex].Type);
            return size * array.Count;
        }

        if (field is StructField str) {
            var colIndex = columnStartIndex;
            var size = 0;
            foreach (var subField in str.Fields) {
                size += GetFieldSize(subField, columns, colIndex);
                colIndex += GetFieldCount(subField);
            }

            return size;
        }

        var baseOffset = columns[columnStartIndex].Offset;
        return columns[columnStartIndex + 1].Offset - baseOffset;
    }

    public static bool NeedsInterop(Field field) {
        return field is ArrayField or StructField;
    }

    public static int CalculateBitOffset(ExcelColumnDefinition def) {
        return CalculateBitOffset(def.Offset, def.Type);
    }

    public static int CalculateBitOffset(int offset, ExcelColumnDataType type) {
        var bitOffset = offset * 8;
        return type switch {
            ExcelColumnDataType.PackedBool0 => bitOffset + 0,
            ExcelColumnDataType.PackedBool1 => bitOffset + 1,
            ExcelColumnDataType.PackedBool2 => bitOffset + 2,
            ExcelColumnDataType.PackedBool3 => bitOffset + 3,
            ExcelColumnDataType.PackedBool4 => bitOffset + 4,
            ExcelColumnDataType.PackedBool5 => bitOffset + 5,
            ExcelColumnDataType.PackedBool6 => bitOffset + 6,
            ExcelColumnDataType.PackedBool7 => bitOffset + 7,
            _ => bitOffset,
        };
    }

    public static string ToFixedArrayName(string fieldName) {
        if (fieldName.Length >= 1)
            return $"_{char.ToLower(fieldName[0])}{fieldName[1..]}";
        return $"_{fieldName.ToLower()}";
    }

    public static string FixIndent(StringBuilder sb, int level) {
        if (level == 0) return sb.ToString();
        var indent = new string(' ', level * 4);
        sb.Replace(Environment.NewLine, Environment.NewLine + indent);
        return indent + sb.ToString().TrimEnd(' ');
    }
}
