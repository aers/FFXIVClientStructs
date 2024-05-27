using System.Runtime.CompilerServices;
using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

[InfoProxy(InfoProxyId.ItemSearch)]
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

    [FieldOffset(0x56A8)] private fixed byte InternalPlayerRetainers[PlayerRetainerInfo.Size * 10];

    /// <summary>
    /// All retainers currently registered to the player. Needs to be loaded by accessing any retainer's marketboard listings and appears
    /// to be a cache of some sort.
    /// </summary>
    public Span<PlayerRetainerInfo> PlayerRetainers => new(Unsafe.AsPointer(ref this.InternalPlayerRetainers[0]), (int)this.PlayerRetainerCount);

    [FieldOffset(0x5B58)] public uint PlayerRetainerCount;

    [FieldOffset(0x5678)] public uint RetainerListingCount;

    [FieldOffset(0x5680)] public LastPurchasedMarketboardItem LastPurchasedMarketboardItem;

    [FieldOffset(0x5B68)] public fixed uint WishlistItems[10];
    [FieldOffset(0x5B90)] public uint WishlistSize;

    // [FieldOffset(0x5B96)] public byte Unk_0x5B96; // controls if AddData gets called? (ResultsPresent?)

    /// <summary>
    /// Loads received marketboard data into the <see cref="Listings"/> array. This method is directly responsible for translating the inbound
    /// <c>MarketBoardOfferings</c> packet into <see cref="MarketBoardListing"/> structs.
    /// </summary>
    /// <param name="packetPtr">A pointer to the packet to load in.</param>
    /// <param name="count">The number of entries to load. Always appears to be 10.</param>
    /// <returns>Returns an nint, probably.</returns>
    [VirtualFunction(1)]
    public partial nint AddData(nint packetPtr, uint count = 10);

    [VirtualFunction(2)]
    public partial void RemoveData(); // nullsub. including for completeless only.

    /// <summary>
    /// Sets the value of <see cref="InfoProxyInterface.EntryCount"/> to 0 for this proxy. Does not actually delete any data from any arrays. 
    /// </summary>
    [VirtualFunction(3)]
    public partial void ClearData();

    /// <summary>
    /// Send a search request to the server based on the currently selected <see cref="SearchItemId"/> and other data. WILL generate a network request.
    /// </summary>
    /// <returns>Returns true if the packet was sent (?), false otherwise.</returns>
    [VirtualFunction(5)]
    public partial bool RequestData();

    /// <summary>
    /// (Currently) a nullsub that gets called by <see cref="AddPage"/> after all data is received from the server.
    /// </summary>
    /// <remarks>
    /// Technically returns <c>0</c>, but the return does not seem to be used at all.
    /// </remarks>
    [VirtualFunction(6)]
    public partial void EndRequest();

    /// <summary>
    /// Handles the <c>MarketBoardOfferings</c> packet and calls <see cref="AddData"/> to load into the InfoProxy. Will also handle dispatching
    /// packets to the server for pagination/fetch purposes. Calls <see cref="EndRequest"/> when all data is loaded.
    /// </summary>
    /// <param name="packetPtr">A pointer to the packet data to load in.</param>
    [VirtualFunction(12)]
    public partial void AddPage(nint packetPtr);

    [MemberFunction("41 83 F8 14 77 3C")]
    public partial void ProcessItemHistory(nint a2, nint a3, nint a4);

    [MemberFunction("44 88 4C 24 ?? 44 89 44 24 ?? 48 89 54 24 ?? 53")]
    public partial nint ProcessItemHistory_Internal(nint a2, uint a3, char a4);

    [MemberFunction("E8 ?? ?? ?? ?? 8B 5B 04 85 DB")]
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

    /// <summary>
    /// The index of the retainer's inventory slot in the RetainerMarket inventory.
    /// </summary>
    [FieldOffset(0x98)] public ushort ContainerIndex;

    [FieldOffset(0x9A)] public ushort Durability; // unused (?)
    [FieldOffset(0x9C)] public ushort Spiritbond; // unused (?)

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

    [FieldOffset(0xB1)] public byte StainId;
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
