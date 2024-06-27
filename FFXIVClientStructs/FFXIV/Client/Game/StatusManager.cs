namespace FFXIVClientStructs.FFXIV.Client.Game;

// Client::Game::StatusManager
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x2F0)]
public unsafe partial struct StatusManager {
    // This field is often null and cannot be relied on to retrieve the owning Character object
    [FieldOffset(0x0)] public Character.Character* Owner;
    [FieldOffset(0x8), FixedSizeArray] internal FixedSizeArray60<Status> _status;

    // FlagsN is a bit vector; bit #i is set if any of the active statuses has column 30/31 in the sheet containing 'i'
    [FieldOffset(0x2D8)] public uint Flags1;
    [FieldOffset(0x2DC)] public ushort Flags2;

    [FieldOffset(0x2E0)] public long Unk_178;
    //[FieldOffset(0x2E8)] public byte Unk_180;
    [FieldOffset(0x2E8)] public byte NumValidStatuses;

    [MemberFunction("E8 ?? ?? ?? ?? C6 43 2D 00")]
    public partial bool HasStatus(uint statusId, uint sourceId = 0xE0000000);

    [MemberFunction("E8 ?? ?? ?? ?? 85 C0 79 21")]
    public partial int GetStatusIndex(uint statusId, uint sourceId = 0xE0000000);

    [MemberFunction("83 FA 3C 72 04 0F 57 C0")]
    public partial float GetRemainingTime(int statusIndex);

    [MemberFunction("E8 ?? ?? ?? ?? 3D ?? ?? ?? ?? 74 19")]
    public partial uint GetStatusId(int statusIndex);

    [MemberFunction("E8 ?? ?? ?? ?? 3B 44 24 28")]
    public partial uint GetSourceId(int statusIndex);

    [MemberFunction("66 85 D2 0F 84 ?? ?? ?? ?? 48 89 5C 24 ?? 48 89 6C 24 ??")]
    public partial void AddStatus(ushort statusId, ushort param = 0, void* u3 = null);

    [MemberFunction("83 FA 3C 73 50")]
    public partial void RemoveStatus(int statusIndex, byte u2 = 0); // u2 always appears to be 0

    /// <summary>
    /// Remove specified status, if it is possible to be removed by user interaction.
    /// Does all the sanity checks (that status is on player, is a buff that can be canceled, etc); on success status is removed from manager immediately.
    /// </summary>
    /// <param name="statusId">Id of status to remove.</param>
    /// <param name="sourceId">Source of status to remove (default value would remove first matching).</param>
    [MemberFunction("48 89 5C 24 ?? 48 89 6C 24 ?? 41 56 48 83 EC ?? 4C 8B 35")]
    public static partial bool ExecuteStatusOff(uint statusId, uint sourceId = 0xE0000000);
}

[StructLayout(LayoutKind.Explicit, Size = 0xC)]
public struct Status {
    [FieldOffset(0x0)] public ushort StatusId;
    // this contains different information depending on the type of status
    // debuffs - stack count
    // food/potions - ID of the food/potion in the ItemFood sheet
    [FieldOffset(0x2)] public ushort Param;
    // remains for compatibility
    [FieldOffset(0x2), CExportIgnore] public byte StackCount; // TODO: remove?
    [FieldOffset(0x4)] public float RemainingTime;
    // ObjectId matching the entity that cast the effect - regens will be from the white mage ID etc
    [FieldOffset(0x8)] public uint SourceId;
}
