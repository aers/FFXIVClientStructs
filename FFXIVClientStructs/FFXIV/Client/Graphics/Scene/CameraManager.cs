namespace FFXIVClientStructs.FFXIV.Client.Graphics.Scene; 

[StructLayout(LayoutKind.Explicit, Size = 0x120)]
public unsafe partial struct CameraManager {

	[FieldOffset(0x50)] public int CameraIndex;
	[FixedSizeArray<Pointer<Camera>>(14)]
	[FieldOffset(0x58)] public fixed byte CameraArray[14 * 8]; //14 * Camera*

	public Camera* CurrentCamera {
		get {
			fixed (byte* ptr = CameraArray)
				return ((Camera**)ptr)[CameraIndex];
		}
	}

	[StaticAddress("48 8B 05 ?? ?? ?? ?? 48 63 3A", 3, isPointer: true)]
	public static partial CameraManager* Instance();
}