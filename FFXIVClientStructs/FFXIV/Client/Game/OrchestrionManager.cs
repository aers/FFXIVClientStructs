using FFXIVClientStructs.FFXIV.Client.Sound;
using FFXIVClientStructs.FFXIV.Common.Component.Excel;

namespace FFXIVClientStructs.FFXIV.Client.Game;

// Client::Game::OrchestrionManager
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x38)]
public unsafe partial struct OrchestrionManager {
    [StaticAddress("66 44 3B 35 DA 6C 2E 01", 4)]
    public static partial OrchestrionManager* Instance();

    [FieldOffset(0x00)] public ushort TrackId;
    [FieldOffset(0x02)] private byte Unk2;
    [FieldOffset(0x03)] public bool IsExecutingCommand;
    [FieldOffset(0x04)] private ushort UnkTrackId;

    [FieldOffset(0x08)] private short Unk8Flags;

    [FieldOffset(0x0C)] public OrchestrionMode Mode;
    [FieldOffset(0x10)] public SoundData* SoundData;

    [FieldOffset(0x18)] private OrchestrionMode UnkMode;
    [FieldOffset(0x1C)] public OrchestrionPlayMode PlayMode;
    [FieldOffset(0x20)] private ExcelSheetWaiter* ExcelSheetWaiter;
    [FieldOffset(0x28), FixedSizeArray] internal FixedSizeArray8<ushort> _playlist;

    /// <remarks> In Island Sanctuary, this will send a packet to the server containing the Orchestrion Roll Id. Make sure you have obtained it! </remarks>
    [MemberFunction("40 53 48 83 EC ?? 0F B7 D9 B9 ?? ?? ?? ?? 8D 43")]
    public static partial void PlayTrack(ushort id);

    [MemberFunction("40 53 48 83 EC ?? 0F B7 D9 E8 ?? ?? ?? ?? 48 8B C8")]
    public static partial void PlaySample(ushort id);

    [MemberFunction("40 53 48 83 EC ?? 48 8B 05 ?? ?? ?? ?? 48 85 C0 74 ?? 80 78")]
    public static partial void StopCurrentTrack();

    [MemberFunction("83 3D ?? ?? ?? ?? ?? 0F 84 ?? ?? ?? ?? C3")]
    public static partial void StopSample();

    [MemberFunction("48 83 EC ?? 66 83 3D ?? ?? ?? ?? 00 75")]
    public static partial bool IsInRange();
}

public enum OrchestrionMode {
    Off = 0,
    Playing = 1,
    Listen = 2,
    /// <remarks> Used in Island Sanctuary </remarks>
    Loop = 3,
}

public enum OrchestrionPlayMode {
    PlayAll = 1,
    Shuffle = 2,
    Repeat = 3,
}
