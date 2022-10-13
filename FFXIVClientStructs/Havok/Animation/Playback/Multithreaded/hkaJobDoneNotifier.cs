namespace FFXIVClientStructs.Havok;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct hkaJobDoneNotifier
{
	public void* hkSemaphore;
	public uint* Flag;
}