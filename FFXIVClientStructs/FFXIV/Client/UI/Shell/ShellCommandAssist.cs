using FFXIVClientStructs.FFXIV.Component.Shell;

namespace FFXIVClientStructs.FFXIV.Client.UI.Shell;

[GenerateInterop]
[Inherits<ShellCommandInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x08)]
public unsafe partial struct ShellCommandAssist {
    public static ShellCommandAssist* Instance() {
        var shellModule = RaptureShellModule.Instance();
        var assistCommand = shellModule == null ? null : shellModule->ShellCommands.TextCommands[258].Value;
        return (ShellCommandAssist*)assistCommand;
    }
}
