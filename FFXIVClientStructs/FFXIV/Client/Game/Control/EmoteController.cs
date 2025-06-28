using FFXIVClientStructs.FFXIV.Client.Game.Character;
using FFXIVClientStructs.FFXIV.Client.Game.Object;
using FFXIVClientStructs.FFXIV.Client.LayoutEngine;

namespace FFXIVClientStructs.FFXIV.Client.Game.Control;

// Client::Game::Control::EmoteController
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x40)]
public unsafe partial struct EmoteController {
    [FieldOffset(0x08)] public BattleChara* OwnerObject;
    [FieldOffset(0x14)] public ushort EmoteId;
    [FieldOffset(0x16)] public ushort Unk1; // Seems to be 1 when close enough to a target that height adjustment is needed, maybe.
    [FieldOffset(0x18)] public GameObjectId Target;
    [FieldOffset(0x21)] public byte CPoseState;

    [MemberFunction("E8 ?? ?? ?? ?? 8B F8 83 F8 FF 0F 84 ?? ?? ?? ?? 8B CF")]
    public partial int GetPoseKind();

    /// <summary> Get the last valid value for a specific type of pose. </summary>
    /// <param name="pose"> The type of pose. </param>
    /// <remarks> The returned value represents the count of the type of pose - 1. </remarks>
    [MemberFunction("E8 ?? ?? ?? ?? FE C3 44 8B F0")]
    public static partial byte GetAvailablePoses(PoseType pose);

    public enum PoseType : byte {
        Idle = 0,
        WeaponDrawn = 1,
        Sit = 2,
        GroundSit = 3,
        Doze = 4,
        Umbrella = 5,
        Accessory = 6,
    }

    // Client::Game::Control::EmoteController::PlayEmoteOption
    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    [VirtualTable("48 8D 05 ?? ?? ?? ?? 48 8D 0D ?? ?? ?? ?? 48 89 44 24", 3, 1)]
    public partial struct PlayEmoteOption {
        [FieldOffset(0x08)] public GameObjectId TargetId;
        /// <remarks> If bit 1 is set it does not display a log message. </remarks>
        [FieldOffset(0x10)] public byte Flags;
        [FieldOffset(0x11)] public bool Unk11;
        [FieldOffset(0x18)] public ILayoutInstance* Layout;
    }
}
