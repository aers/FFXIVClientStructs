using FFXIVClientStructs.FFXIV.Common.Configuration;

namespace FFXIVClientStructs.FFXIV.Client.System.Framework;

//Client::System::Framework::EnvironmentManager:
//  Client::System::Framework::Task
//  Common::Configuration::ConfigBase::ChangeEventInterface
//ctor "E8 ?? ?? ?? ?? EB ?? 48 8B C6 BA ?? ?? ?? ?? 48 89 87 ?? ?? ?? ?? 44 8B C2"
/// <summary>
/// This class is a high level abstraction of sound and window systems. And handles sanity checks before propagating values to the more low-level classes respectively
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 0x698)]
public partial struct EnvironmentManager {
    [FieldOffset(0x000)] public Task Task;
    [FieldOffset(0x038)] public ChangeEventInterface ChangeEventInterface;
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
    [MemberFunction("48 89 5C 24 ?? 48 89 74 24 ?? 57 48 83 EC ?? 41 8B F8 41 0F B6 F1")]
    public partial void SetVolume(uint channel, int volume, bool saveToConfig);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 8F ?? ?? ?? ?? 41 B1 ?? 41 83 C8")]
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
