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
[StructLayout(LayoutKind.Explicit, Size = 0x230)]
public unsafe partial struct AtkComponentTreeList : ICreatable {
    [FieldOffset(0x1B0)] public StdVector<Pointer<AtkComponentTreeListItem>> Items;

    [FieldOffset(0x224)] public bool LayoutRefreshPending;

    [MemberFunction("40 53 48 83 EC 20 48 8B D9 E8 ?? ?? ?? ?? 33 C9 C7 83 ?? ?? ?? ?? ?? ?? ?? ?? 48 89 8B ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 89 03 0F 57 C0")]
    public partial void Ctor();

    /// <remarks> Does not add it to the <see cref="Items"/> list automatically! </remarks>
    [MemberFunction("E8 ?? ?? ?? ?? 48 8B F8 8B CD")]
    public partial AtkComponentTreeListItem* CreateItem();

    [MemberFunction("48 83 EC 28 3B 91 ?? ?? ?? ??")]
    public partial AtkComponentTreeListItem* GetItem(int index);

    [MemberFunction("E8 ?? ?? ?? ?? 85 FF 75 22")]
    public partial void LoadAtkValues(
        int atkValuesCount,
        AtkValue* atkValues,
        int uintValuesOffset,
        int stringValuesOffset,
        int uintValuesCountPerItem,
        int stringValuesCountPerItem,
        int itemCount,
        nint a9);

    /// <remarks>
    /// Expands the given group and collapses all other groups.<br/>
    /// After calling this, you might also want to set <see cref="LayoutRefreshPending"/> to <c>true</c>.
    /// </remarks>
    [MemberFunction("E8 ?? ?? ?? ?? 44 88 BB ?? ?? ?? ?? 80 4F 42 10")]
    public partial void ExpandGroupExclusively(AtkComponentTreeListItem* groupHeaderItem, bool a3 = false);
}

[StructLayout(LayoutKind.Explicit, Size = 0x48)]
public unsafe struct AtkComponentTreeListItem {
    [FieldOffset(0)] public StdVector<uint> UIntValues; // first entry should be AtkComponentTreeListItemType
    [FieldOffset(0x18)] public StdVector<CStringPointer> StringValues; // first entry should be the displayed text
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
