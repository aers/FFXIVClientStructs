namespace FFXIVClientStructs.FFXIV.Client.Graphics.Culling;

// Client::Graphics::Culling::CullingGridManager
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x3201E0)]
public unsafe partial struct CullingGridManager {
    [FieldOffset(0x00)] public ushort CellCount;
    [FieldOffset(0x08)] public void* Cells; // 0x58 bytes each
    /// <summary> Quadtree levels, 1, 4, 16, ... cells each. </summary>
    [FieldOffset(0x28)] public byte LevelCount;
    [FieldOffset(0x90)] private fixed byte Lock[0x28]; // CRITICAL_SECTION
    [FieldOffset(0x320110)] public JobSystem GridJobs; // Client::Graphics::JobSystem<Client::Graphics::Culling::CullingGridManager,Client::Graphics::Culling::CullingGridManager::CullingGridJob,8>
}
