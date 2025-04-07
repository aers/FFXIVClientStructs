using FFXIVClientStructs.FFXIV.Client.Game.Object;
using FFXIVClientStructs.FFXIV.Client.Game.UI;
using FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;
using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Client.UI.Misc;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentCharaCard
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.CharaCard)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x38)]
public unsafe partial struct AgentCharaCard {

    [FieldOffset(0x28)] public Storage* Data;

    [MemberFunction("48 89 5C 24 ?? 57 48 83 EC 20 80 79 30 00 48 8B FA 48 8B D9 75 4B")]
    private partial void OpenCharaCardForContentId(ulong contentId);

    public void OpenCharaCard(ulong contentId) => OpenCharaCardForContentId(contentId);

    [MemberFunction("48 85 D2 74 6D 48 89 5C 24")]
    private partial void OpenCharaCardForObject(GameObject* gameObject);
    public void OpenCharaCard(GameObject* gameObject) => OpenCharaCardForObject(gameObject);

    [MemberFunction("40 55 53 57 41 57 48 8D AC 24 ?? ?? ?? ?? 48 81 EC B8 04 00 00")]
    private partial void OpenCharaCardForPacket(CharaCardPacket* packet, bool a3);

    // Client::UI::Agent::AgentCharaCard::Storage
    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x9B0)]
    public unsafe partial struct Storage {
        [FieldOffset(0x00)] public byte Flag0;
        [FieldOffset(0x01)] public byte Flag1;
        [FieldOffset(0x02)] public byte Flag2;
        [FieldOffset(0x03)] public byte Flag3;
        [FieldOffset(0x04)] public uint EntityId;
        [FieldOffset(0x08)] public ulong AccountId;
        [FieldOffset(0x10)] public ulong ContentId;
        [FieldOffset(0x18)] public bool IsNotCreated; // Addon#15092
        [FieldOffset(0x19)] public bool WasResetDueToFantasia; // Addon#15093
        [FieldOffset(0x1A)] public bool CanEdit;
        [FieldOffset(0x1B)] public bool InvertPortraitPlacement;
        [FieldOffset(0x1C)] public PlateDesign PlateDesign;
        [FieldOffset(0x2C)] public byte NumPlayStyles;
        /// <remarks> CharaCardPlayStyle RowIds </remarks>
        [FieldOffset(0x2D), FixedSizeArray] internal FixedSizeArray6<byte> _playStyles;

        [FieldOffset(0x38)] internal long Unk38;
        [FieldOffset(0x40)] internal int Unk40;
        [FieldOffset(0x44)] internal int Unk44;
        [FieldOffset(0x48)] internal int Unk48;
        [FieldOffset(0x4C)] internal int Unk4C;
        [FieldOffset(0x50)] public uint ActiveHoursWeekdays;
        [FieldOffset(0x54)] public uint ActiveHoursWeekends;

        [FieldOffset(0x58)] public ushort BannerBg;
        [FieldOffset(0x5A)] public ushort BannerFrame;
        [FieldOffset(0x5C)] public ushort BannerDecoration;
        //[FieldOffset(0x5E)] public ushort padding?;
        [FieldOffset(0x60)] public Utf8String Name;
        [FieldOffset(0xC8)] public ushort WorldId;
        [FieldOffset(0xCA)] public byte ClassJobId;
        [FieldOffset(0xCB)] public byte GrandCompany;
        [FieldOffset(0xCC)] public byte GcRank;
        [FieldOffset(0xCD)] public byte Sex;
        [FieldOffset(0xCE)] public byte PreferredClassJobId;
        //[FieldOffset(0xCF)] public byte padding?;
        [FieldOffset(0xD0)] public ushort Level;
        [FieldOffset(0xD2)] public ushort TitleId;
        // [FieldOffset(0xD4)] public uint padding?;
        [FieldOffset(0xD8)] public CrestData FreeCompanyCrestData; // not checked
        [FieldOffset(0xE0)] public Utf8String FreeCompany;
        [FieldOffset(0x148)] public Utf8String SearchComment;
        [FieldOffset(0x1B0)] public Utf8String SearchCommentRaw; // contains unresolved AutoTranslatePayloads
        [FieldOffset(0x218)] public uint BannerBgIconId;
        [FieldOffset(0x21C)] public uint TopBorderIconId;
        [FieldOffset(0x220)] public uint BottomBorderIconId;
        [FieldOffset(0x224)] internal bool Unk224;
        [FieldOffset(0x225)] internal bool Unk225;
        [FieldOffset(0x226)] internal bool Unk226;
        [FieldOffset(0x227)] internal bool Unk227;
        [FieldOffset(0x22C), FixedSizeArray] internal FixedSizeArray5<Decoration> _decorations;

        [FieldOffset(0x258), FixedSizeArray] internal FixedSizeArray6<Activity> _activities;
        [FieldOffset(0x4F8)] public uint BannerFrameIconId;
        [FieldOffset(0x4FC)] public uint BannerDecorationIconId;
        // When EditAddonId is closed without saving, these fields are used:
        [FieldOffset(0x500)] public PlateDesign BackupPlateDesign;
        [FieldOffset(0x510)] public bool BackupInvertPortraitPlacement;

        // bunch of ExcelSheetWaiters

        [FieldOffset(0x540)] public CharaViewPortrait CharaView;
        [FieldOffset(0x960)] public Texture* PortraitTexture;
        [FieldOffset(0x968)] public ExportedPortraitData PortraitData;
        /// <remarks> CharaCardEditMenu, CharaCardDesignSetting, BannerEditor, CharaCardProfileSetting </remarks>
        [FieldOffset(0x99C)] public uint EditAddonId;
        /// <remarks> To display Addon#15091, Addon#15092 or Addon#15093 </remarks>
        [FieldOffset(0x9A0)] public uint SelectOkAddonId;
        [FieldOffset(0x9A4)] public uint InputSearchCommentAddonId;
        [FieldOffset(0x9A8)] public uint PermissionSettingAddonId;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x70)]
    public struct Activity {
        [FieldOffset(0x00)] public uint IconId;
        [FieldOffset(0x08)] public Utf8String Name;
    }

    public enum DecorationType : byte {
        /// This does not correspond to a real decoration and should be ignored.
        Invalid = 0x0,
        Backing = 0x1,
        PatternOverlay = 0x2,
        PortraitFrame = 0x3,
        PlateFrame = 0x4,
        Accent = 0x5,
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x8)]
    public struct Decoration {
        [FieldOffset(0x00)] public DecorationType Type;
        [FieldOffset(0x01)] public byte Unk1;
        [FieldOffset(0x04)] public uint IconId;
    }

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public partial struct PlateDesign {
        /// <remarks> CharaCardBase RowId </remarks>
        [FieldOffset(0x00)] public ushort BasePlate;
        /// <remarks> CharaCardHeader RowId </remarks>
        [FieldOffset(0x02)] public byte TopBorder;
        /// <remarks> CharaCardHeader RowId </remarks>
        [FieldOffset(0x03)] public byte BottomBorder;
        [FieldOffset(0x04)] public byte NumDecorations;
        /// <remarks> CharaCardDecoration RowIds </remarks>
        [FieldOffset(0x06), FixedSizeArray] internal FixedSizeArray5<ushort> _decorations;
    }

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x1E6)]
    public partial struct CharaCardPacket {
        [FieldOffset(0x000)] public CrestData FreeCompanyCrestData; // guessed
        [FieldOffset(0x008)] public ulong AccountId;
        [FieldOffset(0x010)] public ulong ContentId;
        [FieldOffset(0x018)] public uint EntityId;
        [FieldOffset(0x01C)] public uint SomeState;
        [FieldOffset(0x020)] public ushort WorldId;
        [FieldOffset(0x022)] public ushort Level;
        [FieldOffset(0x024)] public byte ClassJobId;
        [FieldOffset(0x025)] public byte Sex;
        [FieldOffset(0x026)] public byte GrandCompany;
        [FieldOffset(0x027)] public byte GcRank;
        [FieldOffset(0x028)] public CharaCardData CharaCardData;
        [FieldOffset(0x0E4), FixedSizeArray] internal FixedSizeArray193<byte> _searchComment;
        [FieldOffset(0x1A5), FixedSizeArray(isString: true)] internal FixedSizeArray32<byte> _name;
        [FieldOffset(0x1C5), FixedSizeArray(isString: true)] internal FixedSizeArray22<byte> _freeCompany; // length unknown; copied from InfoProxyFreeCompany
    }
}
