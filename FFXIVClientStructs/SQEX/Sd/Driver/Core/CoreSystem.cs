namespace FFXIVClientStructs.SQEX.Sd.Driver.Core;

/// <summary>
/// The globals of the software mixer. Once per period the render callback runs the mix pass (every <see cref="CoreSourceVoice"/>, then the
/// <see cref="CoreSubmixVoice"/>s and <see cref="CoreMasterVoice"/>s) and converts each master voice to the format of its endpoint.
/// </summary>
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 1)]
public unsafe partial struct CoreSystem {
    /// <summary> The sample rate of the mixer, 48000. </summary>
    [StaticAddress("44 89 0D ?? ?? ?? ?? 44 89 25 ?? ?? ?? ??", 3)]
    public static partial int* SampleRate();

    /// <summary> The channel count of the mixer layout, 8 (FL, FR, FC, LFE, BL, BR, SL, SR). Voices of format 1 (ambisonic) have 16 channels instead while <see cref="SpatialAudioActive"/> is set. </summary>
    [StaticAddress("89 15 ?? ?? ?? ?? 0F 11 05 ?? ?? ?? ??", 2)]
    public static partial int* ChannelCount();

    /// <summary> The number of frames the mixer renders per period, 256. </summary>
    [StaticAddress("48 63 1D ?? ?? ?? ?? E8 ?? ?? ?? ??", 3)]
    public static partial int* FrameCount();

    /// <summary> 1 while spatial audio is active. Copied from the request at the start of the mix pass. </summary>
    [StaticAddress("39 05 ?? ?? ?? ?? 48 89 5C 24 40", 2)]
    public static partial int* SpatialAudioActive();

    /// <summary> 0 normally, 1 while capturing with offline rendering (the render callback skips the mix pass), 2 while capturing with loopback. </summary>
    [StaticAddress("8B 05 ?? ?? ?? ?? 83 F8 01 0F 85 ?? ?? ?? ??", 2)]
    public static partial int* CaptureMode();

    /// <summary> The render callback of the output devices, called once per period. </summary>
    [MemberFunction("40 55 41 54 41 57 48 8D AC 24 A0 F6 FF FF")]
    public static partial void Render(void* context);
}
