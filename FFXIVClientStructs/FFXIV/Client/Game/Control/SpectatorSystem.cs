using FFXIVClientStructs.FFXIV.Client.Game.Character;
using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Client.Game.Control;

// Client::Game::Control::SpectatorSystem
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0xD0)]
public unsafe partial struct SpectatorSystem {
    [FieldOffset(0x08), FixedSizeArray] internal FixedSizeArray8<SpectatorSpot> _spectatorSpots;
    [FieldOffset(0xAC)] public uint FocusObjectId;
    [FieldOffset(0xB0)] public uint FocusSpotIndex;
    [FieldOffset(0xB4)] public float FocusX;
    [FieldOffset(0xB8)] public float FocusY;
    [FieldOffset(0xBC)] public float FocusZ;
    [FieldOffset(0xC0)] public float FocusDirH;
    [FieldOffset(0xC4)] public float FocusDirV;

    /// <summary> Moves the spectator camera to a specific object. </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 83 ?? ?? ?? ?? 45 85 FF")]
    public partial void FocusOnObject(uint objectId);

    /// <summary> Moves the spectator camera to a spot at this index. </summary>
    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 0F B6 86 ?? ?? ?? ?? 3B D8")]
    public partial void FocusOnSpot(uint index, bool a3);

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x14)]
    public unsafe partial struct SpectatorSpot {
        [FieldOffset(0x00)] public float X; // Spectator.X
        [FieldOffset(0x04)] public float Y; // Spectator.Y
        [FieldOffset(0x08)] public float Z; // Spectator.Z
        [FieldOffset(0x0C)] public float DirH; // Spectator.DirH
        [FieldOffset(0x10)] public float DirV; // Spectator.DirV
    }
}
