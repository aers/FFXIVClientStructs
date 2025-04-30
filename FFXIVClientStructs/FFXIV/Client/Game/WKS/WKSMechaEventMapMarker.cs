using FFXIVClientStructs.FFXIV.Client.Game.UI;
using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.Game.WKS;

[StructLayout(LayoutKind.Explicit, Size = 0xC8)]
public struct WKSMechaEventMapMarker {
    [FieldOffset(0x00)] public Utf8String Name;
    [FieldOffset(0x68)] public MapMarkerData MapMarkerData;
    [FieldOffset(0xB8)] public uint WKSMechaEventDataRowId;
    [FieldOffset(0xBC)] public uint LayoutId;
    [FieldOffset(0xC0)] public uint Icon;
    /// <remarks>
    /// Type 1 = Icon 60493<br/>
    /// Type 2 = Icon 63889<br/>
    /// Type 3 + 4 = Icon 60492<br/>
    /// Type 5 = Icon 63884
    /// </remarks>
    [FieldOffset(0xC4)] public byte Type;
    [FieldOffset(0xC5)] public byte Flags;
    [FieldOffset(0xC6)] public byte MapMarkerDataFlags;
    [FieldOffset(0xC7)] public byte UnkC7;
}
