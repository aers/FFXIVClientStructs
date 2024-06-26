using FFXIVClientStructs.FFXIV.Client.Game;
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
    [StaticAddress("0F 84 ?? ?? ?? ?? 48 8B 49 18 48 8B D6", 3, isPointer: true)]
    public static partial LayoutWorld* Instance();

    [FieldOffset(0x018)] public LayoutManager* GlobalLayout;
    [FieldOffset(0x020)] public LayoutManager* ActiveLayout;
    //[FieldOffset(0x028)] public LayoutManager* UnkLayout28;
    [FieldOffset(0x030)] public LayoutManager* PrefetchLayout;
    [FieldOffset(0x038)] public void* CutscenePrefetchResource;
    [FieldOffset(0x068)] public long MillisecondsSinceLastUpdate;
    [FieldOffset(0x080)] public StdMap<ulong, Pointer<LayoutManager>> LoadedLayouts; // key = (LvbCrc << 32) | TerritoryTypeRowId
    //[FieldOffset(0x090)] public StdMap<ulong, Pointer<LayoutManager>> UnkLayouts90; // key = (LvbCrc << 32) | TerritoryTypeRowId
    [FieldOffset(0x0A0), FixedSizeArray] internal FixedSizeArray90<float> _streamingRadiusPerType;
    // 0x208 - some other map, value = Client::System::Resource::Handle::ResourceHandle*
    [FieldOffset(0x218)] public StdMap<Utf8String, Pointer<byte>>* RsvMap;

    [MemberFunction("E8 ?? ?? ?? ?? 45 33 F6 44 89 B7")]
    public partial void UnloadPrefetchLayout();

    [MemberFunction("48 89 6C 24 ?? 56 57 41 56 48 81 EC ?? ?? ?? ?? 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 84 24 ?? ?? ?? ?? 48 8B 41 20"), GenerateStringOverloads]
    public partial void LoadPrefetchLayout(int type, byte* bgName, byte layerEntryType, uint levelId, uint territoryTypeId, GameMain* gameMain, uint cfcId);
}
