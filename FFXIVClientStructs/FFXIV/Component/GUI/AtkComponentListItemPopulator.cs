namespace FFXIVClientStructs.FFXIV.Component.GUI;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public unsafe partial struct AtkComponentListItemPopulator {
    public delegate void PopulateWithRendererDelegate(AtkUnitBase* unitBase, int listItemIndex, AtkResNode** nodeList, AtkComponentListItemRenderer* listItemRenderer);
    public delegate void PopulateDelegate(AtkUnitBase* unitBase, ListItemInfo* listItemInfo, AtkResNode** nodeList);

    [FieldOffset(0x00)] public AtkUnitBase* UnitBase;
    [FieldOffset(0x08)] public delegate* unmanaged<AtkUnitBase*, int, AtkResNode**, AtkComponentListItemRenderer*, void> PopulateWithRenderer;
    [FieldOffset(0x10)] public delegate* unmanaged<AtkUnitBase*, ListItemInfo*, AtkResNode**, void> Populate;

    [MemberFunction("E8 ?? ?? ?? ?? 41 B1 08")]
    public partial AtkComponentListItemPopulator* CtorWithRenderer(AtkUnitBase* unitBase, delegate* unmanaged<AtkUnitBase*, int, AtkResNode**, AtkComponentListItemRenderer*, void> populateWithRenderer);

    [MemberFunction("E8 ?? ?? ?? ?? 49 8B 8F ?? ?? ?? ?? 4C 8D 45 90")]
    public partial AtkComponentListItemPopulator* Ctor(AtkUnitBase* unitBase, delegate* unmanaged<AtkUnitBase*, ListItemInfo*, AtkResNode**, void> populate);

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public struct ListItemInfo {
        [FieldOffset(0)] public int ListItemIndex;
        [FieldOffset(0x8)] public AtkComponentTreeListItem* ListItem;
    }
}
