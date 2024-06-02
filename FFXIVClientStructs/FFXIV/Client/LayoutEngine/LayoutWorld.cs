using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.LayoutEngine;

// Client::LayoutEngine::LayoutWorld
//   Client::LayoutEngine::IManagerBase
//     Client::System::Common::NonCopyable
/// <summary>
/// Root level manager for 'layouts' (loaded levels with static geometry).
/// </summary>
[GenerateInterop]
[Inherits<IManagerBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x228)]
public unsafe partial struct LayoutWorld {
    [StaticAddress("48 89 05 ?? ?? ?? ?? 48 8B 00", 3, isPointer: true)]
    public static partial LayoutWorld* Instance();

    [FieldOffset(0x018)] public LayoutManager* GlobalLayout;
    [FieldOffset(0x020)] public LayoutManager* ActiveLayout;
    //[FieldOffset(0x028)] public LayoutManager* UnkLayout28;
    //[FieldOffset(0x030)] public LayoutManager* UnkLayout30;
    [FieldOffset(0x038)] public void* CutscenePrefetchResource;
    [FieldOffset(0x068)] public long MillisecondsSinceLastUpdate;
    [FieldOffset(0x080)] public StdMap<ulong, Pointer<LayoutManager>> LoadedLayouts; // key = (LvbCrc << 32) | TerritoryTypeRowId
    //[FieldOffset(0x090)] public StdMap<ulong, Pointer<LayoutManager>> UnkLayouts90; // key = (LvbCrc << 32) | TerritoryTypeRowId
    [FieldOffset(0x0A0)] public fixed float StreamingRadiusPerType[90];
    // 0x208 - some other map, value = Client::System::Resource::Handle::ResourceHandle*
    [FieldOffset(0x218)] public StdMap<Utf8String, Pointer<byte>>* RsvMap;
}
