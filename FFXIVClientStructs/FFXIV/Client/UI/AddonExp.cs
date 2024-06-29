using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonExp
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("_Exp")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x2A0)]
public partial struct AddonExp {
    [FieldOffset(0x280)] public byte ClassJob;

    [FieldOffset(0x288)] public uint CurrentExp;
    [FieldOffset(0x28C)] public uint RequiredExp;
    [FieldOffset(0x290)] public uint RestedExp;

    public float CurrentExpPercent => (float)CurrentExp / RequiredExp * 100;
}
