namespace FFXIVClientStructs.FFXIV.Client.Game;

[StructLayout(LayoutKind.Explicit, Size = 0xC)]
public struct Status
{
    [FieldOffset(0x0)] public ushort StatusID;
    // this contains different information depending on the type of status
    // debuffs - stack count
    // food/potions - ID of the food/potion in the ItemFood sheet
    [FieldOffset(0x2)] public ushort Param;
    // remains for compatibility
    [FieldOffset(0x2)] public byte StackCount;
    [FieldOffset(0x4)] public float RemainingTime;
    // objectID matching the entity that cast the effect - regens will be from the white mage ID etc
    [FieldOffset(0x8)] public uint SourceID;
}