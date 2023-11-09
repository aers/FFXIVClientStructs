using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[StructLayout(LayoutKind.Explicit, Size = 0x260)]
public unsafe partial struct AddonJobHud {
    [FieldOffset(0x000)] public AtkUnitBase AtkUnitBase;
    [FieldOffset(0x248)] public AtkResNode* RootNode;
}

[Addon("JobHudACN0")]
[StructLayout(LayoutKind.Explicit, Size = 0x340)]
public unsafe partial struct AddonJobHudACN0 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;
}

[Addon("JobHudAST0")]
[StructLayout(LayoutKind.Explicit, Size = 0x468)]
public unsafe partial struct AddonJobHudAST0 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;
}

[Addon("JobHudBLM0")]
[StructLayout(LayoutKind.Explicit, Size = 0x4E0)]
public unsafe partial struct AddonJobHudBLM0 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;
}

[Addon("JobHudBRD0")]
[StructLayout(LayoutKind.Explicit, Size = 0x4C0)]
public unsafe partial struct AddonJobHudBRD0 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;
}

[Addon("JobHudDNC0")]
[StructLayout(LayoutKind.Explicit, Size = 0x398)]
public unsafe partial struct AddonJobHudDNC0 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;
}

[Addon("JobHudDNC1")]
[StructLayout(LayoutKind.Explicit, Size = 0x3A8)]
public unsafe partial struct AddonJobHudDNC1 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;
}

[Addon("JobHudDRG0")]
[StructLayout(LayoutKind.Explicit, Size = 0x398)]
public unsafe partial struct AddonJobHudDRG0 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;
}

[Addon("JobHudDRK0")]
[StructLayout(LayoutKind.Explicit, Size = 0x318)]
public unsafe partial struct AddonJobHudDRK0 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;
}

[Addon("JobHudDRK1")]
[StructLayout(LayoutKind.Explicit, Size = 0x338)]
public unsafe partial struct AddonJobHudDRK1 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;
}

[Addon("JobHudGFF0")]
[StructLayout(LayoutKind.Explicit, Size = 0x2C0)]
public unsafe partial struct AddonJobHudGFF0 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;
}

[Addon("JobHudGFF1")]
[StructLayout(LayoutKind.Explicit, Size = 0x370)]
public unsafe partial struct AddonJobHudGFF1 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;
}

[Addon("JobHudGNB0")]
[StructLayout(LayoutKind.Explicit, Size = 0x358)]
public unsafe partial struct AddonJobHudGNB0 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;
}

[Addon("JobHudMCH0")]
[StructLayout(LayoutKind.Explicit, Size = 0x3B8)]
public unsafe partial struct AddonJobHudMCH0 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;
}

[Addon("JobHudMNK0")]
[StructLayout(LayoutKind.Explicit, Size = 0x420)]
public unsafe partial struct AddonJobHudMNK0 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;
}
[Addon("JobHudMNK1")]
[StructLayout(LayoutKind.Explicit, Size = 0x308)]
public unsafe partial struct AddonJobHudMNK1 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;
}

[Addon("JobHudNIN0")]
[StructLayout(LayoutKind.Explicit, Size = 0x308)]
public unsafe partial struct AddonJobHudNIN0 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;
}

[Addon("JobHudNIN1")]
[StructLayout(LayoutKind.Explicit, Size = 0x320)]
public unsafe partial struct AddonJobHudNIN1 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;
}

[Addon("JobHudPLD0")]
[StructLayout(LayoutKind.Explicit, Size = 0x330)]
public unsafe partial struct AddonJobHudPLD0 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;
}

[Addon("JobHudRDM0")]
[StructLayout(LayoutKind.Explicit, Size = 0x440)]
public unsafe partial struct AddonJobHudRDM0 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;
}

[Addon("JobHudRPR0")]
[StructLayout(LayoutKind.Explicit, Size = 0x3F8)]
public unsafe partial struct AddonJobHudRPR0 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;
}

[Addon("JobHudRPR1")]
[StructLayout(LayoutKind.Explicit, Size = 0x490)]
public unsafe partial struct AddonJobHudRPR1 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;
}

[Addon("JobHudSAM0")]
[StructLayout(LayoutKind.Explicit, Size = 0x380)]
public unsafe partial struct AddonJobHudSAM0 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;
}

[Addon("JobHudSAM1")]
[StructLayout(LayoutKind.Explicit, Size = 0x328)]
public unsafe partial struct AddonJobHudSAM1 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;
}

[Addon("JobHudSCH0")]
[StructLayout(LayoutKind.Explicit, Size = 0x388)]
public unsafe partial struct AddonJobHudSCH0 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;
}

[Addon("JobHudSMN0")]
[StructLayout(LayoutKind.Explicit, Size = 0x2F0)]
public unsafe partial struct AddonJobHudSMN0 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;
}

[Addon("JobHudSMN1")]
[StructLayout(LayoutKind.Explicit, Size = 0x4B0)]
public unsafe partial struct AddonJobHudSMN1 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;
}

[Addon("JobHudWAR0")]
[StructLayout(LayoutKind.Explicit, Size = 0x328)]
public unsafe partial struct AddonJobHudWAR0 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;
}

[Addon("JobHudWHM0")]
[StructLayout(LayoutKind.Explicit, Size = 0x3B0)]
public unsafe partial struct AddonJobHudWHM0 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;
}
