namespace FFXIVClientStructs.FFXIV.Component.GUI;
// Component::GUI::AtkModuleInterface::AtkEventInterface

// size = 0x8
// no explicit constructor, just an event interface 
[StructLayout(LayoutKind.Explicit, Size = 0x8)]
public unsafe struct AtkEventInterface
{
    [FieldOffset(0x0)] public void** vtbl;
}