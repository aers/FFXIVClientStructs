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
        [FieldOffset(0x238)] public EventThing SelectIconStringThing;

        [StructLayout(LayoutKind.Explicit, Size = 0x68)]
        public unsafe struct EventThing
        {
            [FieldOffset(0x0)] public void* vtbl;
            [FieldOffset(0x8)] public AtkStage* AtkStage;
            [FieldOffset(0x38)] public AtkComponentList* AtkComponentList;
            [FieldOffset(0x40)] public AddonSelectIconString* Addon;
        }
    }
}
