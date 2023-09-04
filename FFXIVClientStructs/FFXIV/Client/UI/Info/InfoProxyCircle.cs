using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

[InfoProxy(InfoProxyId.Circle)]
[StructLayout(LayoutKind.Explicit, Size = 0x6BB8)]
public unsafe partial struct InfoProxyCircle {
    [FieldOffset(0x0000)] public InfoProxyInterface InfoProxyInterface;

    [FieldOffset(0x0020)] public Utf8String UnkString0020;
    //0x10 bytes
    [FieldOffset(0x0098)] public Utf8String UnkString0098;
    //8 bytes
    [FieldOffset(0x0108)] public Utf8String UnkString0108;
    //8 bytes
    [FieldOffset(0x0178)] public Utf8String UnkString0178;
    [FieldOffset(0x01E0)] public Utf8String UnkString01E0;
    [FieldOffset(0x0248)] public Utf8String UnkString0248;
    [FieldOffset(0x02B0)] public Utf8String UnkString02B0;
    [FieldOffset(0x0318)] public Utf8String UnkString0318;
    //8 bytes
    [FieldOffset(0x0388)] public Utf8String UnkString0388;
    [FieldOffset(0x03F0)] public Utf8String UnkString03F0;
    //8 bytes
    [FieldOffset(0x0460)] public Utf8String UnkString0460;
    //0x10 bytes
    [FieldOffset(0x04D8)] public Utf8String UnkString04D8;
    //8 bytes
    [FieldOffset(0x0548)] public Utf8String UnkString0548;
    //8 bytes
    [FieldOffset(0x05B8)] public Utf8String UnkString05B8;
    [FieldOffset(0x0620)] public Utf8String UnkString0620;
    [FieldOffset(0x0688)] public Utf8String UnkString0688;
    [FieldOffset(0x06F0)] public Utf8String UnkString06F0;
    [FieldOffset(0x0758)] public Utf8String UnkString0758;

    [FixedSizeArray<Unk1>(100)]
    [FieldOffset(0x0A98)] public fixed byte Unk1Arr[100 * 0xF0];//5DC0

    [FieldOffset(0x6850), CExportIgnore] public void* UnkObj6850;
    [FieldOffset(0x6878)] public Utf8String UnkString6878;
    //8 bytes
    [FieldOffset(0x68E8)] public Utf8String UnkString68E8;
    //0x18 bytes
    [FieldOffset(0x6968)] public Utf8String UnkString6968;
    //0x10 bytes
    [FieldOffset(0x69E0)] public void* UnkOBj69E0;

    [FieldOffset(0x6A08)] public Utf8String UnkString3;

    [FieldOffset(0x6AA0)] public void* UnkObj6AA0;

    [FieldOffset(0x6AC0)] public Utf8String UnkString4;

    [FieldOffset(0x6B28)] public void* UnkObj6B28;

    [FieldOffset(0x6B38)] public void* UnkObj6B38;

    [FieldOffset(0x6B70)] public void* UnkObj6B70;

    [FieldOffset(0x6B80)] public void* UnkObj6B80;

    [StructLayout(LayoutKind.Explicit, Size = 0xF0)]
    public struct Unk1 {
        [FieldOffset(0x00)] public Utf8String String0;
        //0x10 bytes
        [FieldOffset(0x80)] public Utf8String String1;
        //0x08 bytes
    }
}
