namespace FFXIVClientStructs.FFXIV.Client.Game;

// Client::Game::BGMSystem
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x100)]
public unsafe partial struct BGMSystem {
    [StaticAddress("4C 8B 15 ?? ?? ?? ?? 4D 85 D2 74 77 41 83 7A", 3, isPointer: true)]
    public static partial BGMSystem* Instance();

    [FieldOffset(0x8)] public uint NumScenes; // equals the amount of rows in the BGMScene sheet

    [FieldOffset(0xC0)] public StdVector<Scene> Scenes;

    [FieldOffset(0xD8)] public SituationKind CurrentSituationKind;
    [FieldOffset(0xDC)] public bool PlayBattleBGM; // is set in update loop, based on combat

    [FieldOffset(0xE0)] private float UnkBattleBGMDuration0;
    [FieldOffset(0xE4)] private float UnkBattleBGMDuration1;

    [FieldOffset(0xF8)] public bool LastingBGM;
    [FieldOffset(0xF9)] public bool ContinueBGMUntilWarp;

    [MemberFunction("4C 8B 1D ?? ?? ?? ?? 4D 85 DB 0F 84")]
    public static partial void SetBGM(
        ushort bgmId,
        uint sceneId,
        byte a3 = 0,
        bool enableCustomFade = false,
        uint fadeOutMs = 0,
        uint fadeInMs = 0,
        uint fadeInStartMs = 0,
        byte a8 = 0,
        byte a9 = 0,
        float initialVolume = 1f);

    // [MemberFunction("4C 8B 05 ?? ?? ?? ?? 4D 85 C0 74 1B")]
    // public static partial void SetBGMPlayState(uint sceneId, PlayState playstate);

    [MemberFunction("4C 8B 05 ?? ?? ?? ?? 4D 85 C0 74 3D")]
    public partial void ResetBGM(uint sceneId);

    [StructLayout(LayoutKind.Explicit, Size = 0x60)]
    public struct Scene {
        /// <summary> The index of <see cref="Scenes"/> and the RowId in the BGMScene sheet. </summary>
        /// <remarks>
        /// 0 = Event<br/>
        /// 1 = Battle<br/>
        /// 2 = MiniGame (RhythmAction, TurnBreak)<br/>
        /// 3 = Content<br/>
        /// 4 = GFate<br/>
        /// 5 = Duel<br/>
        /// 6 = Mount<br/>
        /// 7 = Unknown, no xrefs<br/>
        /// 8 = Unknown, via packet (near PlayerState stuff)<br/>
        /// 9 = Wedding<br/>
        /// 10 = Town<br/>
        /// 11 = Territory
        /// </remarks>
        [FieldOffset(0x00)] public uint SceneId;
        //[FieldOffset(0x04)] public SceneFlags SceneFlags;
        [FieldOffset(0x08)] public SituationKind SituationKind;
        [FieldOffset(0x0C)] public ushort BgmId;
        [FieldOffset(0x0E)] public ushort PlayingBgmId;
        [FieldOffset(0x10)] public ushort PreviousBgmId; // holds BgmId until after BGMSwitch selection
        [FieldOffset(0x12)] private byte Unk12;

        [FieldOffset(0x14)] private float Unk14;
        [FieldOffset(0x18)] public StdVector<SceneIntermission> Intermissions;

        // fade times in ms
        [FieldOffset(0x30)] public bool EnableCustomFade;
        [FieldOffset(0x38)] public uint FadeOutTime;
        [FieldOffset(0x3C)] public uint FadeInTime;
        [FieldOffset(0x40)] public uint FadeInStartTime;
        [FieldOffset(0x44)] public uint ResumeFadeInTime; // unused? it's present in the BGMFadeType sheet

        [FieldOffset(0x50)] public PlayState PlayState;
        [FieldOffset(0x55)] private byte Unk55;

        [FieldOffset(0x58)] public float InitialVolume;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public struct SceneIntermission {
        [FieldOffset(0x00)] public ushort BgmId;
        [FieldOffset(0x02)] private bool IsTimedOut; // ?
        [FieldOffset(0x03)] private byte Unk3;
        [FieldOffset(0x04)] public float ResetWaitTime;
        [FieldOffset(0x08)] public float ElapsedTime;
        [FieldOffset(0x0C)] public bool IsEnabled;
    }

    /* this should be the packed bool from BGMScene sheet, but i don't know if this enum is right
    [Flags]
    public enum SceneFlags : uint {
        None = 0,
        EnableDisableRestart = 1 << 0,
        Resume = 1 << 1,
        EnablePassEnd = 1 << 2,
        ForceAutoReset = 1 << 3,
        IgnoreBattle = 1 << 4,
    }
    */

    public enum SituationKind : uint {
        None = 0,
        Daytime = 1,
        Night = 2,
        Battle = 3,
        Daybreak = 4,
        Twilight = 5
    }

    public enum PlayState : uint {
        Paused = 0,
        Playing = 1,
    }
}
