using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.WKSHud)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x40)]
public unsafe partial struct AgentWKSHud {
    [FieldOffset(0x28)] public HudInfo* Info;

    public readonly bool IsReady => Info != null && Info->State == 3;

    [StructLayout(LayoutKind.Explicit, Size = 0x270)]
    public unsafe partial struct HudInfo {
        [FieldOffset(0)] public byte State; // 1/2 = fetching data for current zone, 3 = ready

        [FieldOffset(0x08)] public int CosmoCredits;
        [FieldOffset(0x0C)] public int CosmoCreditsMax;
        [FieldOffset(0x10)] public int CosmoCreditsIcon;
        [FieldOffset(0x14)] public int ZoneCredits;
        [FieldOffset(0x18)] public int ZoneCreditsMax;
        [FieldOffset(0x1C)] public int ZoneCreditsItemId;
        [FieldOffset(0x20)] public int ZoneCreditsIcon;

        [FieldOffset(0x40)] public Utf8String CosmoCreditsText;
        [FieldOffset(0xA8)] public Utf8String ZoneCreditsText;
    }
}
