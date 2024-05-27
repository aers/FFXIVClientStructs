namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkCrestManager
[StructLayout(LayoutKind.Explicit, Size = 0x48)]
public unsafe struct AtkCrestManager {
    [FieldOffset(0x08)] private void* AtkCrestFactory;
    [FieldOffset(0x10)] private void* AtkCrestColorPallete;
    [FieldOffset(0x18)] private void* AtkCrestBasePallete;

    [FieldOffset(0x40)] public byte TextureVersion;
}
