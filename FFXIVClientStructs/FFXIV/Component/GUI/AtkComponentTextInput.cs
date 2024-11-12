using FFXIVClientStructs.FFXIV.Client.System.Input;
using FFXIVClientStructs.FFXIV.Client.System.Memory;
using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkComponentTextInput
//   Component::GUI::AtkComponentInputBase
//     Component::GUI::AtkComponentBase
//       Component::GUI::AtkEventListener
//   Component::GUI::AtkTextInput::AtkTextInputEventInterface
//   Client::System::Input::SoftKeyboardDeviceInterface::SoftKeyboardInputInterface
// common CreateAtkComponent function "E8 ?? ?? ?? ?? 4C 8B F0 48 85 C0 0F 84 ?? ?? ?? ?? 49 8B 4D 08"
// type 7
[GenerateInterop]
[Inherits<AtkComponentInputBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x600)]
public unsafe partial struct AtkComponentTextInput : ICreatable {

    [FieldOffset(0x1E8)] public SoftKeyboardDeviceInterface.SoftKeyboardInputInterface SoftKeyboardInputInterface; // implemented by class

    [FieldOffset(0x250)] public uint MaxTextLength;
    [FieldOffset(0x254)] public uint MaxTextLength2; // no idea when one of these are used over the other

    [FieldOffset(0x280)] public Utf8String UnkText01;
    [FieldOffset(0x2E8)] public Utf8String UnkText02;
    [FieldOffset(0x350)] public Utf8String UnkText03;
    [FieldOffset(0x450)] public Utf8String UnkText04;
    [FieldOffset(0x4B8)] public Utf8String UnkText05;

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 45 33 C9 33 D2 B9 ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 8B F0")]
    public partial void Ctor();

    [MemberFunction("E8 ?? ?? ?? ?? 45 32 C0 33 D2"), GenerateStringOverloads]
    public partial void SetText(byte* text);
}
