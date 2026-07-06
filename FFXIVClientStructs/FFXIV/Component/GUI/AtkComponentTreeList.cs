using FFXIVClientStructs.FFXIV.Client.System.Memory;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkComponentTreeList
//   Component::GUI::AtkComponentList
//     Component::GUI::AtkComponentBase
//       Component::GUI::AtkEventListener
// common CreateAtkComponent function "E8 ?? ?? ?? ?? 4C 8B F0 48 85 C0 0F 84 ?? ?? ?? ?? 49 8B 4D 08"
// type 12
[GenerateInterop]
[Inherits<AtkComponentList>]
[VirtualTable("48 8D 05 ?? ?? ?? ?? ?? ?? ?? 0F 57 C0 48 89 8B ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 89 83 ?? ?? ?? ?? 33 C0 48 89 8B ?? ?? ?? ?? 48 89 8B ?? ?? ?? ?? 48 89 8B ?? ?? ?? ?? 48 89 8B ?? ?? ?? ?? 48 89 8B ?? ?? ?? ?? 89 8B", 3, 47)]
[StructLayout(LayoutKind.Explicit, Size = 0x230)]
public unsafe partial struct AtkComponentTreeList : ICreatable<AtkComponentTreeList> {
    [FieldOffset(0x1B0)] public StdVector<Pointer<AtkComponentTreeListItem>> Items;

    [FieldOffset(0x1E4)] public uint VisibleItemHeight;
    [FieldOffset(0x1E8)] public uint MaxScrollPosition;
    [FieldOffset(0x1EC)] public uint ItemCount;
    [FieldOffset(0x1F0)] public uint VisibleItemCount;

    [FieldOffset(0x224)] public bool LayoutRefreshPending;

    [MemberFunction("40 53 48 83 EC 20 48 8B D9 E8 ?? ?? ?? ?? 33 C9 C7 83 ?? ?? ?? ?? ?? ?? ?? ?? 48 89 8B ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 89 03 0F 57 C0")]
    public partial AtkComponentTreeList* Ctor();

    /// <remarks> Does not add it to the <see cref="Items"/> list automatically! </remarks>
    [MemberFunction("40 53 48 83 EC ?? 48 8B D9 E8 ?? ?? ?? ?? 33 D2 45 33 C9")]
    public partial AtkComponentTreeListItem* CreateItem();

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 08 F6 01")]
    public partial AtkComponentTreeListItem* GetItem(int index);

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 25 85 ED")]
    public partial bool IsItemSectionHeader(int index);

    [MemberFunction("E8 ?? ?? ?? ?? 44 3B FF 75")]
    public partial void LoadAtkValues(
        int atkValuesCount,
        AtkValue* atkValues,
        int uintValuesOffset,
        int stringValuesOffset,
        int uintValuesCountPerItem,
        int stringValuesCountPerItem,
        int itemCount,
        ListComponentCallBackInterface* callBackInterface = null);

    /// <remarks>
    /// Expands the given group and collapses all other groups.<br/>
    /// After calling this, you might also want to set <see cref="LayoutRefreshPending"/> to <c>true</c>.
    /// </remarks>
    [MemberFunction("E8 ?? ?? ?? ?? 44 88 A3 ?? ?? ?? ?? 80 4F")]
    public partial void ExpandGroupExclusively(AtkComponentTreeListItem* groupItem, bool suppressUpdate = false);

    [MemberFunction("E8 ?? ?? ?? ?? 48 3B D8 74 ?? 48 8B 8F")]
    public partial AtkComponentTreeListItem* FindItemGroup(AtkComponentTreeListItem* item);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 87 ?? ?? ?? ?? 48 8B 74 24 ?? 48 8B 5C 24 ?? 48 85 C0 74")]
    public partial void CalculateVisibleItemHeightAndCount(uint* outItemHeight, uint* outItemCount);
}

[StructLayout(LayoutKind.Explicit, Size = 0x48)]
public unsafe struct AtkComponentTreeListItem {
    [FieldOffset(0)] public StdVector<uint> UIntValues; // first entry should be AtkComponentTreeListItemType
    [FieldOffset(0x18)] public StdVector<CStringPointer> StringValues; // first entry should be the displayed text
    [FieldOffset(0x30)] public AtkComponentListItemRenderer* Renderer;
    [FieldOffset(0x38)] private void* Unk38;
    [FieldOffset(0x40)] public ushort Height;
    [FieldOffset(0x42)] public TreeListItemState State;
    [FieldOffset(0x43)] public TreeListItemType Type;
    [FieldOffset(0x44)] public byte Depth;
    [FieldOffset(0x45)] public bool IsHidden;
}

[Flags]
public enum TreeListItemState : byte {
    None = 0,
    Expanded = 1 << 0,
    Unk2 = 1 << 1,
    Unk4 = 1 << 2,
    Unk8 = 1 << 3,
    Expanding = 1 << 4,
    Disabled = 1 << 5,
}

[Flags]
public enum TreeListItemType : byte {
    None = 0,
    LastItemInGroup = 1 << 0,
    Group = 1 << 1,
    SectionHeader = 1 << 2,
}

[Obsolete("Use TreeListItemType (exposed via AtkComponentTreeListItem.Type)")]
public enum AtkComponentTreeListItemType : uint {
    Leaf = 0,
    LastLeafInGroup = 1,
    CollapsibleGroupHeader = 2, // seen in AddonMJICraftScheduleSetting
    GroupHeader = 4, // always expanded, seen in AddonTelepotTown
}
