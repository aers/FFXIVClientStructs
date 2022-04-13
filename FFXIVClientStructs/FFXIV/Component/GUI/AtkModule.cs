namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkModule
//   Component::GUI::AtkModuleInterface
[StructLayout(LayoutKind.Explicit, Size = 0x8218)]
public unsafe struct AtkModule
{
    [FieldOffset(0x0)] public void* vtbl;
    [FieldOffset(0x1B48)] public AtkArrayDataHolder AtkArrayDataHolder;
}