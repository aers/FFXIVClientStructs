using GatheringPointObject = FFXIVClientStructs.FFXIV.Client.Game.Object.GatheringPointObject;

namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

[GenerateInterop(isInherited: true)]
[Inherits<EventHandler>]
[StructLayout(LayoutKind.Explicit, Size = 0x428)]
public unsafe partial struct GatheringEventHandler {
    /// <remarks> Index into the GatheringPoint Excel sheet. </remarks>
    [FieldOffset(0x2E8)] public uint RowId;
    /// <remarks> Index into the GatheringPointBase Excel sheet. </remarks>
    [FieldOffset(0x2EC)] public uint BaseRowId;
    [FieldOffset(0x2C8)] public int Icon;
    [FieldOffset(0x2F0)] public ushort GatheringPointBonus0;
    [FieldOffset(0x2F2)] public ushort GatheringPointBonus1;
    [FieldOffset(0x308)] private byte Unknown0; // GatheringPoint.Unknown0
    [FieldOffset(0x30B)] public byte Count;
    [FieldOffset(0x30E)] public ushort GatheringSubCategory;
    [FieldOffset(0x306)] public GatheringType GatheringType;
    /// <remarks> From the Type column in the GatheringPoint Excel sheet. </remarks>
    [FieldOffset(0x307)] public byte Type;
    [FieldOffset(0x309)] public byte GatheringLevel;
    /// <remarks> Flags are currently unknown, they are set in Setup. </remarks>
    [FieldOffset(0x310)] public byte Flags;
    [FieldOffset(0x311)] private byte Unknown1; // GatheringPoint.Unknown1

    /// <summary>Reads Excel data and some fields sent by the server that were stored in GatheringPointObject.</summary>
    /// <param name="rowId">Index into the GatheringPoint Excel sheet.</param>
    /// <param name="gatheringPointRow">Row data for this gathering point.</param>
    /// <param name="gatheringPointObject">The object used to read the relevant fields from.</param>
    [MemberFunction("48 89 5C 24 ?? 57 48 83 EC ?? 44 0F B6 91")]
    public partial void Setup(uint rowId, [CExporterExcel("GatheringPoint")] void* gatheringPointRow, GatheringPointObject *gatheringPointObject);
}

/// <summary> Corresponds to rows in the GatheringPoint Excel sheet. </summary>
public enum GatheringType : byte {
    Mining = 0,
    Quarrying = 1,
    Logging = 2,
    Harvesting = 3,
    Spearfishing = 4,
    Spearfishing2 = 5,
}
