namespace FFXIVClientStructs.FFXIV.Client.Game;

// ctor "48 89 5C 24 ?? 57 48 83 EC 20 48 8B D9 C6 01 00 48 83 C1 04"
// note: data is cleared when switching zones
[StructLayout(LayoutKind.Explicit, Size = 0x1478)]
public unsafe partial struct MirageManager {
    [StaticAddress("48 8B 1D ?? ?? ?? ?? 48 85 DB 74 48", 3, isPointer: true)]
    public static partial MirageManager* Instance();

    [FieldOffset(0)] public bool IsApplyingGlamourPlate;

    [FieldOffset(0x4)] public fixed uint PrismBoxItemIds[800];
    [FieldOffset(0xC84)] public fixed byte PrismBoxStainIds[800];
    [FieldOffset(0xFA4)] public bool PrismBoxRequested;
    [FieldOffset(0xFA5)] public bool PrismBoxLoaded;

    [FixedSizeArray<GlamourPlate>(20)]
    [FieldOffset(0xFA8)] public fixed byte GlamourPlates[0x3C * 20];
    [FieldOffset(0x1458)] public bool GlamourPlatesRequested;
    [FieldOffset(0x1459)] public bool GlamourPlatesLoaded;

    [StructLayout(LayoutKind.Explicit, Size = 0x3C)]
    public struct GlamourPlate {
        [FieldOffset(0x00)] public fixed uint ItemIds[12];
        [FieldOffset(0x30)] public fixed byte StainIds[12];
    }
}
