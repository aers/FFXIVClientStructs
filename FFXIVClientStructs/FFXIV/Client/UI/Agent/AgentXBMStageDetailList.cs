using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentXBMStageDetailList
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.XBMStageDetailList)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x271B8)]
public unsafe partial struct AgentXBMStageDetailList {
    [FieldOffset(0x28)] public uint AddonInitState; // 0 = nothing done, 1 = shortcuts registered, 2 = entries built
    [FieldOffset(0x2C)] public bool HasRegisteredShortcuts;
    [FieldOffset(0x2D)] public bool PendingUpdate;
    [FieldOffset(0x30)] public uint StageDetailAddonId;
    [FieldOffset(0x34)] public uint SubAddonId;
    [FieldOffset(0x38)] public uint ContentId; // XBMContent row
    [FieldOffset(0x3C)] public uint Mode; // 0 = stage list of a content, 1 = running challenge, 2 = challenge result
    [FieldOffset(0x40)] public uint SelectedRank; // 0 to 3, index into the ranked difficulty AddonText list
    [FieldOffset(0x44)] public uint ScrollToStageId;
    [FieldOffset(0x48)] private bool Unk48; // set while a challenge is running, decides whether entries are read from the director or from XBMContent
    [FieldOffset(0x49)] private byte Unk49;
    [FieldOffset(0x4A)] private bool Unk4A; // set when the battle starts, forwarded to the event handler as event state
    [FieldOffset(0x4B)] private bool Unk4B;
    [FieldOffset(0x4C)] public bool ScrollToSelection;
    [FieldOffset(0x4D)] private bool Unk4D;
    [FieldOffset(0x4E)] private bool Unk4E; // set when the addon is closed from the challenge flow

    [FieldOffset(0x50), FixedSizeArray] internal FixedSizeArray1000<StageDetailEntry> _entries;
    [FieldOffset(0x27150), FixedSizeArray] internal FixedSizeArray100<byte> _entrySelection;

    [MemberFunction("40 53 56 57 B8 ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 2B E0 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 84 24 ?? ?? ?? ?? 48 8B 01 49 8B F0 8B FA")]
    public partial void SetMode(int mode, int* param);

    [MemberFunction("40 53 48 83 EC ?? 80 79 ?? ?? 48 8B D9 74 ?? 83 79")]
    public partial void ClearAddonState();

    [MemberFunction("40 53 55 56 57 48 83 EC ?? 48 8B EA")]
    public partial void FillStageListValues(AtkValue* values);

    [MemberFunction("48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 57 41 56 41 57 48 83 EC ?? 48 8B F2 48 8B E9")]
    public partial void FillStageDetailValues(AtkValue* values);

    [MemberFunction("48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 57 48 83 EC ?? 48 8D 59 ?? BE ?? ?? ?? ?? 48 8D 79")]
    public partial void ResetEntries();

    [MemberFunction("4C 8B DC 41 55 48 83 EC ?? 8B 41")]
    public partial uint BuildEntriesFromContent();

    [MemberFunction("48 89 4C 24 ?? 56 57 48 81 EC ?? ?? ?? ?? 8B 41")]
    public partial uint BuildEntriesFromDirector();

    [MemberFunction("48 89 5C 24 ?? 55 56 57 41 54 41 55 41 56 41 57 48 81 EC ?? ?? ?? ?? 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 84 24 ?? ?? ?? ?? 33 FF")]
    public partial CStringPointer GetStageEventText(uint stageEventId);

    [MemberFunction("40 53 48 83 EC ?? 83 79 ?? ?? 75 ?? E8")]
    public partial uint GetSelectedEntryIndex();

    [MemberFunction("40 53 48 83 EC ?? 83 79 ?? ?? 48 8B D9 75 ?? 80 49")]
    public partial void StartBattle();
    
    // Type 3 rows are the battle details of the preceding stage row.
    [StructLayout(LayoutKind.Explicit, Size = 0xA0)]
    public unsafe struct StageDetailEntry {
        [FieldOffset(0x00)] public uint EntryType; // 0 = stage, 1 = stage with battles, 2 = stage without battles, 3 = battle detail
        [FieldOffset(0x04)] public uint StageEventId; // XBMContentStageEvent subrow, also used as the index into _entrySelection
        [FieldOffset(0x08)] public uint EventType; // XBMContentStageEvent.Unknown1
        [FieldOffset(0x0C)] public uint StageEventType; // XBMContentStageEvent.Unknown0
        [FieldOffset(0x10)] public Utf8String Name;
        [FieldOffset(0x78)] public uint Icon; // XBMBattleDetail.Unknown1
        [FieldOffset(0x7C)] public uint BattleDetailId; // XBMBattleDetail row
        [FieldOffset(0x80)] public uint BattleDetailIndex; // XBMBattleDetail subrow
        [FieldOffset(0x84)] public uint ElementId; // XBMElement row
        [FieldOffset(0x88)] public uint Strength; // XBMBattleDetail.Unknown5
        [FieldOffset(0x8C)] public uint PhysicalResistance; // XBMBattleDetail.Unknown7
        [FieldOffset(0x90)] public uint Constitution; // XBMBattleDetail.Unknown9
        [FieldOffset(0x94)] public uint Intelligence; // XBMBattleDetail.Unknown6
        [FieldOffset(0x98)] public uint MagicalResistance; // XBMBattleDetail.Unknown8
        [FieldOffset(0x9C)] public uint ResistId; // BNpcResist row
    }
}
