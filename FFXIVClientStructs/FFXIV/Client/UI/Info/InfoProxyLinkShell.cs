using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

// Client::UI::Info::InfoProxyLinkshell
//   Client::UI::Info::InfoProxyInterface
[InfoProxy(InfoProxyId.Linkshell)]
[GenerateInterop]
[Inherits<InfoProxyInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x1E8)]
public unsafe partial struct InfoProxyLinkshell {
    [FieldOffset(0x038)] public Utf8String UnkString0;
    [FieldOffset(0x0A0)] public Utf8String UnkString1;

    [FieldOffset(0x108), FixedSizeArray] internal FixedSizeArray8<Entry> _linkShells;
    [FieldOffset(0x1C8)] public uint ActiveLinkShellIndex;

    [FieldOffset(0x1D0)] public Entry ActiveLinkShell;

    [MemberFunction("3B 51 10 73 0F 8B C2 48 83 C0 0B")]
    public partial Entry* GetLinkshellInfo(uint index);

    [MemberFunction("E8 ?? ?? ?? ?? 4C 8B C8 44 8D 47 01")]
    public partial byte* GetLinkshellName(ulong id);

    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public struct Entry {
        [FieldOffset(0x00)] public ulong Id;
        [FieldOffset(0x08)] public ulong ChatId;
        [FieldOffset(0x10)] public uint Flags;
    }
}
