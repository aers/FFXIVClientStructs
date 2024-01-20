namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkComponentTreeList
//   Component::GUI::AtkComponentList
//     Component::GUI::AtkComponentBase
//       Component::GUI::AtkEventListener
// common CreateAtkComponent function "E8 ?? ?? ?? ?? 48 8B F8 48 85 C0 0F 84 ?? ?? ?? ?? 49 8B 0F"
// type 12
[StructLayout(LayoutKind.Explicit, Size = 0x228)]
public unsafe partial struct AtkComponentTreeList {
    [FieldOffset(0x0)] public AtkComponentList AtkComponentList;

    [FieldOffset(0x1A8)] public StdVector<Pointer<AtkComponentTreeListItem>> Items;

    [FieldOffset(0x21C)] public bool LayoutRefreshPending;

    [VirtualFunction(31)]
    public partial void SelectItem(uint index, bool dispatchEvent);

    [VirtualFunction(32)]
    public partial void DeselectItem();

    /// <remarks> Does not add it to the <see cref="Items"/> list automatically! </remarks>
    [MemberFunction("E8 ?? ?? ?? ?? 48 8B D8 45 85 ED")]
    public partial AtkComponentTreeListItem* CreateItem();

    [MemberFunction("E8 ?? ?? ?? ?? 44 38 60 45")]
    public partial AtkComponentTreeListItem* GetItem(uint index);

    [MemberFunction("E8 ?? ?? ?? ?? 44 39 BD")]
    public partial void LoadAtkValues(
        uint atkValuesCount,
        AtkValue* atkValues,
        uint uintValuesOffset,
        uint stringValuesOffset,
        uint uintValuesCountPerItem,
        uint stringValuesCountPerItem,
        uint itemCount,
        nint a9);

    /// <remarks>
    /// Expands the given group and collapses all other groups.<br/>
    /// After calling this, you might also want to set <see cref="LayoutRefreshPending"/> to <c>true</c>.
    /// </remarks>
    [MemberFunction("E8 ?? ?? ?? ?? 44 88 AB ?? ?? ?? ?? 80 4F 42 10")]
    public partial void ExpandGroupExclusively(AtkComponentTreeListItem* groupHeaderItem, bool a3 = false);
}

[StructLayout(LayoutKind.Explicit, Size = 0x48)]
public unsafe struct AtkComponentTreeListItem {
    [FieldOffset(0)] public StdVector<uint> UIntValues; // first entry should be AtkComponentTreeListItemType
    [FieldOffset(0x18)] public StdVector<Pointer<byte>> StringValues; // first entry should be the displayed text
    [FieldOffset(0x30)] public AtkComponentListItemRenderer* Renderer;

    // [FieldOffset(0x42)] public byte Flags; // for groups: 1 = expanded
    // [FieldOffset(0x43)] public byte Flags2;
}

public enum AtkComponentTreeListItemType : uint {
    Leaf = 0,
    LastLeafInGroup = 1,
    CollapsibleGroupHeader = 2, // seen in AddonMJICraftScheduleSetting
    GroupHeader = 4, // always expanded, seen in AddonTelepotTown
}
