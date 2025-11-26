using FFXIVClientStructs.FFXIV.Client.LayoutEngine;

namespace FFXIVClientStructs.FFXIV.Client.System.Scheduler.Clip;

[GenerateInterop]
[Inherits<BaseClip>]
[StructLayout(LayoutKind.Explicit, Size = 0xD0)]
public partial struct C013 {
    [FieldOffset(0xA0)] public Transform Transform;
}
