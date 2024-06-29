using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonRelicNoteBook
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("RelicNoteBook")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0xAB8)]
public unsafe partial struct AddonRelicNoteBook {
    [FieldOffset(0x230)] public AtkImageNode* CornerImage;
    [FieldOffset(0x238)] public AtkComponentBase* WeaponImageContainer;
    [FieldOffset(0x240)] public AtkImageNode* WeaponImage;
    [FieldOffset(0x248)] public AtkTextNode* WeaponText; // "Gae Bolg Atma"
    [FieldOffset(0x250)] public AtkTextNode* RewardText; // "Reward"
    [FieldOffset(0x258)] public AtkTextNode* RewardTextAmount; // "Strength +2"
    [FieldOffset(0x260)] public AtkComponentList* CategoryList;

    [FieldOffset(0x268)] public AtkResNode* EnemyContainer;
    [FieldOffset(0x270)] public TargetNode Enemy0;
    [FieldOffset(0x298)] public TargetNode Enemy1;
    [FieldOffset(0x2C0)] public TargetNode Enemy2;
    [FieldOffset(0x2E8)] public TargetNode Enemy3;
    [FieldOffset(0x310)] public TargetNode Enemy4;
    [FieldOffset(0x338)] public TargetNode Enemy5;
    [FieldOffset(0x360)] public TargetNode Enemy6;
    [FieldOffset(0x388)] public TargetNode Enemy7;
    [FieldOffset(0x3B0)] public TargetNode Enemy8;
    [FieldOffset(0x3D8)] public TargetNode Enemy9;

    [FieldOffset(0x400)] public AtkResNode* DungeonContainer;
    [FieldOffset(0x408)] public TargetNode Dungeon0;
    [FieldOffset(0x430)] public TargetNode Dungeon1;
    [FieldOffset(0x458)] public TargetNode Dungeon2;

    [FieldOffset(0x598)] public AtkResNode* FateContainer;
    [FieldOffset(0x5A0)] public TargetNode Fate0;
    [FieldOffset(0x5C8)] public TargetNode Fate1;
    [FieldOffset(0x5F0)] public TargetNode Fate2;

    [FieldOffset(0x730)] public AtkResNode* LeveContainer;
    [FieldOffset(0x738)] public TargetNode Leve0;
    [FieldOffset(0x760)] public TargetNode Leve1;
    [FieldOffset(0x788)] public TargetNode Leve2;

    [FieldOffset(0x8C8)] public AtkTextNode* TargetText; // "Defeat 3 Giant Loggers"
    [FieldOffset(0x8D0)] public AtkTextNode* TargetLocationText; // "The Coerthas Central Highlands - Boulder Downs"

    // Various string pointers past here

    [StructLayout(LayoutKind.Explicit, Size = 0x28)]
    public struct TargetNode {
        [FieldOffset(0x0)] public AtkComponentCheckBox* CheckBox;
        [FieldOffset(0x8)] public AtkResNode* ResNode;
        [FieldOffset(0x10)] public AtkImageNode* ImageNode;
        [FieldOffset(0x18)] public AtkTextNode* CounterTextNode; // Only for enemies, null otherwise
    }
}
