using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonExp
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("_Exp")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x2A8)]
public partial struct AddonExp {
    [FieldOffset(0x288)] public byte ClassJob;

    [FieldOffset(0x290)] public uint CurrentExp;
    [FieldOffset(0x294)] public uint RequiredExp;
    [FieldOffset(0x298)] public uint RestedExp;

    public float CurrentExpPercent => (float)CurrentExp / RequiredExp * 100;
}
