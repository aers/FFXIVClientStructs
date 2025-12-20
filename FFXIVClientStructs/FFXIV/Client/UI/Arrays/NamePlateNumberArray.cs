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
    [FieldOffset(1 * 4)] public bool ForceNamePlateRebake;
    [FieldOffset(2 * 4)] public int NamePlateSize;
    [FieldOffset(3 * 4)] public bool DisableFixedFontResolution;
    [FieldOffset(4 * 4)] public bool DoFullUpdate;
    // [FieldOffset(5 * 4)] private int UnkInt;
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
        // [FieldOffset(14 * 4)] private int UnkAdjust;
        [FieldOffset(15 * 4)] public int NamePlateObjectIndex;
        // [FieldOffset(16 * 4)] private int Unk;
        /// <summary>
        /// &amp; 0x1 - Is prefix title<br/>
        /// &amp; 0x8 - Use Depth-based Priority (terrain obstruction)<br/>
        /// &amp; 0x80 - Hide title<br/>
        /// &amp; 0x100 - Disable Alternate Part Id<br/>
        /// </summary>
        [FieldOffset(17 * 4)] public int DrawFlags;
        // [FieldOffset(18 * 4)] private int Unk;
        /// <summary>
        /// &amp; 0x1 - Draw name text<br/>
        /// &amp; 0x2 - Draw gauge<br/>
        /// &amp; 0x4 - Unknown, seems to be set 1-2 frames after node appears<br/>
        /// </summary>
        [FieldOffset(19 * 4)] public int VisibilityFlags;
        [FieldOffset(20 * 4)] public uint EntityId;
    }
}
