namespace FFXIVClientStructs.FFXIV.Common.Configuration;
// Common::Configuration::DevConfig
//   Common::Configuration::ConfigBase
//     Client::System::Common::NonCopyable

// size = 0x110
// ctor E8 ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 89 86 ?? ?? ?? ?? 48 8D 8E
[StructLayout(LayoutKind.Explicit, Size = 0x110)]
public struct DevConfig
{
    [FieldOffset(0x0)] public ConfigBase ConfigBase;
}
