namespace InteropGenerator.Runtime;

public sealed class Address {
    public Address(string name, string @string, byte relativeFollowOffset, ulong[] bytes, ulong[] mask, nuint value) {
        this.Name = name;
        this.String = @string;
        this.RelativeFollowOffset = relativeFollowOffset;
        this.Bytes = bytes;
        this.Mask = mask;
        this.Value = value;

        this.CacheKey = relativeFollowOffset == 0 ? $"{this.String}" : $"{this.String}+relfollow@0x{this.RelativeFollowOffset:X}";
    }

    public readonly string Name;
    public readonly string String;
    public readonly byte RelativeFollowOffset;
    public readonly ulong[] Bytes;
    public readonly ulong[] Mask;
    public nuint Value;
    public readonly string CacheKey;
}
