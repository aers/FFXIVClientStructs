using FFXIVClientStructs.FFXIV.Client.Graphics;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public unsafe struct AtkTimelineData {
    [FieldOffset(0x00)] public uint Id;
    [FieldOffset(0x04)] public ushort AnimationCount;
    [FieldOffset(0x06)] public ushort LabelDataCount;
    // FrameSet0
    [FieldOffset(0x08)] public AtkTimelineAnimation* Animations;
    // FrameSet1
    [FieldOffset(0x10)] public AtkTimelineLabelData* LabelDatas;
}

[StructLayout(LayoutKind.Explicit, Size = 0x88)]
public unsafe partial struct AtkTimelineAnimation {
    [FieldOffset(0x00)] public ushort StartFrameIdx;
    [FieldOffset(0x02)] public ushort EndFrameIdx;
    [FixedSizeArray<AtkTimelineProperty>(8)]
    [FieldOffset(0x08)] public unsafe fixed byte Properties[8 * 16]; // 8 * AtkTimelineProperty
}

// AtkTimelineAnimation but only 1 property
[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public unsafe partial struct AtkTimelineLabelData {
    [FieldOffset(0x00)] public ushort StartFrameIdx;
    [FieldOffset(0x02)] public ushort EndFrameIdx;
    [FieldOffset(0x08)] public AtkTimelineProperty Property;
}

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe struct AtkTimelineProperty {
    [FieldOffset(0x00)] public ushort KeyFrameCount;
    [FieldOffset(0x02)] public AtkTimelineKeyType KeyType;
    [FieldOffset(0x08)] public AtkTimelineKeyFrame* KeyFrames;
}

[StructLayout(LayoutKind.Explicit, Size = 0x14)]
public unsafe struct AtkTimelineKeyFrame {
    [FieldOffset(0x00)] public float SpeedCoefficient1;
    [FieldOffset(0x04)] public float SpeedCoefficient2;
    [FieldOffset(0x08)] public ushort FrameIdx;
    [FieldOffset(0x0A)] public AtkTimelineInterpType InterpType;
    [FieldOffset(0x0C)] public AtkTimelineKeyValue Value;
}

[StructLayout(LayoutKind.Explicit, Size = 0x08)]
public unsafe struct AtkTimelineKeyValue {
    [FieldOffset(0x00)] public StdPair<float, float> Float2;
    [FieldOffset(0x00)] public float Float;
    [FieldOffset(0x00)] public byte Byte;
    [FieldOffset(0x00)] public ushort Word;
    // Alpha values are ignored in these two
    [FieldOffset(0x00)] public ByteColor RGB;
    [FieldOffset(0x00)] public RGBTint RGBTint;
    [FieldOffset(0x00)] public AtkTimelineLabel Label;
}

[StructLayout(LayoutKind.Explicit, Size = 0x08)]
public unsafe struct RGBTint {
    [FieldOffset(0x00)] public ByteColor Multiply;
    [FieldOffset(0x04)] public uint Add;

    public readonly int AddR => (int)(Add & 0x3FF) - 255;
    public readonly int AddG => (int)((Add >> 10) & 0xFFF) - 255;
    public readonly int AddB => (int)((Add >> 22) & 0x3FF) - 255;
}

// LabelKeyframe
[StructLayout(LayoutKind.Explicit, Size = 0x04)]
public unsafe struct AtkTimelineLabel {
    // LabelId
    [FieldOffset(0x00)] public ushort LabelId;
    // LabelCommand
    [FieldOffset(0x02)] public AtkTimelineLoopBehavior LoopBehavior;
    // JumpId
    [FieldOffset(0x03)] public byte JumpLabelId;
}

public enum AtkTimelineKeyType : ushort {
    Float2,
    Float,
    Byte,
    RGBTint,
    UShort,
    RGB,
    Label,
    UnknownShort,
    None = 0xFFFF
}

public enum AtkTimelineInterpType : byte {
    // Some animated properties cannot be interpolated
    None,
    Linear,
    // Speed coefficients dictate the interpolation, but only when smooth.
    Smooth,
}

public enum AtkTimelineLoopBehavior : byte {
    AnimStart,
    PlayOnce,
    LoopForever,
    Unknown,
}

[Flags]
public enum AtkTimelineMask : byte {
    Position = 1 << 0,
    Rotation = 1 << 1,
    Scale = 1 << 2,
    Alpha = 1 << 3,
    NodeTint = 1 << 4,
    VendorSpecific1 = 1 << 5,
    VendorSpecific2 = 1 << 6,
    ActiveLabel = 1 << 7,
}

[Flags]
public enum AtkTimelineMask2 : byte {
    IsAnimated = 1 << 6, // 0x4000 relative to Mask
    UnknownFlag = 1 << 7, // 0x8000 relative to Mask; unsure what this does, but it exists
}

[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public unsafe struct AtkTimeline {
    [FieldOffset(0x00)] public AtkTimelineData* Data;
    [FieldOffset(0x08)] public AtkTimelineData* LabelData;
    [FieldOffset(0x10)] public AtkTimelineAnimation* ActiveAnimation;
    [FieldOffset(0x18)] public AtkResNode* OwnerNode;
    [FieldOffset(0x20)] public float FrameTime;
    [FieldOffset(0x24)] public float ParentFrameTime;
    [FieldOffset(0x28)] public ushort LabelFrameIdxDuration;
    [FieldOffset(0x2A)] public ushort LabelEndFrameIdx;
    [FieldOffset(0x2C)] public ushort ActiveLabelId;
    // Values that aren't modified are put into this mask (?)
    [FieldOffset(0x2E)] public AtkTimelineMask Mask;
    [FieldOffset(0x2F)] public AtkTimelineMask2 Mask2;
}
