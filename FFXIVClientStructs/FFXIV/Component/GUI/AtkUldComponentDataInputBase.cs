using FFXIVClientStructs.FFXIV.Client.Graphics;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

[GenerateInterop(isInherited: true), Inherits<AtkUldComponentDataBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public partial struct AtkUldComponentDataInputBase {
    [FieldOffset(0x0C)] public ByteColor FocusColor;
}
