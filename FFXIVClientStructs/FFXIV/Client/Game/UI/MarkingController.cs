using System.Numerics;

namespace FFXIVClientStructs.FFXIV.Client.Game.UI; 

[StructLayout(LayoutKind.Explicit, Size = 0x2B0)]
public unsafe partial struct MarkingController
{
	[FieldOffset(0x10)] public fixed long MarkerArray[14]; //14 * GameObjectId
	[FieldOffset(0x80)] public fixed uint LetterMarkerArray[26]; //26 * ObjectId
	[FieldOffset(0xE8)] public fixed long MarkerTimeArray[14]; //(1000 * QueryPerformanceCounter / QueryPerformanceFrequency)

	[FixedSizeArray<FieldMarker>(8)]
	[FieldOffset(0x1B0)] public fixed byte FieldMarkerArray[8 * 0x20];

	[StaticAddress("48 8D 0D ?? ?? ?? ?? 4C 8B 85", 3)]
	public static partial MarkingController* Instance();
}

[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public struct FieldMarker
{
	[FieldOffset(0x00)] public Vector3 Position;
	[FieldOffset(0x10)] public int X;
	[FieldOffset(0x14)] public int Y;
	[FieldOffset(0x18)] public int Z;
	[FieldOffset(0x1C)] public bool Active;
}