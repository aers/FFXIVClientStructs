namespace FFXIVClientStructs.FFXIV.Client.System.Scheduler.Object;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x98)]
public unsafe partial struct ObjectManager {
    [FieldOffset(0x40)] private fixed byte CriticalSection1[40];
    [FieldOffset(0x68)] private fixed byte CriticalSection2[40];
}
