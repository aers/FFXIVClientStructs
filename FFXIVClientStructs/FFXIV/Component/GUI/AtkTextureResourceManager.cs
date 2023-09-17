using FFXIVClientStructs.FFXIV.Component.Exd;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

[StructLayout(LayoutKind.Explicit, Size = 0x58)]
public unsafe partial struct AtkTextureResourceManager {
    [FieldOffset(0x00)] public StdLinkedList<Pointer<AtkTextureResource>> LoadedTextures;
    [FieldOffset(0x18)] public int DefaultTextureVersion;
    [FieldOffset(0x20)] public ExdModule* ExdModule;
    [FieldOffset(0x28)] public int IconLanguageSheetId;
    [FieldOffset(0x2C)] public int IconLanguage;
    // Icon ranges are inclusive: id ∈ [a,b]
    [FixedSizeArray<StdPair<uint, uint>>(4)]
    [FieldOffset(0x30)] public unsafe fixed byte LocalizedIconRange[4 * 8]; // 4 * StdPair<uint, uint>
    [FieldOffset(0x50)] public uint LocalizedIconRangeCount;
}
