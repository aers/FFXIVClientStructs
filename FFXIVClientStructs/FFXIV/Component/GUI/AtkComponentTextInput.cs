using FFXIVClientStructs.FFXIV.Client.System.Input;
using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkComponentTextInput
//   Component::GUI::AtkComponentInputBase
//     Component::GUI::AtkComponentBase
//       Component::GUI::AtkEventListener
//   Component::GUI::AtkTextInput::AtkTextInputEventInterface
//   Client::System::Input::SoftKeyboardDeviceInterface::SoftKeyboardInputInterface
// common CreateAtkComponent function "E8 ?? ?? ?? ?? 48 8B F8 48 85 C0 0F 84 ?? ?? ?? ?? 49 8B 0F"
// type 7
[StructLayout(LayoutKind.Explicit, Size = 0x600)]
public unsafe partial struct AtkComponentTextInput {
    [FieldOffset(0x0)] public AtkComponentInputBase AtkComponentInputBase;

    [FieldOffset(0x1E0), CExportIgnore] public void** AtkTextInputEventInterfaceVtbl;
    [FieldOffset(0x1E8)] public SoftKeyboardDeviceInterface.SoftKeyboardInputInterface SoftKeyboardInputInterface; // implemented by class

    [FieldOffset(0x250)] public uint MaxTextLength;
    [FieldOffset(0x254)] public uint MaxTextLength2; // no idea when one of these are used over the other

    [FieldOffset(0x280)] public Utf8String UnkText1;
    [FieldOffset(0x2E8)] public Utf8String UnkText2;
    [FieldOffset(0x350)] public Utf8String UnkText3;
    [FieldOffset(0x450)] public Utf8String UnkText4;
    [FieldOffset(0x4B8)] public Utf8String UnkText5;

    [MemberFunction("E8 ?? ?? ?? ?? 45 32 C0 8B D6"), GenerateCStrOverloads]
    public readonly partial void SetText(byte* text);
}
