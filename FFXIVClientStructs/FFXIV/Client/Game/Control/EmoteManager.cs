using static FFXIVClientStructs.FFXIV.Client.Game.Control.EmoteController;

namespace FFXIVClientStructs.FFXIV.Client.Game.Control;

// Client::Game::Control::EmoteManager
[StructLayout(LayoutKind.Explicit, Size = 0x40)]
public unsafe struct EmoteManager {
    public static EmoteManager* Instance() => &GameMain.Instance()->EmoteManager;

    [FieldOffset(0x30)] public float IdlePoseCountdown;

    [FieldOffset(0x3C)] public PoseType IdlePoseType; // 0xFF when not counting down
}
