namespace FFXIVClientStructs.FFXIV.Client.Game;

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe partial struct ReconstructionBoxManager {
    [StaticAddress("48 8B 15 ?? ?? ?? ?? 48 8B C8 48 8B 5C 24", 3)]
    public static partial ReconstructionBoxManager* Instance();

    [FieldOffset(0x00)] public ReconstructionBoxData* ReconstructionBoxData;
    [FieldOffset(0x08)] public void* UnknownDataPointer;
}

[StructLayout(LayoutKind.Explicit, Size = 0xA8)]
public struct ReconstructionBoxData {
    [FieldOffset(0xA0)]
    public ushort Donated;

    [FieldOffset(0xA6)]
    public ushort Allowance;
}
