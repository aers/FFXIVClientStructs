using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Component.Shell;

[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public struct ShellCommands {
    [FieldOffset(0x08)] public StdMap<uint, Pointer<ShellCommandInterface>> TextCommands;
    [FieldOffset(0x18)] public StdMap<Utf8String, Pointer<DebugCommandInterface>> DebugCommands;
}
