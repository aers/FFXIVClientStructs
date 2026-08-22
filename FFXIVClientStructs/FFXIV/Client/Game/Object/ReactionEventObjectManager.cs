using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Client.Game.Object;

// Client::Game::Object::ReactionEventObjectManager
// Gatherables/Farm in Island Sanctuary
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x328)]
public unsafe partial struct ReactionEventObjectManager {
    [StaticAddress("48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 33 C9", 3)]
    public static partial ReactionEventObjectManager* Instance();

    [FieldOffset(0x00)] public ReactionEventObject* ReactionEventObjectMemory;
    [FieldOffset(0x08), FixedSizeArray] internal FixedSizeArray100<Pointer<ReactionEventObject>> _reactionEventObjects;

    /// <summary>
    /// Creates a new <see cref="ReactionEventObject"/>.
    /// </summary>
    /// <param name="baseId">The EObj RowId.</param>
    /// <param name="layoutId">A SharedGroupLayoutInstance Id.</param>
    /// <param name="position">The position of the object.</param>
    /// <param name="rotation">The rotation of the object.</param>
    /// <returns>The object index (in the <see cref="ReactionEventObjectManager"/>).</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 0F 28 74 24 ?? 83 F8 ?? 74")]
    public partial int CreateObject(uint baseId, uint layoutId, Vector3* position, float rotation);
}
