namespace FFXIVClientStructs.Havok.Animation.Playback.Multithreaded;

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe struct hkaJobDoneNotifier {
    [FieldOffset(0x00)] public void* hkSemaphore;
    [FieldOffset(0x08)] public uint* Flag;
}
