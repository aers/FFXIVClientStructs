namespace FFXIVClientStructs.FFXIV.Client.Game.WKS;

// Client::Game::WKS::WKSMissionModule
//   Client::Game::WKS::WKSModuleBase
[GenerateInterop]
[Inherits<WKSModuleBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public unsafe partial struct WKSMissionModule {
    [MemberFunction("E8 ?? ?? ?? ?? 41 B2 ?? EB ?? 49 8B D0")]
    public partial void InitiateMission(ushort missionUnitId);

    [MemberFunction("48 83 EC ?? E8 ?? ?? ?? ?? 84 C0 0F 84")]
    public partial void ReportMission();

    [MemberFunction("E8 ?? ?? ?? ?? B0 01 E9 ?? ?? ?? ?? 49 8B C8")]
    public partial void AbandonMission();

    [StructLayout(LayoutKind.Explicit, Size = 0x40)]
    public unsafe partial struct MissionState {
        /// <remarks> RowId of WKSMissionUnit sheet. </remarks>
        [FieldOffset(0x00)] public ushort MissionUnitRowId;

        [FieldOffset(0x0C)] public ushort Score;

        [FieldOffset(0x10)] public MissionRank Rank;
        [FieldOffset(0x14)] private byte Unk14; // bool? status?

        [FieldOffset(0x16)] public ushort CollectedTotal;
        [FieldOffset(0x18)] public byte CollectedIndividual;
    }

    public enum MissionRank {
        None,
        Bronze,
        Silver,
        Gold,
        Failed = 5,
    }
}
