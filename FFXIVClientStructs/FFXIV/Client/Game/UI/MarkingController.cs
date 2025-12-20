using System.Numerics;
using FFXIVClientStructs.FFXIV.Client.Game.Object;

namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

// Client::Game::UI::MarkingController
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x2E0)]
public unsafe partial struct MarkingController {
    [StaticAddress("48 8D 0D ?? ?? ?? ?? 4C 8B 85", 3)]
    public static partial MarkingController* Instance();

    [FieldOffset(0x10), FixedSizeArray] internal FixedSizeArray17<GameObjectId> _markers; //17 * GameObjectId
    [FieldOffset(0x98), FixedSizeArray] internal FixedSizeArray26<uint> _letterMarkers; //26 * ObjectId
    [FieldOffset(0x100), FixedSizeArray] internal FixedSizeArray17<long> _markerTimes; //(1000 * QueryPerformanceCounter / QueryPerformanceFrequency)

    [FieldOffset(0x1E0), FixedSizeArray] internal FixedSizeArray8<FieldMarker> _fieldMarkers;

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 EB 5C")]
    public partial byte PlaceFieldMarker(uint index, Vector3* position);

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 75 1B B0 01")]
    public partial byte PlacePreset(MarkerPresetPlacement* placement);

    /// <remarks>
    /// 0 - Success <br/>
    /// 1 - Invalid index <br/>
    /// 2 - Operation lock (too frequent) (500ms) <br/>
    /// 3 - All markers pending <br/>
    /// 4 - In combat <br/>
    /// 5 - No markers allowed in territory <br/>
    /// </remarks>
    [MemberFunction("E8 ?? ?? ?? ?? EB D8 83 FB 09")]
    public partial byte ClearFieldMarker(uint index);

    /// <remarks>
    /// 0 - Success <br/>
    /// 1 - Invalid index <br/>
    /// 2 - Operation lock (too frequent) (500ms) <br/>
    /// 3 - All markers pending <br/>
    /// 4 - In combat <br/>
    /// 5 - No markers allowed in territory <br/>
    /// </remarks>
    [MemberFunction("41 55 48 83 EC 50 4C 8B E9")]
    public partial byte ClearFieldMarkers();
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x68)]
public partial struct MarkerPresetPlacement {
    [FieldOffset(0x00), FixedSizeArray] internal FixedSizeArray8<bool> _active;
    [FieldOffset(0x08), FixedSizeArray] internal FixedSizeArray8<int> _x;
    [FieldOffset(0x28), FixedSizeArray] internal FixedSizeArray8<int> _y;
    [FieldOffset(0x48), FixedSizeArray] internal FixedSizeArray8<int> _z;
}

[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public struct FieldMarker {
    [FieldOffset(0x00)] public Vector3 Position;
    [FieldOffset(0x10)] public int X;
    [FieldOffset(0x14)] public int Y;
    [FieldOffset(0x18)] public int Z;
    [FieldOffset(0x1C)] public bool Active;
}
