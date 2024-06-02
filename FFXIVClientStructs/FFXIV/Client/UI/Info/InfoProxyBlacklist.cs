using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

// Client::UI::Info::InfoProxyBlacklist
//   Client::UI::Info::InfoProxyPageInterface
//     Client::UI::Info::InfoProxyInterface
[InfoProxy(InfoProxyId.Blacklist)]
[GenerateInterop]
[Inherits<InfoProxyPageInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x1A00)]
public unsafe partial struct InfoProxyBlacklist {
    [FieldOffset(0x20), FixedSizeArray] internal FixedSizeArray200<long> _contentIdArray;
    [FieldOffset(0x660)] public Utf8String Unk660;
    [FieldOffset(0x6C8)] public Utf8String Unk6C8;
}
