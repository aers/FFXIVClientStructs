using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonRetainerTaskList
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[StructLayout(LayoutKind.Explicit, Size = 0x8)]
public unsafe partial struct AddonRetainerTaskList
{
    [FieldOffset(0x0)] public AtkUnitBase AtkUnitBase;

    [MemberFunction("48 89 5C 24 ?? 55 56 57 48 81 EC 10 01 00 00 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 84 ?? ?? ?? ?? ?? 8B DA 49 8B F0 BA 03 00 00 00 48 8B F9 E8 ?? ?? ?? ??")]
    public partial void OnSetup(uint a2, byte* data);
}
