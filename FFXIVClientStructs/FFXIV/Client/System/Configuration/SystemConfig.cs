namespace FFXIVClientStructs.FFXIV.Client.System.Configuration;
// Client::System::Configuration::SystemConfig
//   Common::Configuration::SystemConfig
//     Common::Configuration::ConfigBase
//       Client::System::Common::NonCopyable

// size = 0x450
// ctor inlined in Framework ctor
[StructLayout(LayoutKind.Explicit, Size = 0x450)]
public partial struct SystemConfig
{
    [FieldOffset(0x0)] public Common.Configuration.SystemConfig CommonSystemConfig;

    [MemberFunction("E8 ?? ?? ?? ?? 66 85 C0 74 19")]
    public partial uint GetLastWorldID();
}