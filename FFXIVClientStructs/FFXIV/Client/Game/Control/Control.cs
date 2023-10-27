using FFXIVClientStructs.FFXIV.Client.Game.Character;

namespace FFXIVClientStructs.FFXIV.Client.Game.Control;

[StructLayout(LayoutKind.Explicit, Size = 0x5A60)]
public unsafe partial struct Control {
    [FieldOffset(0x00)] public CameraManager CameraManager;
    [FieldOffset(0x180)] public TargetSystem TargetSystem;

    [FieldOffset(0x5AE8)] public uint LocalPlayerObjectId;
    [FieldOffset(0x5AF0)] public BattleChara* LocalPlayer;

    /// <summary>
    /// Indicates if addon windows such as the Map, Inventory, should be shown.
    /// Changes to false when interacting with things like Aethernets
    /// </summary>
    [FieldOffset(0x5460)] public bool ShouldShowWindows;

    [StaticAddress("4C 8D 35 ?? ?? ?? ?? 85 D2", 3)]
    public static partial Control* Instance();
}
