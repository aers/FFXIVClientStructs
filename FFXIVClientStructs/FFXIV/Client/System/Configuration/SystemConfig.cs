namespace FFXIVClientStructs.FFXIV.Client.System.Configuration;

// Client::System::Configuration::SystemConfig
//   Common::Configuration::SystemConfig
//     Common::Configuration::ConfigBase
//       Client::System::Common::NonCopyable
[GenerateInterop]
[Inherits<Common.Configuration.SystemConfig>]
[StructLayout(LayoutKind.Explicit, Size = 0x450)]
public partial struct SystemConfig {
    [MemberFunction("E8 ?? ?? ?? ?? 0F B7 E8 48 8D 4B")]
    public partial uint GetLastWorldId();
}
