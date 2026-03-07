using System;
using System.Collections.Generic;
using System.Text;
using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Scene;

[GenerateInterop]
[Inherits<DrawObject>]
[StructLayout(LayoutKind.Explicit, Size = 0xA0)]
public unsafe partial struct Light {
    [FieldOffset(0x90)] public Render.Light* RenderLight;
    [FieldOffset(0x98)] public TextureResourceHandle* ProjectedCubemapTexture;

    [GenerateStringOverloads]
    [MemberFunction("48 89 5C 24 ?? 57 48 83 EC 20 49 8B D8 8B F9")]
    public static partial Light* Create(Render.LightShape shape, CStringPointer poolName, Light* existingAllocation = null);
}
