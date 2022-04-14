using FFXIVClientStructs.FFXIV.Client.Game.Object;

namespace FFXIVClientStructs.FFXIV.Client.Game.Character;
// Client::Game::Character::Character
//   Client::Game::Object::GameObject
//   Client::Graphics::Vfx::VfxDataListenner

// size = 0x19F0
// ctor E8 ? ? ? ? 0F B7 93 ? ? ? ? 45 33 C9 
[StructLayout(LayoutKind.Explicit, Size = 0x1AE0)]
public unsafe partial struct Character
{
    [FieldOffset(0x0)] public GameObject GameObject;

    #region This is inside a new 0x48 byte class at offset 0x1A8

    [FieldOffset(0x1B0)] public float ModelScale;
    [FieldOffset(0x1B4)] public int ModelCharaId;
    [FieldOffset(0x1B8)] public int ModelSkeletonId;
    [FieldOffset(0x1BC)] public int ModelCharaId_2; // == -1 -> return ModelCharaId
    [FieldOffset(0x1C0)] public int ModelSkeletonId_2; // == 0 -> return ModelSkeletonId

    [FieldOffset(0x1C4)] public uint Health;
    [FieldOffset(0x1C8)] public uint MaxHealth;
    [FieldOffset(0x1CC)] public uint Mana;
    [FieldOffset(0x1D0)] public uint MaxMana;
    [FieldOffset(0x1D4)] public ushort GatheringPoints;
    [FieldOffset(0x1D6)] public ushort MaxGatheringPoints;
    [FieldOffset(0x1D8)] public ushort CraftingPoints;
    [FieldOffset(0x1DA)] public ushort MaxCraftingPoints;

    [FieldOffset(0x1DC)] public short TransformationId;

    [FieldOffset(0x1E0)] public byte ClassJob;
    [FieldOffset(0x1E1)] public byte Level;

    #endregion

    [FieldOffset(0xC50)] public uint PlayerTargetObjectID;

    [FieldOffset(0x808)] public fixed byte EquipSlotData[4 * 10];
    [FieldOffset(0x830)] public fixed byte CustomizeData[0x1A];

    [FieldOffset(0x1760)] public Balloon Balloon;

    //[FieldOffset(0x1968)] public void* VfxObject;
    //[FieldOffset(0x1970)] public void* VfxObject2;
    [FieldOffset(0x1998)] public void* Omen;

    [FieldOffset(0x6B0)] public Companion* CompanionObject; // minion
    [FieldOffset(0x1A30)] public fixed byte FreeCompanyTag[6];
    [FieldOffset(0x1A50)] public uint TargetObjectID;

    [FieldOffset(0x1A94)] public uint NameID;

    [FieldOffset(0x1AB0)] public ushort CurrentWorld;
    [FieldOffset(0x1AB2)] public ushort HomeWorld;
    [FieldOffset(0x1ABC)] public byte EventState; // or something
    [FieldOffset(0x1ABE)] public byte OnlineStatus;
    [FieldOffset(0x1AD3)] public byte ShieldValue;
    [FieldOffset(0x1AD6)] public byte StatusFlags;
    [FieldOffset(0x1AA4)] public uint CompanionOwnerID;

    [MemberFunction("E8 ?? ?? ?? ?? 49 3B C7 0F 84")]
    public partial uint GetTargetId();

    [VirtualFunction(87)]
    public partial bool IsMount();
}