using FFXIVClientStructs.FFXIV.Client.System.Framework;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Render;

// Client::Graphics::Render::BGInstancingRenderer
//   Client::Graphics::Render::BaseRenderer
[GenerateInterop]
[Inherits<BaseRenderer>]
[StructLayout(LayoutKind.Explicit, Size = 0x18E00)]
public partial struct BGInstancingRenderer {
    /// <summary> Single task, scheduled at the start of every Manager.RenderView and waited on in Render. </summary>
    [FieldOffset(0x181F8)] public JobListNoArg PrepareJobList;
    [FieldOffset(0x18538)] public bool Wireframe;
}
