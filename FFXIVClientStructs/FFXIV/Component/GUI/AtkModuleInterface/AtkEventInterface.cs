namespace FFXIVClientStructs.FFXIV.Component.GUI.AtkModuleInterface;

// Component::GUI::AtkModuleInterface::AtkEventInterface
// no explicit constructor, just an event interface 
[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x8)]
public unsafe partial struct AtkEventInterface {
    [VirtualFunction(0)]
    public partial AtkValue* ReceiveEvent(AtkValue* returnValue, AtkValue* values, uint valueCount, ulong eventKind);
}
