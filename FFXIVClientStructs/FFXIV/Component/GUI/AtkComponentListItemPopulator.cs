namespace FFXIVClientStructs.FFXIV.Component.GUI;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public unsafe partial struct AtkComponentListItemPopulator {
    public delegate void PopulateWithRendererDelegate(AtkEventListener* eventListener, int listItemIndex, AtkResNode** nodeList, AtkComponentListItemRenderer* listItemRenderer);
    public delegate void PopulateDelegate(AtkEventListener* eventListener, ListItemInfo* listItemInfo, AtkResNode** nodeList);

    [FieldOffset(0x00)] public AtkEventListener* EventListener;
    [FieldOffset(0x08)] public delegate* unmanaged<AtkEventListener*, int, AtkResNode**, AtkComponentListItemRenderer*, void> PopulateWithRenderer;
    [FieldOffset(0x10)] public delegate* unmanaged<AtkEventListener*, ListItemInfo*, AtkResNode**, void> Populate;

    [MemberFunction("E8 ?? ?? ?? ?? 45 0F B6 CE 89 74 24")]
    public partial AtkComponentListItemPopulator* CtorWithRenderer(AtkEventListener* eventListener, delegate* unmanaged<AtkEventListener*, int, AtkResNode**, AtkComponentListItemRenderer*, void> populateWithRenderer);

    [MemberFunction("E8 ?? ?? ?? ?? 45 0F B6 CD")]
    public partial AtkComponentListItemPopulator* Ctor(AtkEventListener* eventListener, delegate* unmanaged<AtkEventListener*, ListItemInfo*, AtkResNode**, void> populate);

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public struct ListItemInfo {
        [FieldOffset(0x0)] public int ListItemIndex;
        [FieldOffset(0x8)] public AtkComponentTreeListItem* ListItem;
    }
}
