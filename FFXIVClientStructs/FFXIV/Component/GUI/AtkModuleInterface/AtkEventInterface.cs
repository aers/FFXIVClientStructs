namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkModuleInterface::AtkEventInterface
// no explicit constructor, just an event interface 
[StructLayout(LayoutKind.Explicit, Size = 0x8)]
public unsafe partial struct AtkEventInterface {
    [FieldOffset(0x0)] public void** vtbl;

    [VirtualFunction(0)]
    public partial AtkValue* ReceiveEvent(AtkValue* returnValue, AtkValue* values, uint valueCount, ulong eventKind);
}
