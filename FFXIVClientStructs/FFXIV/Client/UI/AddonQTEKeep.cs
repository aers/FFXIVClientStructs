using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[Addon("_QTEKeep")]
[GenerateInterop(true)]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x278)]
public unsafe partial struct AddonQTEKeep {
    [FieldOffset(0x240)] public AtkComponentButton* Button;
    [FieldOffset(0x248)] public AtkTextNode* ProgressText;
    [FieldOffset(0x250)] public AtkComponentTextNineGrid* NineGrid;
    [FieldOffset(0x258)] public AtkComponentGaugeBar* Bar;

    [FieldOffset(0x268)] public float Progress; // 0-100
}

[Addon("_QTEKeepTime")]
[GenerateInterop]
[Inherits<AddonQTEKeep>]
[StructLayout(LayoutKind.Explicit, Size = 0x278)]
public partial struct AddonQTEKeepTime;
