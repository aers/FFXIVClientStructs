using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Arrays;

[CExportIgnore]
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 8 * 8)]
public unsafe partial struct BuddyStringArray {
    public static BuddyStringArray* Instance() => (BuddyStringArray*)AtkStage.Instance()->GetStringArrayData(StringArrayType.Buddy)->StringArray;

    [FieldOffset(0), FixedSizeArray, CExportIgnore] internal FixedSizeArray8<CStringPointer> _data;

    [FieldOffset(0 * 8)] public CStringPointer BuddyName;
    [FieldOffset(2 * 8)] public CStringPointer CurrentHP;
    [FieldOffset(3 * 8)] public CStringPointer MaxHP;
    [FieldOffset(4 * 8)] public CStringPointer RemaningSummonTime;
    [FieldOffset(5 * 8)] public CStringPointer MaxSummonTime;
    [FieldOffset(6 * 8)] public CStringPointer AvailableCombatPoints;
    [FieldOffset(7 * 8)] public CStringPointer Exp;
}
