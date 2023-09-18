using System.Runtime.CompilerServices;

namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

[StructLayout(LayoutKind.Explicit, Size = 0x5B98)]
[VTableAddress("48 8D 05 ?? ?? ?? ?? 48 8B F1 48 89 01 48 8D 99 ?? ?? ?? ?? BF ?? ?? ?? ?? 0F 1F 84 00 ?? ?? ?? ?? 48 83 EB 78 48 8B CB E8 ?? ?? ?? ?? 48 83 EF 01 75 EE 8D 5F 14", 3)]
public unsafe partial struct InfoProxyItemSearch {
    [FieldOffset(0x00)] public InfoProxyPageInterface InfoProxyPageInterface;

    /// <summary>
    /// The ItemID that has been searched.
    /// </summary>
    [FieldOffset(0x20)] public uint SearchItemId;

    // Following are used for requesting item data from the server in RequestData
    // [FieldOffset(0x24)] public byte Unk_0x24; // ?
    // [FieldOffset(0x25)] public byte Unk_0x25; // ?
    // [FieldOffset(0x28)] public byte Unk_0x28;

    [FieldOffset(0x30)] private fixed byte InternalListings[MarketBoardListing.Size * 100];

    /// <summary>
    /// All items currently available on the general marketboard for the last specified search term (found in <see cref="SearchItemId"/>.
    /// Can be empty if no results were found.
    /// </summary>
    public Span<MarketBoardListing> Listings => new(Unsafe.AsPointer(ref this.InternalListings[0]), (int)this.ListingCount);

    [FieldOffset(0x4810)] public uint ListingCount;

    [FieldOffset(0x4818)] private fixed byte InternalRetainerListings[MarketBoardListing.Size * 20];

    /// <summary>
    /// All items currently available for sale from the last targeted retainer. Can be empty if no results were found.
    /// </summary>
    public Span<MarketBoardListing> RetainerListings =>
        new(Unsafe.AsPointer(ref this.InternalRetainerListings[0]), (int)this.RetainerListingCount);

    [FieldOffset(0x5678)] public uint RetainerListingCount;

    [FieldOffset(0x5680)] public LastPurchasedMarketboardItem LastPurchasedMarketboardItem;

    [FieldOffset(0x5B68)] public fixed uint WishlistItems[10];
    [FieldOffset(0x5B90)] public uint WishlistSize;

    // [FieldOffset(0x5B96)] public byte Unk_0x5B96; // controls if AddData gets called? (ResultsPresent?)

    [VirtualFunction(6)]
    public partial void EndRequest();

    [MemberFunction("41 83 F8 14 77 3C")]
    public partial void ProcessItemHistory(nint a2, nint a3, nint a4);

    [MemberFunction("44 88 4C 24 ?? 44 89 44 24 ?? 48 89 54 24 ?? 53")]
    public partial nint ProcessItemHistory_Internal(nint a2, uint a3, char a4);

    [MemberFunction("E8 ?? ?? ?? ?? 8B 5B 04 85 DB")]
    public partial nint ProcessRequestResult(nint a2, nint a3, nint a4, int a5, byte a6, int a7);

    /// <summary>
    /// Copies the specified market board listing into the <see cref="LastPurchasedMarketboardItem"/> fields of the InfoProxy.
    /// </summary>
    /// <param name="listing">The listing to copy.</param>
    /// <returns>Returns true if successful.</returns>
    [MemberFunction("40 56 48 8B C2")]
    public partial bool SetLastPurchasedItem(MarketBoardListing* listing);
}

[StructLayout(LayoutKind.Explicit, Size = Size)]
public unsafe struct MarketBoardListing {
    public const int Size = 0xB8;

    // [FieldOffset(0x00)] public Utf8String Unk_0x00;

    [FieldOffset(0x68)] public ulong ListingId;
    [FieldOffset(0x70)] public ulong SellingRetainerContentId; // ??
    [FieldOffset(0x78)] public ulong SellingPlayerContentId;

    [FieldOffset(0x88)] public uint UnitPrice;
    [FieldOffset(0x8C)] public uint TotalTax;
    [FieldOffset(0x90)] public uint Quantity;
    [FieldOffset(0x94)] public uint ItemId;

    // [FieldOffset(0x98)] public ushort Unk_0x98; // From Packet 0x36
    // [FieldOffset(0x9A)] public ushort Durability; // From Packet 0x38 (per Kara)
    // [FieldOffset(0x9C)] public ushort Spiritbond; // From Packet 0x3A (per Kara)

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
    [FieldOffset(0xB0)] public byte TownId;

    // [FieldOffset(0xB1)] public byte UNK_0xB1;
}

[StructLayout(LayoutKind.Explicit)]
public struct LastPurchasedMarketboardItem {
    [FieldOffset(0x00)] public ulong SellingRetainerContentId;
    [FieldOffset(0x08)] public ulong ListingId;
    [FieldOffset(0x10)] public uint ItemId;
    [FieldOffset(0x14)] public uint Quantity;
    [FieldOffset(0x18)] public uint UnitPrice;
    [FieldOffset(0x1C)] public uint TotalTax;
    // [FieldOffset(0x20)] public uint Unk_0x20; // Filled from 0x98
    [FieldOffset(0x22)] public bool IsHqItem;
    [FieldOffset(0x23)] public byte TownId;

    public bool Present => ListingId != 0;
}
