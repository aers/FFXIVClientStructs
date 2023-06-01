using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Render; 

[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public unsafe struct Material {
    [FieldOffset(0x00)] public ReferencedClassBase ReferencedClassBase;
    [FieldOffset(0x10)] public MaterialResourceHandle* MaterialResourceHandle;
}
