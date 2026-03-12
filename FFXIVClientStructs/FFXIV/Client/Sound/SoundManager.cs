using FFXIVClientStructs.FFXIV.Client.System.Resource;
using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;
using Thread = FFXIVClientStructs.FFXIV.Client.System.Threading.Thread;

namespace FFXIVClientStructs.FFXIV.Client.Sound;

// TODO: rename everything channel to bus
// TODO: remove enum overloads, use it directly

// Client::Sound::SoundManager
//   Client::System::Resource::ResourceEventListener
//   Client::System::Threading::Thread
/// <summary>
/// This class is the low level handler for sound related functions and abstracts from the operating system.
/// The functions in this class are not intended by SE to be used directly and do not have proper checks for correct values.
/// </summary>
[GenerateInterop]
[Inherits<ResourceEventListener>, Inherits<Thread>]
[StructLayout(LayoutKind.Explicit, Size = 0x1D08)]
public unsafe partial struct SoundManager {
    [StaticAddress("48 89 35 ?? ?? ?? ?? 48 83 C4 20", 3, isPointer: true)]
    public static partial SoundManager* Instance();

    [FieldOffset(0x0031)] public bool Disabled;
    [FieldOffset(0x0034)] public float MasterVolume;
    [FieldOffset(0x0038)] public float ActiveVolume;
    [FieldOffset(0x003C), FixedSizeArray] internal FixedSizeArray19<float> _volume;
    [FieldOffset(0x0088), FixedSizeArray] internal FixedSizeArray19<float> _unkVolume2; // All are 1.0f
    [FieldOffset(0x00D4), FixedSizeArray] internal FixedSizeArray19<float> _unkVolume3; // All are 1.0f
    [FieldOffset(0x0120), FixedSizeArray] internal FixedSizeArray19<float> _unkVolume4; // All are 1.0f
    [FieldOffset(0x016C), FixedSizeArray] internal FixedSizeArray19<bool> _channelMuted;
    [FieldOffset(0x017F), FixedSizeArray] internal FixedSizeArray19<bool> _channelAlwaysOn;

    [FieldOffset(0x01C9)] public bool MasterEnabled;
    [FieldOffset(0x01CA)] public bool IsSoundAlways;
    [FieldOffset(0x01CB)] public bool SoundEnabled;
    [FieldOffset(0x01CC)] public bool WindowInactive;

    [FieldOffset(0x0218)] public SoundDataMemory* SoundDataPool; // This points to +8 bytes into the allocated memory.
    [FieldOffset(0x0220)] public SoundData* InactiveSoundDataListHead;
    [FieldOffset(0x0228)] public SoundData* ActiveSoundDataListHead;

    [FieldOffset(0x0260)] private int Unk260; // 1 = In Cutscene

    [FieldOffset(0x02A0)] public nint CriticalSection;

    [FieldOffset(0x02C8)] public nint EventHandle2;

    // Red: System sounds
    // Green: Sound effects, ambient noises, voices, instruments
    // Blue: Music
    [FieldOffset(0x0358), FixedSizeArray] internal FixedSizeArray256<float> _FFTRed1;
    [FieldOffset(0x0758), FixedSizeArray] internal FixedSizeArray256<float> _FFTRed2;
    [FieldOffset(0x0B58), FixedSizeArray] internal FixedSizeArray256<float> _FFTGreen1;
    [FieldOffset(0x0F58), FixedSizeArray] internal FixedSizeArray256<float> _FFTGreen2;
    [FieldOffset(0x1358), FixedSizeArray] internal FixedSizeArray256<float> _FFTBlue1;
    [FieldOffset(0x1758), FixedSizeArray] internal FixedSizeArray256<float> _FFTBlue2;

    [FieldOffset(0x1BE0)] public float OrchestrionPosX;
    [FieldOffset(0x1BE4)] public float OrchestrionPosY;
    [FieldOffset(0x1BE8)] public float OrchestrionPosZ;
    [FieldOffset(0x1BEC), FixedSizeArray(isString: true)] internal FixedSizeArray260<byte> _orchestrionPath;

    /// <summary>
    /// Calculates effective volume
    /// </summary>
    /// <param name="channel">The specific sound channel. This is different from the channels visible to the user</param>
    /// <returns>Volume in the ange 0-1</returns>
    [MemberFunction("F3 0F 10 0D ?? ?? ?? ?? 48 63 C2")]
    public partial float GetEffectiveVolume(int channel);

    /// <inheritdoc cref="GetEffectiveVolume(int)"/>
    public float GetEffectiveVolume(SoundChannel channel) => GetEffectiveVolume((int)channel);

    /// <summary>
    /// Sets channel volume
    /// </summary>
    /// <param name="channel">The specific sound channel. This is different from the channels visible to the user</param>
    /// <param name="volume">Volume in the ange 0-1</param>
    /// <param name="p3">unknown</param>
    [MemberFunction("E8 ?? ?? ?? ?? FF C7 ?? ?? 75 ?? EB")]
    public partial void SetVolume(int channel, float volume, int p3 = 100);

    /// <inheritdoc cref="SetVolume(int,float,int)"/>
    public void SetVolume(SoundChannel channel, float volume, int p3 = 100) => SetVolume((int)channel, volume, p3);

    [MemberFunction("48 89 5C 24 ?? 57 48 83 EC 20 80 79 31 00 0F B6 FA 48 8B D9 75 2B")]
    public partial void SetMasterEnabled(bool enabled);

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 49 8B 89 ?? ?? ?? ?? 83 FE ?? 0F 94 C2 E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 49 8B 89 ?? ?? ?? ?? 83 FE ?? 0F 94 C2 E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 49 8B 89 ?? ?? ?? ?? 83 FE ?? 0F 94 C2 E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 49 8B 89 ?? ?? ?? ?? 83 FE ?? 0F 94 C2 E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 49 8B 89 ?? ?? ?? ?? 83 FE ?? 0F 94 C2 E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 49 8B 89 ?? ?? ?? ?? 8B D6")] // someone should find a better sig for this
    public partial void SetBgmEnabled(bool enabled);

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 49 8B 89 ?? ?? ?? ?? 83 FE ?? 0F 94 C2 E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 49 8B 89 ?? ?? ?? ?? 83 FE ?? 0F 94 C2 E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 49 8B 89 ?? ?? ?? ?? 83 FE ?? 0F 94 C2 E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 49 8B 89 ?? ?? ?? ?? 83 FE ?? 0F 94 C2 E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 49 8B 89 ?? ?? ?? ?? 8B D6")]
    public partial void SetSoundEffectsEnabled(bool enabled);

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 49 8B 89 ?? ?? ?? ?? 83 FE ?? 0F 94 C2 E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 49 8B 89 ?? ?? ?? ?? 83 FE ?? 0F 94 C2 E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 49 8B 89 ?? ?? ?? ?? 83 FE ?? 0F 94 C2 E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 49 8B 89 ?? ?? ?? ?? 8B D6")]
    public partial void SetVoiceEnabled(bool enabled);

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 49 8B 89 ?? ?? ?? ?? 83 FE ?? 0F 94 C2 E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 49 8B 89 ?? ?? ?? ?? 83 FE ?? 0F 94 C2 E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 49 8B 89 ?? ?? ?? ?? 8B D6")]
    public partial void SetSystemEnabled(bool enabled);

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 49 8B 89 ?? ?? ?? ?? 83 FE ?? 0F 94 C2 E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 49 8B 89 ?? ?? ?? ?? 8B D6")]
    public partial void SetEnvironmentEnabled(bool enabled);

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 49 8B 89 ?? ?? ?? ?? 8B D6")]
    public partial void SetPerfomEnabled(bool enabled);

    /// <summary>
    /// Plays a sound from an .scd file.
    /// </summary>
    /// <param name="path">The path to the scd file.</param>
    /// <param name="volume">The volume.</param>
    /// <param name="fadeInDuration">The fade in duration.</param>
    /// <param name="posX">X-Position of the source.</param>
    /// <param name="posY">Y-Position of the source.</param>
    /// <param name="posZ">Z-Position of the source.</param>
    /// <param name="speed">The playback speed.</param>
    /// <param name="a9"></param>
    /// <param name="soundNumber">The number of the sound in the scd.</param>
    /// <param name="autoRelease">If set to <see langword="true"/>, the SoundData entry will automatically be released after playback. Otherwise it stays active so it can be reused and has to be stopped manually.<br/>Note: There can only be up to 256 SoundData entries!</param>
    /// <param name="volumeCategory">The volume category. Depending on the category, ConfigOptions may influence the volume.</param>
    /// <param name="a13"></param>
    /// <param name="midiNote">The MIDI note that should be played.</param>
    /// <param name="a15"></param>
    /// <param name="defaultFadeOut">Whether to use the default fade out duration of 10 seconds.</param>
    /// <param name="isPositional">If the sound is coming from a position.</param>
    /// <param name="a18"></param>
    /// <returns>A pointer to the acquired SoundData.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 83 FB ?? 41 BF"), GenerateStringOverloads]
    public partial SoundData* PlaySound( // Actions, Movement, Instruments.. kinda everything
        CStringPointer path,
        float volume, // default: 1.0f
        uint fadeInDuration, // default: 0
        float posX, // default: 0.0f
        float posY, // default: 0.0f
        float posZ, // default: 0.0f
        float speed, // default: 1.0f
        int a9, // default: 0 - Priority?
        uint soundNumber, // default: 0
        bool autoRelease, // default: true
        SoundVolumeCategory volumeCategory, // default: SoundVolumeCategory.BypassVolumeRules
        bool a13, // default: false
        int midiNote, // default: -1
        bool a15, // default: false
        bool defaultFadeOut, // default: false, FadeOutDuration = 10.0
        bool isPositional, // default: true
        bool a18); // default: false

    [MemberFunction("E8 ?? ?? ?? ?? 48 85 C0 74 ?? 48 89 43 ?? 48 8B 4B ?? 48 85 C9 74 ?? ?? ?? ?? FF 50 ?? 84 C0 75"), GenerateStringOverloads]
    public partial SoundData* PlayClipSound( // Cutscene Vo (Preloading?!), VFX
        CStringPointer path,
        float volume,
        uint fadeInDuration,
        float posX,
        float posY,
        float posZ,
        float playbackSpeed,
        int a9, // Priority?
        uint soundNumber,
        bool autoRelease,
        bool a12);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B AC 24 ?? ?? ?? ?? 48 89 43")]
    public partial SoundData* PlayLayoutSound(SoundResourceHandle* resourceHandle, SoundLayoutOptions* options, ushort size); // Env

    [MemberFunction("E8 ?? ?? ?? ?? 48 89 43 ?? 48 8B C8 48 85 C0 74 ?? 80 7B ?? 00"), GenerateStringOverloads]
    public partial SoundData* PlayBGMSound(CStringPointer path); // BGM

    [MemberFunction("E8 ?? ?? ?? ?? 48 89 47 ?? 89 5F ?? 48 8B 9C 24"), GenerateStringOverloads]
    public partial SoundData* PlayGAYATitleSound(CStringPointer path, float volume, uint fadeInDuration); // GAYA, Title

    [MemberFunction("48 89 6C 24 ?? 56 48 83 EC ?? 80 79 ?? 00 48 8B EA"), GenerateStringOverloads]
    public partial SoundData* PlayOrchestrionSound(CStringPointer path, float posX, float posY, float posZ, bool enableFadeIn); // Orchestrion

    [MemberFunction("E8 ?? ?? ?? ?? 48 0F BE 46 ?? 41 B1"), GenerateStringOverloads]
    public partial SoundData* PlaySystemSound(CStringPointer path, float volume, uint soundNumber, uint fadeInDuration, bool autoRelease, SoundVolumeCategory volumeCategory); // UI

    [MemberFunction("E8 ?? ?? ?? ?? 48 89 43 ?? 48 8D 8D"), GenerateStringOverloads]
    public partial SoundData* PlayMovieSound(CStringPointer path, float volume, uint soundNumber, uint fadeInDuration, bool autoRelease); // Movies

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B CB 48 8B F8 FF 15 ?? ?? ?? ?? EB"), GenerateStringOverloads]
    public partial SoundData* PlayCutsceneVoSound(CStringPointer path); // Cutscene Vo

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 256 * 0xD0)]
    public partial struct SoundDataMemory {
        [FieldOffset(0), FixedSizeArray] internal FixedSizeArray256<SoundData> _entries;
    }

    // TODO: rename to SoundBus, move out of struct?
    /// <remarks> All busses use 44100 Hz sampling rate. </remarks>
    public enum SoundChannel {
        /// <remarks>  2 Tracks, 2D </remarks>
        Music = 1,
        /// <remarks> 20 Tracks, 3D </remarks>
        SE = 2,
        /// <remarks>  5 Tracks, 3D </remarks>
        Voice = 3,
        /// <remarks>  5 Tracks, 2D </remarks>
        System = 4,
        /// <remarks> 12 Tracks, 3D </remarks>
        BG = 5,
        /// <remarks> 15 Tracks, 3D </remarks>
        Foot = 6,
        /// <remarks>  5 Tracks, 3D </remarks>
        PlacedNPC = 7,
        /// <remarks>  2 Tracks, 2D </remarks>
        TimeStretchBGM = 8,
        /// <remarks>  2 Tracks, 2D </remarks>
        Zingle = 9,
        /// <remarks>  8 Tracks, 3D </remarks>
        CommonVFX = 10,
        /// <remarks>  4 Tracks, 3D </remarks>
        BGEnv = 11,
        /// <remarks>  2 Tracks, 3D </remarks>
        Walla = 12,
        /// <remarks>  2 Tracks, 2D </remarks>
        Movie = 13,
        /// <remarks> 28 Tracks, 3D </remarks>
        Unknown0 = 14,
        /// <remarks>  4 Tracks, 3D </remarks>
        Unknown1 = 15,
        /// <remarks>  2 Tracks, 3D </remarks>
        Orchestrion = 16,
        /// <remarks> 16 Tracks, 3D </remarks>
        Instruments = 17,
        /// <remarks>  4 Tracks, 2D </remarks>
        Vibration = 18,
        /// <remarks> 12 Tracks, 3D </remarks>
        Housing = 19,
        /// <remarks>  2 Tracks, 3D </remarks>
        RandomWind = 20,

        [Obsolete("Renamed to Music")] Bgm1 = 1,
        [Obsolete("Renamed to SE")] Se1 = 2,
        [Obsolete("Renamed to BG")] Env1 = 5,
        [Obsolete("Renamed to Foot")] Se2 = 6,
        [Obsolete("Renamed to PlacedNPC")] Se3 = 7,
        [Obsolete("Renamed to TimeStretchBGM")] Bgm2 = 8,
        [Obsolete("Renamed to Zingle")] Bgm3 = 9,
        [Obsolete("Renamed to BGEnv")] Env2 = 11,
        [Obsolete("Renamed to Walla")] Env3 = 12,
        [Obsolete("Renamed to Orchestrion")] Bgm4 = 16,
        [Obsolete("Renamed to Instruments")] Perform = 17,
    }
}

[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public unsafe partial struct ClipSoundManager {
    [FieldOffset(0x00)] public SoundManager* SoundManager;
    [FieldOffset(0x08)] private fixed byte CriticalSection[40];
}

public enum SoundVolumeCategory {
    /// <remarks> Modifies volume based on ConfigOption.SoundPlayer </remarks>
    Player = 0,
    /// <remarks> Modifies volume based on ConfigOption.SoundParty </remarks>
    Party = 1,
    /// <remarks> Modifies volume based on ConfigOption.SoundOther </remarks>
    Other = 2,
    Unk3 = 3, // Enemy?
    Unk4 = 4, // Enemy Player?
    /// <remarks> Won't load/play the sound at all. </remarks>
    NoPlay = 5,
    /// <remarks> Does not modify volume, always plays. For example, sounds in Cutscenes. </remarks>
    BypassVolumeRules = 6,
}
