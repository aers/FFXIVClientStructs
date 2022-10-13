namespace FFXIVClientStructs.Havok;

// this can be used as hkArrayBase as well
[StructLayout(LayoutKind.Sequential)]
public unsafe struct hkArray<T> where T : unmanaged
{
	public enum hkArrayFlags : uint
	{
		CapacityMask = 0x3FFFFFFF,
		FlagMask = 0xC0000000,
		DontDeallocate = 0x80000000,
		AllocatedFromSpu = 0x40000000,
		ForceSigned = 0xFFFFFFFF,
	}

	public T* Data;
	public int Length;
	public int CapacityAndFlags;

	public int Capacity => CapacityAndFlags & (int)hkArrayFlags.CapacityMask;
	public int Flags => (int) ((uint)CapacityAndFlags & (uint)hkArrayFlags.FlagMask);

	public T this[int index] {
		get => Data[index];
		set => Data[index] = value;
	}

	public T this[uint index] {
		get => Data[index];
		set => Data[index] = value;
	}
}