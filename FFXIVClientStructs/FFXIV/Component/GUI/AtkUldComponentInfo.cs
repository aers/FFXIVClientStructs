namespace FFXIVClientStructs.FFXIV.Component.GUI;

[GenerateInterop]
[Inherits<AtkUldObjectInfo>]
[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public partial struct AtkUldComponentInfo {
    [FieldOffset(0x10)] public ComponentType ComponentType;
}
