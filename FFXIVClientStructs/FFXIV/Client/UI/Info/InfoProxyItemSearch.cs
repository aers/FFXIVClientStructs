using System.Runtime.CompilerServices;
using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

// Client::UI::Info::InfoProxyItemSearch
//   Client::UI::Info::InfoProxyPageInterface
//     Client::UI::Info::InfoProxyInterface
[InfoProxy(InfoProxyId.ItemSearch)]
[GenerateInterop]
[Inherits<InfoProxyPageInterface>]
[VirtualTable("48 8D 05 ?? ?? ?? ?? 48 8B F1 48 89 01 48 8D 99 ?? ?? ?? ?? BF ?? ?? ?? ?? 0F 1F 84 00 ?? ?? ?? ?? 48 83 EB 78 48 8B CB E8 ?? ?? ?? ?? 48 83 EF 01 75 EE 8D 5F 14", 3)]
[StructLayout(LayoutKind.Explicit, Size = 0x5B98)]
public unsafe partial struct InfoProxyItemSearch {

    /// <summary>
    /// The ItemID that has been searched.
    /// </summary>
    [FieldOffset(0x20)] public uint SearchItemId;

    // Following are used for requesting item data from the server in RequestData
    // [FieldOffset(0x24)] public byte Unk_0x24; // ?
    // [FieldOffset(0x25)] public byte Unk_0x25; // ?
    // [FieldOffset(0x28)] public byte Unk_0x28;

    /// <summary>
    /// All items currently available on the general marketboard for the last specified search term (found in <see cref="SearchItemId"/>.
    /// Can be empty if no results were found.
    /// </summary>
    [FieldOffset(0x30), FixedSizeArray] internal FixedSizeArray100<MarketBoardListing> _listings;

    [FieldOffset(0x4810)] public uint ListingCount;

    /// <summary>
    /// All items currently available for sale from the last targeted retainer. Can be empty if no results were found.
    /// </summary>
    [FieldOffset(0x4818), FixedSizeArray] internal FixedSizeArray20<MarketBoardListing> _retainerListings;

    /// <summary>
    /// All retainers currently registered to the player. Needs to be loaded by accessing any retainer's marketboard listings and appears
    /// to be a cache of some sort.
    /// </summary>
    [FieldOffset(0x56A8), FixedSizeArray] internal FixedSizeArray10<PlayerRetainerInfo> _playerRetainers;

    [FieldOffset(0x5B58)] public uint PlayerRetainerCount;

    [FieldOffset(0x5678)] public uint RetainerListingCount;

    [FieldOffset(0x5680)] public LastPurchasedMarketboardItem LastPurchasedMarketboardItem;

    [FieldOffset(0x5B68), FixedSizeArray] internal FixedSizeArray10<uint> _wishlistItems;
    [FieldOffset(0x5B90)] public uint WishlistSize;

    // [FieldOffset(0x5B96)] public byte Unk_0x5B96; // controls if AddData gets called? (ResultsPresent?)

    [MemberFunction("40 57 41 56 48 83 EC 48 83 3A 00")]
    public partial void ProcessItemHistory(nint packet);

    [MemberFunction("E8 ?? ?? ?? ?? 8B 3F 85 FF")]
    public partial nint ProcessRequestResult(nint a2, nint a3, nint a4, int a5, byte a6, int a7);

    /// <summary>
    /// Load player retainer information from a packet into the
    /// </summary>
    /// <param name="packetData"></param>
    /// <param name="retainerCount"></param>
    /// <returns></returns>
    [MemberFunction("41 83 F8 0A 0F 87 ?? ?? ?? ?? 55")]
    public partial nint ProcessPlayerRetainerInfo(nint packetData, uint retainerCount = 0xA);

    /// <summary>
    /// Copies the specified market board listing into the <see cref="LastPurchasedMarketboardItem"/> fields of the InfoProxy.
    /// </summary>
    /// <param name="listing">The listing to copy.</param>
    /// <returns>Returns true if successful.</returns>
    [MemberFunction("40 56 48 8B C2")]
    public partial bool SetLastPurchasedItem(MarketBoardListing* listing);
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = Size)]
public unsafe partial struct MarketBoardListing {
    public const int Size = 0xB8;

    // [FieldOffset(0x00)] public Utf8String Unk_0x00;

    [FieldOffset(0x68)] public ulong ListingId;
    [FieldOffset(0x70)] public ulong SellingRetainerContentId; // ??
    [FieldOffset(0x78)] public ulong SellingPlayerContentId;
    [FieldOffset(0x80)] public ulong ArtisanId;

    [FieldOffset(0x88)] public uint UnitPrice;
    [FieldOffset(0x8C)] public uint TotalTax;
    [FieldOffset(0x90)] public uint Quantity;
    [FieldOffset(0x94)] public uint ItemId;

    /// <summary>
    /// The index of the retainer's inventory slot in the RetainerMarket inventory.
    /// </summary>
    [FieldOffset(0x98)] public ushort ContainerIndex;

    [FieldOffset(0x9A)] public ushort Durability;
    [FieldOffset(0x9C)] public ushort Spiritbond;

    /// <summary>
    /// List of materias associated with this item. Only valid up to the count specified in MateriaCount.
    /// </summary>
    [FieldOffset(0x9E), FixedSizeArray] internal FixedSizeArray5<ushort> _materia;

    [FieldOffset(0xA8)] public bool IsHqItem;
    [FieldOffset(0xA9)] public byte MateriaCount;
    [FieldOffset(0xAA)] public bool IsMannequin;

    // [FieldOffset(0xAC)] public ushort Unk_0xAC;

    /// <summary>
    /// The Town (from EXD) that this marketboard entry is from.
    /// </summary>
    [FieldOffset(0xB0)] public byte TownId;
    [FieldOffset(0xB1)] public byte Stain0Id;
    [FieldOffset(0xB2)] public byte Stain1Id;
}

[StructLayout(LayoutKind.Explicit, Size = 0x24)]
public struct LastPurchasedMarketboardItem {
    [FieldOffset(0x00)] public ulong SellingRetainerContentId;
    [FieldOffset(0x08)] public ulong ListingId;
    [FieldOffset(0x10)] public uint ItemId;
    [FieldOffset(0x14)] public uint Quantity;
    [FieldOffset(0x18)] public uint UnitPrice;
    [FieldOffset(0x1C)] public uint TotalTax;
    [FieldOffset(0x20)] public ushort ContainerIndex;
    [FieldOffset(0x22)] public bool IsHqItem;
    [FieldOffset(0x23)] public byte TownId;

    public bool Present => ListingId != 0;
}

[StructLayout(LayoutKind.Explicit, Size = Size)]
public struct PlayerRetainerInfo {
    public const int Size = 0x78;

    [FieldOffset(0x00)] public ulong RetainerId;
    [FieldOffset(0x08)] public byte TownId;
    [FieldOffset(0x09)] public bool SellingItems;
    // [FieldOffset(0x0A)] public byte Unk_0x0A;

    // [FieldOffset(0x0C)] public int Unk_0x0C; // Some kind of timestamp?
    [FieldOffset(0x10)] public Utf8String Name;
}
