using FFXIVClientStructs.FFXIV.Client.System.Memory;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkComponentMap
//   Component::GUI::AtkComponentBase
//     Component::GUI::AtkEventListener
// type 22
[GenerateInterop]
[Inherits<AtkComponentBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x420)]
public partial struct AtkComponentMap : ICreatable {
    [MemberFunction("48 89 5C 24 ?? 57 48 83 EC 20 33 FF C7 81 ?? ?? ?? ?? ?? ?? ?? ?? 48 8D 05")]
    public partial void Ctor();
}
