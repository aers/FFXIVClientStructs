using FFXIVClientStructs.FFXIV.Common.Configuration;

namespace FFXIVClientStructs.FFXIV.Client.System.Framework;

// Client::System::Framework::EnvironmentManager:
//   Client::System::Framework::Task
//   Common::Configuration::ConfigBase::ChangeEventInterface
// ctor "E8 ?? ?? ?? ?? EB ?? 48 8B C6 BA ?? ?? ?? ?? 48 89 87 ?? ?? ?? ?? 44 8B C2"
/// <summary>
/// This class is a high level abstraction of sound and window systems. And handles sanity checks before propagating values to the more low-level classes respectively
/// </summary>
[GenerateInterop]
[Inherits<Task>]
[Inherits<ChangeEventInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x698)]
public partial struct EnvironmentManager {
    /// <summary>
    ///Cutscene Audio Language (-1 indicates to use ClientLanguage) 
    /// </summary>
    [FieldOffset(0x084)] public int CutsceneMovieVoice;

    /// <summary>
    /// Sets the volume if volume is in the allowed range
    /// </summary>
    /// <param name="channel">Indicates which volume to set</param>
    /// <param name="volume">Volume in range 0-100, -1 indicates to read the configuration value</param>
    /// <param name="saveToConfig">Wether the new volume should be written to system configuration</param>
    [MemberFunction("E8 ?? ?? ?? ?? EB 7F 45 33 C9")]
    public partial void SetVolume(uint channel, int volume, bool saveToConfig);

    [MemberFunction("E8 ?? ?? ?? ?? 49 8B 8F ?? ?? ?? ?? 41 B1 01 BA ?? ?? ?? ??")]
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
}
