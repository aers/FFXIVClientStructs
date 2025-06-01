using FFXIVClientStructs.FFXIV.Client.Game.Object;

namespace FFXIVClientStructs.FFXIV.Client.Game;

// Client::Game::StatusManager
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x3E0)]
public unsafe partial struct StatusManager {
    // This field is often null and cannot be relied on to retrieve the owning Character object
    [FieldOffset(0x0)] public Character.Character* Owner;
    [FieldOffset(0x8), FixedSizeArray] internal FixedSizeArray60<Status> _status;

    // Flags is a bit vector; bit #i is set if any of the active statuses has column 30/31 in the sheet containing 'i'
    [FieldOffset(0x3C8), FixedSizeArray] internal FixedSizeArray7<byte> _flags;

    [FieldOffset(0x3D0)] public long Unk3D0;
    //[FieldOffset(0x2E8)] public byte Unk_180;
    [FieldOffset(0x3D8)] public byte NumValidStatuses;

    /// <summary>
    /// 0x01: lose control (set if any active status has IsGaze flag set in sheet)
    /// </summary>
    [FieldOffset(0x3D9)] public byte ExtraFlags;

    [MemberFunction("E8 ?? ?? ?? ?? C6 43 2D 00")]
    public partial bool HasStatus(uint statusId, uint sourceId = 0xE0000000);

    [MemberFunction("E8 ?? ?? ?? ?? 8B D8 0F 28 C6")]
    public partial int GetStatusIndex(uint statusId, uint sourceId = 0xE0000000);

    [MemberFunction("83 FA 3C 72 04 0F 57 C0")]
    public partial float GetRemainingTime(int statusIndex);

    [MemberFunction("E8 ?? ?? ?? ?? 3D ?? ?? ?? ?? 74 19")]
    public partial uint GetStatusId(int statusIndex);

    [MemberFunction("E8 ?? ?? ?? ?? 3B 44 24 28")]
    public partial uint GetSourceId(int statusIndex);

    [MemberFunction("66 85 D2 0F 84 ?? ?? ?? ?? 48 89 5C 24 ?? 48 89 6C 24 ??")]
    public partial void AddStatus(ushort statusId, ushort param = 0, void* u3 = null);

    [MemberFunction("83 FA 3C 73 ?? 53 48 83 EC 30 48 8B D9")] // INLINED
    public partial void RemoveStatus(int statusIndex, byte u2 = 0); // u2 always appears to be 0

    [MemberFunction("E8 ?? ?? ?? ?? FF C6 48 8D 5B 0C")]
    public partial bool SetStatus(int statusIndex, ushort statusId, float remaining, ushort param, GameObjectId sourceObject, bool refreshFlags);

    [Obsolete("Use SetStatus with GameObjectId sourceObject")]
    public bool SetStatus(int statusIndex, ushort statusId, float remaining, ushort param, uint sourceId, bool refreshFlags) => SetStatus(statusIndex, statusId, remaining, param, (ulong)sourceId, refreshFlags);

    /// <summary>
    /// Remove specified status, if it is possible to be removed by user interaction.
    /// Does all the sanity checks (that status is on player, is a buff that can be canceled, etc); on success status is removed from manager immediately.
    /// </summary>
    /// <param name="statusId">Id of status to remove.</param>
    /// <param name="sourceId">Source of status to remove (default value would remove first matching).</param>
    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 75 ?? 48 8B 07 48 8B CF 48 8B 5D")]
    public static partial bool ExecuteStatusOff(uint statusId, uint sourceId = 0xE0000000);
}

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public struct Status {
    [FieldOffset(0x0)] public ushort StatusId;
    // this contains different information depending on the type of status
    // debuffs - stack count
    // food/potions - ID of the food/potion in the ItemFood sheet
    [FieldOffset(0x2)] public ushort Param;
    [FieldOffset(0x4)] public float RemainingTime;
    // ObjectId matching the entity that cast the effect - regens will be from the white mage ID etc
    [FieldOffset(0x8)] public GameObjectId SourceObject;
    [FieldOffset(0x8), Obsolete("Use SourceObject")] public uint SourceId;
}
