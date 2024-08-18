using FFXIVClientStructs.FFXIV.Client.System.Memory;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkComponentJournalCanvas
//   Component::GUI::AtkComponentBase
//     Component::GUI::AtkEventListener
// common CreateAtkComponent function "E8 ?? ?? ?? ?? 48 8B F8 48 85 C0 0F 84 ?? ?? ?? ?? 49 8B 0F"
// type 20
[GenerateInterop]
[Inherits<AtkComponentBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x520)]
public partial struct AtkComponentJournalCanvas : ICreatable {
    [MemberFunction("40 53 48 83 EC 20 48 8B D9 48 8D 05 ?? ?? ?? ?? 33 C9 33 D2 41 B8 ?? ?? ?? ?? 48 89 4B 08")]
    public partial void Ctor();
}
