using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Client.UI;

namespace FFXIVClientStructs.FFXIV.Component.Shell;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public unsafe partial struct ShellCommands {
    [FieldOffset(0x08)] public StdMap<uint, Pointer<ShellCommandInterface>> TextCommands;
    [FieldOffset(0x18)] public StdMap<Utf8String, Pointer<DebugCommandInterface>> DebugCommands;

    /// <summary>
    /// Attempts to invoke a "debug" command (e.g. //gm). This method is ultimately called on everything passed to
    /// <see cref="ShellCommandModule.ExecuteCommandInner"/> that isn't actually a text command. This method is
    /// used as a de-facto error handler to catch "invalid" commands, as well as special-case handle plain messages.
    /// </summary>
    /// <param name="message">The message to process/attempt to invoke.</param>
    /// <param name="uiModule">A pointer to <see cref="UIModule"/>.</param>
    /// <returns>Returns 0 if the command was executed, -1 if the command is not found, -2 if the message is not a command at all.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 83 F8 ?? 74 ?? 83 F8 ?? 0F 85 ?? ?? ?? ?? 48 8B 07")]
    public partial int TryInvokeDebugCommand(Utf8String* message, UIModule* uiModule);
}
