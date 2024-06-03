namespace FFXIVClientStructs.FFXIV.Component.GUI;
// Component::GUI::AtkComponentNumericInput
//   Component::GUI::AtkComponentInputBase
//     Component::GUI::AtkComponentBase
//       Component::GUI::AtkEventListener

[GenerateInterop]
[Inherits<AtkComponentInputBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x338)]
public unsafe partial struct AtkComponentNumericInput {
    [FieldOffset(0x1F8)] public int Value; // Found through SetValue function
    [FieldOffset(0x2F8)] public AtkUldComponentDataNumericInput Data;

    [MemberFunction("E8 ?? ?? ?? ?? 81 4F ?? ?? ?? ?? ?? EB 07")]
    public partial void SetValue(int value);
}
