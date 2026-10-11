namespace FFXIVClientStructs.FFXIV.Client.Graphics.Render;

// Client::Graphics::Render::DecalRenderer
//   Client::Graphics::Render::BaseRenderer
/// <summary> Draws decals into the G-buffers, sorted, each with a draw index that wraps at 100. </summary>
[GenerateInterop]
[Inherits<BaseRenderer>]
[StructLayout(LayoutKind.Explicit, Size = 0x230)]
public partial struct DecalRenderer {
    [FieldOffset(0x148)] public JobSystem DecalJobs; // Client::Graphics::JobSystem<Client::Graphics::Render::DecalRenderer>
    /// <summary> Decals registered for this frame. </summary>
    [FieldOffset(0x208)] public StdVector<Pointer<Decal>> Decals;
}
