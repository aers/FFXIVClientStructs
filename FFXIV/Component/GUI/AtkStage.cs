using FFXIVClientStructs.FFXIV.Client.Graphics.Render;
using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;
using FFXIVClientStructs.FFXIV.Client.UI;
using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Component.GUI
{
    // Component::GUI::AtkStage
    //   Component::GUI::AtkEventTarget

    // size = 0x75DF8
    // ctor E8 ? ? ? ? 48 8B F8 48 89 BE ? ? ? ? 48 8B 43 10 
    [StructLayout(LayoutKind.Explicit, Size = 0x75DF8)]
    public unsafe struct AtkStage
    {
        [FieldOffset(0x0)] public AtkEventTarget AtkEventTarget;
        [FieldOffset(0x20)] public RaptureAtkUnitManager* RaptureAtkUnitManager;
    }
}
