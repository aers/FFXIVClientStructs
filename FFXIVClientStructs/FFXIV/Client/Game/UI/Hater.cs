namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

[StructLayout(LayoutKind.Explicit, Size = 0x908)]
public unsafe partial struct Hater
{
    [FixedSizeArray<HaterInfo>(32)]
    [FieldOffset(0x00)] public fixed byte HaterArray[0x48 * 32];
    [FieldOffset(0x900)] public int HaterArrayLength;
}

[StructLayout(LayoutKind.Explicit, Size = 0x48)]
public unsafe struct HaterInfo
{
    [FieldOffset(0x00)] public fixed byte Name[64];
    [FieldOffset(0x40)] public uint ObjectId;
    [FieldOffset(0x44)] public int Enmity;
}