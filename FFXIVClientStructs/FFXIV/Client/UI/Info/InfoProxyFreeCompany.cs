using FFXIVClientStructs.FFXIV.Client.UI.Agent;

namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

// Client::UI::Info::InfoProxyFreeCompany
//   Client::UI::Info::InfoProxyInterface
[InfoProxy(InfoProxyId.FreeCompany)]
[GenerateInterop]
[Inherits<InfoProxyInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x6E8)]
public unsafe partial struct InfoProxyFreeCompany {
    [FieldOffset(0x20)] private void* Unk20; //Low adress probably high in hierarchy
    [FieldOffset(0x30)] public ulong Id;
    [FieldOffset(0x46)] public ushort HomeWorldId;
    [FieldOffset(0x69)] public GrandCompany GrandCompany;
    [FieldOffset(0x6B)] public byte Rank;
    [FieldOffset(0x70)] public CrestData Crest;
    [FieldOffset(0x78)] public ushort OnlineMembers;
    [FieldOffset(0x7A)] public ushort TotalMembers;
    [FieldOffset(0x7C), FixedSizeArray(isString: true)] internal FixedSizeArray22<byte> _name;
    [FieldOffset(0x93), FixedSizeArray(isString: true)] internal FixedSizeArray60<byte> _master;
    [FieldOffset(0xD0)] private Utf8String UnkD0;
    [FieldOffset(0x138)] public byte ActiveListItemNum; //0=Topics, 1 = Members, ....
    [FieldOffset(0x139)] public byte MemberTabIndex;
    [FieldOffset(0x13E)] public byte InfoTabIndex;
    [FieldOffset(0x178), FixedSizeArray] internal FixedSizeArray14<RankData> _ranks;

    [MemberFunction("E8 ?? ?? ?? ?? EB ?? E8 ?? ?? ?? ?? 84 C0 74 ?? BA ?? ?? ?? ?? 48 8B CB")]
    public partial void RequestDataForCharacter(uint entityId);

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x58)]
    public partial struct RankData {
        [FieldOffset(0x00), FixedSizeArray] internal FixedSizeArray10<byte> _permissions;
        [FieldOffset(0x20)] public ushort MemberCount;
        [FieldOffset(0x22)] public byte RankNumber;
        [FieldOffset(0x23), FixedSizeArray(isString: true)] internal FixedSizeArray16<byte> _name;

        public BasicSettings BasicSettingsData => (BasicSettings)((Permissions[1] & 0x7F << 8) + (ushort)Permissions[0]);
        public ChestAccess Items1 => (ChestAccess)(((Permissions[2] & 0x03) << 1) + ((Permissions[1] & 0x80) >> 7) + (Permissions[4] & 0x10 >> 1));
        public ChestAccess Items2 => (ChestAccess)(((Permissions[2] & 0x1C) >> 2) + (Permissions[4] & 0x20 >> 2));
        public ChestAccess Items3 => (ChestAccess)(((Permissions[2] & 0xE0) >> 5) + (Permissions[4] & 0x40 >> 3));
        public ChestAccess Items4 => (ChestAccess)(((Permissions[3] & 0x07) >> 0) + (Permissions[4] & 0x80 >> 4));
        public ChestAccess Items5 => (ChestAccess)(((Permissions[3] & 0x38) >> 3) + (Permissions[5] % 0x01 << 3));
        public ChestAccess Crystals => (ChestAccess)(((Permissions[4] & 1) << 2) + ((Permissions[3] & 0xC0) >> 6) + (Permissions[5] % 0x02 << 2));
        public ChestAccess Gil => (ChestAccess)(((Permissions[4] & 0x0E) >> 1) + (Permissions[5] % 0x04 << 1));
        public HousingAccess Housing => (HousingAccess)
            ((uint)(Permissions[5] >> 3) + (((uint)Permissions[6]) << 5) + (((uint)Permissions[7] & 0x0F) << 13) + (((uint)Permissions[9] & 0x08) << 14));
        public WorkshopAccess Workshop =>
            (WorkshopAccess)(((Permissions[7] & 0xC0) >> 6) + (((uint)Permissions[8]) << 2) + (((uint)Permissions[9] & 0x07) << 10));
        public enum BasicSettings : ushort {
            None = 0,
            CompanyProfile = 1 << 0,
            RankSettings = 1 << 2,
            CrestDetails = 1 << 3,
            Unk4 = 1 << 4,
            Invitations = 1 << 5,
            Applications = 1 << 6,
            MemberDismissal = 1 << 7,
            PromotionDemotion = 1 << 8,
            CompanyBoard = 1 << 9,
            Unk10 = 1 << 10,
            ShortMessage = 1 << 11,
            CompanyCredists = 1 << 12,
            ExecutingActions = 1 << 13,
            DiscardingActions = 1 << 14,
        }
        /// <summary>
        /// Deposit Only is stored at a diferent location
        /// The definition of using bit 4 is virtual and done for ease of use
        /// </summary>
        public enum ChestAccess : byte {
            NoAccess = 1 << 0,
            ViewOnly = 1 << 1,
            FullAccess = 1 << 2,
            DepositOnly = 1 << 3,
        }
        public enum HousingAccess : uint {
            EstateHallAccess = 1 << 0,
            EstateRenameing = 1 << 1,
            GreetingCustomization = 1 << 2,
            PurchaseRelinquishLAnd = 1 << 3,
            HallConsructionRemoval = 1 << 4,
            HallRemodeling = 1 << 5,
            NoFurnishingPriv = 1 << 6,
            FurnishingPlacement = 1 << 7,
            FurnishingPlacementREmoval = 1 << 8,
            PaintFixturesFurnishings = 1 << 9,
            GuestAccess = 1 << 10,
            MessageBook = 1 << 11,
            Planting = 1 << 12,
            Harvesting = 1 << 13,
            CropDisposal = 1 << 14,
            ChocoboStabling = 1 << 15,
            TrainingChocobo = 1 << 16,
            OrchestrionOperation = 1 << 17,

        }
        public enum WorkshopAccess : ushort {
            CosntructionRemoval = 1 << 0,
            ProjCommenceDisc = 1 << 1,
            ProjMatDelivery = 1 << 2,
            ProjectProgression = 1 << 3,
            ProjectItemCollection = 1 << 4,
            PrototypeCreation = 1 << 5,
            //Airship
            RegistrationDismantling = 1 << 6,
            Outfitting = 1 << 7,
            ColorCustomization = 1 << 8,
            Unk = 1 << 9,
            Renaming = 1 << 10,
            VoyageDeploymentRecall = 1 << 11,
            VoyageFinalization = 1 << 12,
        }
    }
}
