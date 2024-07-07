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

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8B 4B 10 48 8B 01 FF 90 ?? ?? ?? ?? 44 0F B7 8B ?? ?? ?? ??")]
    private partial void OpenCharaCardForContentId(ulong contentId);

    public void OpenCharaCard(ulong contentId) => OpenCharaCardForContentId(contentId);

    [MemberFunction("48 85 D2 74 6D 48 89 5C 24")]
    private partial void OpenCharaCardForObject(GameObject* gameObject);
    public void OpenCharaCard(GameObject* gameObject) => OpenCharaCardForObject(gameObject);

    // Client::UI::Agent::AgentCharaCard::Storage
    // ctor "E8 ?? ?? ?? ?? 48 8B F0 48 89 73 ?? C6 06"
    // dtor "E8 ?? ?? ?? ?? BA ?? ?? ?? ?? 48 8B CF E8 ?? ?? ?? ?? 48 89 73 ?? E8"
    [StructLayout(LayoutKind.Explicit, Size = 0x9B0)]
    public unsafe partial struct Storage {
        [FieldOffset(0x4)] public uint EntityId;
        [FieldOffset(0x8)] public ulong ContentId;

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
        [FieldOffset(0x960)] public Texture* PortraitTexture;
    }
}
