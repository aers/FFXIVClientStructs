using FFXIVClientStructs.FFXIV.Component.GUI;
using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Client.UI
{
    // Client::UI::AddonSelectIconString
    //   Component::GUI::AtkUnitBase
    //     Component::GUI::AtkEventListener
    [StructLayout(LayoutKind.Explicit, Size = 0x2A0)]
    public unsafe struct AddonSelectIconString
    {
        [FieldOffset(0x0)] public AtkUnitBase AtkUnitBase;
        [FieldOffset(0x238)] public void* vtbl238;
        [FieldOffset(0x240)] public AtkStage* AtkStage;
        [FieldOffset(0x248)] public char** SelectStrings;
        [FieldOffset(0x258)] public void* unk258;
        [FieldOffset(0x268)] public AtkComponentWindow* AtkComponentWindow;
        [FieldOffset(0x270)] public AtkComponentList* AtkComponentList;
        [FieldOffset(0x278)] public AddonSelectIconString* this278;
        [FieldOffset(0x298)] public void* unk298;
    }
}
