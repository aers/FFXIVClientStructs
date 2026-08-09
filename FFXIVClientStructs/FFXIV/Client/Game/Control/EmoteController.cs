using FFXIVClientStructs.FFXIV.Client.Game.Character;
using FFXIVClientStructs.FFXIV.Client.Game.Object;
using FFXIVClientStructs.FFXIV.Client.LayoutEngine;
using FFXIVClientStructs.FFXIV.Client.UI.Agent;

namespace FFXIVClientStructs.FFXIV.Client.Game.Control;

// Client::Game::Control::EmoteController
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x40)]
public unsafe partial struct EmoteController {
    [FieldOffset(0x08)] public BattleChara* OwnerObject;
    [FieldOffset(0x14)] public ushort EmoteId;
    [FieldOffset(0x16)] public byte Stance;
    [FieldOffset(0x17)] private byte Unk17;
    [FieldOffset(0x18)] public GameObjectId Target;
    [FieldOffset(0x20)] public PoseType CurrentPoseType;
    [FieldOffset(0x21)] public byte CPoseState;

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 75 ?? 48 39 5D")]
    public partial bool IsEmoting(); // EmoteId != 0

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 ?? 33 D2 48 8D 8E")]
    public partial bool IsInEmoteLoop(); // OwnerObject->Mode == CharacterModes.EmoteLoop

    /// <summary> Plays an emote for a character that's not the local player. </summary>
    /// <remarks> For the local player, use <see cref="AgentEmote.ExecuteEmote"/> or <see cref="EmoteManager.ExecuteEmote(ushort, PlayEmoteOption*)"/> instead. </remarks>
    [MemberFunction("E8 ?? ?? ?? ?? E8 ?? ?? ?? ?? 44 0F B7 44 24")]
    public partial bool PlayEmote(uint emoteId, PlayEmoteOption* options);

    [MemberFunction("E8 ?? ?? ?? ?? 44 0F B6 E8 41 B7")]
    public static partial bool TryGetEmoteDetails(uint emoteId, EmoteDetails* outEmoteDetails);

    [MemberFunction("E8 ?? ?? ?? ?? FF C8 33 DB")]
    public partial Posture GetPosture();

    [MemberFunction("E8 ?? ?? ?? ?? 8B F8 83 F8 FF 0F 84 ?? ?? ?? ?? 8B CF")]
    public partial int GetPoseKind();

    /// <summary> Get the last valid value for a specific type of pose. </summary>
    /// <param name="pose"> The type of pose. </param>
    /// <remarks> The returned value represents the count of the type of pose - 1. </remarks>
    [MemberFunction("E8 ?? ?? ?? ?? FE C3 44 8B F0")]
    public static partial byte GetAvailablePoses(PoseType pose);

    [StructLayout(LayoutKind.Explicit, Size = 0x21)]
    public struct EmoteDetails {
        [FieldOffset(0x00)] public CStringPointer Name;
        [FieldOffset(0x08)] public uint UnlockLink;
        [FieldOffset(0x0C)] public int TextCommand;
        [FieldOffset(0x10)] public uint Icon;
        [FieldOffset(0x14)] public ushort Order;
        /// <remarks> When the value is <c>3</c> (Expressions), all conditions are overwritten with <see langword="true"/> in the calling function. </remarks>
        [FieldOffset(0x16)] public byte EmoteCategory;
        [FieldOffset(0x17)] public bool SittingOnGround;
        [FieldOffset(0x18)] public bool SittingInChair;
        [FieldOffset(0x19)] public bool Mounted;
        [FieldOffset(0x1A)] public bool Fishing;
        [FieldOffset(0x1B)] public bool Standing;
        [FieldOffset(0x1C)] public bool Swimming;
        [FieldOffset(0x1D)] public bool Diving;
        [FieldOffset(0x1E)] public bool HoldingTorch;
        [FieldOffset(0x1F)] public bool WearingFashionAccessory;
        [FieldOffset(0x20)] public bool HoldingUmbrella;
    }

    // Client::Game::Control::EmoteController::PlayEmoteOption
    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    [VirtualTable("48 8D 05 ?? ?? ?? ?? 48 8D 0D ?? ?? ?? ?? 48 89 44 24", 3)]
    public partial struct PlayEmoteOption {
        [FieldOffset(0x08)] public GameObjectId TargetId;
        [BitField<bool>(nameof(DisableLogMessage), 0, 1)]
        [FieldOffset(0x10)] public byte Flags;
        /// <remarks> For example, this might be useful to set for spawning characters in a sitting pose. </remarks>
        [FieldOffset(0x11)] public bool DisableSitDownAnimation; // or DisableInitAnimation?
        [FieldOffset(0x18)] public ILayoutInstance* Layout;
    }

    public enum PoseType : byte {
        Idle = 0,
        WeaponDrawn = 1,
        Sit = 2,
        GroundSit = 3,
        Doze = 4,
        Umbrella = 5,
        Accessory = 6,
    }

    public enum Posture {
        Normal = 0, // not existing, standing, ..., fallback
        SittingOnGround = 1,
        SittingInChair = 2,
        Mounted = 3,
        Dozing = 4,
        Swimming = 5,
        Diving = 6,
    }
}
