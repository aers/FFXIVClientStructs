using FFXIVClientStructs.FFXIV.Client.Game.Character;

namespace FFXIVClientStructs.FFXIV.Client.Game.Control.MoveControl;

// Client::Game::Control::MoveControl::MoveController
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x440)]
public unsafe partial struct MoveController {
    [FieldOffset(0x3E0)] public BattleChara* OwnerObject;

    [FieldOffset(0x410)] public MovementStateOptions MovementState;
    [BitField<bool>(nameof(IsSwimming), 5)] // found in Client::Game::Event::EventSceneModuleUsualImpl.IsSwimming
    [FieldOffset(0x438)] private byte Flags438;

    [MemberFunction("E8 ?? ?? ?? ?? 38 05")]
    public partial bool IsFlying();

    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 F8 40 80 E6")]
    public partial bool IsDiving();
}
