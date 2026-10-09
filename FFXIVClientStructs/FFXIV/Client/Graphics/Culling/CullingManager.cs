using FFXIVClientStructs.FFXIV.Client.Graphics.Scene;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Culling;

// Client::Graphics::Culling::CullingManager
//   Client::Graphics::Singleton<Client::Graphics::Culling::CullingManager>
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x2660)]
public unsafe partial struct CullingManager {
    [StaticAddress("48 8B 0D ?? ?? ?? ?? B2 06", 3, isPointer: true)]
    public static partial CullingManager* Instance();

    [FieldOffset(0x10)] public void* Objects; // 40960 slots of 16 bytes
    /// <summary> One bit per object slot that has been written. </summary>
    [FieldOffset(0x18)] public uint* ObjectSlotMask;
    /// <summary> 4 u32 per object slot, one per view slot, cleared every frame. Bits 24-25 are cleared for occluded objects. </summary>
    [FieldOffset(0x20)] public uint* Visibility;

    [FieldOffset(0x20A8)] public JobSystem CullingJobs; // Client::Graphics::JobSystem<Client::Graphics::Culling::CullingManager,Client::Graphics::Culling::CullingJobOpt,8>
    [FieldOffset(0x2168)] public JobSystem CallbackJobs; // Client::Graphics::JobSystem<Client::Graphics::Culling::CullingManager,Client::Graphics::Culling::CallbackJobOpt,8>, culls the cells of a view
    /// <summary> Draws occluders into <see cref="OcclusionDepth"/>. Started without waiting, joined before the occlusion tests. </summary>
    [FieldOffset(0x2228)] public JobSystem OccluderJobs; // Client::Graphics::JobSystem<Client::Graphics::Culling::CullingManager,Client::Graphics::Culling::OccluderJob,8>
    /// <summary> Tests object bounds against <see cref="OcclusionDepth"/>, run before <see cref="CallbackJobs"/>. Skipped without occluders. </summary>
    [FieldOffset(0x22E8)] public JobSystem OcclusionTestJobs; // Client::Graphics::JobSystem<Client::Graphics::Culling::CullingManager,Client::Graphics::Culling::OcclusionTestJob,80>
    /// <summary> Camera view: BG objects in items of up to 200, all characters in one item, each running the objects' render callbacks. </summary>
    [FieldOffset(0x23A8)] public JobSystem RenderCallbackJobs; // Client::Graphics::JobSystem<Client::Graphics::Culling::CullingManager,Client::Graphics::Culling::RenderCallbackJob,1>

    [FieldOffset(0x2478)] public CullingGridManager* CullingGrid;
    /// <summary> Objects drawn into <see cref="OcclusionDepth"/>. Occlusion is skipped while empty. </summary>
    [FieldOffset(0x2480)] public StdSet<Pointer<DrawObject>> Occluders;
    /// <summary> Software depth buffer of <see cref="OcclusionWidth"/> x <see cref="OcclusionHeight"/> floats, cleared to <see cref="float.MaxValue"/> each frame. </summary>
    [FieldOffset(0x2490)] public float* OcclusionDepth;
    /// <summary> Smallest depth drawn into <see cref="OcclusionDepth"/> this frame. </summary>
    [FieldOffset(0x2498)] public float OcclusionMinDepth;
    [FieldOffset(0x249C)] public uint OcclusionWidth;
    [FieldOffset(0x24A0)] public uint OcclusionHeight;

    [FieldOffset(0x2648)] public int OcclusionTestCount;
    [FieldOffset(0x264C)] public int OccludedCount;
    [FieldOffset(0x2650)] public int OccluderCount; // drawn this frame

    [MemberFunction("48 89 5C 24 08 48 89 74 24 10 57 48 83 EC 40 48 8D B1")]
    public partial void AddOccluder(DrawObject* drawObject);

    [MemberFunction("48 89 54 24 10 48 83 EC 28 48 81 C1 80 24 00 00")]
    public partial void RemoveOccluder(DrawObject* drawObject);

    /// <summary> Job function of <see cref="RenderCallbackJobs"/>. </summary>
    [MemberFunction("40 53 56 41 54 41 55 41 56 48 81 EC 90 00 00 00")]
    public partial long ExecuteRenderCallbackJob(RenderCallbackJobItem* item);

    [StructLayout(LayoutKind.Explicit, Size = 0x40)]
    public struct RenderCallbackJobItem {
        [FieldOffset(0x00)] public byte Type; // 1 or 2 picks that callback for every object, anything else each object's own
        [FieldOffset(0x08)] public ushort* ObjectSlots;
        [FieldOffset(0x10)] public int ViewSlot;
        [FieldOffset(0x14)] public int ViewIndex;
        [FieldOffset(0x30)] public uint Start;
        [FieldOffset(0x34)] public uint Count;
    }
}
