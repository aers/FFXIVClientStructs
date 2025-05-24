namespace FFXIVClientStructs.FFXIV.Client.Game.WKS;

// Client::Game::WKS::WKSMissionModule
//   Client::Game::WKS::WKSModuleBase
[GenerateInterop]
[Inherits<WKSModuleBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public unsafe partial struct WKSMissionModule {
    [MemberFunction("E8 ?? ?? ?? ?? 41 B2 ?? EB ?? 49 8B D0")]
    public partial void InitiateMission(ushort missionUnitId);

    [MemberFunction("48 83 EC ?? E8 ?? ?? ?? ?? 84 C0 74 ?? 45 33 C9 C7 44 24 ?? ?? ?? ?? ?? 45 33 C0 33 D2 B9 ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 83 C4 ?? C3 CC CC CC CC CC CC CC CC CC CC CC CC CC CC CC CC CC CC CC CC 48 83 EC")]
    public partial void ReportMission();

    [MemberFunction("E8 ?? ?? ?? ?? B2 ?? C7 03")]
    public partial void AbandonMission();
}
