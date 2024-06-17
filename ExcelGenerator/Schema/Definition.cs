namespace ExcelGenerator.Schema;

public class Sheet(string name) {
    public string Name { get; set; } = name;
    public List<Field> Fields { get; set; } = [];
}

public abstract class Field(string? name) {
    public string? Name { get; } = name;
    public List<string> Remarks { get; set; } = [];
    public string Comment { get; set; } = string.Empty;
}

public class ScalarField(string? name) : Field(name);

public class ArrayField(string? name, int count) : Field(name) {
    public int Count { get; set; } = count;
}

public class StructField(string? name, int count, List<Field> fields) : Field(name) {
    public int Count { get; set; } = count;
    public List<Field> Fields { get; set; } = fields;
}
