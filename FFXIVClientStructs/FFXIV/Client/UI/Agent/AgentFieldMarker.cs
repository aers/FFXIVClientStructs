using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.FieldMarker)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0xCE0)]
public unsafe partial struct AgentFieldMarker {
    [FieldOffset(0x34)] public byte ActiveMarkerFlags;
    [FieldOffset(0x38)] public int PageIndexOffset; //0 on page 1, 5 on page 2, 10 on page 3 etc.

    [FieldOffset(0x40), FixedSizeArray] internal FixedSizeArray30<Utf8String> _presetLabels;

    [FieldOffset(0xC70)] public Utf8String TooltipString;

    /// <summary>
    /// Check if a specific field marker (waymark) has been placed.
    /// </summary>
    /// <param name="index">The EXD row ID of the field marker to check.</param>
    /// <returns>Returns true if the field marker is placed, false otherwise.</returns>
    public bool IsFieldMarkerActive(int index) => (ActiveMarkerFlags & (1 << index)) != 0;
}
