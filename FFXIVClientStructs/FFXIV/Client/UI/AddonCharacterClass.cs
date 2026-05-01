using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonCharacterClass
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("CharacterClass")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[VirtualTable("48 8D 05 ?? ?? ?? ?? 0F 57 C0 ?? ?? ?? 48 8B CF", 3)]
[StructLayout(LayoutKind.Explicit, Size = 0x8D8)]
public unsafe partial struct AddonCharacterClass {
    [FieldOffset(0x238), FixedSizeArray] internal FixedSizeArray34<Pointer<AtkComponentBase>> _classComponents;
    [FieldOffset(0x348)] public AtkComponentButton* TabsNode;
    [FieldOffset(0x350)] public AtkTextNode* CurrentXPTextNode;
    [FieldOffset(0x358)] public AtkTextNode* MaxXPTextNode;
    [FieldOffset(0x360)] public AtkTextNode* CurrentDesynthesisLevelTextNode;
    [FieldOffset(0x368)] public AtkTextNode* MaxDesynthesisLevelTextNode;
    [FieldOffset(0x370), FixedSizeArray] internal FixedSizeArray34<ClassEntry> _classEntries;

    [FieldOffset(0x8D0)] public int TabIndex;

    [MemberFunction("48 89 6C 24 ?? 48 89 74 24 ?? 57 48 83 EC 20 48 8B 81 ?? ?? ?? ?? 8B F2")]
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
