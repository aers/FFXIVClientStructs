namespace FFXIVClientStructs.Interop;

public sealed record Signature(string Name, string String, byte[] Bytes, byte[] Mask, nuint Value, Action<nuint> ApplyAction)
{
    public void Apply() => ApplyAction(Value);
}