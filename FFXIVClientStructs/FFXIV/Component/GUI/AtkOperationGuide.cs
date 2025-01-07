namespace FFXIVClientStructs.FFXIV.Component.GUI;

[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public unsafe struct AtkOperationGuide {
    [FieldOffset(0x00)] public AtkStage* AtkStage;
    [FieldOffset(0x08)] private AtkUnitBase* UnkUnitBase1;
    [FieldOffset(0x10)] private AtkUnitBase* UnkUnitBase2;
    [FieldOffset(0x18)] private byte Unk18;
    [FieldOffset(0x19)] private byte Unk19;
    [FieldOffset(0x1A)] private byte Unk1A;
    [FieldOffset(0x1B)] private byte Unk1B;
    [FieldOffset(0x1C)] private short X;
    [FieldOffset(0x1E)] private short Y;
    [FieldOffset(0x20)] private short Width;
    [FieldOffset(0x22)] private short Height;
    [FieldOffset(0x24)] private float ScaleX; // result of ScaleX / Scale
    [FieldOffset(0x28)] private float Scale;
}
