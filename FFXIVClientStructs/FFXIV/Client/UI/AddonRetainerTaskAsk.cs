using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonRetainerTaskAsk
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[StructLayout(LayoutKind.Explicit, Size = 0x2B8)]
public unsafe partial struct AddonRetainerTaskAsk
{
    [FieldOffset(0x0)] public AtkUnitBase AtkUnitBase;
    [FieldOffset(0x2A8)] public AtkComponentButton* AssignButton;
    [FieldOffset(0x2B0)] public AtkComponentButton* ReturnButton;

    [MemberFunction("40 53 48 83 EC 30 48 8B D9 83 FA 03 7C 53 49 8B C8 E8 ?? ?? ?? ??")]
    public partial void OnSetup(uint a2, byte* data);
}