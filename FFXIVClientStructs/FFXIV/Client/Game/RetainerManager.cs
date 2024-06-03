namespace FFXIVClientStructs.FFXIV.Client.Game;

// Client::Game::RetainerManager
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x310)]
public unsafe partial struct RetainerManager {
    [StaticAddress("48 8D 0D ?? ?? ?? ?? 48 8B 18", 3)]
    public static partial RetainerManager* Instance();

    [FieldOffset(0x000), FixedSizeArray] internal FixedSizeArray10<Retainer> _retainers;
    [FieldOffset(0x2D0), FixedSizeArray] internal FixedSizeArray10<byte> _displayOrder;
    [FieldOffset(0x2DA)] public byte Ready;
    [FieldOffset(0x2DB)] public byte MaxRetainerEntitlement;

    /// <summary>
    /// Contains the Retainer.RetainerId of the last retainer to be selected.
    /// </summary>
    [FieldOffset(0x2E0)] public ulong LastSelectedRetainerId;
    [FieldOffset(0x2E8)] public uint RetainerObjectId;

    [MemberFunction("83 FA 0A 73 21")]
    public partial Retainer* GetRetainerBySortedIndex(uint sortedIndex);

    /// <summary>
    /// Counts the number of Retainers that have an assigned ID.
    /// </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 48 8B CB 8B E8 E8 ?? ?? ?? FF 8B")]
    public partial byte GetRetainerCount();

    /// <summary>
    /// Will return the Retainer referenced by LastSelectedRetainerId.
    /// </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 45 33 DB 45 8D 73 01")]
    public partial Retainer* GetActiveRetainer();

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x48)]
    public partial struct Retainer {
        [FieldOffset(0x00)] public ulong RetainerId;
        [FieldOffset(0x08), FixedSizeArray(isString: true)] internal FixedSizeArray32<byte> _name;
        [FieldOffset(0x28)] public bool Available;
        [FieldOffset(0x29)] public byte ClassJob;
        [FieldOffset(0x2A)] public byte Level;
        [FieldOffset(0x2B)] public byte ItemCount;
        [FieldOffset(0x2C)] public uint Gil;
        [FieldOffset(0x30)] public RetainerTown Town;
        [FieldOffset(0x31)] public byte MarketItemCount;
        [FieldOffset(0x34)] public uint MarketExpire; // 7 Days after last opened retainer
        [FieldOffset(0x38)] public uint VentureId;
        [FieldOffset(0x3C)] public uint VentureComplete;
    }

    public enum RetainerTown : byte {
        LimsaLominsa = 1,
        Gridania = 2,
        Uldah = 3,
        Ishgard = 4,
        Kugane = 7,
        Crystarium = 10,
        OldSharlayan = 12
    }
}
