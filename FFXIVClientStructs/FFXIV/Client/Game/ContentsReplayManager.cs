using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.Game;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x748)]
public unsafe partial struct ContentsReplayManager {
    [StaticAddress("48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 84 C0 0F 84 ?? ?? ?? ?? 48 8B 4E ?? ?? ?? ?? FF 50", 3)]
    public static partial ContentsReplayManager* Instance();

    [FieldOffset(0x00)] public uint GameBuildRevision;

    [FieldOffset(0x48)] public FFXIVREPLAYHeader Header;
    [FieldOffset(0xB0)] public ushort NumChapters;
    [FieldOffset(0xB4), FixedSizeArray] internal FixedSizeArray64<FFXIVREPLAYChapter> _chapters;

    [FieldOffset(0x3B8)] public Utf8String ContentTitle;

    [FieldOffset(0x450)] public ulong LocalContentId;

    [FieldOffset(0x460)] public Utf8String CharacterRecordingName;
    [FieldOffset(0x4C8)] public Utf8String ReplayTitle;
    [FieldOffset(0x530)] private Utf8String Unk530;

    // 5D0 InitZonePacket

    [FieldOffset(0x724)] public float PositionMs;

    [FieldOffset(0x72C)] public float PlaybackSpeed;

    [FieldOffset(0x742)] public ContentsReplayStatus Status;
    [FieldOffset(0x743)] public ContentsReplayPlaybackControl PlaybackControls;

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x68)]
    public unsafe partial struct FFXIVREPLAYHeader {
        [FieldOffset(0x00), FixedSizeArray(isString: true)] internal FixedSizeArray12<byte> _magic;
        [FieldOffset(0x0C)] public ushort Version;
        [FieldOffset(0x0E)] public ushort OperatingSystemType;
        [FieldOffset(0x10)] public uint GameBuildRevision;
        [FieldOffset(0x14)] public uint Timestamp;
        [FieldOffset(0x18)] public uint TotalMs;
        [FieldOffset(0x1C)] public uint DisplayedMs;
        [FieldOffset(0x20)] public ushort ContentFinderConditionId;

        [FieldOffset(0x28)] public byte Flags;

        [FieldOffset(0x30)] public ulong LocalContentId;
        [FieldOffset(0x38), FixedSizeArray] internal FixedSizeArray8<byte> _jobIds;
        [FieldOffset(0x40)] public byte PlayerIndex;

        [FieldOffset(0x48)] public uint ReplayLength;

        [FieldOffset(0x4E), FixedSizeArray] internal FixedSizeArray7<ushort> _bNpcNames;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x0C)]
    public unsafe partial struct FFXIVREPLAYChapter {
        [FieldOffset(0x00)] public FFXIVREPLAYChapterType Type;
        [FieldOffset(0x04)] public uint Offset;
        /// <remarks> Relative to first chapter: <code>(Chapters[i].PositionMs - Chapters[0].PositionMs) * 0.001</code> </remarks>
        [FieldOffset(0x08)] public uint PositionMs;
    }
}

[Flags]
public enum ContentsReplayStatus : byte {
    None = 0,
    CanRecord = 1 << 1,
    RecordingPackets = 1 << 2,
    ContentStarted = 1 << 6,
}

[Flags]
public enum ContentsReplayPlaybackControl : byte {
    None = 0,
    InPlayback = 1 << 2,
    Paused = 1 << 3,
}

// Based on Addon#3079
public enum FFXIVREPLAYChapterType : byte {
    None = 0,
    /// <summary> Start of boss fight </summary>
    Countdown = 1,
    StartRestart = 2,

    EventCutscene = 4,
    ContentStart = 5,
}
