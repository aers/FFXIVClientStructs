using System.Numerics;

namespace FFXIVClientStructs.Apricot.Data;

[StructLayout(LayoutKind.Explicit)]
public struct RgbFunctionCurve {
	[FieldOffset(0x0)] public uint Data;
    // not a fixed size array, not sure how else to handle this?
    [FieldOffset(0x4), FixedSizeArray] internal unsafe fixed byte _keys[0x10];

	public ushort KeyCount => (ushort)(this.Data >> 9);

    public unsafe RgbKey* GetKey(int index) {
        if (index < 0 || index >= this.KeyCount)
            throw new IndexOutOfRangeException($"{index}");
        
        fixed (void* ptr = this._keys)
            return (RgbKey*)ptr + index;
    }

	[StructLayout(LayoutKind.Explicit, Size = 0x10)]
	public struct RgbKey {
		[FieldOffset(0x0)] public uint Data;
		[FieldOffset(0x4)] public Vector3 Color;
	}
}
