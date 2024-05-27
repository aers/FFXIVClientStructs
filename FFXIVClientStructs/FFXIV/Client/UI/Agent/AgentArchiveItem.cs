using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.ArchiveItem)]
[StructLayout(LayoutKind.Explicit, Size = 0x30)]
[GenerateInterop]
[Inherits<AgentInterface>]
public unsafe partial struct AgentArchiveItem {
    [FieldOffset(0x28)] public ArchiveItem* ArchiveItem;

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 9C 24 ?? ?? ?? ?? C7 06")]
    public partial void* ViewArchiveItem(uint itemId);
}

[StructLayout(LayoutKind.Explicit, Size = 0xB0)]
public unsafe struct ArchiveItem {
    [FieldOffset(0x10)] public uint ItemId;
    [FieldOffset(0x18)] public Utf8String ItemName;
}
