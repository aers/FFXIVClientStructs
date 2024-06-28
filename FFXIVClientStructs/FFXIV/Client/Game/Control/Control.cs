using FFXIVClientStructs.FFXIV.Client.Game.Character;

namespace FFXIVClientStructs.FFXIV.Client.Game.Control;

// Client::Game::Control::Control
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x5F00)]
public unsafe partial struct Control {
    [FieldOffset(0x00)] public CameraManager CameraManager;
    [FieldOffset(0x180)] public TargetSystem TargetSystem;

    // [FieldOffset(0x5A7B)] public bool IsWalking; doesn't exist?
    [FieldOffset(0x5EB0)] public uint LocalPlayerEntityId;
    [FieldOffset(0x5EA8)] public BattleChara* LocalPlayer;

    [StaticAddress("4C 8D 35 ?? ?? ?? ?? 48 8B 09", 3)]
    public static partial Control* Instance();

    [StaticAddress("48 8B 2D ?? ?? ?? ?? 75", 3, true)]
    public static partial BattleChara* GetLocalPlayer(); // g_Client::Game::Control::Control_LocalPlayer
}
