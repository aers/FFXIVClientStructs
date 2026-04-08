namespace FFXIVClientStructs.FFXIV.Client.System.Crypt;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe partial struct Crc32 {
    [FieldOffset(0x8)] public uint CrcDigest;

    [VirtualFunction(0)]
    public partial Crc32* Dtor(byte freeFlags);

    [MemberFunction("E8 ?? ?? ?? ?? 8B 7B EE")]
    public partial Crc32* FromBuffer(void* buf, ulong bufSize);

    [MemberFunction("E8 ?? ?? ?? ?? 39 43 0C")]
    public partial uint GetDigest();
}