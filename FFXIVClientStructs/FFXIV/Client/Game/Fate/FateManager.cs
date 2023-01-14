using FFXIVClientStructs.FFXIV.Client.Game.Object;
using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.Game.Fate;

// This is a struct of some sort, likely part of the FateDirector.
// Size taken from dtor, no vtbl
[StructLayout(LayoutKind.Explicit, Size = 0xB0)]
public unsafe partial struct FateManager
{
    [FieldOffset(0x00)] public StdVector<GameObjectID> Unk_Vector;
    [FieldOffset(0x18)] public Utf8String Unk_String;

    [FieldOffset(0x80)] public FateDirector* FateDirector;
    [FieldOffset(0x88)] public FateContext* CurrentFate;
    [FieldOffset(0x90)] public StdVector<Pointer<FateContext>> Fates;
    [FieldOffset(0xA8)] public ushort SyncedFateId;
    [FieldOffset(0xAC)] public byte FateJoined;

    [StaticAddress("48 89 01 48 8B 3D ?? ?? ?? ?? 48 8B 87", 6, isPointer: true)]
    public static partial FateManager* Instance();

    [MemberFunction("E8 ?? ?? ?? ?? 48 8D 4C 24 ?? 48 85 C0 75")]
    public partial FateContext* GetFateById(ushort fateId);
}