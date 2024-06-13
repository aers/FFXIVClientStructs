namespace FFXIVClientStructs.FFXIV.Client.System.Configuration;

// Client::System::Configuration::SystemConfig
//   Common::Configuration::SystemConfig
//     Common::Configuration::ConfigBase
//       Client::System::Common::NonCopyable
[GenerateInterop]
[Inherits<Common.Configuration.SystemConfig>]
[StructLayout(LayoutKind.Explicit, Size = 0x450)]
public partial struct SystemConfig {
    [MemberFunction("E8 ?? ?? ?? ?? 66 85 C0 74 1A")]
    public partial uint GetLastWorldId();
}
