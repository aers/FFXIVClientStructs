using FFXIVClientStructs.FFXIV.Client.Game.Object;
using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Client.Game.Control;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x28)]
[VirtualTable("89 51 18 48 8D 05 ?? ?? ?? ?? 48 89 41 10 48 8D 05", 6)]
public partial struct CharacterLookAtTargetParam {
    [FieldOffset(0x8)] public TargetInfoType Type;

    /// <summary>
    /// The current target for this character's gaze. Can be set independently of soft or hard targets, and may be set
    /// by NPCs or minions. For players, an action cast will generally target the LookTarget (which generally will be
    /// the soft target if set, then the hard target).
    /// </summary>
    /// <remarks>
    /// Used when Type is <see cref="TargetInfoType.GameObjectId"/>.<br/>
    /// Unlike other GameObjectIDs, this one appears to be set to fully 0 if the player is not looking at anything.
    /// </remarks>
    [FieldOffset(0x10), CExporterUnion("Union.Target")] public GameObjectId TargetId;

    /// <remarks>
    /// Used when Type is <see cref="TargetInfoType.Unk2"/> or <see cref="TargetInfoType.Unk3"/>.
    /// </remarks>
    [FieldOffset(0x10), CExporterUnion("Union.Target")] public Vector3 Unk10;
    [FieldOffset(0x20)] public int Unk20;

    public enum TargetInfoType {
        None = 0,
        GameObjectId = 1,
        Unk2 = 2,
        Unk3 = 3,
    }
}
