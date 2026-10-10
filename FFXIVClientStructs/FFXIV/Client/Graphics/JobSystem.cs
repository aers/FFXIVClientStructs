using FFXIVClientStructs.FFXIV.Client.System.Framework;

namespace FFXIVClientStructs.FFXIV.Client.Graphics;

// Client::Graphics::JobSystem<Owner, Job, ItemsPerBlock>
/// <summary>
/// Parallel-for over items appended by any thread through its <see cref="Writer"/>. Items go into blocks
/// (u32 item count, then the items from +0x10), 32 blocks per chunk, item size depending on Job.
/// Running it schedules <see cref="JobList"/>, helps on the calling thread, then waits for the list.
/// </summary>
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0xC0)]
public unsafe partial struct JobSystem {
    [FieldOffset(0x08)] public Writer* Writers; // one per graphics kernel context
    [FieldOffset(0x10)] public uint WriterCount;
    [FieldOffset(0x14)] public uint NextWriter;
    /// <summary> One task per pool thread, each a help call. </summary>
    [FieldOffset(0x18)] public JobListArgArrayAndIndex* JobList;
    [FieldOffset(0x20)] public void* CallbackThisArg;
    [FieldOffset(0x28)] public delegate* unmanaged<void*, void*, void> CallbackFunction;
    [FieldOffset(0x30), FixedSizeArray] internal FixedSizeArray16<Pointer<uint>> _blockChunks;
    [FieldOffset(0xB0)] public uint BlockCount;
    [FieldOffset(0xB4)] public uint NextBlock;
    [FieldOffset(0xB8)] public uint NextItem;
    /// <summary> Helpers claim single items instead of whole blocks. </summary>
    [FieldOffset(0xBC)] public bool ClaimPerItem;

    /// <summary>
    /// Each pool thread claims one writer per JobSystem when it starts (through <see cref="NextWriter"/>) and keeps it in
    /// its TLS block (TLS[_tls_index] + slot):<br/>
    /// 0x250 CullingManager.OcclusionTestJobs, 0x258 CullingManager.CallbackJobs, 0x260 CullingManager.CullingJobs,
    /// 0x268 CullingManager.RenderCallbackJobs, 0x270 CullingManager.OccluderJobs, 0x278 VerticalFogRenderer,
    /// 0x288 LightShaftRenderer, 0x290 LookAtIkUpdater, 0x298 SkeletonUpdater, 0x2A0 WaterRenderer,
    /// 0x2A8 OffscreenRenderingManager, 0x2B0 Render.Manager, 0x2B8 DecalRenderer,
    /// 0x2C0 ModelRenderer, 0x2C8 ShadowMaskRenderer.
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 0x28)]
    public struct Writer {
        [FieldOffset(0x08)] public void* Items; // of the current block
        [FieldOffset(0x10)] public uint ItemCount; // a full block starts a new one
        [FieldOffset(0x18)] public JobSystem* Owner;
        [FieldOffset(0x20)] public uint* Block;
    }
}
