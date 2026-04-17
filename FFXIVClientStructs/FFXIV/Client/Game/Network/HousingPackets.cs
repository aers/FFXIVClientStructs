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
