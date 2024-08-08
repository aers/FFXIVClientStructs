using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[Addon("AreaMap")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x7D8)]
public unsafe partial struct AddonAreaMap {
    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 6 * 4)]
    public unsafe partial struct AddonAreaMapNumberArray {
        public static AddonAreaMapNumberArray* Instance() => (AddonAreaMapNumberArray*)AtkStage.Instance()->GetNumberArrayData(NumberArrayType.AreaMap)->IntArray;

        [FieldOffset(0x0)] public int X;
        [FieldOffset(0x4)] public int Y;
        [FieldOffset(0x8)] public int PlayerRotation; // 0 is South, -90 is West, -180/+180 is North, 90 is East
        [FieldOffset(0xC)] public int ConeRotation; // 0 is North, -90 is East, -180/+180 is South, 90 is West
        // [FieldOffset(0x10)] public int UnkInt; // Always a zero it seems
        // [FieldOffset(0x14)] public int UnkInt; // Always a zero it seems
    }
}
