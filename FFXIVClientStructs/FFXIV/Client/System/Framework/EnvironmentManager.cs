using FFXIVClientStructs.FFXIV.Common.Math;
using ChangeEventInterface = FFXIVClientStructs.FFXIV.Common.Configuration.ConfigBase.ChangeEventInterface;

namespace FFXIVClientStructs.FFXIV.Client.System.Framework;

// Client::System::Framework::EnvironmentManager:
//   Client::System::Framework::Task
//   Common::Configuration::ConfigBase::ChangeEventInterface
// ctor "E8 ?? ?? ?? ?? EB ?? 48 8B C6 BA ?? ?? ?? ?? 48 89 87 ?? ?? ?? ?? 44 8B C2"
/// <summary>
/// This class is a high level abstraction of sound and window systems. And handles sanity checks before propagating values to the more low-level classes respectively
/// </summary>
[GenerateInterop]
[Inherits<Task>, Inherits<ChangeEventInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x698)]
public partial struct EnvironmentManager {
    [FieldOffset(0x050)] public bool IsShutDown;

    /// <summary>
    /// Fade is an optional full-screen overlay blended on top of the rendered image.
    /// Alpha of the overlay is equal to FadeColor.W - FadeCurrent.
    /// </summary>
    [FieldOffset(0x054)] public float FadeDelay; // in seconds; ticks down every frame, while >0 fade is not changed
    [FieldOffset(0x058)] public float FadeCurrent; // 0 for full fade, 1 for no fade
    [FieldOffset(0x05C)] public float FadeFrom;
    [FieldOffset(0x060)] public float FadeTo;
    [FieldOffset(0x064)] public float FadeRemaining;
    [FieldOffset(0x068)] public float FadeDuration;
    [FieldOffset(0x06C)] public bool FadeActive;
    [FieldOffset(0x070)] public int FadeCounter;
    [FieldOffset(0x074)] public Vector4 FadeColor;

    /// <summary>
    /// Cutscene Audio Language (-1 indicates to use ClientLanguage) 
    /// </summary>
    [FieldOffset(0x084)] public int CutsceneMovieVoice;

    /// <summary>
    /// Ring buffer of window mode update operations.
    /// </summary>
    [FieldOffset(0x08C)] internal FixedSizeArray128<ModeUpdateOp> _updateOps;
    [FieldOffset(0x68C)] public uint UpdateOpNext;
    [FieldOffset(0x690)] public uint UpdateOpLast;
    [FieldOffset(0x694)] public uint UpdateOpCount;

    /// <summary>
    /// Sets the volume if volume is in the allowed range
    /// </summary>
    /// <param name="channel">Indicates which volume to set</param>
    /// <param name="volume">Volume in range 0-100, -1 indicates to read the configuration value</param>
    /// <param name="saveToConfig">Wether the new volume should be written to system configuration</param>
    [MemberFunction("E8 ?? ?? ?? ?? EB 7F 45 33 C9")]
    public partial void SetVolume(uint channel, int volume, bool saveToConfig);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 8F ?? ?? ?? ?? 41 B1 01 BA ?? ?? ?? ?? 41 B8")]
    public partial void SetMasterVolume(int volume, bool saveToConfig);

    ///<inheritdoc cref="SetVolume(uint,int,bool)"/>
    public void SetVolume(SoundChannel channel, int volume, bool saveToConfig) => SetVolume((uint)channel, volume, saveToConfig);

    /// <summary>
    /// Each value represents one volume slider in the system configuration, expect master volume.<br/>
    /// </summary>
    public enum SoundChannel : uint {
        BGM = 0,
        SoundEffects = 1,
        Voice = 2,
        Environment = 3,
        System = 4,
        Perform = 5,
        All = 6
    }

    public enum ModeUpdateOpType : int {
        Delay = 1, // params: {num frames, -, -}
        MakeWindowedAndResize = 2, // params: {w, h, -}
        MakeWindowed = 3,
        MakeBorderless = 4,
        WaitUntilDeviceReady = 5,
        Resize = 6, // params: {w, h, -}
        MakeFullscreen = 7, // params: {w, h, refresh}
        // 8: params: {?, -. -}
    }

    [StructLayout(LayoutKind.Explicit, Size = 0xC)]
    public struct ModeUpdateOp {
        [FieldOffset(0)] public ModeUpdateOpType Type;
        [FieldOffset(4)] public short Param1;
        [FieldOffset(6)] public short Param2;
        [FieldOffset(8)] public short Param3;
    }
}
