using System.Numerics;
using FFXIVClientStructs.FFXIV.Client.Game.Object;

namespace FFXIVClientStructs.FFXIV.Client.Game.Character;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0xF00)]
public unsafe partial struct ActionEffectHandler {
    [FieldOffset(0)] internal FixedSizeArray32<EffectEntry> _incomingEffects;

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x78)]
    public unsafe partial struct EffectEntry {
        [FieldOffset(0x00)] public uint GlobalSequence;
        [FieldOffset(0x08)] public byte TargetIndex;
        [FieldOffset(0x09)] public ActionType ActionType;
        [FieldOffset(0x0C)] public uint ActionId;
        [FieldOffset(0x10)] public ushort SpellId;
        [FieldOffset(0x18)] public GameObjectId Source;
        [FieldOffset(0x20)] public bool SourceConfirmed; // set when EffectResult for this action/target tuple is received (for retaliation part of the effect)
        [FieldOffset(0x28)] public GameObjectId Target;
        [FieldOffset(0x30)] public bool TargetConfirmed; // set when EffectResult for this action/target tuple is received (for usual part of the effect)
        [FieldOffset(0x38)] public TargetEffects Effects;
    }

    /// <summary>
    /// A single effect (damage, heal, status, miss, etc) an action had on a single target.
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 8)]
    public partial struct Effect {
        [FieldOffset(0)] public byte Type;
        [FieldOffset(1)] public byte Param0;
        [FieldOffset(2)] public byte Param1;
        [FieldOffset(3)] public byte Param2;
        [FieldOffset(4)] public byte Param3;
        [FieldOffset(5)] public byte Param4;
        [FieldOffset(6)] public ushort Value;
    }

    /// <summary>
    /// A full set of effects an action had on a single target.
    /// </summary>
    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x40)]
    public partial struct TargetEffects {
        [FieldOffset(0), FixedSizeArray] internal FixedSizeArray8<Effect> _effects;
    }

    /// <summary>
    /// Global result of a single action. Used in combination with target data: a list of GameObjectId's and sets of Effect's.
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 0x28)]
    public struct Header {
        [FieldOffset(0x00)] public GameObjectId AnimationTargetId; // 'primary' target of the action; animation is played on this object
        [FieldOffset(0x08)] public uint ActionId;
        [FieldOffset(0x0C)] public uint GlobalSequence; // unique id of the action, monotonously increasing as the server is running
        [FieldOffset(0x10)] public float AnimationLock; // caster's animation lock is set to this value, unless this action was not caster-initiated and force-set flag is not set
        // 0x14: some entity id, related to ActionCategory 17 (Artillery) and used for some animations
        [FieldOffset(0x18)] public ushort SourceSequence; // 0 if action was not initiated by a client, otherwise monotonously increasing as the client initiates actions
        [FieldOffset(0x1A)] public ushort RotationInt; // quantized rotation: 0 -> -pi, 65535 -> pi
        [FieldOffset(0x1C)] public ushort SpellId;
        [FieldOffset(0x1E)] public byte AnimationVariation;
        [FieldOffset(0x1F)] public ActionType ActionType;
        [FieldOffset(0x20)] public byte Flags;
        [FieldOffset(0x21)] public byte NumTargets;

        public bool ShowInLog => (Flags & 1) != 0; // if this flag is set, the message will be printed to the action log when processing the action
        public bool ForceAnimationLock => (Flags & 2) != 0; // if this flag is set, the animation lock is applied to caster even though SourceSequence == 0
    }

    /// <summary>
    /// The main entry point, called when receiving ActionEffectN server packets.
    /// </summary>
    /// <param name="casterEntityId">Caster entity id.</param>
    /// <param name="casterPtr">Caster pointer.</param>
    /// <param name="targetPos">Only relevant for area-targeted actions.</param>
    /// <param name="header">Details of the action.</param>
    /// <param name="effects">Per-target effect list array. Contains header->NumTargets elements.</param>
    /// <param name="targetEntityIds">Per-target effect id array. Contains header->NumTargets elements.</param>
    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 4C 24 68 48 33 CC E8 ?? ?? ?? ?? 4C 8D 5C 24 70 49 8B 5B 20 49 8B 73 28 49 8B E3 5F C3")]
    public static partial void Receive(uint casterEntityId, Character* casterPtr, Vector3* targetPos, Header* header, TargetEffects* effects, GameObjectId* targetEntityIds);
}
