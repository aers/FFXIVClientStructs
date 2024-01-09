using FFXIVClientStructs.FFXIV.Client.Game.Character;

namespace FFXIVClientStructs.FFXIV.Client.Game.Control;

[StructLayout(LayoutKind.Explicit, Size = 0x5B00)]
public unsafe partial struct Control {
    [FieldOffset(0x00)] public CameraManager CameraManager;
    [FieldOffset(0x180)] public TargetSystem TargetSystem;

    [FieldOffset(0x5A7B)] public bool IsWalking;
    [FieldOffset(0x5AE8)] public uint LocalPlayerObjectId;
    [FieldOffset(0x5AF0)] public BattleChara* LocalPlayer;

    [StaticAddress("4C 8D 35 ?? ?? ?? ?? 85 D2", 3)]
    public static partial Control* Instance();
}
