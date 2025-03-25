namespace FFXIVClientStructs.FFXIV.Client.Game.Object;

// Client::Game::Object::HousingObject
//   Client::Game::Object::GameObject
[GenerateInterop(isInherited: true)]
[Inherits<GameObject>]
[StructLayout(LayoutKind.Explicit, Size = 0x1C0)]
public unsafe partial struct HousingObject {
    [FieldOffset(0x1A8)] public HousingObjectId HousingObjectId;

    /// <remarks> Index in <see cref="IndoorTerritory.Furniture"/> or <see cref="OutdoorTerritory.Furniture"/> depending on <see cref="HousingObjectId.Type"/>. </remarks>
    [FieldOffset(0x1AE)] public short HousingFurnitureIndex;
}

[StructLayout(LayoutKind.Explicit, Size = 0x04)]
public struct HousingObjectId {
    [FieldOffset(0x00), CExportIgnore] public uint Id;
    [FieldOffset(0x00)] public ushort EntryId;
    [FieldOffset(0x02)] public HousingObjectType Type;
}

public enum HousingObjectType : ushort {
    YardObject = 2,
    Furniture = 3,
}
