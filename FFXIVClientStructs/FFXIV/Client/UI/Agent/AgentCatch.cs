namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentCatch
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.Catch)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x40)]
public unsafe partial struct AgentCatch {
    [FieldOffset(0x28)] public uint ItemId;
    [FieldOffset(0x2C)] public ushort Size; // ilm size as int (e.g. 446 = 44.6 ilm)
    [FieldOffset(0x2E)] public byte Amount;
    [FieldOffset(0x2F)] public byte Level;
    [FieldOffset(0x30)] public byte Stars;
    [FieldOffset(0x31)] public byte OceanStars;
    [FieldOffset(0x32)] public bool IsLarge;
    [FieldOffset(0x33)] public bool IsMoochable; // true for Mooch or MoochII
    [FieldOffset(0x34)] public bool IsFirstTimeCatch;
    [FieldOffset(0x35)] private byte Unk35; // a11 in UpdateCatch, only seen it at 1
    [FieldOffset(0x36)] private byte Unk36; // a12 in UpdateCatch, only seen it at 0
    [FieldOffset(0x38)] private uint Unk38; // some addonstate flag I think

    /// <remarks>Function is only for regular fishing, not spearfishing. Triggers when AddonCatch is shown.</remarks>
    [MemberFunction("48 89 6C 24 ?? 56 41 56 41 57 48 81 EC ?? ?? ?? ?? 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 84 24 ?? ?? ?? ?? 48 8B 01")]
    public partial void UpdateCatch(uint itemId, bool isLarge, ushort size, byte amount, byte level, byte stars, byte oceanStars, bool isMoochable, bool isFirstTimeCatch, byte a11, byte a12);
}
