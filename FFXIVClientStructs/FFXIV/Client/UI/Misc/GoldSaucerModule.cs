using UserFileEvent = FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager.UserFileEvent;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::GoldSaucerModule
//   Client::UI::Misc::UserFileManager::UserFileEvent
[GenerateInterop]
[Inherits<UserFileEvent>]
[StructLayout(LayoutKind.Explicit, Size = 0x2D0)]
public unsafe partial struct GoldSaucerModule {
    public static GoldSaucerModule* Instance() {
        var uiModule = UIModule.Instance();
        return uiModule == null ? null : uiModule->GetGoldSaucerModule();
    }

    [FieldOffset(0x48), FixedSizeArray] internal FixedSizeArray10<TripleTriadDeck> _decks;
    [FieldOffset(0x28C), FixedSizeArray] internal FixedSizeArray23<ushort> _hotbarMinions; // Companion RowIds
    [FieldOffset(0x2BC), FixedSizeArray] internal FixedSizeArray10<ushort> _unseenCards; // TripleTriadCard RowIds, the ones indicated with a green dot

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x3A)]
    public unsafe partial struct TripleTriadDeck {
        [FieldOffset(0), FixedSizeArray(isString: true)] internal FixedSizeArray48<byte> _name;
        [FieldOffset(0x30), FixedSizeArray] internal FixedSizeArray5<ushort> _cards; // TripleTriadCard RowIds
    }

    [MemberFunction("48 89 5C 24 ?? 57 48 81 EC ?? ?? ?? ?? 48 63 DA 49 8B C0"), GenerateStringOverloads]
    public partial void SetDeckName(int deckIndex, CStringPointer name);

    [MemberFunction("83 FA 09 77 1D")]
    public partial void SetDeckCard(int deckIndex, int cardIndex, ushort cardId);

    [MemberFunction("E8 ?? ?? ?? ?? 33 C9 48 2B D8")]
    public partial TripleTriadDeck* GetDeck(int deckIndex);

    [MemberFunction("E8 ?? ?? ?? ?? 44 0F B7 C3 8B D6")]
    public partial void SetHotbarMinion(int slotIndex, ushort companionId);

    [MemberFunction("E8 ?? ?? ?? ?? 8B D6 0F B7 D8")]
    public partial ushort GetHotbarMinion(int slotIndex);

    [MemberFunction("48 83 EC 28 33 C0 4C 8D 81")]
    public partial int AddUnseenCard(ushort cardId);

    [MemberFunction("40 57 48 83 EC 20 45 33 C9 48 8D B9")]
    public partial int RemoveUnseenCard(ushort cardId);

    [MemberFunction("E8 ?? ?? ?? ?? 49 8D 5D 10")]
    public partial bool IsUnseenCard(ushort cardId);
}
