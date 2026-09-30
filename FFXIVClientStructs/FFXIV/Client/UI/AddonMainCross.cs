using FFXIVClientStructs.FFXIV.Common.Math;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonMainCross
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("_MainCross")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0xAE8)]
public unsafe partial struct AddonMainCross {
    [FieldOffset(0x248), FixedSizeArray] internal FixedSizeArray7<CategoryNodeContainer> _categoryNodes;
    [FieldOffset(0x2F0)] public ItemNodeContainer* CurrentItemNodes; // ItemMaxCount * ItemNodeStruct
    [FieldOffset(0x2F8), FixedSizeArray] internal FixedSizeArray7<int> _defaultCategoryItemIndexes;
    [FieldOffset(0x318), FixedSizeArray] internal FixedSizeArray7<CommandCategoryData> _categoryData;
    [FieldOffset(0x3F8), FixedSizeArray] internal FixedSizeArray4<ColumnNodeContainer> _columnNodes;
    [FieldOffset(0x458)] public Size ScreenSize;
    [FieldOffset(0x460)] public AtkComponentTextNineGrid* OperationGuideTextNineGrid;
    [FieldOffset(0x468)] private short Unk468;
    [FieldOffset(0x46A)] private short Unk46A;
    [FieldOffset(0x46C)] private short Unk46C;
    [FieldOffset(0x46E)] private short Unk46E;
    [FieldOffset(0x470), FixedSizeArray] internal FixedSizeArray7<Utf8String> _categoryLabelsWithPatchMark;
    [FieldOffset(0x748), FixedSizeArray] internal FixedSizeArray7<AtkSimpleTween> _categoryTweens;
    [FieldOffset(0x978)] public AtkSimpleTween* CurrentItemTweens; // dynamic array (new T[n]), length: ItemMaxCount
    [FieldOffset(0x980)] public AtkSimpleTween ColumnTween;
    [FieldOffset(0x9D0), FixedSizeArray] internal FixedSizeArray3<AtkSimpleTween> _crossfadeTweens;
    /// <summary> The largest amount of entries/commands in any category. </summary>
    [FieldOffset(0xAC0)] public int ItemMaxCount;
    [FieldOffset(0xAC4)] private int UnkAC4;
    [FieldOffset(0xAC8)] private int UnkAC8;
    [FieldOffset(0xACC)] public int SelectedCategory;
    [FieldOffset(0xAD0)] public int SelectedItem;
    [FieldOffset(0xAD4)] private int UnkAD4;
    [FieldOffset(0xAD8)] private float UnkAD8; // an additional scaling multiplier. when AtkUnitManagerFlags.Unk80 is set, this is 0.6
    [FieldOffset(0xADC)] private float UnkADC; // ScreenTextBaseScale * GlobalUIScale
    [FieldOffset(0xAE0)] private float UnkAE0; // height of Node#1 divided by screen height
    [FieldOffset(0xAE4)] private byte UnkAE4; // set to 1/true when Show is called

    [MemberFunction("E8 ?? ?? ?? ?? 33 DB 4D 8B CD")]
    public partial void RefreshCurrentItemNodes();

    [MemberFunction("E8 ?? ?? ?? ?? 33 D2 49 8B CC E8 ?? ?? ?? ?? 0F 28 74 24")]
    public partial void UpdateHelpText(bool a2);

    [MemberFunction("E8 ?? ?? ?? ?? 8B 7C 24 ?? FF C7 89 7C 24 ?? 48 83 EB")]
    public static partial void StdVectorCommandDataInsert(StdVector<CommandData>* vector, CommandData* pos, CommandData* newItem); // std::vector<CommandData>::insert

    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public struct CategoryNodeContainer {
        [FieldOffset(0x00)] public AtkComponentNode* Node;
        [FieldOffset(0x08)] public AtkComponentRadioButton* Component;
        [FieldOffset(0x10)] public AtkTextNode* TextNode;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public struct CommandCategoryData {
        [FieldOffset(0x00)] public StdVector<CommandData> Commands;
        [FieldOffset(0x18)] public int SortId;
        [FieldOffset(0x1C)] public bool IsUnseen;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0xE8)]
    public struct CommandData {
        [FieldOffset(0x00)] public int RowId;
        [FieldOffset(0x04)] public int SortId;
        [FieldOffset(0x08)] public int IconId;
        [FieldOffset(0x10)] public Utf8String Label;
        [FieldOffset(0x78)] public Utf8String LabelWithPatchMark;
        [FieldOffset(0xE0)] public bool IsEnabled;
        [FieldOffset(0xE1)] public bool IsUnseen;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public struct ColumnNodeContainer {
        [FieldOffset(0x08)] public AtkComponentNode* ComponentNode;
        [FieldOffset(0x10)] public ItemNodeContainer* ItemNodes; // ItemMaxCount * ItemNodeContainer
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public struct ItemNodeContainer {
        [FieldOffset(0x00)] public AtkComponentNode* Node;
        [FieldOffset(0x08)] public AtkComponentButton* Component;
        [FieldOffset(0x10)] public AtkTextNode* TextNode;
    }
}
