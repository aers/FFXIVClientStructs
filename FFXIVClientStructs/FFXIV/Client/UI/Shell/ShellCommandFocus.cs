using FFXIVClientStructs.FFXIV.Component.Shell;

namespace FFXIVClientStructs.FFXIV.Client.UI.Shell;

[GenerateInterop]
[Inherits<ShellCommandInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x08)]
public unsafe partial struct ShellCommandFocus {
    public static ShellCommandFocus* Instance() {
        var shellModule = RaptureShellModule.Instance();
        var focusCommand = shellModule == null ? null : shellModule->ShellCommands.TextCommands[265].Value;
        return (ShellCommandFocus*)focusCommand;
    }
}
