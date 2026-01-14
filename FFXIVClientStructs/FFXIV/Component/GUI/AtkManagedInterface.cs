using FFXIVClientStructs.FFXIV.Common.Component;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkManagedInterface
[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x08)]
public unsafe partial struct AtkManagedInterface {
    [VirtualFunction(0)]
    public partial bool ManagedInvoke(int command, void* data, AtkResNode* node);

    [VirtualFunction(1)]
    public partial void ManagedHide();

    [VirtualFunction(2)]
    public partial AtkUnitBase* GetManagedUnitBase();
}
