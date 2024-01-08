using FFXIVClientStructs.FFXIV.Common.Configuration;

namespace FFXIVClientStructs.FFXIV.Client.System.Framework;

[StructLayout(LayoutKind.Explicit, Size = 0x698)]
public struct EnvironmentManager {
    [FieldOffset(0x000)] public Task Task;
    [FieldOffset(0x038)] public ChangeEventInterface ChangeEventInterface;
}
