namespace FFXIVClientStructs.SQEX.Sd.Driver.Core;

/// <summary> An output of a source or submix voice: the voice adds its processed buffer to <see cref="Destination"/> with <see cref="CoreSubmixVoice.MixIn"/>. </summary>
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public struct VoiceSend {
    /// <summary> A <see cref="CoreSubmixVoice"/> or a <see cref="CoreMasterVoice"/>. </summary>
    [FieldOffset(0x00)] public nint Destination;
    [FieldOffset(0x08)] public float Gain;
}
