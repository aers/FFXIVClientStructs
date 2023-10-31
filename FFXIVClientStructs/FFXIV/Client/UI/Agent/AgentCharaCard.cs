using FFXIVClientStructs.FFXIV.Client.Game.Object;
using FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;
using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Client.UI.Misc;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentCharaCard
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.CharaCard)]
[StructLayout(LayoutKind.Explicit, Size = 0x38)]
public unsafe partial struct AgentCharaCard {
    [FieldOffset(0x0)] public AgentInterface AgentInterface;

    [FieldOffset(0x28)] public Storage* Data;

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8B 4B 10 48 8D BB")]
    private partial void OpenCharaCardForContentId(ulong contentId);

    public void OpenCharaCard(ulong contentId) => OpenCharaCardForContentId(contentId);

    [MemberFunction("48 85 D2 74 6D 48 89 5C 24")]
    private partial void OpenCharaCardForObject(GameObject* gameObject);
    public void OpenCharaCard(GameObject* gameObject) => OpenCharaCardForObject(gameObject);


    // Client::UI::Agent::AgentCharaCard::Storage
    // ctor "E8 ?? ?? ?? ?? 48 8B F0 48 89 73 ?? C6 06"
    // dtor "E8 ?? ?? ?? ?? BA ?? ?? ?? ?? 48 8B CF E8 ?? ?? ?? ?? 48 89 73 ?? E8"
    [StructLayout(LayoutKind.Explicit, Size = 0x950)]
    public unsafe partial struct Storage {
        [FieldOffset(0x4)] public uint ObjectId;
        [FieldOffset(0x8)] public ulong ContentId;

        [FieldOffset(0x58)] public Utf8String Name;
        [FieldOffset(0xC0)] public ushort WorldId;
        [FieldOffset(0xC2)] public byte ClassJobId;

        [FieldOffset(0xC4)] public byte GcRank;

        [FieldOffset(0xC8)] public ushort Level;
        [FieldOffset(0xCA)] public ushort TitleId;

        [FieldOffset(0xD8)] public Utf8String FreeCompany;
        [FieldOffset(0x140)] public Utf8String SearchComment;
        [FieldOffset(0x1A8)] public Utf8String SearchCommentRaw; // contains unresolved AutoTranslatePayloads

        [FieldOffset(0x250)] public uint Activity1IconId;
        [FieldOffset(0x258)] public Utf8String Activity1Name;
        [FieldOffset(0x2C0)] public uint Activity2IconId;
        [FieldOffset(0x2C8)] public Utf8String Activity2Name;
        [FieldOffset(0x330)] public uint Activity3IconId;
        [FieldOffset(0x338)] public Utf8String Activity3Name;
        [FieldOffset(0x3A0)] public uint Activity4IconId;
        [FieldOffset(0x3A8)] public Utf8String Activity4Name;
        [FieldOffset(0x410)] public uint Activity5IconId;
        [FieldOffset(0x418)] public Utf8String Activity5Name;
        [FieldOffset(0x480)] public uint Activity6IconId;
        [FieldOffset(0x488)] public Utf8String Activity6Name;

        [FieldOffset(0x540)] public CharaViewPortrait CharaView;
        [FieldOffset(0x900)] public Texture* PortraitTexture;
    }
}
