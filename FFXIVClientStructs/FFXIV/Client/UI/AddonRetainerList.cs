using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonRetainerTaskList
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[StructLayout(LayoutKind.Explicit, Size = 0x8)]
public unsafe partial struct AddonRetainerList
{
    [FieldOffset(0x0)] public AtkUnitBase AtkUnitBase;

    [MemberFunction("48 89 5C 24 ?? 55 56 57 41 56 41 57 48 81 EC 00 01 00 00 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 84 ?? ?? ?? 00 00 49 8B F8 48 8B F1 E8 ?? ?? ?? ??")]
    public partial void OnSetup(uint a2, byte* data);
}
