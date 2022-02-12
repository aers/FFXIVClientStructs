using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonRelicNoteBook
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[StructLayout(LayoutKind.Explicit, Size = 0xAA8)]
public unsafe struct AddonRelicNoteBook
{
    [FieldOffset(0x0)] public AtkUnitBase AtkUnitBase;
    [FieldOffset(0x220)] public AtkImageNode* CornerImage;
    [FieldOffset(0x228)] public AtkComponentBase* WeaponImageContainer;
    [FieldOffset(0x230)] public AtkImageNode* WeaponImage;
    [FieldOffset(0x238)] public AtkTextNode* WeaponText; // "Gae Bolg Atma"
    [FieldOffset(0x240)] public AtkTextNode* RewardText; // "Reward"
    [FieldOffset(0x248)] public AtkTextNode* RewardTextAmount; // "Strength +2"
    [FieldOffset(0x250)] public AtkComponentList* CategoryList;

    [StructLayout(LayoutKind.Explicit, Size = 0x28)]
    public struct TargetNode
    {
        [FieldOffset(0x0)] public AtkComponentCheckBox* CheckBox;
        [FieldOffset(0x8)] public AtkResNode* ResNode;
        [FieldOffset(0x10)] public AtkImageNode* ImageNode;
        [FieldOffset(0x18)] public AtkTextNode* CounterTextNode; // Only for enemies, null otherwise
    }

    [FieldOffset(0x258)] public AtkResNode* EnemyContainer;
    [FieldOffset(0x260)] public TargetNode Enemy0;
    [FieldOffset(0x288)] public TargetNode Enemy1;
    [FieldOffset(0x2B0)] public TargetNode Enemy2;
    [FieldOffset(0x2D8)] public TargetNode Enemy3;
    [FieldOffset(0x300)] public TargetNode Enemy4;
    [FieldOffset(0x328)] public TargetNode Enemy5;
    [FieldOffset(0x350)] public TargetNode Enemy6;
    [FieldOffset(0x378)] public TargetNode Enemy7;
    [FieldOffset(0x3A0)] public TargetNode Enemy8;
    [FieldOffset(0x3C8)] public TargetNode Enemy9;

    [FieldOffset(0x3F0)] public AtkResNode* DungeonContainer;
    [FieldOffset(0x3F8)] public TargetNode Dungeon0;
    [FieldOffset(0x420)] public TargetNode Dungeon1;
    [FieldOffset(0x448)] public TargetNode Dungeon2;

    [FieldOffset(0x588)] public AtkResNode* FateContainer;
    [FieldOffset(0x590)] public TargetNode Fate0;
    [FieldOffset(0x5B8)] public TargetNode Fate1;
    [FieldOffset(0x5E0)] public TargetNode Fate2;

    [FieldOffset(0x720)] public AtkResNode* LeveContainer;
    [FieldOffset(0x728)] public TargetNode Leve0;
    [FieldOffset(0x750)] public TargetNode Leve1;
    [FieldOffset(0x778)] public TargetNode Leve2;

    [FieldOffset(0x8B8)] public AtkTextNode* TargetText; // "Defeat 3 Giant Loggers"
    [FieldOffset(0x8C0)] public AtkTextNode* TargetLocationText; // "The Coerthas Central Highlands - Boulder Downs"

    // Various string pointers past here
}