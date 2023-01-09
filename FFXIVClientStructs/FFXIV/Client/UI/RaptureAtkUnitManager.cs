using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;
// Client::UI::RaptureAtkUnitManager
//   Component::GUI::AtkUnitManager
//     Component::GUI::AtkEventListener

// size = 0x9D2C
// ctor 40 53 48 83 EC 20 48 8B D9 E8 ?? ?? ?? ?? C6 83 ?? ?? ?? ?? ?? 48 8D 8B ?? ?? ?? ?

[StructLayout(LayoutKind.Explicit, Size = 0x9D10)]
public unsafe partial struct RaptureAtkUnitManager
{
    [FieldOffset(0x0)] public AtkUnitManager AtkUnitManager;

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B F8 41 B0 01")]
    [GenerateCStrOverloads]
    public partial AtkUnitBase* GetAddonByName(byte* name, int index = 1);

    [MemberFunction("E8 ?? ?? ?? ?? 8B 6B 20")]
    public partial AtkUnitBase* GetAddonById(ushort id);
}