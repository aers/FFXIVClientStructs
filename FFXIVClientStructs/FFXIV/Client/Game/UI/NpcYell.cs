using FFXIVClientStructs.FFXIV.Client.Game.Object;
using FFXIVClientStructs.FFXIV.Common.Component.Excel;

namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

// Client::Game::UI::NpcYell
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x2850)]
public unsafe partial struct NpcYell {
    [StaticAddress("48 8D 0D ?? ?? ?? ?? 0F 11 44 24 ?? C6 44 24", 3)]
    public static partial NpcYell* Instance();

    /// <remarks>
    /// Null until at least one NpcYell has been queued.
    /// </remarks>
    [FieldOffset(0x10)] public ExcelSheet* NpcYellSheet;

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
    [FieldOffset(0x2849)] public byte UnhandledBattleTalkCount;
    [FieldOffset(0x284A)] private bool Unk284A; // Probably indicates waiting on the Excel sheet when an ENpc is involved, but can't tell for sure.

    [StructLayout(LayoutKind.Explicit, Size = 0x28)]
    public struct NpcYellSlot {
        [FieldOffset(0x0)] public GameObjectId ObjectId;
        /// <remarks>
        /// Only valid before this slot is handled.
        /// </remarks>
        [FieldOffset(0x8)] public uint NpcYellRowId;
        /// <remarks>
        /// In the case of the speaker being an event NPC (i.e., for Gold Saucer announcements), this will instead contain the ENpcResident row ID.
        /// </remarks>
        [FieldOffset(0xC)] public uint NameId;
        [FieldOffset(0x10), FixedSizeArray] internal FixedSizeArray4<uint> _messageParams;
        /// <summary>
        /// How much longer (in seconds) before the yell should be expanded into a <see cref="NpcYellInfo"/>.
        /// </summary>
        [FieldOffset(0x20)] public float Delay;
        [FieldOffset(0x24)] private bool Unk24; // Something to do with whether this entry shows a BattleTalk, but only sometimes.
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x118)]
    public struct NpcYellInfo {
        [FieldOffset(0x0)] public uint NpcYellRowId;
        [FieldOffset(0x8)] public GameObjectId ObjectId;
        /// <remarks>
        /// In the case of the speaker being an event NPC (i.e., for Gold Saucer announcements), this will instead contain the ENpcResident row ID.
        /// </remarks>
        [FieldOffset(0x10)] public uint NameId;
        [FieldOffset(0x18)] public Utf8String Name;
        [FieldOffset(0x80)] public Utf8String Message;
        [FieldOffset(0xE8), FixedSizeArray] internal FixedSizeArray4<uint> _messageParams;

        /// <summary>
        /// How much longer (in seconds) before the yell should be handled.
        /// </summary>
        [FieldOffset(0xF8)] public float Delay;

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

        /// <summary>
        /// The background style used if <see cref="OutputType"/> includes <see cref="NpcYellOutputFlags.ShowBattleTalk"/>.
        /// </summary>
        /// <remarks>
        /// 6 is linkshell-style.<br/>
        /// 7 is dark.<br/>
        /// 9 and 11 are robot-style (blue).<br/>
        /// Others are default white.
        /// </remarks>
        [FieldOffset(0x105)] public byte BattleTalkStyle;

        /// <summary>
        /// The icon ID to show as the BattleTalk portrait if <see cref="OutputType"/> includes <see cref="NpcYellOutputFlags.ShowBattleTalk"/>.
        /// </summary>
        [FieldOffset(0x108)] public uint BattleTalkImage;

        /// <summary>
        /// The index of the character bone to which to attach the <see cref="NpcYellBalloon"/>.
        /// </summary>
        /// <remarks>
        /// Only used if <see cref="OutputType"/> includes <see cref="NpcYellOutputFlags.ShowBalloon"/>.
        /// </remarks>
        [FieldOffset(0x10C)] public byte ParentBone;
        [FieldOffset(0x10E)] private ushort Unk10E; // Copied to NpcYellSot 0x8 in one function.  May be sheet row ID sometimes, but that doesn't make a ton of sense, and have never seen it used during gameplay.
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
        Unk4 = 4,
        /// <remarks>
        /// Causes speaker name to be an empty string.
        /// </remarks>
        HideSpeakerName = 8,
        /// <summary>
        /// Indicates that this slot is currently ready to be assigned yell information.
        /// </summary>
        /// <remarks>
        /// If this is set, all other information in the structure should be considered stale.
        /// </remarks>
        SlotAvailable = 0x10,
        Unk20 = 0x20,
        Unk40 = 0x40, // May indicate that message string is valid.  Is set in certain places after copying the string.
    }
}
