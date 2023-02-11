namespace FFXIVClientStructs.FFXIV.Client.UI;

[StructLayout(LayoutKind.Explicit, Size = 0x598)]
public unsafe struct AddonFieldMarker
{
    [FieldOffset(0x190)] public int Collapsed;
    [FieldOffset(0x230)] public int HoveredButtonIndex; // Index 0-8 of the currently moused over button (A-D, 1-4, Clear)
    
    [FixedSizeArray<AddonWaymarkInfo>(8)]
    [FieldOffset(0x238)] public fixed byte WaymarkInfo[0x18 * 8];
    
    [FieldOffset(0x57C)] public int HoveredPresetIndex; // Index 0-4 of the currently moused over slot, -1 if not hovering over a slot
    [FieldOffset(0x580)] public byte SelectedPage;

    public bool IsCollapsed => Collapsed != 0;
}

[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public unsafe struct AddonWaymarkInfo
{
    [FieldOffset(0x00)] public int IconId; // Map IconId
    [FieldOffset(0x04)] public int Active;
    [FieldOffset(0x08)] public byte* TooltipString; //null-terminated cstring
    [FieldOffset(0x10)] public int Slot; // Index 0-7 [A,B,C,D,1,2,3,4] 

    public bool IsActive => Active != 0;
}