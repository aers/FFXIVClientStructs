using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Client.UI
{
    // Client::UI::RaptureAtkModule
    //   Component::GUI::AtkModule
    //     Component::GUI::AtkModuleInterface

    [StructLayout(LayoutKind.Explicit, Size = 0x8)]  // either this is tiny, or huge
    public unsafe struct RaptureAtkModule
    {
        [FieldOffset(0x0)] public void* vtbl;
    }
}
