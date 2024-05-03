using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.TelepotTown)]
[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public unsafe partial struct AgentTelepotTown {
    [FieldOffset(0)] public AgentInterface AgentInterface;
    [FieldOffset(0x28)] public AgentTelepotTownData* Data;

    [MemberFunction("48 89 5C 24 ?? 57 48 83 EC 50 0F B6 FA")]
    public readonly partial void TeleportToAetheryte(byte index);
}

[StructLayout(LayoutKind.Explicit, Size = 0xD168)]
public struct AgentTelepotTownData {
    [FieldOffset(0x4)] public byte CurrentAetheryte; // the one you're standing at

    [FieldOffset(0x70A)] public byte SelectedAetheryte;

    [FieldOffset(0x70C)] public byte Flags;
}
