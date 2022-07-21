namespace FFXIVClientStructs.FFXIV.Client.System.Configuration;
// Client::System::Configuration::DevConfig
//   Common::Configuration::DevConfig
//     Common::Configuration::ConfigBase
//       Client::System::Common::NonCopyable

// size = 0x110
// ctor inlined in Framework ctor
[StructLayout(LayoutKind.Explicit, Size = 0x110)]
public struct DevConfig
{
    [FieldOffset(0x0)] public Common.Configuration.DevConfig CommonDevConfig;
}
