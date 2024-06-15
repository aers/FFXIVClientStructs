namespace FFXIVClientStructs.FFXIV.Component.GUI;

[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe partial struct AtkUldObjectInfo {
    [FieldOffset(0x0)] public uint Id;
    [FieldOffset(0x4)] public int NodeCount;
    [FieldOffset(0x8)] public AtkResNode** NodeList;
}
