using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonRetainerTaskList
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[StructLayout(LayoutKind.Explicit, Size = 0x8)]
[VTableAddress("48 8d 05 ?? ?? ?? ?? 48 89 03 33 c0 80 8b 88 01 00 00 20 48 89 83 20 02 00 00 48 89 83 28 02 00 00 88", 3)]
public unsafe partial struct AddonRetainerTaskList
{
    [FieldOffset(0x0)] public AtkUnitBase AtkUnitBase;

    //[MemberFunction("48 89 5C 24 ?? 55 56 57 48 81 EC 10 01 00 00 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 84 ?? ?? ?? ?? ?? 8B DA 49 8B F0 BA 03 00 00 00 48 8B F9 E8 ?? ?? ?? ??")]
    [VirtualFunction(47)]
    public partial void OnSetup(uint a2, AtkValue* atkValues);
}
