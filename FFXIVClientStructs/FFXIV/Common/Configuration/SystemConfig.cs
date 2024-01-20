namespace FFXIVClientStructs.FFXIV.Common.Configuration;

// Common::Configuration::SystemConfig
//   Common::Configuration::ConfigBase
//     Client::System::Common::NonCopyable
// ctor "E8 ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 8D 8E ?? ?? ?? ?? 48 89 46 10"
[StructLayout(LayoutKind.Explicit, Size = 0x450)]
public struct SystemConfig {
    [FieldOffset(0x0)] public ConfigBase ConfigBase;
    [FieldOffset(0x118)] public ConfigBase UiConfig;
    [FieldOffset(0x228)] public ConfigBase UiControlConfig;
    [FieldOffset(0x338)] public ConfigBase UiControlGamepadConfig;
}
