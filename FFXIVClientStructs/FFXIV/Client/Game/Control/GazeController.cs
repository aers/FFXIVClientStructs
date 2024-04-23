using FFXIVClientStructs.FFXIV.Client.Game.Character;
using FFXIVClientStructs.FFXIV.Client.Game.Object;
using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Client.Game.Control;

// Client::Game::Control::GazeController
// ctor "48 89 5C 24 ?? 48 8D 05 ?? ?? ?? ?? BA"
[VTableAddress("48 89 5C 24 ?? 48 8D 05 ?? ?? ?? ?? BA", 8)]
[StructLayout(LayoutKind.Explicit, Size = 0x5E0)]
public unsafe partial struct GazeController {
    [FieldOffset(0x10)] public BattleChara* OwnerObject;

    /// <remarks>
    /// 0 = Torso<br/>
    /// 1 = Head<br/>
    /// 2 = Eyes
    /// </remarks>
    [FixedSizeArray<Gaze>(3)]
    [FieldOffset(0x20)] public fixed byte Gazes[3 * Gaze.Size];

    [FieldOffset(0x5C4)] public int GazesCount;

    [VTableAddress("48 8D 05 ?? ?? ?? ?? 48 89 01 33 D2 89 51 18", 3)]
    [StructLayout(LayoutKind.Explicit, Size = Size)]
    public partial struct Gaze {
        public const int Size = 0x1E0;

        [FieldOffset(0x10)] public TargetInformation TargetInfo;

        [VTableAddress("89 51 18 48 8D 05 ?? ?? ?? ?? 48 89 41 10 48 8D 05", 6)]
        [StructLayout(LayoutKind.Explicit, Size = 0x28)]
        public partial struct TargetInformation {
            [FieldOffset(0x8)] public TargetInfoType Type;

            /// <summary>
            /// The current target for this character's gaze. Can be set independently of soft or hard targets, and may be set
            /// by NPCs or minions. For players, an action cast will generally target the LookTarget (which generally will be
            /// the soft target if set, then the hard target).
            /// </summary>
            /// <remarks>
            /// Used when Type is <see cref="TargetInfoType.GameObjectID"/>.<br/>
            /// Unlike other GameObjectIDs, this one appears to be set to fully 0 if the player is not looking at anything.
            /// </remarks>
            [FieldOffset(0x10), CExporterUnion("Union.Target")] public GameObjectID TargetId;

            /// <remarks>
            /// Used when Type is <see cref="TargetInfoType.Unk2"/> or <see cref="TargetInfoType.Unk3"/>.
            /// </remarks>
            [FieldOffset(0x10), CExporterUnion("Union.Target")] public Vector3 Unk10;
            [FieldOffset(0x20)] public int Unk20;

            public enum TargetInfoType {
                None = 0,
                GameObjectID = 1,
                Unk2 = 2,
                Unk3 = 3,
            }
        }
    }
}
