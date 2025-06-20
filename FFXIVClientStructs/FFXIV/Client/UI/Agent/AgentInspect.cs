using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Client.UI.Info;
using FFXIVClientStructs.FFXIV.Client.UI.Misc;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentInspect
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.Inspect)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x808)]
public unsafe partial struct AgentInspect {
    [FieldOffset(0x028)] public uint RequestEntityId;
    [FieldOffset(0x02C)] public uint RequestSearchCommentEntityId;
    [FieldOffset(0x030)] public uint RequestFreeCompanyEntityId;
    [FieldOffset(0x034)] public uint CurrentEntityId;
    [FieldOffset(0x038)] public Utf8String SearchComment;
    /// <remarks> PSN-Online-ID or Xbox-Gamertag </remarks>
    [FieldOffset(0x108)] public Utf8String OnlineId;
    [FieldOffset(0x170), FixedSizeArray] internal FixedSizeArray3<Utf8String> _chocoboBarding;
    [FieldOffset(0x2A8), FixedSizeArray] internal FixedSizeArray13<ItemData> _items;

    [FieldOffset(0x449)] public bool IsBuddyInspect;

    // Offset can be found with "44 89 BF ? ? ? ? E8 ? ? ? ? 48 8B C8 48 8B D8"
    [FieldOffset(0x44C)] public int SelectedItemSlot;

    [FieldOffset(0x450)] public FreeCompanyData FreeCompany;
    // Status fields
    // 0: Nothing to do
    // 1: Fetching Data
    // 2: Data ready (Fills window)
    // 3: Probably failure
    [FieldOffset(0x4D0)] public uint FetchCharacterDataStatus;
    [FieldOffset(0x4D4)] public uint FetchSearchCommentStatus;
    [FieldOffset(0x4D8)] public uint FetchFreeCompanyStatus;

    [FieldOffset(0x4E0)] public InfoProxyDetail* InfoProxyDetail;
    [FieldOffset(0x4E8)] public InfoProxyFreeCompany* InfoProxyFreeCompany;
    [FieldOffset(0x4F0)] public InspectCharaView CharaView;

    [MemberFunction("48 89 5C 24 ?? 48 89 6C 24 ?? 56 48 83 EC 20 49 8B E8 8B DA")]
    public partial void ReceiveSearchComment(uint entityId, byte* searchComment);

    [MemberFunction("48 8B 01 44 88 81 ?? ?? ?? ?? 89 51")]
    public partial void ExamineCharacter(uint entityId, bool isChocobo = false);

    // Client::UI::Agent::AgentInspect::InspectCharaView
    //   Client::UI::Misc::CharaView
    [GenerateInterop]
    [Inherits<CharaView>]
    [StructLayout(LayoutKind.Explicit, Size = 0x318)]
    public partial struct InspectCharaView;

    [StructLayout(LayoutKind.Explicit, Size = 0x80)]
    public struct FreeCompanyData {
        //[FieldOffset(0x00)] public byte Unkown4b0; // Maybe FreeCompany get status 1 = Finished
        [Obsolete("This field is wrong, it is IsBuddyInspect actually", true)]
        [FieldOffset(0x01)] public bool IsPartOfFreeCompany; // HasGuild???????? if 0 Client::UI::RaptureAtkModule.OpenAddon can be called without getting additional infos
        [FieldOffset(0x00)] public long Id;
        [FieldOffset(0x8)] public CrestData Crest;
        [FieldOffset(0x10)] public ushort MemberCount;
        [FieldOffset(0x12)] public ushort GrandCompany; // 1 = Maelstorm 2 = TwinAdder 3 = ImmortalFlames
        [FieldOffset(0x18)] public Utf8String GuildName;
    }

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public partial struct ItemData {
        [FieldOffset(0x00)] public uint IconId;
        [FieldOffset(0x04)] public IconFlagsTopRight IconFlags1;
        [FieldOffset(0x05)] public ColorRgb Color;
        [FieldOffset(0x08)] public bool Filled;
        [FieldOffset(0x09)] public bool IsILevelSynced; // 1 if Level < Level{Equip} So probably ILVSynced
        [FieldOffset(0x10), FixedSizeArray] internal FixedSizeArray4<short> _modelMain;
        [FieldOffset(0x18), FixedSizeArray] internal FixedSizeArray4<short> _modelSub;

        [StructLayout(LayoutKind.Explicit, Size = 0x3)]
        public struct ColorRgb {
            [FieldOffset(0x0)] public byte B;
            [FieldOffset(0x1)] public byte G;
            [FieldOffset(0x2)] public byte R;
        }

        public enum IconFlagsTopRight : byte {
            None = 0,
            Dyeable = 1,
            Glamoured = 4,
        }
    }
}
