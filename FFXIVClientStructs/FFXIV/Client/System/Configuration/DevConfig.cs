namespace FFXIVClientStructs.FFXIV.Client.System.Configuration;

// Client::System::Configuration::DevConfig
//   Common::Configuration::DevConfig
//     Common::Configuration::ConfigBase
//       Client::System::Common::NonCopyable
[StructLayout(LayoutKind.Explicit, Size = 0x110)]
public struct DevConfig {
    [FieldOffset(0x0)] public Common.Configuration.DevConfig CommonDevConfig;
}
