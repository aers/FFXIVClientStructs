using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonCharacterClass
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("CharacterClass")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[VirtualTable("48 8D 05 ?? ?? ?? ?? 48 89 03 48 8D 83 ?? ?? ?? ?? 48 89 90", 3)]
[StructLayout(LayoutKind.Explicit, Size = 0x830)]
public unsafe partial struct AddonCharacterClass {
    [FieldOffset(0x220), FixedSizeArray] internal FixedSizeArray31<Pointer<AtkComponentButton>> _buttonNodes;
    [FieldOffset(0x318)] public AtkComponentButton* TabsNode;
    [FieldOffset(0x320)] public AtkTextNode* CurrentXPTextNode;
    [FieldOffset(0x328)] public AtkTextNode* MaxXPTextNode;
    [FieldOffset(0x330)] public AtkTextNode* CurrentDesynthesisLevelTextNode;
    [FieldOffset(0x338)] public AtkTextNode* MaxDesynthesisLevelTextNode;
    [FieldOffset(0x340), FixedSizeArray] internal FixedSizeArray31<ClassEntry> _classEntries;

    [FieldOffset(0x828)] public int TabIndex;

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 8F ?? ?? ?? ?? 48 8B 01 FF 50 78 48 89 87")]
    public partial void SetTab(int tab);

    [StructLayout(LayoutKind.Explicit, Size = 0x28)]
    public struct ClassEntry {
        [FieldOffset(0x00)] public uint Level;
        [FieldOffset(0x04)] public uint CurrentXP;
        [FieldOffset(0x08)] public uint LevelMaxXP;
        [FieldOffset(0x10)] public nint DesynthesisLevel;
        [FieldOffset(0x18)] public nint TooltipText;
        [FieldOffset(0x20)] public bool IsMaxLevel;
    }
}
