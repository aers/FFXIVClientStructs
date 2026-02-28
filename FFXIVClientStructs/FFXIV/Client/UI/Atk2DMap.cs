using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::Atk2DMap
[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x50)]
public unsafe partial struct Atk2DMap {
    [FieldOffset(0x00)] public nint VTable;
    [FieldOffset(0x08)] public AtkComponentNode* PlayerPin;
    [FieldOffset(0x10)] public AtkImageNode* PlayerCone;
    [FieldOffset(0x18)] private float Unk18;
    [FieldOffset(0x1C)] private float Unk1C;
    [FieldOffset(0x20)] public float X;
    [FieldOffset(0x24)] public float Y;
    [FieldOffset(0x28)] public float MarkerRadiusScale;
    [FieldOffset(0x2C)] public float MarkerPositionScaling;
    [FieldOffset(0x30)] public float PlayerPinRotation;
    [FieldOffset(0x34)] public float PlayerConeRotation;
    [FieldOffset(0x38)] public float CrosshairOriginX;
    [FieldOffset(0x3C)] public float CrosshairOriginY;
    [FieldOffset(0x40)] public ushort Width;
    [FieldOffset(0x42)] public ushort Height;
    [FieldOffset(0x44)] private ushort Unk44; // cast to float
    [FieldOffset(0x46)] private ushort Unk46; // cast to float
    [FieldOffset(0x48)] private short Unk48;
    [FieldOffset(0x4A)] private byte Unk4A;
}
