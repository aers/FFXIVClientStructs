using FFXIVClientStructs.FFXIV.Client.System.Input;
using static FFXIVClientStructs.FFXIV.Component.GUI.AtkUnitManager;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkModuleInterface
[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x08)]
public unsafe partial struct AtkModuleInterface {
    [VirtualFunction(0)]
    public partial void Dtor(bool free);

    [VirtualFunction(9)]
    public partial NumberArrayData* GetNumberArrayData(int index);

    [VirtualFunction(10)]
    public partial StringArrayData* GetStringArrayData(int index);

    [VirtualFunction(11)]
    public partial ExtendArrayData* GetExtendArrayData(int index);

    [VirtualFunction(12)]
    public partial void ClearNumberArrayData(int index);

    [VirtualFunction(13)]
    public partial void ClearStringArrayData(int index);

    [VirtualFunction(14)]
    public partial void ClearExtendArrayData(int index);

    [VirtualFunction(15)]
    public partial void ResetNumberArrayDataSubscribers(int index);

    [VirtualFunction(16)]
    public partial void ResetStringArrayDataSubscribers(int index);

    [VirtualFunction(21)]
    public partial bool CloseAddon(uint addonId);

    [VirtualFunction(23)]
    public partial bool RefreshAddon(uint addonId, uint valueCount, AtkValue* values);

    [VirtualFunction(25)]
    public partial bool SetAddonVisibility(uint addonId, bool visible);

    [VirtualFunction(26)]
    public partial bool IsAddonReady(uint addonId);

    [VirtualFunction(27)]
    public partial bool FocusAddon(uint addonId, bool focusContextMenu = false);

    [VirtualFunction(28)]
    public partial void ClearFocus();

    [VirtualFunction(33)]
    public partial bool IsCursorVisible();

    [VirtualFunction(40)]
    public partial SoftKeyboardDeviceInterface* GetSoftKeyboardDeviceInterface();

    [VirtualFunction(44)]
    public partial AddonStatus GetAddonStatus(uint addonId);

    // Component::GUI::AtkModuleInterface::AtkEventInterface
    // no explicit constructor, just an event interface 
    [GenerateInterop(isInherited: true)]
    [StructLayout(LayoutKind.Explicit, Size = 0x8)]
    public unsafe partial struct AtkEventInterface {
        [VirtualFunction(0)]
        public partial AtkValue* ReceiveEvent(AtkValue* returnValue, AtkValue* values, uint valueCount, ulong eventKind);

        [VirtualFunction(1)]
        public partial AtkValue* ReceiveEvent2(AtkValue* returnValue, AtkValue* values, uint valueCount, ulong eventKind); // seems to handle user input validation? but.. not always 🤔
    }
}
