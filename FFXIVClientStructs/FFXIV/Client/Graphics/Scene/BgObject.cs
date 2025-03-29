using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Scene;

[GenerateInterop]
[Inherits<DrawObject>]
[StructLayout(LayoutKind.Explicit, Size = 0xD0)]
public unsafe partial struct BgObject {
    [FieldOffset(0x90)] public ModelResourceHandle* ModelResourceHandle;
}
