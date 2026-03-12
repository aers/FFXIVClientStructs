using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::Atk2DNaviMap
//   Client::UI::Atk2DMap
[GenerateInterop]
[Inherits<Atk2DMap>]
[StructLayout(LayoutKind.Explicit, Size = 0x1350)]
public unsafe partial struct Atk2DNaviMap {
    [FieldOffset(0x50), FixedSizeArray] internal FixedSizeArray101<NaviMapMarker> _naviMapMarkers;
    [FieldOffset(0x1340)] public AtkResNode* CompassFrame;
    [FieldOffset(0x134C)] public bool NorthLockedUp;
}

[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public unsafe struct NaviMapMarker {
    [FieldOffset(0x00)] public int SubtextOrientation;
    [FieldOffset(0x04)] public uint IconId;
    [FieldOffset(0x08)] public uint SecondaryIconId;
    [FieldOffset(0x10)] public AtkComponentNode* ComponentNode;
    [FieldOffset(0x18)] public uint Unknown18;
    [FieldOffset(0x1C)] public float Unknown1C; // Set to Scale/100 * 1.1 if scale > 0
    [FieldOffset(0x20)] public float Scale;
    [FieldOffset(0x24)] public short X;
    [FieldOffset(0x26)] public short Y;
    [FieldOffset(0x28)] public float Unknown28;
    [FieldOffset(0x2C)] public byte Unknown2C;
}
