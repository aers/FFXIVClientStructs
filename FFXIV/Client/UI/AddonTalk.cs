using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.GUI;
using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Client.UI
{
    // Client::UI::AddonTalk
    //   Component::GUI::AtkUnitBase
    //     Component::GUI::AtkEventListener
    [StructLayout(LayoutKind.Explicit, Size = 0x5F8)]
    public unsafe struct AddonTalk
    {
        [FieldOffset(0x0)] public AtkUnitBase AtkUnitBase;
        [FieldOffset(0x220)] public AtkTextNode* AtkTextNode220;
        [FieldOffset(0x228)] public AtkTextNode* AtkTextNode228;
        [FieldOffset(0x230)] public AtkResNode* AtkResNode230;
        [FieldOffset(0x248)] public void* unk248;
        [FieldOffset(0x250)] public Utf8String String250;
        [FieldOffset(0x2B8)] public Utf8String String2B8;
        [FieldOffset(0x320)] public Utf8String String320;
        [FieldOffset(0x388)] public Utf8String String388;
        [FieldOffset(0x3F0)] public Utf8String String3F0;
        [FieldOffset(0x458)] public Utf8String String458;
        [FieldOffset(0x4C0)] public Utf8String String4C0;
        [FieldOffset(0x5B8)] public AddonTalk* this5B8;
        [FieldOffset(0x5C0)] public AtkStage* AtkStage;
    }
}
