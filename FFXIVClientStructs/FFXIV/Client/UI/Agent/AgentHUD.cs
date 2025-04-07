using FFXIVClientStructs.FFXIV.Client.Game;
using FFXIVClientStructs.FFXIV.Client.Game.Character;
using FFXIVClientStructs.FFXIV.Client.Game.Object;
using FFXIVClientStructs.FFXIV.Client.Game.UI;
using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.GUI;
using static FFXIVClientStructs.FFXIV.Common.Configuration.ConfigBase;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentHUD
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
//   Common::Configuration::ConfigBase::ChangeEventInterface
[Agent(AgentId.Hud)]
[GenerateInterop]
[Inherits<AgentInterface>, Inherits<ChangeEventInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x4DF0)]
public unsafe partial struct AgentHUD {
    [FieldOffset(0x60)] public HudStatus* Status;

    [FieldOffset(0xB18)] public uint CastBarAddonId;

    [FieldOffset(0xB38)] public uint CurrentTargetId;
    [FieldOffset(0xB40)] public int TargetCounter;
    [FieldOffset(0xB48)] public uint TargetPartyMemberId;
    [FieldOffset(0xB50)] public int TargetSwitchToSelfCounter;
    [FieldOffset(0xB54)] public uint CurrentBattleCharaTargetLevel;

    [FieldOffset(0xD2C)] public int CompanionSummonTimer;

    /// <remarks> The local player is always first in the Span, their actual position in the UI can be retrieved using Index </remarks>
    [FieldOffset(0xD38), FixedSizeArray] internal FixedSizeArray10<HudPartyMember> _partyMembers;

    [FieldOffset(0x1384)] public short PartyMemberCount;
    [FieldOffset(0x138C)] public uint PartyTitleAddonId;
    [FieldOffset(0x1390), FixedSizeArray] internal FixedSizeArray40<uint> _raidMemberIds;
    [FieldOffset(0x1430)] public int RaidGroupSize;

    [FieldOffset(0x1444), FixedSizeArray] internal FixedSizeArray10<HudPartyMemberEnmity> _hudPartyMemberEnmity;
    [FieldOffset(0x14C0), FixedSizeArray] internal FixedSizeArray10<Pointer<HudPartyMemberEnmity>> _hudPartyMemberEnmityPtrs;

    [FieldOffset(0x33B8), FixedSizeArray] internal FixedSizeArray30<HudTargetInfoBuffTimeRemainingCacheEntry> _targetInfoBuffTimeRemainingCache;

    [FieldOffset(0x3548)] public uint ExpCurrentExperience;
    [FieldOffset(0x354C)] public uint ExpNeededExperience;
    [FieldOffset(0x3550)] public uint ExpRestedExperience;
    [FieldOffset(0x3554)] public uint CharacterClassJobId;

    [FieldOffset(0x3564)] public uint ExpClassJobId;
    [FieldOffset(0x3568)] public ushort ExpLevel;
    [FieldOffset(0x356A)] public ushort ExpContentLevel; // level in eureka and bozja for example
    [FieldOffset(0x356C)] public AgentHudExpFlag ExpFlags;

    [FieldOffset(0x3578), FixedSizeArray] internal FixedSizeArray16<HudQueuedBattleTalk> _queuedBattleTalks;

    [FieldOffset(0x4A58)] public StdVector<MapMarkerData> MapMarkers;
    [FieldOffset(0x4A70)] public StdVector<Pointer<MapMarkerData>> MapMarkerPtrs;

    [MemberFunction("48 8B 81 ?? ?? ?? ?? 44 8B C2 83 E2 1F")]
    public partial bool IsMainCommandEnabled(uint mainCommandId);

    [MemberFunction("E8 ?? ?? ?? ?? 40 32 FF 45 32 C0")]
    public partial bool SetMainCommandEnabledState(uint mainCommandId, bool enabled);

    [MemberFunction("48 85 D2 74 7F 48 89 5C 24")]
    public partial void OpenContextMenuFromTarget(GameObject* gameObject);

    [MemberFunction("E8 ?? ?? ?? ?? EB 08 48 8B CB E8 ?? ?? ?? ?? 48 8B 4C 24 ?? 45 85 F6")]
    public partial CStringPointer GetMainCommandString(uint commandId, bool includeKeybind = true, bool includeNewIndicator = false);

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8B CF 4C 89 B4 24 B8 08 00 00")]
    public partial void OpenSystemMenu(AtkValue* atkValueArgs, uint menuSize);

    [MemberFunction("E8 ?? ?? ?? ?? E8 ?? ?? ?? ?? 84 C0 75 ?? 80 BF")]
    public partial void UpdateExp(NumberArrayData* expNumberArray, StringArrayData* expStringArray, StringArrayData* characterStringArray);

    [MemberFunction("48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 7C 24 ?? 41 56 48 83 EC 30 48 8B F9 48 8B 49 10")]
    public partial void UpdateTargetInfo();

    [MemberFunction("E8 ?? ?? ?? ?? 8B 44 24 64 48 8D 4D B0")]
    public partial void UpdateStatusDisplay(HudStatus.DisplayStatus* displayStatus, StringArrayData* stringArray, int stringArrayIndex, int iconId, int remainingTime, byte unkCrafterStatus, bool isPermanent);
}

[StructLayout(LayoutKind.Explicit, Size = 0x0C)]
public struct HudPartyMemberEnmity {
    [FieldOffset(0x00)] public uint EntityId;
    [FieldOffset(0x04)] public int Enmity;
    [FieldOffset(0x08)] public short Index;
}

[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public unsafe struct HudPartyMember {
    [FieldOffset(0x0)] public BattleChara* Object;
    [FieldOffset(0x8)] public CStringPointer Name;
    [FieldOffset(0x10)] public ulong ContentId;
    [FieldOffset(0x18)] public uint EntityId;
    [FieldOffset(0x20)] public byte Index;
}

[StructLayout(LayoutKind.Explicit, Size = 8 + 4)]
public struct HudTargetInfoBuffTimeRemainingCacheEntry {
    [FieldOffset(0x00)] public uint Icon;
    [FieldOffset(0x04)] public uint TimeRemaining;
    [FieldOffset(0x08)] public byte Unk8;
    [FieldOffset(0x09)] public bool HasTimeRemaining;
    [FieldOffset(0x0A)] internal bool UnkA; // temporary value to reset TimeRemaining after setting it?!?
}

[StructLayout(LayoutKind.Explicit, Size = 0xE8)]
public unsafe struct HudQueuedBattleTalk {
    [FieldOffset(0x0)] public bool IsPending;
    //[FieldOffset(0x1)] public byte Unk1;
    [FieldOffset(0x2)] public byte Style;

    [FieldOffset(0x8)] public Utf8String Name;
    [FieldOffset(0x70)] public Utf8String Text;
    [FieldOffset(0xDC)] public uint Image;
    [FieldOffset(0xE0)] public int Sound;
    [FieldOffset(0xE4)] public uint EntityId;
}

[StructLayout(LayoutKind.Explicit, Size = 0x200, Pack = 0x8)]
[GenerateInterop]
public unsafe partial struct HudStatus {
    [FieldOffset(0x0), FixedSizeArray] internal FixedSizeArray30<DisplayStatus> _DisplayedStatus;
    [FieldOffset(0x168), FixedSizeArray] internal FixedSizeArray30<uint> _StatusIds;
    [FieldOffset(0x1E0), FixedSizeArray] internal FixedSizeArray4<ushort> _StatusCustomAddonIds;
    [FieldOffset(0x1E8)] public UIModuleInterface* UiModuleInterface;
    [FieldOffset(0x1F0)] public AgentHUD* AgentHUD;
    [FieldOffset(0x1F8)] public ushort AddonId;

    [StructLayout(LayoutKind.Explicit, Size = 0x10, Pack = 0x8)]
    [GenerateInterop]
    public unsafe partial struct Status {
        [FieldOffset(0x0)] public uint StatusId;
        [FieldOffset(0x4)] public int RemainingTime;
        [FieldOffset(0x8)] public ushort Param;
        [FieldOffset(0xA)] public bool PartyListPriority;
        [FieldOffset(0xB)] public byte CanIncreaseRewards;
        [FieldOffset(0xC)] public bool IsOwnStatus;
        [FieldOffset(0xD)] public byte StatusIndex;

        [MemberFunction("E8 ?? ?? ?? ?? 6B DD 2B")]
        public partial uint ProcessStatuses(int maxIndex, int entityId1, int entityId2, StatusManager* statusManager, PlayerState* playerState, char unk1, char unk2, char unk3, nint unk4, int unk5);
    }

    [StructLayout(LayoutKind.Explicit, Size = 0xC, Pack = 0x4)]
    public unsafe struct DisplayStatus {
        [FieldOffset(0x0)] public uint IconId;
        [FieldOffset(0x4)] public int RemainingTime;
        [FieldOffset(0x8)] public byte UnkStatusFlag;
        [FieldOffset(0x9)] public bool IsUpdated;
        [FieldOffset(0xA)] public bool IsProcessedOnce;
    }

    [MemberFunction("E8 ?? ?? ?? ?? 4D 8B CF 4C 8B C5 49 8B D6 48 8B CF")]
    public partial void Update(NumberArrayData* numberArray, StringArrayData* stringArray);
}

[Flags]
public enum AgentHudExpFlag : byte {
    None = 0,
    Unk1 = 1 << 0,
    Synced = 1 << 1,
    Unk2 = 1 << 2,
    MaxLevel = 1 << 3,
    InEureka = 1 << 4,
    Unk5 = 1 << 5, // In TerritoryIntendedUse 61?
}
