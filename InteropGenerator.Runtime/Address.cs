namespace InteropGenerator.Runtime;

public sealed class Address {
    public readonly ulong[] Bytes;
    public readonly string CacheKey;
    public readonly ulong[] Mask;

    public readonly string Name;
    public readonly byte[] RelativeFollowOffsets;
    public readonly string String;
    public nint Value;
    public Address(string name, string @string, byte[] relativeFollowOffsets, ulong[] bytes, ulong[] mask, nint value) {
        Name = name;
        String = @string;
        RelativeFollowOffsets = relativeFollowOffsets;
        Bytes = bytes;
        Mask = mask;
        Value = value;

        CacheKey = relativeFollowOffsets.Length == 0 ? $"{String}" : $"{String}+relfollow[{string.Join(',', relativeFollowOffsets)}]";
    }
}
