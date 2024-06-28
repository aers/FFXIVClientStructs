using FFXIVClientStructs.FFXIV.Component.GUI;
using static FFXIVClientStructs.FFXIV.Client.UI.AddonJobHud;

namespace FFXIVClientStructs.FFXIV.Client.UI;

/// <summary>
/// AST - Arcana Gauge
/// </summary>
[Addon("JobHudAST0")]
[GenerateInterop]
[Inherits<AddonJobHud>]
[StructLayout(LayoutKind.Explicit, Size = 0x3F8)]
public unsafe partial struct AddonJobHudAST0 {
    [FieldOffset(0x270)] public ArcanaGaugeData DataPrevious;
    [FieldOffset(0x290)] public ArcanaGaugeData DataCurrent;
    [FieldOffset(0x2B0)] public ArcanaGauge GaugeStandard;
    [FieldOffset(0x2B8)] public ArcanaGaugeSimple GaugeSimple;

    [GenerateInterop]
    [Inherits<AddonJobHudGaugeData>]
    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public partial struct ArcanaGaugeData {

        // Reduced size in 7.0

      /*  [FieldOffset(0x08), FixedSizeArray] internal FixedSizeArray3<byte> _prerequisites;
        [FieldOffset(0x0C)] public int DrawnCard;
        [FieldOffset(0x10)] public int DrawnMinorArcanum;
        [FieldOffset(0x14)] public int DrawnRoleBuff;
        [FieldOffset(0x18)] public int DrawnAstrosign;
        [FieldOffset(0x1C)] public int Astrosign1;
        [FieldOffset(0x20)] public int Astrosign2;
        [FieldOffset(0x24)] public int Astrosign3;
        [FieldOffset(0x30)] public byte* CardName;
        [FieldOffset(0x38)] public byte* MinorArcanaName;*/
    }

    [GenerateInterop]
    [Inherits<AddonJobHudGauge>]
    [StructLayout(LayoutKind.Explicit, Size = 0xA8)]
    public partial struct ArcanaGauge {

        // Reduced size in 7.0

        /* [FieldOffset(0x10)] public AtkResNode* Container;
         [FieldOffset(0x18)] public AtkComponentBase* CardContainer;
         [FieldOffset(0x20)] public AtkTextNode* CardName;
         [FieldOffset(0x28)] public AtkResNode* CardAstrosign;
         [FieldOffset(0x30)] public AtkResNode* CardSymbol;
         [FieldOffset(0x38)] public AtkResNode* CardBorder;
         [FieldOffset(0x40)] public AtkResNode* GaugePlate;
         [FieldOffset(0x48)] public AtkResNode* MinorArcanaContainer;
         [FieldOffset(0x50)] public AtkTextNode* MinorArcanaName;
         [FieldOffset(0x58)] public AtkResNode* MinorArcanaSymbol;
         [FieldOffset(0x60)] public AtkResNode* AstrosignContainer;

         [FieldOffset(0x78), FixedSizeArray] internal FixedSizeArray3<Astrosign> _astrosigns;
     */
    }

    [GenerateInterop]
    [Inherits<AddonJobHudGauge>]
    [StructLayout(LayoutKind.Explicit, Size = 0xA0)]
    public partial struct ArcanaGaugeSimple {

        // Reduced size in 7.0

        /* [FieldOffset(0x10)] public AtkComponentBase* CardContainer;
         [FieldOffset(0x18)] public AtkComponentTextNineGrid* CardName;
         [FieldOffset(0x20)] public AtkResNode* CardAstrosign;
         [FieldOffset(0x28)] public AtkResNode* CardSymbol;
         [FieldOffset(0x30)] public AtkResNode* CardBorder;
         [FieldOffset(0x38)] public AtkResNode* Container;
         [FieldOffset(0x40)] public AtkComponentBase* MinorArcanaContainer;
         [FieldOffset(0x48)] public AtkComponentTextNineGrid* MinorArcanaName; // seemingly unused
         [FieldOffset(0x50)] public AtkResNode* MinorArcanaSymbol;
         [FieldOffset(0x58)] public AtkResNode* AstrosignContainer;

         [FieldOffset(0x70), FixedSizeArray] internal FixedSizeArray3<Astrosign> _astrosigns;
    */
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public struct Astrosign {
        [FieldOffset(0x00)] public AtkComponentBase* Container;
        [FieldOffset(0x08)] public AtkResNode* Symbol;
        [FieldOffset(0x10)] public int Type;
    }
}
