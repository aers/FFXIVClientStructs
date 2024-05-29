namespace FFXIVClientStructs.FFXIV.Client.System.Configuration;

// Client::System::Configuration::SystemConfig
//   Common::Configuration::SystemConfig
//     Common::Configuration::ConfigBase
//       Client::System::Common::NonCopyable
[StructLayout(LayoutKind.Explicit, Size = 0x450)]
[GenerateInterop]
[Inherits<Common.Configuration.SystemConfig>]
public partial struct SystemConfig {
    [MemberFunction("E8 ?? ?? ?? ?? 66 85 C0 74 19")]
    public partial uint GetLastWorldId();
}
