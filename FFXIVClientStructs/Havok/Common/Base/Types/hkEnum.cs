namespace FFXIVClientStructs.Havok;

[StructLayout(LayoutKind.Sequential)]
public struct hkEnum<T, U> where T : unmanaged, Enum where U : unmanaged
{
	public U Storage;
	
	public T Value
	{
		get => (T) Convert.ChangeType(Storage, EnumType);
		set => Storage = (U) (object) value;
	}
	
	private Type EnumType => Enum.GetUnderlyingType(typeof(T));
}