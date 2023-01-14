using FFXIVClientStructs.FFXIV.Client.Game.Character;

namespace FFXIVClientStructs.FFXIV.Client.Game.Control; 

[StructLayout(LayoutKind.Explicit, Size = 0x5A60)]
public unsafe partial struct Control
{
    [FieldOffset(0x00)] public CameraManager CameraManager;
    [FieldOffset(0x180)] public TargetSystem TargetSystem;
    
    [FieldOffset(0x5A48)] public uint LocalPlayerObjectId;
    [FieldOffset(0x5A50)] public BattleChara* LocalPlayer;

    [StaticAddress("4C 8D 35 ?? ?? ?? ?? 85 D2", 3)]
    public static partial Control* Instance();
}