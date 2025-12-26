using FFXIVClientStructs.FFXIV.Client.Game.Object;

namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

// Client::Game::Event::EventIdleCamController
[StructLayout(LayoutKind.Explicit, Size = 0x38)]
public unsafe struct EventIdleCamController {
    [FieldOffset(0x00)] private int ObjectIndex; // ?
    [FieldOffset(0x08)] public GameObjectId CurrentTargetObjectId;
    [FieldOffset(0x10)] public GameObjectId LockedTargetObjectId; // set when /icam is called with a subcommand like <me>
    [FieldOffset(0x18)] private GameObject* Unk18;
    [FieldOffset(0x20)] private byte Unk20;
    [FieldOffset(0x24)] private ushort EmoteId; // ?
    [FieldOffset(0x28)] private float EmoteCountdown; // or Cooldown?
    [FieldOffset(0x34)] public IdleCamFlag Flags;

    [Flags]
    public enum IdleCamFlag : byte {
        None = 0,
        Paused = 1 << 0,
        Waiting = 1 << 3, // not fading screen to/from black
        SwitchingEnabled = 1 << 5 // checkbox in Camera Settings
    }
}
