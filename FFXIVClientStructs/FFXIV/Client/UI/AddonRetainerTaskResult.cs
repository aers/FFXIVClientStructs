using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonRetainerTaskResult
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[StructLayout(LayoutKind.Explicit, Size = 0x258)]
public unsafe partial struct AddonRetainerTaskResult
{
    [FieldOffset(0x0)] public AtkUnitBase AtkUnitBase;
    [FieldOffset(0x240)] public AtkComponentButton* ReassignButton;
    [FieldOffset(0x248)] public AtkComponentButton* ConfirmButton;

    [MemberFunction("48 89 5C 24 ?? 55 56 57 48 83 EC 40 8B F2 49 8B F8 BA ?? ?? ?? ?? 48 8B D9 E8 ?? ?? ?? ??")]
    public partial void OnSetup(uint a2, byte* data);
}