using FFXIVClientStructs.FFXIV.Client.System.Memory;

namespace FFXIVClientStructs.FFXIV.Component.GUI;
// note: Name made up
// This is the "hold to proceed" button type

// Component::GUI::AtkComponentHoldButton
//   Component::GUI::AtkComponentButton
//     Component::GUI::AtkComponentBase
//       Component::GUI::AtkEventListener
// common CreateAtkComponent function "E8 ?? ?? ?? ?? 48 8B F8 48 85 C0 0F 84 ?? ?? ?? ?? 49 8B 0F"
// type 24
[GenerateInterop]
[Inherits<AtkComponentButton>]
[StructLayout(LayoutKind.Explicit, Size = 0x120)]
public partial struct AtkComponentHoldButton : ICreatable {
    [MemberFunction("40 53 48 83 EC 20 48 8B D9 E8 ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? C7 83 ?? ?? ?? ?? ?? ?? ?? ?? 48 89 03 33 C0 48 89 83 ?? ?? ?? ?? 48 89 83 ?? ?? ?? ?? 66 89 83 ?? ?? ?? ?? 48 89 83 ?? ?? ?? ??")]
    public partial void Ctor();
}
