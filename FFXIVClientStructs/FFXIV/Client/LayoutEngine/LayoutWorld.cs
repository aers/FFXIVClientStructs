using FFXIVClientStructs.FFXIV.Client.Game;
using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Common.Component.BGCollision;

namespace FFXIVClientStructs.FFXIV.Client.LayoutEngine;

// Client::LayoutEngine::LayoutWorld
//   Client::LayoutEngine::IManagerBase
//     Client::System::Common::NonCopyable
/// <summary>
/// Root level manager for 'layouts' (loaded levels with static geometry).
/// </summary>
[GenerateInterop]
[Inherits<IManagerBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x238)]
public unsafe partial struct LayoutWorld {
    [StaticAddress("48 8B D1 48 8B 0D ?? ?? ?? ?? 48 85 C9 74 0A", 6, isPointer: true)]
    public static partial LayoutWorld* Instance();

    [FieldOffset(0x018)] public LayoutManager* GlobalLayout;
    [FieldOffset(0x020)] public LayoutManager* ActiveLayout;
    //[FieldOffset(0x028)] public LayoutManager* UnkLayout28;
    [FieldOffset(0x030)] public LayoutManager* PrefetchLayout;
    [FieldOffset(0x038)] public void* CutscenePrefetchResource;
    //[FieldOffset(0x058)] public VFXObject* UnkVfxObject;
    [FieldOffset(0x068)] public long MillisecondsSinceLastUpdate;
    [FieldOffset(0x080)] public StdMap<ulong, Pointer<LayoutManager>> LoadedLayouts; // key = (LvbCrc << 32) | TerritoryTypeRowId
    //[FieldOffset(0x090)] public StdMap<ulong, Pointer<LayoutManager>> UnkLayouts90; // key = (LvbCrc << 32) | TerritoryTypeRowId
    [FieldOffset(0x0A0), FixedSizeArray] internal FixedSizeArray92<float> _streamingRadiusPerType;
    // 0x210 - some other map, value = Client::System::Resource::Handle::ResourceHandle*
    [FieldOffset(0x220)] public StdMap<Utf8String, CStringPointer>* RsvMap;
    [FieldOffset(0x228)] public StdMap<ulong, Pointer<byte>>* RsfMap; // Key is v0 index hash, value is always 64 bytes in size

    /// <remarks> Tries to get it from <see cref="ActiveLayout"/> first, then from <see cref="GlobalLayout"/>. </remarks>
    [MemberFunction("E9 ?? ?? ?? ?? 8B 43 78 45 33 C0")]
    public static partial ILayoutInstance* GetLayoutInstance(InstanceType instanceType, uint instanceId, uint subId = 0);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B F0 48 85 C0 74 ?? 8B 90")]
    public static partial ILayoutInstance* GetColliderLayoutInstance(InstanceType instanceType, Collider* collider);

    [MemberFunction("E8 ?? ?? ?? ?? 45 33 F6 44 89 B7")]
    public static partial void UnloadPrefetchLayout();

    /// <remarks> <paramref name="festivals"/> is a pointer to an array of 4 <see cref="GameMain.Festival"/>s. </remarks>
    [MemberFunction("48 89 5C 24 ?? 48 89 6C 24 ?? 56 57 41 56 48 81 EC ?? ?? ?? ?? 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 84 24 ?? ?? ?? ?? 48 8B 41 20"), GenerateStringOverloads]
    public partial void LoadPrefetchLayout(int type, CStringPointer bgName, byte layerEntryType, uint levelId, uint territoryTypeId, GameMain.Festival* festivals, uint cfcId);

    [MemberFunction("48 89 5C 24 ?? 48 89 74 24 ?? 57 48 81 EC ?? ?? ?? ?? 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 84 24 ?? ?? ?? ?? 48 83 B9 ?? ?? ?? ?? ?? 48 8B F1"), GenerateStringOverloads]
    public partial CStringPointer ResolveRsvString(CStringPointer rsvString);

    [MemberFunction("40 53 55 56 57 41 54 41 55 41 56 41 57 48 81 EC ?? ?? ?? ?? 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 84 24 ?? ?? ?? ?? 4D 8B E8")]
    public partial bool AddRsvString(byte* rsvString, byte* resolvedString, nuint resolvedStringSize);

    [MemberFunction("4C 8B 81 ?? ?? ?? ?? 4D 85 C0 74 45")]
    public partial byte* ResolveRsfEntry(ulong indexHash);

    [MemberFunction("48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 48 89 7C 24 ?? 41 56 48 83 EC 50 48 8B 99")]
    public partial bool AddRsfEntry(ulong indexHash, byte* rsfData);
}
