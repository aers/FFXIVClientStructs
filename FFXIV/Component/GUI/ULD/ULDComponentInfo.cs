using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Component.GUI.ULD
{
    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public unsafe struct ULDComponentInfo
    {
        [FieldOffset(0x0)] public ULDObjectInfo ObjectInfo;
        [FieldOffset(0x10)] public ComponentType ComponentType;
    }
}
