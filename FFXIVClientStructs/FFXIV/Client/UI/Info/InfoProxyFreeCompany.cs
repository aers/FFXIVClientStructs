using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Client.UI.Agent;

namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

[InfoProxy(InfoProxyId.FreeCompany)]
[StructLayout(LayoutKind.Explicit, Size = 0x6E8)]
public unsafe partial struct InfoProxyFreeCompany
{
    [FieldOffset(0x00)] public InfoProxyInterface InfoProxyInterface;
    [FieldOffset(0x20)] public void* Unk20; //Low adress probably high in hierarchy
    [FieldOffset(0x30)] public ulong ID;
    [FieldOffset(0x44)] public GrandCompany GrandCompany;
    [FieldOffset(0x46)] public uint HomeWorldID;
    [FieldOffset(0x59)] public byte Rank;
    [FieldOffset(0x70)] public CrestData Crest;
    [FieldOffset(0x78)] public ushort OnlineMembers;
    [FieldOffset(0x7A)] public ushort TotalMembers;
    [FieldOffset(0x7C)] public fixed byte Name[22];
    [FieldOffset(0x93)] public fixed byte Master[60];
    [FieldOffset(0xD0)] public Utf8String UnkD0;
    [FieldOffset(0x138)] public byte ActiveListItemNum; //0=Topics, 1 = Members, ....
    [FieldOffset(0x139)] public byte MemberTabIndex;
    [FieldOffset(0x13E)] public byte InfoTabIndex;
    [FixedSizeArray<RankData>(14)]
    [FieldOffset(0x178)] public fixed byte RankArray[14 * 0x58];
    //668 after


    //0x100fc0d0
    //40 53 48 81 EC 80 0F 00 00 48 8B 05 E0 47 F9 01 48 33 C4 48 89 84 24 70 0F 00 00 48 8B 0D E6 1E FB 01 8B DA
    [MemberFunction("e8 dc 99 47 ff")]
    public partial void RequestDataForCharacter(uint objectID);

    [StructLayout(LayoutKind.Explicit, Size = 0x58)]
    public struct RankData
    {
        [FieldOffset(0x00)] public fixed byte Permissions[10];
        [FieldOffset(0x20)] public ushort MemberCount;
        [FieldOffset(0x22)] public byte RankNumber;
        [FieldOffset(0x23)] public fixed byte Name[16];//Guessing allowed laength + 0 byte

        public BasicSettings BasicSettingsData => (BasicSettings)((Permissions[1] & 0x7F << 8) + (ushort)Permissions[0]);
        public ChestAccess Items1 => (ChestAccess)(((Permissions[2] & 0x03) << 1) + ((Permissions[1] & 0x80) >> 7) + (Permissions[4] & 0x10 >> 1));
        public ChestAccess Items2 => (ChestAccess)(((Permissions[2] & 0x1C) >> 2) + (Permissions[4] & 0x20 >> 2));
        public ChestAccess Items3 => (ChestAccess)(((Permissions[2] & 0xE0) >> 5) + (Permissions[4] & 0x40 >> 3));
        public ChestAccess Items4 => (ChestAccess)(((Permissions[3] & 0x07) >> 0) + (Permissions[4] & 0x80 >> 4));
        public ChestAccess Items5 => (ChestAccess)(((Permissions[3] & 0x38) >> 3) + (Permissions[5] % 0x01 << 3));
        public ChestAccess Crystals => (ChestAccess)(((Permissions[4] & 1) << 2) + ((Permissions[3] & 0xC0) >> 6) + (Permissions[5] % 0x02 << 2));
        public ChestAccess Gil => (ChestAccess)(((Permissions[4] & 0x0E) >> 1) + (Permissions[5] % 0x04 << 1));
        public HousingAccess Housing => (HousingAccess)((uint)(Permissions[5] >> 3) + (((uint)Permissions[6]) << 5) + (((uint)Permissions[6] & 0x0F) << 13));
        public enum BasicSettings : ushort
        {
            None = 0,
            CompanyProfile = 1,
            RankSettings = 4,
            CrestDetails = 8,
            Invitations = 32,
            Applications = 64,
            MemberDismissal = 128,
            PromotionDemotion = 256,
            CompanyBoard = 512,
            ShortMessage = 2048,
            CompanyCredists = 4096,
            ExecutingActions = 8192,
            DiscardingActions = 16384,
        }
        /// <summary>
        /// Deposit Only is stored at a diferent location
        /// The definition of using bit 4 is virtual and done for ease of use
        /// </summary>
        public enum ChestAccess : byte
        {
            NoAccess = 1,
            ViewOnly = 2,
            FullAccess = 4,
            DepositOnly
        }
        public enum HousingAccess : uint
        {
            EstateHallAccess = 1,
            EstateRenameing = 2,
            GreetingCustomization = 4,
            PurchaseRelinquishLAnd = 8,
            HallConsructionRemoval = 16,
            HallRemodeling = 32,
            NoFurnishingPriv = 64,
            FurnishingPlacement = 128,
            FurnishingPlacementREmoval = 256,
            PaintFixturesFurnishings = 512,
            GuestAccess = 1024,
            MessageBook = 2048,
            Planting = 4096,
            Harvesting = 8192,
            CropDisposal = 16384,
            ChocoboStabling = 32768,
            TrainingChocobo = 65536,
        }
    }
}
