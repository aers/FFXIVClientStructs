using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonTripleTriad
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("TripleTriad")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x1000)]
public unsafe partial struct AddonTripleTriad {
    [FieldOffset(0x238)] public TurnState TurnState;

    [FieldOffset(0x240), FixedSizeArray] internal FixedSizeArray5<TripleTriadCard> _blueDeck;
    [FieldOffset(0x588), FixedSizeArray] internal FixedSizeArray5<TripleTriadCard> _redDeck;
    [FieldOffset(0x8D0), FixedSizeArray] internal FixedSizeArray9<TripleTriadCard> _board;
}

[StructLayout(LayoutKind.Explicit, Size = 0xA8)]
public unsafe partial struct TripleTriadCard {
    [FieldOffset(0x8)] public AtkComponentBase* CardDropControl;
    [FieldOffset(0x80)] public byte CardRarity; // 1..5
    [FieldOffset(0x81)] public CardType CardType;
    [FieldOffset(0x82)] public CardOwner CardOwner;
    [FieldOffset(0x83)] public byte NumSideU;
    [FieldOffset(0x84)] public byte NumSideD;
    [FieldOffset(0x85)] public byte NumSideR;
    [FieldOffset(0x86)] public byte NumSideL;
    [FieldOffset(0x87)] private byte Unk87; // constant tied to npcs
    [FieldOffset(0x88)] private byte Unk88; // fixed per card, not Id
    [FieldOffset(0x89)] private byte Unk89; // fixed per card, 41/42
    [FieldOffset(0xA4)] public bool HasCard;
}

public enum CardType : byte {
    None = 0,
    Primal = 1,
    Scion = 2,
    Beastman = 3,
    Garland = 4,
}

public enum CardOwner : byte {
    Empty = 0,
    Blue = 1,
    Red = 2,
}

public enum TurnState : byte {
    Waiting = 0,
    NormalMove = 1,
    MaskedMove = 2, // Order/Chaos
}
