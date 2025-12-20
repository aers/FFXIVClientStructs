using FFXIVClientStructs.FFXIV.Client.LayoutEngine.Housing;

namespace FFXIVClientStructs.FFXIV.Client.Game.Object;

// Client::Game::Object::HousingObject
//   Client::Game::Object::GameObject
//   Client::LayoutEngine::Housing::HousingEventListener
[GenerateInterop(isInherited: true)]
[Inherits<GameObject>]
[Inherits<HousingEventListener>]
[StructLayout(LayoutKind.Explicit, Size = 0x1C0)]
public unsafe partial struct HousingObject {
    [FieldOffset(0x1A8)] public HousingObjectId HousingObjectId;

    /// <remarks> Index in <see cref="HousingFurnitureManager.FurnitureMemory"/> of either <see cref="IndoorTerritory"/> or <see cref="OutdoorTerritory"/> depending on <see cref="HousingObjectId.Type"/>. </remarks>
    [FieldOffset(0x1AE)] public short HousingFurnitureIndex;
}

[StructLayout(LayoutKind.Explicit, Size = 0x04)]
public struct HousingObjectId : IEquatable<HousingObjectId>, IComparable<HousingObjectId> {
    [FieldOffset(0x00), CExporterIgnore] public uint Id;
    [FieldOffset(0x00)] public ushort EntryId;
    [FieldOffset(0x02)] public HousingObjectType Type;

    public static implicit operator uint(HousingObjectId id) => id.Id;
    public static unsafe implicit operator HousingObjectId(uint id) => *(HousingObjectId*)&id;
    public bool Equals(HousingObjectId other) => Id == other.Id;
    public override bool Equals(object? obj) => obj is HousingObjectId other && Equals(other);
    public override int GetHashCode() => Id.GetHashCode();
    public static bool operator ==(HousingObjectId left, HousingObjectId right) => left.Id == right.Id;
    public static bool operator !=(HousingObjectId left, HousingObjectId right) => left.Id != right.Id;
    public int CompareTo(HousingObjectId other) => Id.CompareTo(other);
}

public enum HousingObjectType : ushort {
    YardObject = 2,
    Furniture = 3,
}
