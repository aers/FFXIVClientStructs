using FFXIVClientStructs.Component.GUI;
using System.Runtime.InteropServices;

namespace FFXIVClientStructs.Client.UI
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
        [FieldOffset(0x250)] public FFXIVString String250;
        [FieldOffset(0x2B8)] public FFXIVString String2B8;
        [FieldOffset(0x320)] public FFXIVString String320;
        [FieldOffset(0x388)] public FFXIVString String388;
        [FieldOffset(0x3F0)] public FFXIVString String3F0;
        [FieldOffset(0x458)] public FFXIVString String458;
        [FieldOffset(0x4C0)] public FFXIVString String4C0;
        [FieldOffset(0x590)] public void* vtbl590;
        [FieldOffset(0x2F0)] public void* vtbl598;
        [FieldOffset(0x2F8)] public void* unk2F8;
        [FieldOffset(0x5B8)] public AddonTalk* this5B8;
        [FieldOffset(0x5C0)] public AtkStage* AtkStage;
    }
}
