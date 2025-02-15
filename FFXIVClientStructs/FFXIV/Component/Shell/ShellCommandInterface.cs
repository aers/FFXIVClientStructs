using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Component.Shell;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x08)]
public unsafe partial struct ShellCommandInterface {
    [VirtualFunction(1)]
    public partial int ExecuteCommand(CommandContext* context, void* source);

    [StructLayout(LayoutKind.Explicit, Size = 0x30)]
    public struct CommandContext {
        [FieldOffset(0x00)] public ushort TextCommandId;

        [FieldOffset(0x18)] public StdVector<Utf8String> StringArgs;
    }
}
