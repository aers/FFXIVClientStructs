namespace FFXIVClientStructs.FFXIV.Common.Component.Environment;

[GenerateInterop(true)]
[StructLayout(LayoutKind.Explicit, Size = 0x8)]
public unsafe partial struct ResourceInterface {
    [VirtualFunction(0)]
    public partial ResourceInterface* Dtor(byte freeFlags);

    // [VirtualFunction(1)]
    // public partial LoadFile;

    // [VirtualFunction(2)]
    // public partial UnloadFile;
}