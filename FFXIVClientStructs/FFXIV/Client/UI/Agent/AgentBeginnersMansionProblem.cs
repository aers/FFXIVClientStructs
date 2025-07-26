using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Common.Component.Excel;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.BeginnersMansionProblem)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x338)]
public partial struct AgentBeginnersMansionProblem {

    [FieldOffset(0x28)] private ExcelSheetWaiter _sheetWaiter;

    [FieldOffset(0xC8)] public StdVector<nint> TutorialRows;

    [FieldOffset(0xF4)] public RoleType CurrentRoleType;
    [FieldOffset(0xF8)] public TutorialCategory CurrentTutorialCategory;

    // should be used for CurrentRoleTutorialRows
    [FieldOffset(0xFC)] public uint CurrentRoleTutorialCategoryRowId;

    // should be used for TutorialRows
    [FieldOffset(0x100)] public uint TutorialRowId;
    [FieldOffset(0x104)] public uint RewardItemId;

    [FieldOffset(0x108)] public TutorialCategory AddonSelectedCategory;

    // when CurrentRoleType is Tank, it will be rows from TutorialTank, same goes to Healer, DPS and Gimmick
    [FieldOffset(0x110)] public StdVector<nint> CurrentRoleTutorialRows;

    [FieldOffset(0x128), FixedSizeArray] internal FixedSizeArray5<Utf8String> _strings;

    [FieldOffset(0x330)] public uint GroupMemberCount;

    public enum TutorialCategory : uint {
        Tank = 0,
        Healer = 1,
        DPS = 2,
        Gimmick = 3
    }

    public enum RoleType : uint {
        Tank = 1,
        DPS = 2,
        Healer = 3
    }
}
