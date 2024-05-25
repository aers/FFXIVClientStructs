namespace InteropGenerator.Runtime;

public sealed class Address {
    public readonly ulong[] Bytes;
    public readonly string CacheKey;
    public readonly ulong[] Mask;

    public readonly string Name;
    public readonly byte RelativeFollowOffset;
    public readonly string String;
    public nuint Value;
    public Address(string name, string @string, byte relativeFollowOffset, ulong[] bytes, ulong[] mask, nuint value) {
        Name = name;
        String = @string;
        RelativeFollowOffset = relativeFollowOffset;
        Bytes = bytes;
        Mask = mask;
        Value = value;

        CacheKey = relativeFollowOffset == 0 ? $"{String}" : $"{String}+relfollow@0x{RelativeFollowOffset:X}";
    }
}
