using System.Numerics;

namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

// Client::Game::UI::MarkingController
[StructLayout(LayoutKind.Explicit, Size = 0x2E0)]
public unsafe partial struct MarkingController {
    [StaticAddress("48 8D 0D ?? ?? ?? ?? 4C 8B 85", 3)]
    public static partial MarkingController* Instance();

    [FieldOffset(0x10)] public fixed long MarkerArray[17]; //17 * GameObjectId
    [FieldOffset(0x98)] public fixed uint LetterMarkerArray[26]; //26 * ObjectId
    [FieldOffset(0x100)] public fixed long MarkerTimeArray[17]; //(1000 * QueryPerformanceCounter / QueryPerformanceFrequency)

    [FixedSizeArray<FieldMarker>(8)]
    [FieldOffset(0x1E0)] public fixed byte FieldMarkerArray[8 * 0x20];
}

[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public struct FieldMarker {
    [FieldOffset(0x00)] public Vector3 Position;
    [FieldOffset(0x10)] public int X;
    [FieldOffset(0x14)] public int Y;
    [FieldOffset(0x18)] public int Z;
    [FieldOffset(0x1C)] public bool Active;
}
