using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[Addon("_QTEMash")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x268)]
public unsafe partial struct AddonQTEMash {
    [FieldOffset(0x238)] public uint State; // 0 = idle? 1 = accepting inputs, 2 = success
    //[FieldOffset(0x23C)] public byte Unk23C; // might be some kind of debounce flag
    [FieldOffset(0x240)] public AtkComponentButton* Button;
    [FieldOffset(0x248)] public AtkTextNode* TimerText;
    [FieldOffset(0x250)] public AtkComponentTextNineGrid* NineGrid;
    [FieldOffset(0x258)] public AtkComponentGaugeBar* ProgressBar;
    [FieldOffset(0x262)] public ushort FillProgress;
    [FieldOffset(0x264)] public ushort FillMax;

    [MemberFunction("E8 ?? ?? ?? ?? 33 C9 E8 ?? ?? ?? ?? 33 D2 48 8B CF")]
    public partial void Complete();
}
