namespace FFXIVClientStructs.FFXIV.Component.GUI;

[CExporterStructUnion]
[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public struct AtkEventData {
    [FieldOffset(0x00)] public ListItemToggleData ListItemToggleData;
}

[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public struct ListItemToggleData {
    [FieldOffset(0x10)] public int SelectedIndex;
}
