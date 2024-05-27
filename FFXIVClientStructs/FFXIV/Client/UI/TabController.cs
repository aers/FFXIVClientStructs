using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[StructLayout(LayoutKind.Explicit, Size = 0xB0)]
public unsafe struct TabController {
    [FieldOffset(0x08)] public AtkStage* AtkStage;

    [FieldOffset(0x80)] public int TabIndex;
    [FieldOffset(0x84)] public int TabCount;

    [FieldOffset(0x90)] public delegate* unmanaged<int, AtkUnitBase*, void> CallbackFunction; // (int tabIndex, AtkUnitBase* addon)
    [FieldOffset(0x98)] public AtkUnitBase* Addon;

    [FieldOffset(0xA8)] public bool Enabled;
}
