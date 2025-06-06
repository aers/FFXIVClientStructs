using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonMKDInfo
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("MKDInfo")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x3F8)]
public unsafe partial struct AddonMKDInfo {
    [FieldOffset(0x238)] private uint Unk238; // Seems to be related to the knowledge level ui timelines
    [FieldOffset(0x23C)] public PartyState PartyStateFlags;
    [FieldOffset(0x240)] public StdVector<StdPair<uint,Pointer<AtkComponentButton>>> Buttons;
    [FieldOffset(0x258)] public ButtonOperationGuideManager CriticalEncounterButtonManager; 
    [FieldOffset(0x290)] public AtkTextNode *KnowledgeExpTextNode;
    [FieldOffset(0x298)] public AtkTextNode *KnowledgeNeededTextNode;
    [FieldOffset(0x2A0)] public AtkTextNode *KnowledgeLevelTextNode;
    [FieldOffset(0x2A8)] public AtkTextNode *AreaKnowledgeLevelTextNode;
    [FieldOffset(0x2B0)] public AtkResNode *KnowledgeLevelHeaderResNode;
    [FieldOffset(0x2B8)] public AtkResNode *AreaKnowledgeLevelResNode;
    [FieldOffset(0x2C0)] public AtkResNode *JobButtonResNode;
    [FieldOffset(0x2C8)] public AtkResNode *JobButtonCharJumpingResNode;
    [FieldOffset(0x2D0)] public AtkTextNode *JobNameNode;
    [FieldOffset(0x2D8)] public AtkTextNode *JobNameSubtitleTextNode;
    [FieldOffset(0x2E0)] public AtkTextNode *JobLevelTextNode;
    [FieldOffset(0x2E8)] public AtkTextNode *JobExpTextNode;
    [FieldOffset(0x2F0)] public AtkComponentBase *JobIconComponent;
    [FieldOffset(0x2F8)] public AtkResNode *JobMasteryResNode;
    [FieldOffset(0x300)] public AtkResNode *JobNotificationResNode;
    [FieldOffset(0x308)] public AtkResNode *LoreNotificationResNode;
    [FieldOffset(0x310)] public AtkTextNode *SilverPieceCountTextNode;
    [FieldOffset(0x318)] public uint SilverPieceCount;
    [FieldOffset(0x320)] public AtkTextNode *GoldPieceCountTextNode;
    [FieldOffset(0x328)] public uint GoldPieceCount;
    [FieldOffset(0x330)] public AtkTextNode *CipherCountTextNode;
    [FieldOffset(0x338)] public uint CipherCount;
    [FieldOffset(0x340)] public AtkResNode *CipherCountResNode;
    [FieldOffset(0x348)] public AtkResNode *ChainResNode;
    [FieldOffset(0x350)] public AtkTextNode *ChainCountTextNode;
    [FieldOffset(0x358)] public AtkResNode *ChainTimerResNode;
    [FieldOffset(0x360)] public AtkResNode *ChainTimerTextNode;
    [FieldOffset(0x368)] public AtkComponentGaugeBar *ChainGaugeComponent;
    [FieldOffset(0x370)] public float ChainTimer;
    [FieldOffset(0x374)] public uint TimerMax;
    [FieldOffset(0x378)] public uint ContentTypeRowId;
    [FieldOffset(0x37C)] public uint CriticalEngagementStartCountdown;
    [FieldOffset(0x380)] public CStringPointer oneSlashTwoMacroString;
    [FieldOffset(0x388)] public CStringPointer paramOneMacroString;
    [FieldOffset(0x390)] public CStringPointer italicizeParamOneIfParam2PositiveMacroString;
    [FieldOffset(0x398)] public CStringPointer HyphenString;
    [FieldOffset(0x3A0)] public CStringPointer SyncPartyLevelsLeaderString;
    [FieldOffset(0x3A8)] public CStringPointer PartyLevelSyncedLeaderString;
    [FieldOffset(0x3B0)] public CStringPointer SyncPartyLevelsString;
    [FieldOffset(0x3B8)] public CStringPointer PartyLevelSyncedString;
    [FieldOffset(0x3C0)] public CStringPointer MasteredString;
    [FieldOffset(0x3C8)] public CStringPointer CECountdownMacroString;
    [FieldOffset(0x3D0)] public CStringPointer CEStartingString;
    // 3d8
    [FieldOffset(0x3E0)] public ResourceHandle *InteractSoundResHandle;
    [FieldOffset(0x3E8)] public ResourceHandle *CursorSoundResHandle;
    [FieldOffset(0x3F0)] public ResourceHandle *CancelSoundResHandle;

    [Flags]
    public enum PartyState {
        PartyLeader = 0x1,
        InParty = 0x2,
        InAlliance = 0x4,
        InCrossrealmParty = 0x8,
        InOccultCrescent = 0x10,
        InBalancedParty = 0x20,
        IsKnowledgeLevelSynced = 0x40,
        SyncStatusChanging = 0x80
    }
}

