using FFXIVClientStructs.FFXIV.Client.Game.Event;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Arrays;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 198 * 4)]
public unsafe partial struct ToDoListNumberArray {
    public static ToDoListNumberArray* Instance() {
        var numberArray = AtkStage.Instance()->GetNumberArrayData(NumberArrayType.ToDoList);
        return numberArray == null ? null : (ToDoListNumberArray*)numberArray->IntArray;
    }

    [FieldOffset(0), FixedSizeArray, CExporterIgnore] internal FixedSizeArray198<int> _data;

    [FieldOffset(0)] public int HideDutyList;

    [FieldOffset(1 * 4)] public int ForceFullRedraw;

    [FieldOffset(2 * 4)] public int DutyTimerEnabled;

    // 3 - unknown

    /*
     * 1- Chocobo Racing
     * 2- Lord of Verminion
     * All other values- Default exclamation point
     */
    [FieldOffset(3 * 4)] public int DutyHeaderIcon;

    /*
     * 0 hidden
     * 1 when queueing
     * 2 in duty
     * 3 like in duty, with single text line
     */
    [FieldOffset(4 * 4)] public int DutyState;

    [FieldOffset(5 * 4)] public int DutyFinderNameTextCount;

    [FieldOffset(6 * 4)] public int DutyFinderTextsCount;

    [FieldOffset(7 * 4)] public bool QuestListEnabled;
    [FieldOffset(8 * 4)] public int QuestCount;
    [FieldOffset(9 * 4), FixedSizeArray] internal FixedSizeArray10<int> _questTypeIcon;

    [FieldOffset(19 * 4), FixedSizeArray] internal FixedSizeArray10<int> _objectiveCountForQuest;
    [FieldOffset(29 * 4), FixedSizeArray] internal FixedSizeArray10<int> _objectiveProgress;
    [FieldOffset(39 * 4), FixedSizeArray] internal FixedSizeArray10<int> _buttonCountForQuest;

    // 49-88
    // ButtonActionId should be either an itemID or an emoteId|0x2000000
    // These are compacted, so from left-right, top-bottom
    [FieldOffset(49 * 4), FixedSizeArray] internal FixedSizeArray40<int> _questButtonActionId;

    // 89-128
    // These are indexed the same as the button actions
    [FieldOffset(89 * 4), FixedSizeArray] internal FixedSizeArray40<int> _questButtonIconID;

    [FieldOffset(129 * 4)] public int DutySectionEnable;
    [FieldOffset(130 * 4)] public int DutyIconId;

    [FieldOffset(131 * 4)] public int LeveCardIconId;
    [FieldOffset(132 * 4)] public int LeveFrameIconId;
    [FieldOffset(133 * 4)] public int LeveLocationIconId;

    [FieldOffset(134 * 4)] public int EventItemId;

    [FieldOffset(135 * 4)] public int DeepDungeonButtonIconId;

    [FieldOffset(136 * 4)] public int DutyObjectiveCount;
    [FieldOffset(137 * 4), FixedSizeArray] internal FixedSizeArray10<ObjectiveType> _dutyObjectiveTypes;

    // -1 causes ???, otherwise in range 0~100 for percentage, otherwise just a value
    [FieldOffset(147 * 4), FixedSizeArray] internal FixedSizeArray10<int> _dutyObjectiveValue;

    // Bar color is only enabled for duty objectives, and only for objective type LargeColorBar
    [FieldOffset(157 * 4), FixedSizeArray] internal FixedSizeArray10<BarColor> _barColors;

    [FieldOffset(167 * 4), Obsolete($"Renamed to {nameof(DutyCompletedObjectives)}")] public int CurrentDutyObjective;
    // bitfields, bit index is objective index
    [FieldOffset(167 * 4)] public uint DutyCompletedObjectives;
    [FieldOffset(168 * 4)] public int ObjectiveFocusable; // TODO: change type to uint
    [FieldOffset(169 * 4)] public int DutyTitleFocusable; // TODO: change type to uint

    // 170 - Related to MassivePcContent, displays a duty header section but is unstable when used

    [FieldOffset(171 * 4)] public int ShowFateUI;
    [FieldOffset(172 * 4)] public int ShowBonusEXPIndicator;

    [FieldOffset(173 * 4)] public CheckboxButtonFlags LevelSyncButton;

    [FieldOffset(174 * 4)] public int FateIconId;
    [FieldOffset(175 * 4)] public int FateObjectiveCount;

    [FieldOffset(176 * 4), FixedSizeArray] internal FixedSizeArray10<ObjectiveType> _fateObjectiveType;
    [FieldOffset(186 * 4), FixedSizeArray] internal FixedSizeArray10<int> _fateObjectiveValue;

    // 196 - Appears to be a bitfield with each bit from the lsb set if that objective is completed
    // [FieldOffset(196 * 4)] public int Unknown196;

    // Acts like 171- maybe cosmic/occult??
    // [FieldOffset(197 * 4)] public int Unknown197;

    /// <remarks> See also <see cref="TodoType"/> (same thing, different values). </remarks>
    public enum ObjectiveType {
        /// <remarks> See <see cref="TodoType.Text"/>. </remarks>
        Text = 0,
        /// <remarks> See <see cref="TodoType.Number"/>. </remarks>
        Number = 1,
        /// <remarks> See <see cref="TodoType.Fraction"/>. </remarks>
        Fraction = 2,
        /// <remarks> See <see cref="TodoType.Bar"/>. </remarks>
        Bar = 3,
        /// <remarks> See <see cref="TodoType.FractionBar"/>. </remarks>
        FractionBar = 4,
        /// <remarks> See <see cref="TodoType.TimeRemaining"/>. </remarks>
        TimeRemaining = 5,
        /// <remarks> See <see cref="TodoType.LargeGrayText"/>. </remarks>
        LargeGrayText = 6,
        /// <remarks> See <see cref="TodoType.LargeGrayNumber"/>. </remarks>
        LargeGrayNumber = 7,
        /// <remarks> See <see cref="TodoType.LargeGrayFraction"/>. </remarks>
        LargeGrayFraction = 8,
        /// <remarks> See <see cref="TodoType.LargeBar"/>. </remarks>
        ProgressBar = 9,
        /// <remarks> See <see cref="TodoType.ColorableBar"/>. </remarks>
        ColorableBar = 10,
        /// <remarks> See <see cref="TodoType.QuestTitle"/>. </remarks>
        QuestTitle = 11,
        /// <remarks> See <see cref="TodoType.LargeBlueText"/>. </remarks>
        LargeBlueText = 12,
        /// <remarks> See <see cref="TodoType.LargeTimeRemaining"/>. </remarks>
        LargeTimeRemaining = 13,
        /// <remarks> See <see cref="TodoType.JoinButton"/>. </remarks>
        JoinButton = 14,
        /// <remarks> See <see cref="TodoType.LongBar"/>. </remarks>
        LongBar = 15,

        // old values
        [Obsolete($"Renamed to {nameof(Text)}")] None = 0,
        [Obsolete($"Renamed to {nameof(Number)}")] SmallText = 1, // 2 also has this effect
        [Obsolete($"Renamed to {nameof(Bar)}")] InlineBar = 3, // 4 also has this effect
        [Obsolete($"Renamed to {nameof(TimeRemaining)}")] InlineTimer = 5,
        [Obsolete($"Renamed to {nameof(LargeGrayText)}")] LargeText = 6, // 7 and 8 also have this effect
        [Obsolete($"Renamed to {nameof(ProgressBar)}")] LargeBar = 9,
        [Obsolete($"Renamed to {nameof(ColorableBar)}")] LargeBarColorable = 10,
        [Obsolete($"Renamed to {nameof(LargeBlueText)}")] LargeText2 = 12, // Much like LargeText, but different for unknown reasons
        [Obsolete($"Renamed to {nameof(LargeTimeRemaining)}")] LargeInlineTimer = 13,
        [Obsolete($"Renamed to {nameof(JoinButton)}")] BigCheckbox = 14, // looks like level sync button
        [Obsolete($"Renamed to {nameof(LongBar)}")] InlineBarLong = 15 // 16 also has this effect
    }

    public enum BarColor {
        Blue = 0,
        Red = 1,
        Yellow = 2,
        White = 3,
        Green = 4
    }

    [Flags]
    public enum CheckboxButtonFlags {
        Show = 0x1000,
        Toggled = 0x0010,
        AsCheckbox = 0x0100
    }
}
