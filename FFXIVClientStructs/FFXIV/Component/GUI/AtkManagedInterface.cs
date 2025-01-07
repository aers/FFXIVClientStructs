using FFXIVClientStructs.FFXIV.Common.Component;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkManagedInterface
[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x08)]
public unsafe partial struct AtkManagedInterface {
    // [VirtualFunction(0)]
    // public partial void ManagedVf0(int command, nint a3, nint a4);

    [VirtualFunction(1)]
    public partial void ManagedHide();

    [VirtualFunction(2)]
    public partial AtkUnitBase* GetManagedUnitBase();
}
