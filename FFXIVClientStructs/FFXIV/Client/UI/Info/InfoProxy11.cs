using System.Runtime.CompilerServices;

namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

[StructLayout(LayoutKind.Explicit, Size = 0x5B98)]
public unsafe partial struct InfoProxy11 {
    [FieldOffset(0x00)] public InfoProxyPageInterface InfoProxyPageInterface;

    /// <summary>
    /// The ItemID that has been searched.
    /// </summary>
    [FieldOffset(0x20)] public uint SelectedItemId;

    [FieldOffset(0x30)] private fixed byte InternalListings[MarketBoardListing.Size * 100];

    public Span<MarketBoardListing> Listings => new(Unsafe.AsPointer(ref this.InternalListings[0]), (int)this.ListingCount);

    [FieldOffset(0x4810)] public uint ListingCount;

    [VirtualFunction(6)]
    public partial void EndRequest();

    [MemberFunction("41 83 F8 14 77 3C")]
    public partial void ProcessItemHistory(nint a2, nint a3, nint a4);

    [MemberFunction("44 88 4C 24 ?? 44 89 44 24 ?? 48 89 54 24 ?? 53")]
    public partial nint ProcessItemHistory_Internal(nint a2, uint a3, char a4);

    [MemberFunction("E8 ?? ?? ?? ?? 8B 5B 04 85 DB")]
    public partial nint ProcessRequestResult(nint a2, nint a3, nint a4, int a5, byte a6, int a7);
}

[StructLayout(LayoutKind.Explicit, Size = Size)]
public unsafe struct MarketBoardListing {
    public const int Size = 0xB8;

    // [FieldOffset(0x00)] public Utf8String Unk_0x00;

    [FieldOffset(0x68)] public ulong GlobalItemId;
    [FieldOffset(0x70)] public ulong SellingRetainerContentId; // ??
    [FieldOffset(0x78)] public ulong SellingPlayerContentId;

    [FieldOffset(0x88)] public uint UnitPrice;
    [FieldOffset(0x8C)] public uint TotalTax;
    [FieldOffset(0x90)] public uint Quantity;
    [FieldOffset(0x94)] public uint ItemId;

    // [FieldOffset(0x98)] public uint Unk_0x98;
    // [FieldOffset(0x9A)] public uint Unk_0x9A;
    // [FieldOffset(0x9C)] public uint Unk_0x9C;

    /// <summary>
    /// List of materias associated with this item. Only valid up to the count specified in MateriaCount.
    /// </summary>
    [FieldOffset(0x9E)] public fixed ushort Materia[5];

    [FieldOffset(0xA8)] public bool IsHqItem;
    [FieldOffset(0xA9)] public byte MateriaCount;

    // [FieldOffset(0xAC)] public ushort Unk_0xAC;

    /// <summary>
    /// The Town (from EXD) that this marketboard entry is from.
    /// </summary>
    [FieldOffset(0xB0)] public byte Town;

    // [FieldOffset(0xB1)] public byte UNK_0xB1;
}

