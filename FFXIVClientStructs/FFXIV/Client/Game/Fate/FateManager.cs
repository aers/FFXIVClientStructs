using System.Numerics;
using FFXIVClientStructs.FFXIV.Client.Game.Object;
using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.Game.Fate;

// Client::Game::Fate::FateManager
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0xD0)]
public unsafe partial struct FateManager {
    [StaticAddress("48 89 01 48 8B 3D ?? ?? ?? ?? 48 8B 87", 6, isPointer: true)]
    public static partial FateManager* Instance();

    [FieldOffset(0x00)] public StdVector<GameObjectId> Unk_Vector;
    [FieldOffset(0x18)] public Utf8String Unk_String;
    [FieldOffset(0x80)] public FateDirector* FateDirector;
    [FieldOffset(0x88)] public FateContext* CurrentFate;
    [FieldOffset(0x90)] public StdVector<Pointer<FateContext>> Fates;
    [FieldOffset(0xA8)] public ushort SyncedFateId;
    [FieldOffset(0xAF)] public byte FateJoined;

    [MemberFunction("48 8B 81 ?? ?? ?? ?? 4C 8B D2 4C 8B 89")]
    public partial bool IsInFateRadius(Vector3* position);

    [MemberFunction("E8 ?? ?? ?? ?? 66 39 87")]
    public partial ushort GetCurrentFateId();

    [MemberFunction("E8 ?? ?? ?? ?? 48 85 C0 48 8D 4C 24 ?? 0F 95 C2")]
    public partial FateContext* GetFateById(ushort fateId);

    [MemberFunction("40 53 48 83 EC ?? 48 8B 81 ?? ?? ?? ?? 49 8B D8")]
    public partial bool TryGetFatePosition(ushort fateId, Vector3* position);

    [MemberFunction("40 53 48 83 EC ?? 48 8B 91 ?? ?? ?? ?? 48 8B D9 48 85 D2 0F 84 ?? ?? ?? ?? E8")]
    public partial FateContext* LevelSync();

    [MemberFunction("48 83 EC ?? 0F B7 42 ?? 66 39 81")]
    public partial bool IsSyncedToFate(FateContext* fate);
}
