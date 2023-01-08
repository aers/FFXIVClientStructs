namespace FFXIVClientStructs.Interop;

public class Address
{
    public Address(string name, string @string, byte[] bytes, bool[] mask, nuint value)
    {
        this.Name = name;
        this.String = @string;
        this.Bytes = bytes;
        this.Mask = mask;
        this.Value = value;
    }

    public string Name;
    public string String;
    public readonly byte[] Bytes;
    public readonly bool[] Mask;
    public nuint Value;
}

public sealed class StaticAddress : Address
{
    public StaticAddress(string name, string @string, byte[] bytes, bool[] mask, nuint value, int offset) : base(name, @string, bytes, mask, value)
    {
        this.Offset = offset;
    }

    public int Offset;
}