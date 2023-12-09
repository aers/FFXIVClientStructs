using System.Runtime.CompilerServices;
using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.Text;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

[StructLayout(LayoutKind.Explicit, Size = 0xCC0)]
public struct AtkInputManager {
    [FieldOffset(0x1c0)] public ClipboardReadWrite ClipMan;
    [FieldOffset(0x298)] public Utf8String CopyBufferRaw;
    [FieldOffset(0x300)] public Utf8String CopyBufferFiltered;
}
