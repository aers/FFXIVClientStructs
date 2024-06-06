using FFXIVClientStructs.FFXIV.Client.System.Input;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkModuleInterface
[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x08)]
public unsafe partial struct AtkModuleInterface {
    [VirtualFunction(9)]
    public partial NumberArrayData* GetNumberArrayData(int index);

    [VirtualFunction(10)]
    public partial StringArrayData* GetStringArrayData(int index);

    [VirtualFunction(11)]
    public partial ExtendArrayData* GetExtendArrayData(int index);

    [VirtualFunction(26)]
    public partial bool IsAddonReady(uint addonId);

    [VirtualFunction(40)]
    public partial SoftKeyboardDeviceInterface* GetSoftKeyboardDeviceInterface();

    // Component::GUI::AtkModuleInterface::AtkEventInterface
    // no explicit constructor, just an event interface 
    [GenerateInterop(isInherited: true)]
    [StructLayout(LayoutKind.Explicit, Size = 0x8)]
    public unsafe partial struct AtkEventInterface {
        [VirtualFunction(0)]
        public partial AtkValue* ReceiveEvent(AtkValue* returnValue, AtkValue* values, uint valueCount, ulong eventKind);
    }
}
