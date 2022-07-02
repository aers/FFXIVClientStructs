namespace FFXIVClientStructs.FFXIV.Component.GUI;
// Component::GUI::AtkComponentNumericInput
//   Component::GUI::AtkComponentInputBase
//     Component::GUI::AtkComponentBase
//       Component::GUI::AtkEventListener

[StructLayout(LayoutKind.Explicit, Size = 0x338)]
public unsafe partial struct AtkComponentNumericInput
{
    [FieldOffset(0x0)] public AtkComponentInputBase AtkComponentInputBase;
    [FieldOffset(0x2F8)] public AtkUldComponentDataNumericInput Data;

    [MemberFunction("E8 ?? ?? ?? ?? 81 4E ?? ?? ?? ?? ?? EB 07")]
    public partial void SetValue(int value);
}