using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Component.GUI
{
    // Component::GUI::AtkModule
    //   Component::GUI::AtkModuleInterface
    [StructLayout(LayoutKind.Explicit, Size = 0x8200)]
    public unsafe struct AtkModule
    {
        [FieldOffset(0x0)] public void* vtbl;
        [FieldOffset(0x1B30)] public AtkArrayDataHolder AtkArrayDataHolder;
    }
}