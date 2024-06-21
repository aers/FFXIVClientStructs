namespace FFXIVClientStructs.FFXIV.Component.GUI;

[CExporterStructUnion]
[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public struct AtkEventData {
    [FieldOffset(0x00)] public AtkListItemData AtkListItemData;
}

[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public unsafe struct AtkListItemData {
    [FieldOffset(0x00)] public AtkComponentListItemRenderer* ListItemRenderer;
    [FieldOffset(0x10)] public int SelectedIndex;
    // [FieldOffset(0x16)] public ushort HoveredItemIndex3;
}
