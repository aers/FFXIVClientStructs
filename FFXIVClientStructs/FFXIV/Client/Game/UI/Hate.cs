namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

[StructLayout(LayoutKind.Explicit, Size = 0x108)]
[GenerateInterop]
public unsafe partial struct Hate {
    [FieldOffset(0x00), FixedSizeArray] internal FixedSizeArray32<HateInfo> _hateInfo;
    [FieldOffset(0x100)] public int HateArrayLength;
    [FieldOffset(0x104)] public uint HateTargetId;
}

[StructLayout(LayoutKind.Explicit, Size = 0x08)]
public struct HateInfo {
    [FieldOffset(0x00)] public uint ObjectId;
    [FieldOffset(0x04)] public int Enmity;
}
