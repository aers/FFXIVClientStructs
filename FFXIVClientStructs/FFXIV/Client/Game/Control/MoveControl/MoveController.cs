using FFXIVClientStructs.FFXIV.Client.Game.Character;

namespace FFXIVClientStructs.FFXIV.Client.Game.Control.MoveControl;

// Client::Game::Control::MoveControl::MoveController
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x440)]
public unsafe partial struct MoveController {
    [FieldOffset(0x3E0)] public BattleChara* OwnerObject;

    [FieldOffset(0x410)] public MovementStateOptions MovementState;
    [BitField<bool>(nameof(IsSurfacePlacementComplete), 0)] // when not set, the game tries to place the owner on the nearest collision below its position on each frame. gets set when succeeded, skipped or disabled.
    [BitField<bool>(nameof(IsSurfacePlacementDisabled), 2)] // skips surface placement on objects which are supposed to be kept at a fixed height (mounts, hovering minions, preview characters, some event NPCs)
    [BitField<bool>(nameof(IsSwimming), 5)] // found in Client::Game::Event::EventSceneModuleUsualImpl.IsSwimming
    [BitField<bool>(nameof(IsSurfacePlacementPending), 7)] // queues a placement attempt which is delayed by a few frames. placement has to be completed and not disabled for this to work.
    [FieldOffset(0x438)] private byte Flags438;

    [MemberFunction("E8 ?? ?? ?? ?? 38 05")]
    public partial bool IsFlying();

    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 F8 40 80 E6")]
    public partial bool IsDiving();
}
