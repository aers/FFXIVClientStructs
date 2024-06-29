using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonGSInfoChocoboParam
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("GSInfoChocoboParam")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x258)]
public unsafe partial struct AddonGSInfoChocoboParam {
    [FieldOffset(0x248)] public AtkComponentBase* RaceAbility1;
    [FieldOffset(0x250)] public AtkComponentBase* RaceAbility2;
}
