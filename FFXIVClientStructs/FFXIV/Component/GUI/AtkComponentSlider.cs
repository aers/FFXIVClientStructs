namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkComponentSlider
//   Component::GUI::AtkComponentBase
//     Component::GUI::AtkEventListener
// common CreateAtkComponent function "E8 ?? ?? ?? ?? 48 8B F8 48 85 C0 0F 84 ?? ?? ?? ?? 49 8B 0F"
// type 6
[StructLayout(LayoutKind.Explicit, Size = 0x100)]
public partial struct AtkComponentSlider {
    [FieldOffset(0x0)] public AtkComponentBase AtkComponentBase;

    [FieldOffset(0xE8)] public int MinValue;
    [FieldOffset(0xEC)] public int MaxValue;
    [FieldOffset(0xF0)] public int Value;
    [FieldOffset(0xF4)] public int Steps;

    [MemberFunction("3B 91 ?? ?? ?? ?? 7F 06")]
    public partial void SetMinValue(int minValue);

    [MemberFunction("3B 91 ?? ?? ?? ?? 7C 06")]
    public partial void SetMaxValue(int maxValue);

    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 43 3C")]
    public partial void SetValue(int value, bool dispatchEvent29 = true);
}
