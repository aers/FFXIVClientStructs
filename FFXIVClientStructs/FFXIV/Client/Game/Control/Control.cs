using FFXIVClientStructs.FFXIV.Client.Game.Character;

namespace FFXIVClientStructs.FFXIV.Client.Game.Control; 

[StructLayout(LayoutKind.Explicit, Size = 0x5A00)] //could be bigger
public unsafe partial struct Control
{
    [FieldOffset(0x00)] public CameraManager CameraManager;
    [FieldOffset(0x180)] public TargetSystem TargetSystem;
    
    //0x3ED0 Unk 0x18 byte class
    //0x3EE8 Unk 0x08 byte class
    //0x3EF0 Unk 0x560-0x5A0 byte class, movecontroller stuff
    //0x3F00 g_PlayerMoveController (0x3EF0 + 0x10) Client::Game::Control::MoveControl::MoveControllerSubMemberForMine

    [FieldOffset(0x59E8)] public uint LocalPlayerObjectId;
    [FieldOffset(0x59F0)] public BattleChara* LocalPlayer;

    [StaticAddress("4C 8D 35 ?? ?? ?? ?? 85 D2")]
    public static partial Control* Instance();
}