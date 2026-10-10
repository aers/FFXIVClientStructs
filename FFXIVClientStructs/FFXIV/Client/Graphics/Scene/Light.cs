using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Scene;

// Client::Graphics::Scene::Light
//   Client::Graphics::Scene::DrawObject
//     Client::Graphics::Scene::Object
[GenerateInterop]
[Inherits<DrawObject>]
[StructLayout(LayoutKind.Explicit, Size = 0xB0)]
public unsafe partial struct Light {
    [FieldOffset(0x90)] public Render.Light* RenderLight;
    [FieldOffset(0x98), Obsolete("Use ProjectedTexture")] public TextureResourceHandle* ProjectedCubemapTexture;
    /// <summary>
    /// The texture that should be used as a projected multiplicative mask for the light.
    /// </summary>
    /// <remarks>
    /// <para>
    /// For point lights this must be a cube texture, for flat and spot lights this must be a 2D texture, and for world lights projected textures are not supported.
    /// </para>
    /// <para>
    /// Before setting this, make sure to clear and <c>DecRef</c> the previous ProjectedTexture as well as the <see cref="RenderLight"/>'s <see cref="Render.Light.ProjectedTexture"/>.
    /// <br />
    /// Then after setting this, make sure to OR a <c>2</c> into <see cref="OutlineFlags"/> for a non-null texture resource, or a <c>4</c> otherwise.
    /// </para>
    /// </remarks>
    [FieldOffset(0x98)] public TextureResourceHandle* ProjectedTexture;

    [GenerateStringOverloads]
    [MemberFunction("48 89 5C 24 ?? 57 48 83 EC 20 49 8B D8 8B F9")]
    public static partial Light* Create(Render.LightShape shape, CStringPointer poolName, Light* existingAllocation = null);
}
