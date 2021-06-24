using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Component.GUI
{
    // Component::GUI::AtkComponentNumericInput
    //   Component::GUI::AtkComponentInputBase
    //     Component::GUI::AtkComponentBase
    //       Component::GUI::AtkEventListener

    [StructLayout(LayoutKind.Explicit, Size = 0x338)]
    public struct AtkComponentNumericInput
    {
        [FieldOffset(0x0)] public AtkComponentInputBase AtkComponentInputBase;
    }
}