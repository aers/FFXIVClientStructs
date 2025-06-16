using FFXIVClientStructs.FFXIV.Client.System.Memory;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkComponentSlider
//   Component::GUI::AtkComponentBase
//     Component::GUI::AtkEventListener
// common CreateAtkComponent function "E8 ?? ?? ?? ?? 4C 8B F0 48 85 C0 0F 84 ?? ?? ?? ?? 49 8B 4D 08"
// type 6
[GenerateInterop]
[Inherits<AtkComponentBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x100)]
public partial struct AtkComponentSlider : ICreatable {
    [FieldOffset(0xE8)] public int MinValue;
    [FieldOffset(0xEC)] public int MaxValue;
    [FieldOffset(0xF0)] public int Value;
    [FieldOffset(0xF4)] public int Steps;
    [FieldOffset(0xF8)] public short OffsetL; // Not set automatically via component initializer
    [FieldOffset(0xFA)] public short OffsetR; // Not set automatically via component initializer
    [FieldOffset(0xFC)] public short SliderSize; // Size in pixels of the parent, not set automatically via component initializer, used for calculating/setting width of green bar/ninegridnode

    [MemberFunction("3B 91 ?? ?? ?? ?? 7F 06")]
    public partial void SetMinValue(int minValue);

    [MemberFunction("3B 91 ?? ?? ?? ?? 7C 06")]
    public partial void SetMaxValue(int maxValue);

    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 43 3C")]
    public partial void SetValue(int value, bool dispatchEvent29 = true);

    // Inlined in 7.0, but still hanging around
    [MemberFunction("33 D2 C7 81 ?? ?? ?? ?? ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 89 51 08 48 89 01 48 8B C1 48 89 51 10 48 89 51 18 48 89 51 20 48 89 51 28 48 89 51 30 48 89 51 38 48 89 51 40 89 51 48 48 89 51 50 48 89 51 58 48 89 51 60 48 89 51 68 89 51 70 48 89 51 78 48 89 91 ?? ?? ?? ?? 48 89 91 ?? ?? ?? ?? 66 89 91 ?? ?? ?? ?? 89 91 ?? ?? ?? ?? 48 89 91 ?? ?? ?? ?? 48 89 91 ?? ?? ?? ?? 48 89 91 ?? ?? ?? ?? 88 91 ?? ?? ?? ?? 48 89 91 ?? ?? ?? ?? 48 89 91 ?? ?? ?? ?? 48 89 91 ?? ?? ?? ?? 48 89 91 ?? ?? ?? ?? 48 89 91 ?? ?? ?? ?? 89 91 ?? ?? ?? ??")]
    public partial void Ctor();
}
