namespace FFXIVClientStructs.FFXIV.Component.GUI;
// Component::GUI::AtkEventListenerUnk1
// size = 0x60?

[StructLayout(LayoutKind.Explicit, Size = 0x60)]
public unsafe struct AtkEventListenerUnk1
{
    [FieldOffset(0x0)] public void* vtbl;
    [FieldOffset(0x0)] public void** vfunc;
    [FieldOffset(0x8)] public void* Unk;

    [FieldOffset(0x20)] public AtkUnitBase* AtkUnitBase;
    [FieldOffset(0x28)] public AtkStage* AtkStage;
}