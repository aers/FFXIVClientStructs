using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.WKSHud)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x38)]
public unsafe partial struct AgentWKSHud {
    [FieldOffset(0x28)] public HudInfo* Info;

    public readonly bool IsReady => Info != null && Info->State == 3;

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 D5 48 8B 47 28")]
    public partial bool InitZoneData();

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 EE")]
    public partial bool InitAddon();

    [MemberFunction("E8 ?? ?? ?? ?? 80 7F 30 00 74 08")]
    public partial byte InitInventory();

    [StructLayout(LayoutKind.Explicit, Size = 0x190)]
    public unsafe partial struct HudInfo {
        [FieldOffset(0)] public byte State; // 1/2 = fetching data for current zone, 3 = ready

        [FieldOffset(0x08)] public int CosmoCredits;
        [FieldOffset(0x0C)] public int CosmoCreditsMax;
        [FieldOffset(0x10)] public int CosmoCreditsIcon;
        [FieldOffset(0x14)] public int ZoneCredits;
        [FieldOffset(0x18)] public int ZoneCreditsMax;
        [FieldOffset(0x1C)] public int ZoneCreditsItemId;
        [FieldOffset(0x20)] public int ZoneCreditsIcon;

        [FieldOffset(0x30)] public Utf8String CosmoCreditsText;
        [FieldOffset(0x98)] public Utf8String ZoneCreditsText;
    }
}
