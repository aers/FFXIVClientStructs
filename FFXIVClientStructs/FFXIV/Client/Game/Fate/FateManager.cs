using FFXIVClientStructs.FFXIV.Client.Game.Object;
using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.Game.Fate;

// Client::Game::Fate::FateManager
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0xB8)]
public unsafe partial struct FateManager {
    [FieldOffset(0x00)] public StdVector<GameObjectId> Unk_Vector;
    [FieldOffset(0x18)] public Utf8String Unk_String;
    [FieldOffset(0x80)] public FateDirector* FateDirector;
    [FieldOffset(0x88)] public FateContext* CurrentFate;
    [FieldOffset(0x90)] public StdVector<Pointer<FateContext>> Fates;
    [FieldOffset(0xA8)] public ushort SyncedFateId;
    [FieldOffset(0xAC)] public byte FateJoined;

    [StaticAddress("48 89 01 48 8B 3D ?? ?? ?? ?? 48 8B 87", 6, isPointer: true)]
    public static partial FateManager* Instance();

    [MemberFunction("E8 ?? ?? ?? ?? 48 85 C0 48 8D 4C 24 ?? 0F 95 C2")]
    public partial FateContext* GetFateById(ushort fateId);
}
