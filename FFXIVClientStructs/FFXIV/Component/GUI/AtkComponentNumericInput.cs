using FFXIVClientStructs.Common;
using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Component.GUI
{
    // Component::GUI::AtkComponentNumericInput
    //   Component::GUI::AtkComponentInputBase
    //     Component::GUI::AtkComponentBase
    //       Component::GUI::AtkEventListener

    [StructLayout(LayoutKind.Explicit, Size = 0x338)]
    public partial struct AtkComponentNumericInput
    {
        [FieldOffset(0x0)] public AtkComponentInputBase AtkComponentInputBase;
        [FieldOffset(0xC8)] public AtkTextNode AtkTextNode;

        [MemberFunction("40 53 48 83 EC 60 8B 81")]
        public partial void SetValue(int value);
    }
}