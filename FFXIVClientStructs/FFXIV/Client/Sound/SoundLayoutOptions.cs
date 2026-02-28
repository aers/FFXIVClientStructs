namespace FFXIVClientStructs.FFXIV.Client.Sound;

[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 3)] // size might be incorrect
public partial struct SoundLayoutOptions {
    [FieldOffset(0x00)] public ushort Size;
    [FieldOffset(0x02)] public SoundObjectType Type;
}

public enum SoundObjectType : byte {
    Null = 0,
    AmbientSound = 1,
    DirectionSound = 2,
    PointSound = 3,
    PointDirSound = 4,
    LineSound = 5,
    PolyLineSound = 6,
    SurfaceSound = 7,
    BoardObstruction = 8,
    BoxObstruction = 9,
    PolyLineObstruction = 10,
    PolygonSound = 11,
    BoxExtController = 12,
    LineExtController = 13,
    PolygonObstruction = 14,
}
