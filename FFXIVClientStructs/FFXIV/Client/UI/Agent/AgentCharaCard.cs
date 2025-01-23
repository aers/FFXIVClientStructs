using FFXIVClientStructs.FFXIV.Client.Game.Object;
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

    public enum DecorationType
    {
        /// This does not correspond to a real decoration and should be ignored.
        Invald = 0x0,
        Backing = 0x1,
        PatternOverlay = 0x2,
        PortraitFrame = 0x3,
        PlateFrame = 0x4,
        Accent = 0x5,
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x8)]
    public unsafe struct Decoration
    {
        [FieldOffset(0x0)] public DecorationType Type;
    }

    // Client::UI::Agent::AgentCharaCard::Storage
    [StructLayout(LayoutKind.Explicit, Size = 0x9B0)]
    public unsafe partial struct Storage {
        /// If the player has the "Edit Plate" window open.
        [FieldOffset(0x2)] public bool Editing;
        [FieldOffset(0x4)] public uint EntityId;
        [FieldOffset(0x8)] public ulong ContentId;

        [FieldOffset(0x1B)] public bool InvertPortraitPlacement;
        /// Row index into the CharaCardBase sheet
        [FieldOffset(0x1C)] public byte BasePlate;
        /// Row index into the CharaCardHeader sheet
        [FieldOffset(0x1E)] public byte TopBorder;
        /// Row index into the CharaCardHeader sheet
        [FieldOffset(0x1F)] public byte BottomBorder;

        /// The number of decorations.
        /// This is any Pattern Overlay, Backing, Portrait Frame, Plate Frame and Accents.
        /// It won't update to it's true value until the "Edit Plate" window is closed, and the game clears out the unused entries.
        [FieldOffset(0x20)] public ushort DecorationCount;
        
        /// The size of this array is NumDecorations.
        /// All of these index into the CharaCardDecoration sheet.
        [FieldOffset(0x22)] internal FixedSizeArray5<ushort> _decorationRowIndices;
        
        [FieldOffset(0x60)] public Utf8String Name;
        [FieldOffset(0xC8)] public ushort WorldId;
        [FieldOffset(0xCA)] public byte ClassJobId;

        [FieldOffset(0xCC)] public byte GcRank;

        [FieldOffset(0xD0)] public ushort Level;
        [FieldOffset(0xD2)] public ushort TitleId;

        [FieldOffset(0xE0)] public Utf8String FreeCompany;
        [FieldOffset(0x148)] public Utf8String SearchComment;
        [FieldOffset(0x1B0)] public Utf8String SearchCommentRaw; // contains unresolved AutoTranslatePayloads

        [FieldOffset(0x258)] public uint Activity1IconId;
        [FieldOffset(0x260)] public Utf8String Activity1Name;
        [FieldOffset(0x2C8)] public uint Activity2IconId;
        [FieldOffset(0x2D0)] public Utf8String Activity2Name;
        [FieldOffset(0x338)] public uint Activity3IconId;
        [FieldOffset(0x340)] public Utf8String Activity3Name;
        [FieldOffset(0x3A8)] public uint Activity4IconId;
        [FieldOffset(0x3B0)] public Utf8String Activity4Name;
        [FieldOffset(0x418)] public uint Activity5IconId;
        [FieldOffset(0x420)] public Utf8String Activity5Name;
        [FieldOffset(0x488)] public uint Activity6IconId;
        [FieldOffset(0x490)] public Utf8String Activity6Name;

        [FieldOffset(0x540)] public CharaViewPortrait CharaView;

        /// The size of this array is NumDecorations.
        [FieldOffset(0x22C), FixedSizeArray] internal FixedSizeArray5<Decoration> _decorations;
        
        [FieldOffset(0x960)] public Texture* PortraitTexture;
    }
}
