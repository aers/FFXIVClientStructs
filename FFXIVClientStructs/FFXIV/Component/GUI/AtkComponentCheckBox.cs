using FFXIVClientStructs.FFXIV.Client.System.Memory;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkComponentCheckBox
//   Component::GUI::AtkComponentButton
//     Component::GUI::AtkComponentBase
//       Component::GUI::AtkEventListener
// common CreateAtkComponent function "E8 ?? ?? ?? ?? 4C 8B F0 48 85 C0 0F 84 ?? ?? ?? ?? 49 8B 4D 08"
// type 3
[GenerateInterop]
[Inherits<AtkComponentButton>]
[StructLayout(LayoutKind.Explicit, Size = 0x110)]
[VirtualTable("E8 ?? ?? ?? ?? 4C 8B F0 48 85 C0 0F 84 ?? ?? ?? ?? 49 8B 4D 08", [1, 407])]
public unsafe partial struct AtkComponentCheckBox : ICreatable {
    public void Ctor() {
        AtkComponentButton.Ctor();
        VirtualTable = StaticVirtualTablePointer;
    }
}
