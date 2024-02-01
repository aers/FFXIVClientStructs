namespace FFXIVClientStructs.FFXIV.Client.Game;

[StructLayout(LayoutKind.Explicit, Size = 0xA8)]
public unsafe partial struct ReconstructionBoxManager {
    [StaticAddress("48 8B 15 ?? ?? ?? ?? 48 8B C8 48 8B 5C 24", 3, isPointer: true)]
    public static partial ReconstructionBoxManager* Instance();

    [FieldOffset(0x8)] public bool Loaded;

    [FieldOffset(0xA0)] public ushort Donated;
    [FieldOffset(0xA2)] public ushort Progress;

    /// <remarks> Add 100 to get the correct value. </remarks>
    [FieldOffset(0xA4)] public byte Factor;

    [FieldOffset(0xA6)] public ushort Allowance;
}
