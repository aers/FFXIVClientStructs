namespace FFXIVClientStructs.FFXIV.Common.Configuration;

// Common::Configuration::DevConfig
//   Common::Configuration::ConfigBase
//     Client::System::Common::NonCopyable
// ctor "E8 ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 89 86 ?? ?? ?? ?? 48 8D 8E ?? ?? ?? ?? 48 89 AE"
[StructLayout(LayoutKind.Explicit, Size = 0x110)]
public struct DevConfig {
    [FieldOffset(0x0)] public ConfigBase ConfigBase;
}
