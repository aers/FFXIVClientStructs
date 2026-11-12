namespace FFXIVClientStructs.FFXIV.Client.Game.Network;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x96C)] // at least this big
public partial struct HousingPortalPacket {
    [FieldOffset(0x00)] public HouseId HouseId;
    [FieldOffset(0x08), FixedSizeArray] internal FixedSizeArray60<HouseInfoEntry> _houseInfoEntries;

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x28)]
    public partial struct HouseInfoEntry {
        [FieldOffset(0x00)] public uint HousePrice;
        [FieldOffset(0x04)] public HouseInfoFlags InfoFlags;
        /// <remarks>HousingAppeal RowIds</remarks>
        [FieldOffset(0x05), FixedSizeArray] internal FixedSizeArray3<byte> _houseAppeals;
        [FieldOffset(0x08), FixedSizeArray(isString: true)] internal FixedSizeArray32<byte> _ownerName;
    }

    [Flags]
    public enum HouseInfoFlags : byte {
        PlotOwned = 1 << 0,
        VisitorsAllowed = 1 << 1,
        HasSearchComment = 1 << 2,
        HouseBuilt = 1 << 3,
        OwnedByFC = 1 << 4
    }
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x118)] // at least this big
public partial struct HousingSignboardPacket {
    [FieldOffset(0x00)] public HouseId HouseId;
    [FieldOffset(0x08)] public ulong OwnerId; // Can be either a Player or an FC

    [FieldOffset(0x14)] public bool IsOpen;
    /// <remarks>
    /// Small = 0<br/>
    /// Medium = 1<br/>
    /// Large = 2<br/>
    /// Apartment = 5?
    /// </remarks>
    [FieldOffset(0x15)] public byte Size;
    /// <summary>
    /// See <see cref="Game.EstateType"/>.
    /// </summary>
    [FieldOffset(0x16)] public byte EstateType;
    [FieldOffset(0x17), FixedSizeArray(isString: true)] internal FixedSizeArray21<byte> _name;

    [FieldOffset(0x2E), FixedSizeArray(isString: true)] internal FixedSizeArray193<byte> _greeting;
    [FieldOffset(0xEF), FixedSizeArray(isString: true)] internal FixedSizeArray31<byte> _ownerName;

    [FieldOffset(0x10E), FixedSizeArray(isString: true)] internal FixedSizeArray4<byte> _FCTag;

    /// <remarks>HousingAppeal RowIds</remarks>
    [FieldOffset(0x115), FixedSizeArray] internal FixedSizeArray3<byte> _houseAppeals;
}

[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public struct HousingSignboardPurchaseDetailPacket {
    [FieldOffset(0x00)] public PlotPurchaseType PurchaseType;
    [FieldOffset(0x01)] public PlotPurchaseOwnerType AvailabilityType;
    [FieldOffset(0x02)] public PlotLotteryPeriod LotteryPeriod;
    [FieldOffset(0x03)] public PlotBidStatus BidStatus;
    [FieldOffset(0x04)] public PlotPurchaseOwnerType BidType;

    /// <remarks> Unix timestamp. </remarks>
    [FieldOffset(0x08)] public uint PhaseEndTimestamp;

    /// <remarks> Unix timestamp. </remarks>
    [FieldOffset(0x0C)] public uint ClaimEndTimestamp;

    [FieldOffset(0x10)] public int BidEntryCount;
    [FieldOffset(0x14)] public int BidWinnerNumber1; // Used if BidStatus is PlotBidStatus.Won
    [FieldOffset(0x18)] public int BidWinnerNumber2; // Used if BidStatus is PlotBidStatus.Lost
    [FieldOffset(0x1C)] public int GilToReceive; // Gil to receive for relocating if you won, the refund if you lost or your bid was forfeited
}

[StructLayout(LayoutKind.Explicit, Size = 0x08)]
public struct HousingSignboardPricePacket {
    [FieldOffset(0x00)] public int Price;

    /// <remarks> Unix timestamp. </remarks>
    [FieldOffset(0x04)] public uint NextDevaluationTimestamp;
}

public enum PlotPurchaseType : byte {
    Unavailable = 0,
    FCFS = 1,
    Lottery = 2,
}

public enum PlotPurchaseOwnerType : byte {
    Any = 0,
    FreeCompany = 1,
    Individual = 2,
}

public enum PlotLotteryPeriod : byte {
    Entry = 1,
    Results = 2,
    Unavailable = 3,
}

public enum PlotBidStatus : byte {
    None,
    Placed = 1,
    Won = 2,
    Forfeited = 3,
    Lost = 4,
    LostExpired = 5,
}
