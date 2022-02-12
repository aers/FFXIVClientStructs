namespace FFXIVClientStructs.FFXIV.Component.GUI;

[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public struct AtkUldAsset
{
    [FieldOffset(0x0)] public uint Id;
    [FieldOffset(0x8)] public AtkTexture AtkTexture;
}