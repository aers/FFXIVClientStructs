namespace FFXIVClientStructs.FFXIV.Client.Game;

[StructLayout(LayoutKind.Explicit, Size = 0x2E8)]
public unsafe partial struct RetainerManager
{
    [StaticAddress("48 8D 0D ?? ?? ?? ?? 49 89 46", 3)]
    public static partial RetainerManager* Instance();

    [FieldOffset(0x000)] public RetainerList Retainer;
    [FieldOffset(0x2D0)] public fixed byte DisplayOrder[10];
    [FieldOffset(0x2DA)] public byte Ready;
    [FieldOffset(0x2DB)] public byte RetainerCount;

    /// <summary>
    /// Contains the Retainer.RetainerId of the last retainer to be selected.
    /// </summary>
    [FieldOffset(0x2E0)] public ulong LastSelectedRetainerId;

    [MemberFunction("E8 ?? ?? ?? ?? 48 85 C0 74 05 4C 39 20")]
    public partial RetainerList.Retainer* GetRetainerBySortedIndex(uint sortedIndex);

    [StructLayout(LayoutKind.Explicit, Size = 0x2D0)]
    public struct RetainerList
    {
        [FieldOffset(0x00)] private fixed byte Retainers[0x2D0];
        [FieldOffset(0x48 * 0)] public Retainer Retainer0;
        [FieldOffset(0x48 * 1)] public Retainer Retainer1;
        [FieldOffset(0x48 * 2)] public Retainer Retainer2;
        [FieldOffset(0x48 * 3)] public Retainer Retainer3;
        [FieldOffset(0x48 * 4)] public Retainer Retainer4;
        [FieldOffset(0x48 * 5)] public Retainer Retainer5;
        [FieldOffset(0x48 * 6)] public Retainer Retainer6;
        [FieldOffset(0x48 * 7)] public Retainer Retainer7;
        [FieldOffset(0x48 * 8)] public Retainer Retainer8;
        [FieldOffset(0x48 * 9)] public Retainer Retainer9;

        public Retainer* this[int index]
        {
            get
            {
                if (index is < 0 or >= 10) return null;
                fixed (byte* p = Retainers)
                {
                    var r = (Retainer*) p;
                    return r + index;
                }
            }
        }

        [StructLayout(LayoutKind.Explicit, Size = 0x48)]
        public struct Retainer
        {
            [FieldOffset(0x00)] public ulong RetainerID;
            [FieldOffset(0x08)] public fixed byte Name[0x20];
            [FieldOffset(0x28)] public bool Available;
            [FieldOffset(0x29)] public byte ClassJob;
            [FieldOffset(0x2A)] public byte Level;
            [FieldOffset(0x2B)] public byte ItemCount;
            [FieldOffset(0x2C)] public uint Gil;
            [FieldOffset(0x30)] public RetainerTown Town;
            [FieldOffset(0x31)] public byte MarkerItemCount;
            [FieldOffset(0x34)] public uint MarketExpire; // 7 Days after last opened retainer
            [FieldOffset(0x38)] public uint VentureID;
            [FieldOffset(0x3C)] public uint VentureComplete;
        }

        public enum RetainerTown : byte
        {
            LimsaLominsa = 1,
            Gridania = 2,
            Uldah = 3,
            Ishgard = 4,
            Kugane = 7,
            Crystarium = 10,
            OldSharlayan = 12
        }
    }
}