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
}
