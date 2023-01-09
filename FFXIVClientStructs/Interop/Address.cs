namespace FFXIVClientStructs.Interop;

public class Address
{
    public Address(string name, string @string, ulong[] bytes, ulong[] mask, nuint value)
    {
        this.Name = name;
        this.String = @string;
        this.Bytes = bytes;
        this.Mask = mask;
        this.Value = value;
    }

    public readonly string Name;
    public readonly string String;
    public readonly ulong[] Bytes;
    public readonly ulong[] Mask;
    public nuint Value;
}

public sealed class StaticAddress : Address
{
    public StaticAddress(string name, string @string, ulong[] bytes, ulong[] mask, nuint value, int offset) : base(name, @string, bytes, mask, value)
    {
        this.Offset = offset;
    }

    public int Offset;
}