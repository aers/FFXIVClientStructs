using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Arrays;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 1056 * 4)]
public unsafe partial struct NamePlateNumberArray {
    public static NamePlateNumberArray* Instance() {
        var numberArray = AtkStage.Instance()->GetNumberArrayData(NumberArrayType.NamePlate);
        return numberArray == null ? null : (NamePlateNumberArray*)numberArray->IntArray;
    }

    [FieldOffset(0), FixedSizeArray, CExporterIgnore] internal FixedSizeArray1056<int> _data;

    [FieldOffset(0 * 4)] public int ActiveNamePlateCount;
    /// <summary>
    /// One-shot flag that causes all nameplates to be rebaked. The addon clears it after consuming it.
    /// </summary>
    [FieldOffset(1 * 4)] public bool ForceNamePlateRebake;
    [FieldOffset(2 * 4)] public int NamePlateSize;
    [FieldOffset(3 * 4)] public bool DisableFixedFontResolution;
    // A change causes AddonNamePlate to update all nameplates.
    [FieldOffset(4 * 4)] public bool IsInPvPArea;
    [Obsolete("This is PvP-area state. Use IsInPvPArea, or AddonNamePlate.UpdateAllNamePlates to force an update.")]
    [FieldOffset(4 * 4)] public bool DoFullUpdate;
    [FieldOffset(5 * 4)] public bool IsParticipatingInCustomMatchOrSpectating;
    [FieldOffset(6 * 4), FixedSizeArray] internal FixedSizeArray50<NamePlateObjectIntArrayData> _objectData;

    [StructLayout(LayoutKind.Explicit, Size = 21 * 4)]
    public struct NamePlateObjectIntArrayData {
        [FieldOffset(0 * 4)] public UIObjectKind NamePlateKind;
        [FieldOffset(1 * 4)] public int HPLabelState;
        /// <summary>
        /// &amp; 0x1 - Update<br/>
        /// &amp; 0x2 - Update Colors<br/>
        /// </summary>
        [FieldOffset(2 * 4)] public int UpdateFlags;
        [FieldOffset(3 * 4)] public int X;
        [FieldOffset(4 * 4)] public int Y;
        [FieldOffset(5 * 4)] public float Depth;
        [FieldOffset(6 * 4)] public int Scale;
        [FieldOffset(7 * 4)] public int GaugeFillPercentage;
        [FieldOffset(8 * 4)] public uint NameTextColor;
        [FieldOffset(9 * 4)] public uint NameEdgeColor;
        [FieldOffset(10 * 4)] public uint GaugeFillColor;
        [FieldOffset(11 * 4)] public uint GaugeContainerColor; // unused if Disable Alternate Part Id true
        [FieldOffset(12 * 4)] public int MarkerIconId;
        [FieldOffset(13 * 4)] public int NameIconId;
        // Set for elemental icons on Eureka battle NPC nameplates.
        [FieldOffset(14 * 4)] public bool UseLargeNameIcon;
        [FieldOffset(15 * 4)] public int NamePlateObjectIndex;
        // index 16 is unused
        /// <summary>
        /// &amp; 0x1 - Is prefix title<br/>
        /// &amp; 0x4 - PvP enemy<br/>
        /// &amp; 0x8 - Use Depth-based Priority (terrain obstruction)<br/>
        /// &amp; 0x20 - Enable gauge<br/>
        /// &amp; 0x40 - Use attack cursor<br/>
        /// &amp; 0x80 - Hide title<br/>
        /// &amp; 0x100 - Disable Alternate Part Id<br/>
        /// </summary>
        [FieldOffset(17 * 4)] public int DrawFlags;
        // index 18 is unused
        /// <summary>
        /// &amp; 0x1 - Draw name text<br/>
        /// &amp; 0x2 - Draw gauge<br/>
        /// &amp; 0x4 - Nameplate already exists with unchanged data. Uses the timeline.<br/>
        /// </summary>
        [FieldOffset(19 * 4)] public int VisibilityFlags;
        [FieldOffset(20 * 4)] public uint EntityId;
    }
}
