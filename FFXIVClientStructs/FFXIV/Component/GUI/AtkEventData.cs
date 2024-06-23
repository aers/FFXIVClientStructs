namespace FFXIVClientStructs.FFXIV.Component.GUI;

[CExporterStructUnion]
[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public partial struct AtkEventData {
    [FieldOffset(0x00)] public AtkListItemData ListItemData;
}

public partial struct AtkEventData {
    [StructLayout(LayoutKind.Explicit, Size = 0x28)]
    public unsafe struct AtkListItemData {
        [FieldOffset(0x00)] public AtkComponentListItemRenderer* ListItemRenderer;
        [FieldOffset(0x10)] public int SelectedIndex;
        // [FieldOffset(0x16)] public ushort HoveredItemIndex3;
    }
}
