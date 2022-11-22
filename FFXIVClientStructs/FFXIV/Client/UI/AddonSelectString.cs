using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonSelectString
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[StructLayout(LayoutKind.Explicit, Size = 0x2A0)]
public unsafe partial struct AddonSelectString
{
    [FieldOffset(0x0)] public AtkUnitBase AtkUnitBase;
    [FieldOffset(0x220)] public PopupMenuDerive PopupMenu;
    
    [MemberFunction("40 53 56 57 41 54 41 55 41 57 48 83 EC 48 4D 8B F8 44 8B E2 48 8B F1 E8 ?? ?? ?? ??")]
    public partial void OnSetup(uint a2, byte* data);

    [StructLayout(LayoutKind.Explicit, Size = 0x68)]
    public struct PopupMenuDerive
    {
        [FieldOffset(0x0)] public PopupMenu PopupMenu;
    }
}