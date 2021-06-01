using System.Runtime.InteropServices;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI
{
    // Client::UI::AddonSelectString
    //   Component::GUI::AtkUnitBase
    //     Component::GUI::AtkEventListener
    [StructLayout(LayoutKind.Explicit, Size = 0x2A8)]
    public unsafe struct AddonSelectString
    {
        [FieldOffset(0x0)] public AtkUnitBase AtkUnitBase;
        [FieldOffset(0x238)] public PopupMenuDerive PopupMenu;

        // this has a base class but I don't feel like adding it right now
        [StructLayout(LayoutKind.Explicit, Size = 0x70)]
        public struct PopupMenuDerive
        {
            [FieldOffset(0x0)] public void* vtbl;
            [FieldOffset(0x8)] public AtkStage* AtkStage;
            [FieldOffset(0x10)] public byte** EntryNames; // array of char* pointers
            [FieldOffset(0x30)] public AtkComponentWindow* Window;
            [FieldOffset(0x38)] public AtkComponentList* List;
            [FieldOffset(0x40)] public AtkUnitBase* Owner;
            [FieldOffset(0x4C)] public int EntryCount;
        }
    }
}