using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::GoldSaucerModule
//   Client::UI::Misc::UserFileManager::UserFileEvent
// ctor "E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 49 8B D4 E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 49 8B D4 E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 49 8B D4"
[GenerateInterop, Inherits<UserFileEvent>]
[StructLayout(LayoutKind.Explicit, Size = 0x2C8)]
public unsafe partial struct GoldSaucerModule {
    public static GoldSaucerModule* Instance() => Framework.Instance()->GetUIModule()->GetGoldSaucerModule();

    [FieldOffset(0x40)] internal FixedSizeArray10<TripleTriadDeck> _decks;
    [FieldOffset(0x284), FixedSizeArray] internal FixedSizeArray23<ushort> _hotbarMinions; // Companion RowIds
    [FieldOffset(0x2B4), FixedSizeArray] internal FixedSizeArray10<ushort> _unseenCards; // TripleTriadCard RowIds, the ones indicated with a green dot

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x3A)]
    public unsafe partial struct TripleTriadDeck {
        [FieldOffset(0), FixedSizeArray(isString: true)] internal FixedSizeArray48<byte> _name;
        [FieldOffset(0x30), FixedSizeArray] internal FixedSizeArray5<ushort> _cards; // TripleTriadCard RowIds
    }

    [MemberFunction("48 89 5C 24 ?? 57 48 81 EC ?? ?? ?? ?? 48 63 DA"), GenerateStringOverloads]
    public partial void SetDeckName(int deckIndex, byte* name);

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

    [MemberFunction("E8 ?? ?? ?? ?? 8D 55 10 0F B6 F8")]
    public partial bool IsUnseenCard(ushort cardId);
}
