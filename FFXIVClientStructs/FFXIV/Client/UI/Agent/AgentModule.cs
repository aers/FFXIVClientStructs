using System.Runtime.InteropServices;
using FFXIVClientStructs.Attributes;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent
{
    // Client::UI::Agent::AgentModule

    // size = 0xC10
    // ctor E8 ? ? ? ? 48 8B 85 ? ? ? ? 49 8B CF 48 89 87
    [StructLayout(LayoutKind.Explicit, Size = 0xC10)]
    public unsafe partial struct AgentModule
    {
        [FieldOffset(0x0)] public void* vtbl;
        [FieldOffset(0x8)] public UIModule* UIModule;
        [FieldOffset(0x10)] public byte Initialized;
        [FieldOffset(0x11)] public byte Unk_11;
        [FieldOffset(0x14)] public uint FrameCounter;
        [FieldOffset(0x18)] public float FrameDelta;

        [FieldOffset(0x20)] public AgentInterface* AgentArray; // 380 pointers patch 5.50
        // why are those 2 here, included for completeness
        // [FieldOffset(0xC00)] public UIModule* UIModulePtr;
        // [FieldOffset(0xC08)] public AgentModule* AgentModulePtr;

        [MemberFunction("E8 ?? ?? ?? ?? 83 FF 0D")]
        public partial AgentInterface* GetAgentByInternalID(uint agentID);

        public AgentInterface* GetAgentByInternalId(AgentId agentId) => GetAgentByInternalID((uint)agentId);

        public AgentHUD* GetAgentHUD() => (AgentHUD*)GetAgentByInternalId(AgentId.Hud);
        public AgentHudLayout* GetAgentHudLayout() => (AgentHudLayout*)GetAgentByInternalId(AgentId.HudLayout);
        public AgentTeleport* GetAgentTeleport() => (AgentTeleport*)GetAgentByInternalId(AgentId.Teleport);
    }

    public enum AgentId : uint {
        Lobby = 0,
        CharaMake = 1,
        Cursor = 3,
        Hud = 4,
        GatherNote = 22,
        RecipeNote = 23,
        ItemSearch = 120,
        ChatLog = 5,
        Inventory = 6,
        ScenarioTree = 7,
        Context = 9,
        InventoryContext = 10,
        Config = 11,
        // Configlog,
        // Configlogcolor,
        Configkey = 14,
        ConfigCharacter = 15,
        // ConfigPadcustomize,
        HudLayout = 18,
        Emote = 19,
        Macro = 20,
        // TargetCursor,
        // TargetCircle,
        GatheringNote = 22,
        FishingNote = 27,
        FishGuide = 28,
        FishRecord = 29,
        Journal = 31,
        ActionMenu = 32,
        Marker = 33,
        Trade = 34,
        ScreenLog = 35,
        // NPCTrade,
        // Status,
        Map = 38,
        // Loot,
        // Repair,
        // Materialize,
        // MateriaAttach,
        // MiragePrism,
        Colorant = 44,
        // Howto,
        // HowtoNotice,
        Inspect = 48,
        Teleport = 49,
        ContentsFinder = 50,
        Social = 52,
        Blacklist = 53,
        FriendList = 54,
        Linkshell = 55,
        PartyMember = 56,
        // PartyInvite,
        Search = 58,
        Detail = 59,
        Letter = 60,
        LetterView = 61,
        LetterEdit = 62,
        ItemDetail = 63,
        ActionDetail = 64,
        // Retainer,
        // Return,
        // Cutscene,
        CutsceneReplay = 68,
        MonsterNote = 69,
        Market = 70,
        FateReward = 72, // FateProgress (Shared FATE)
        // Catch,
        FreeCompany = 74,
        // FreeCompanyOrganizeSheet,
        FreeCompanyProfile = 76,
        // FreeCompanyProfileEdit,
        // FreeCompanyInvite,
        FreeCompanyInputString = 79,
        // FreeCompanyChest,
        // FreeCompanyExchange,
        // FreeCompanyCrestEditor,
        // FreeCompanyCrestDecal,
        // FreeCompanyPetition,
        ArmouryBoard = 85,
        HowtoList = 86,
        Cabinet = 87,
        // LegacyItemStorage,
        // GrandCompanyRank,
        // GrandCompanySupply,
        // GrandCompanyExchange,
        // Gearset,
        SupportMain = 93,
        SupportList = 94,
        SupportView = 95,
        SupportEdit = 96,
        Achievement = 97,
        // CrossEditor,
        LicenseViewer = 99,
        ContentsTimer = 100,
        // MovieSubtitle,
        // PadMouseMode,
        RecommendList = 103,
        Buddy = 104,
        // ColosseumRecord,
        // CloseMessage,
        // CreditPlayer,
        // CreditScroll,
        // CreditCast,
        // CreditEnd,
        Shop = 112,
        // Bait,
        Housing = 114,
        // HousingHarvest,
        HousingSignboard = 116,
        // HousingPortal,
        // HousingTravellersNote,
        // HousingPlant,
        // PersonalRoomPortal,
        // HousingBuddyList,
        TreasureHunt = 122,
        // Salvage,
        LookingForGroup = 124,
        // ContentsMvp,
        // VoteKick,
        // VoteGiveup,
        // VoteTreasure,
        PvpProfile = 129,
        ContentsNote = 130,
        // ReadyCheck,
        FieldMarker = 132,
        // CursorLocation,
        RetainerStatus = 135,
        RetainerTask = 136,
        RelicNotebook = 138,
        // RelicSphere,
        // TradeMultiple,
        // RelicSphereUpgrade,
        Minigame = 145,
        Tryon = 146,
        AdventureNotebook = 147,
        // ArmouryNotebook,
        MinionNotebook = 149,
        MountNotebook = 150,
        ItemCompare = 151,
        // DailyQuestSupply,
        MobHunt = 153,
        // PatchMark,
        // Max,
        RetainerList = 325,
        Orchestrion = 212,
        InventoryBuddy = 288,
        Dawn = 329, //Trust
        CountDownSettingDialog = 239,
        Currency = 193,
        GoldSaucer = 175,
        WebGuidance = 211,
        TeleportHousingFriend = 286,
        PlayGuide = 209,
        BeginnersMansionProblem = 207, //Hall of the Novice
        AOZNotebook = 312, //Bluemage Spells
        OrnamentNoteBook = 372,
        McGuffin = 357, //Collection
        QuestRedo = 333,
        ContentsReplaySetting = 290,
        MountSpeed = 262,
        AetherCurrent = 191,
        CircleList = 336, //Fellowships
        MiragePrismPrismBox = 291, //Glamour Dresser
        MiragePrismMiragePlate = 291, //Glamour Plates
    }
}
