using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Component.GUI;
// Component::GUI::AtkComponentTextInput
//   Component::GUI::AtkComponentInputBase
//     Component::GUI::AtkComponentBase
//       Component::GUI::AtkEventListener
//   Component::GUI::AtkTextInput::AtkTextInputEventInterface
//   Client::System::Input::SoftKeyboardDeviceInterface::SoftKeyboardInputInterface

// size = 0x600
// common CreateAtkComponent function 8B FA 33 DB E8 ?? ?? ?? ?? 
// type 7
[StructLayout(LayoutKind.Explicit, Size = 0x600)]
public struct AtkComponentTextInput
{
    [FieldOffset(0x0)] public AtkComponentInputBase AtkComponentInputBase;
    [FieldOffset(0x280)] public Utf8String UnkText1;
    [FieldOffset(0x2E8)] public Utf8String UnkText2;
    [FieldOffset(0x350)] public Utf8String UnkText3;
    [FieldOffset(0x450)] public Utf8String UnkText4;
    [FieldOffset(0x4B8)] public Utf8String UnkText5;
}