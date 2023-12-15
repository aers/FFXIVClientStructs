using FFXIVClientStructs.FFXIV.Component.GUI;
using static FFXIVClientStructs.FFXIV.Client.UI.AddonJobHud;

namespace FFXIVClientStructs.FFXIV.Client.UI;

/// <summary>
/// AST - Arcana Gauge
/// </summary>
[Addon("JobHudAST0")]
[StructLayout(LayoutKind.Explicit, Size = 0x468)]
public unsafe partial struct AddonJobHudAST0 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;

    [StructLayout(LayoutKind.Explicit, Size = 0x40)]
    public partial struct ArcanaGaugeData {
        [FieldOffset(0x00)] public AddonJobHudGaugeData GaugeData;
        [FieldOffset(0x08)] public fixed byte Prerequisites[3];
        [FieldOffset(0x0C)] public int DrawnCard;
        [FieldOffset(0x10)] public int DrawnMinorArcanum;
        [FieldOffset(0x14)] public int DrawnRoleBuff;
        [FieldOffset(0x18)] public int DrawnAstrosign;
        [FieldOffset(0x1C)] public int Astrosign1;
        [FieldOffset(0x20)] public int Astrosign2;
        [FieldOffset(0x24)] public int Astrosign3;
        [FieldOffset(0x30)] public byte* CardName;
        [FieldOffset(0x38)] public byte* MinorArcanaName;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0xC8)]
    public partial struct ArcanaGauge {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
        [FieldOffset(0x10)] public AtkResNode* Container;
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

        [FixedSizeArray<Astrosign>(3)]
        [FieldOffset(0x78)] public fixed byte Astrosigns[3 * Astrosign.Size];
    }

    [StructLayout(LayoutKind.Explicit, Size = 0xC0)]
    public partial struct ArcanaGaugeSimple {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
        [FieldOffset(0x10)] public AtkComponentBase* CardContainer;
        [FieldOffset(0x18)] public AtkComponentTextNineGrid* CardName;
        [FieldOffset(0x20)] public AtkResNode* CardAstrosign;
        [FieldOffset(0x28)] public AtkResNode* CardSymbol;
        [FieldOffset(0x30)] public AtkResNode* CardBorder;
        [FieldOffset(0x38)] public AtkResNode* Container;
        [FieldOffset(0x40)] public AtkComponentBase* MinorArcanaContainer;
        [FieldOffset(0x48)] public AtkComponentTextNineGrid* MinorArcanaName; // seemingly unused
        [FieldOffset(0x50)] public AtkResNode* MinorArcanaSymbol;
        [FieldOffset(0x58)] public AtkResNode* AstrosignContainer;

        [FixedSizeArray<Astrosign>(3)]
        [FieldOffset(0x70)] public fixed byte Astrosigns[3 * Astrosign.Size];
    }

    [StructLayout(LayoutKind.Explicit, Size = Size)]
    public partial struct Astrosign {
        public const int Size = 0x18;
        [FieldOffset(0x00)] public AtkComponentBase* Container;
        [FieldOffset(0x08)] public AtkResNode* Symbol;
        [FieldOffset(0x10)] public int Type;
    }

    [FieldOffset(0x260)] public ArcanaGaugeData DataPrevious;
    [FieldOffset(0x2A0)] public ArcanaGaugeData DataCurrent;
    [FieldOffset(0x2E0)] public ArcanaGauge GaugeStandard;
    [FieldOffset(0x3A8)] public ArcanaGaugeSimple GaugeSimple;
}
