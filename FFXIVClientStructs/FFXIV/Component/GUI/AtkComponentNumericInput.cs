using FFXIVClientStructs.FFXIV.Client.System.Memory;

namespace FFXIVClientStructs.FFXIV.Component.GUI;
// Component::GUI::AtkComponentNumericInput
//   Component::GUI::AtkComponentInputBase
//     Component::GUI::AtkComponentBase
//       Component::GUI::AtkEventListener

[GenerateInterop]
[Inherits<AtkComponentInputBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x338)]
public unsafe partial struct AtkComponentNumericInput : ICreatable {
    [FieldOffset(0x1F8)] public int Value; // Found through SetValue function
    [FieldOffset(0x2F8)] public AtkUldComponentDataNumericInput Data;

    [MemberFunction("48 89 5C 24 ?? 48 89 74 24 ?? 57 48 81 EC ?? ?? ?? ?? 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 84 24 ?? ?? ?? ?? 48 8B F1 E8 ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 C7 86 ?? ?? ?? ?? ?? ?? ?? ??")]
    public partial void Ctor();

    [MemberFunction("E8 ?? ?? ?? ?? 81 4F ?? ?? ?? ?? ?? EB 07")]
    public partial void SetValue(int value);
}
