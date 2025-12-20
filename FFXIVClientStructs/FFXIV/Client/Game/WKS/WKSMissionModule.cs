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
}
