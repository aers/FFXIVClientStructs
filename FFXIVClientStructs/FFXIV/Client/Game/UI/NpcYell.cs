using FFXIVClientStructs.FFXIV.Client.Game.Object;
using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

// Client::Game::UI::NpcYell
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x2850)]
public partial struct NpcYell {

    /// <remarks>
    /// Entries at index <see cref="UnhandledYellCount"/> and above are stale.
    /// </remarks>
    [FieldOffset(0x48), FixedSizeArray] internal FixedSizeArray32<NpcYellSlot> _yellSlots;

    /// <remarks>
    /// Entries at index <see cref="UnhandledYellCount"/> and above are stale.
    /// </remarks>
    [FieldOffset(0x548), FixedSizeArray] internal FixedSizeArray32<NpcYellInfo> _yellInfo;

    /// <summary>
    /// The number of new <see cref="YellSlots"/> and <see cref="YellInfo"/> entries that have not yet been handled.
    /// </summary>
    [FieldOffset(0x2848)] public byte UnhandledYellCount;
    [FieldOffset(0x2849)] private byte Unk_2849; // Looks like a counter that has something to do specifically with entries that show a BattleTalk.
    [FieldOffset(0x284A)] private bool Unk_284A;

    [StructLayout(LayoutKind.Explicit, Size = 0x28)]
    public struct NpcYellSlot {
        [FieldOffset(0x0)] public GameObjectId ObjectId;
        [FieldOffset(0xC)] public uint NameId;
        [FieldOffset(0x10)] private uint Unk_MessageParams; // A (probably) four-long array of integer parameters for the message string.
        [FieldOffset(0x20)] private float Unk_20; // Probably a delay.  Has effective frame delta subracted each update.
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x118)]
    public struct NpcYellInfo {
        [FieldOffset(0x0)] public uint NpcYellRowId;
        [FieldOffset(0x8)] public GameObjectId ObjectId;
        [FieldOffset(0x10)] public uint NameId;
        [FieldOffset(0x18)] public Utf8String Name;
        [FieldOffset(0x80)] public Utf8String Message;
        [FieldOffset(0xE8)] private uint Unk_MessageParams; // A (probably) four-long array of integer parameters for the message string.
        [FieldOffset(0xF8)] private float Unk_F8; // Countdown timer of unknown use.  Has effective frame delta subracted each update.

        /// <summary>
        /// How long (in seconds) to display the message as a balloon.
        /// </summary>
        /// <remarks>
        /// Only used if <see cref="OutputType"/> includes <see cref="NpcYellOutputFlags.ShowBalloon"/>.
        /// </remarks>
        [FieldOffset(0xFC)] public float BalloonTime;

        /// <summary>
        /// How long (in seconds) to display the message in the BattleTalk addon.
        /// </summary>
        /// <remarks>
        /// Only used if <see cref="OutputType"/> includes <see cref="NpcYellOutputFlags.ShowBattleTalk"/>.
        /// </remarks>
        [FieldOffset(0x100)] public float BattleTalkTime;

        /// <summary>
        /// The method(s) used to show the dialogue to the player.
        /// </summary>
        [FieldOffset(0x104)] public NpcYellOutputFlags OutputType;

        /// <remarks>
        /// Controls which UIModule::ShowBattleTalk overload is called.
        /// </remarks>
        [FieldOffset(0x108)] private uint Unk_108;

        /// <summary>
        /// The index of the character bone to which to attach the <see cref="NpcYellBalloon"/>.
        /// </summary>
        /// <remarks>
        /// Only used if <see cref="OutputType"/> includes <see cref="NpcYellOutputFlags.ShowBalloon"/>.
        /// </remarks>
        [FieldOffset(0x10C)] public byte ParentBone;
        [FieldOffset(0x110)] public NpcYellFlags Flags;
    }

    [Flags]
    public enum NpcYellOutputFlags : byte {
        None = 0,
        PrintToLog = 1,
        ShowBalloon = 2,
        ShowBattleTalk = 4,
    }

    [Flags]
    public enum NpcYellFlags : byte {
        None = 0,
        /// <summary>
        /// Controls the corresponding flag in the <see cref="NpcYellBalloon"/>.
        /// </summary>
        SkipCloseChecks = 1,
        /// <summary>
        /// Controls the corresponding flag in the <see cref="NpcYellBalloon"/>.
        /// </summary>
        /// <remarks>
        /// Also checked when formatting NPC name.
        /// </remarks>
        SkipRangeCheck = 2,
        Unk_4 = 4,
        Unk_8 = 8,
        /// <remarks>
        /// This is the default value after initialization.
        /// </remarks>
        Unk_10 = 0x10,
        Unk_20 = 0x20,
        Unk_40 = 0x40,
    }
}
