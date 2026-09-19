namespace FFXIVClientStructs.FFXIV.Client.Graphics.PostEffect;

[StructLayout(LayoutKind.Explicit, Size = 0x34)]
public struct PostEffectDepthOfFieldParameters {
    [FieldOffset(0x00)] public bool UseUpdatedDepthOfField;
    [FieldOffset(0x01)] public bool UseManualDepthOfField;
    [FieldOffset(0x02)] public bool UseFocusDistanceOverride;

    [FieldOffset(0x04)] public float NearFocusDistance;
    [FieldOffset(0x08)] public float FarFocusDistance;
    [FieldOffset(0x0C)] public float FarBlurDistance;
    [FieldOffset(0x10)] public float NearBlurRate;
    [FieldOffset(0x14)] public float FarBlurRate;

    [FieldOffset(0x1C)] public float EffectMaskRate;
    [FieldOffset(0x20)] public float FocusDistance;
    [FieldOffset(0x24)] public float FNumber;
    [FieldOffset(0x28)] public float CocNormalizationDivisor;

    [FieldOffset(0x2C)] public float PreviousFrameWeight;
    [FieldOffset(0x30)] public float PreviousRangeScale;
}
