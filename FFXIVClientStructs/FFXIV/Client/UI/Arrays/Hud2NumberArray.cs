using FFXIVClientStructs.FFXIV.Client.Game.Object;
using FFXIVClientStructs.FFXIV.Component.GUI;


namespace FFXIVClientStructs.FFXIV.Client.UI.Arrays;

[CExportIgnore]
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 192 * 4)]
public unsafe partial struct Hud2NumberArray {
    public static Hud2NumberArray* Instance() => (Hud2NumberArray*)AtkStage.Instance()->GetNumberArrayData(NumberArrayType.Hud2)->IntArray;

    [FieldOffset(0), FixedSizeArray, CExportIgnore] internal FixedSizeArray192<int> _data;

    [FieldOffset(0 * 4)] public bool TargetInfoUICombined;
    /// <summary>
    /// Keeps count of how often you targeted someone and the target changed.
    /// </summary>
    [FieldOffset(1 * 4)] public int TargetCount;
    [FieldOffset(2 * 4)] public ObjectKind TargetObjectKind;
    /// <summary>
    /// Range 0 to 10,000
    /// </summary>
    [FieldOffset(3 * 4)] public int TargetCurrentHealth;
    [FieldOffset(4 * 4)] public int TargetStatusCount;
    /// <summary>
    /// The final 3 bytes per status are used for the UIColor RowId
    /// </summary>
    [FieldOffset(5 * 4), FixedSizeArray] internal FixedSizeArray30<uint> _targetStatusIconIds;
    [FieldOffset(35 * 4), FixedSizeArray] internal FixedSizeArray30<bool> _targetStatusDispellable;
    [FieldOffset(65 * 4)] public Hud2ColorNumberArray TargetBarFillColor;
    [FieldOffset(66 * 4)] public Hud2ColorNumberArray TargetBarBackdropColor;
    [FieldOffset(67 * 4)] public bool UnkFlag1;
    [FieldOffset(69 * 4)] public int TargetCastPercent;
    [FieldOffset(72 * 4)] public bool TargetHasTarget;
    /// <summary>
    /// Keeps count of how your target has targeted a new target.
    /// </summary>
    [FieldOffset(74 * 4)] public int TargetOfTargetCount;
    [FieldOffset(76 * 4)] public bool UnkFlag2;
    [FieldOffset(77 * 4)] public int TargetOfTargetEntityId;
    [FieldOffset(78 * 4)] public Hud2ColorNumberArray TargetOfTargetBarFillColor;
    [FieldOffset(79 * 4)] public Hud2ColorNumberArray TargetOfTargetBarBackdropColor;
    [FieldOffset(80 * 4)] public int FocusTargetCount;
    [FieldOffset(81 * 4)] public int FocusTargetLevel;
    [FieldOffset(84 * 4)] public int FocusTargetMaxHealth;
    /// <summary>
    /// Range 0 to 10,000
    /// </summary>
    [FieldOffset(85 * 4)] public int FocusTargetCurrentHealth;
    [FieldOffset(86 * 4)] public Hud2ColorNumberArray FocusTargetBarFillColor;
    [FieldOffset(87 * 4)] public Hud2ColorNumberArray FocusTargetBarBackdropColor;
    [FieldOffset(88 * 4)] public int FocusTargetCastPercent;
    [FieldOffset(91 * 4)] public int FocusTargetStatusCount;
    [FieldOffset(92 * 4), FixedSizeArray] internal FixedSizeArray5<uint> _focusTargetStatusIconIds;
    [FieldOffset(97 * 4), FixedSizeArray] internal FixedSizeArray5<bool> _focusTargetStatusDispellable;

    [CExportIgnore]
    [StructLayout(LayoutKind.Explicit, Size = 1 * 4)]
    public partial struct Hud2ColorNumberArray {
        [FieldOffset(0), FixedSizeArray, CExportIgnore] internal FixedSizeArray1<int> _data;

        [FieldOffset(3)] public byte R;
        [FieldOffset(2)] public byte G;
        [FieldOffset(1)] public byte B;
        [FieldOffset(0)] public byte A;
    }
}


