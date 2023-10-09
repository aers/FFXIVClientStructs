namespace FFXIVClientStructs.FFXIV.Component.GUI;

[StructLayout(LayoutKind.Explicit, Size = 0x14)]
public struct AtkTimelineKeyFrame {
    [FieldOffset(0x00)] public float SpeedCoefficient1;
    [FieldOffset(0x04)] public float SpeedCoefficient2;
    [FieldOffset(0x08)] public ushort FrameIdx;
    [FieldOffset(0x0A)] public AtkTimelineInterpolation Interpolation;
    [FieldOffset(0x0C)] public AtkTimelineKeyValue Value;
}
