namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

[StructLayout(LayoutKind.Explicit, Size = 0x378)]
public partial struct TofuTransferObject {
    // Different structure to TofuModule's TofuObject
    [FieldOffset(0x10)] public Utf8String Name;
    [FieldOffset(0x78)] public ushort PosX;
    [FieldOffset(0x7A)] public ushort PosY;
    [FieldOffset(0x80)] public ushort Scale;
    [FieldOffset(0x82)] public ushort Angle;
    [FieldOffset(0x84)] public uint RGBA;
    [FieldOffset(0x88)] public bool IsVisible;
    [FieldOffset(0x8A)] public ushort ArgExtra1;
    [FieldOffset(0x8C)] public ushort ArgExtra2;
    [FieldOffset(0x8E)] public ushort ArgExtra3;
    [FieldOffset(0x90)] public Utf8String TextContent;
    [FieldOffset(0x100)] public Utf8String Arg1Name;
    [FieldOffset(0x178)] public Utf8String Arg2Name;
    [FieldOffset(0x1F0)] public Utf8String Arg3Name;
    [FieldOffset(0x268)] public Utf8String Arg4Name;
    [FieldOffset(0x2E0)] public Utf8String Arg5Name;
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x450)]
public partial struct TofuPackedBoard {
    // Packed Board to be sent as packet to server. Structure changes dramatically with small object changes
    // Manipulating bytes here before packet send has a high chance of being rejected by the server, thus not being sent to receiver
    [FieldOffset(0x0)] private byte ObjectCount; // increments by 0x11 with number of objects starting at 0x03
    [FieldOffset(0x2)] public SharingType SharingType;
    [FieldOffset(0x6)] private byte Background; // lower nibble
    [FieldOffset(0x410), FixedSizeArray(isString: true)] internal FixedSizeArray60<byte> _boardName;
}

public enum SharingType : byte {
    Normal = 0,
    RealTime = 1,
    Folder = 4,
}
