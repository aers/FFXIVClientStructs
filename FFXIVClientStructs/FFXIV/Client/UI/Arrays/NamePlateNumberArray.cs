using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Arrays;

[CExportIgnore]
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 1006 * 4)]
public unsafe partial struct NamePlateNumberArray {
    public static NamePlateNumberArray* Instance() => (NamePlateNumberArray*)AtkStage.Instance()->GetNumberArrayData(NumberArrayType.NamePlate)->IntArray;

    [FieldOffset(0), FixedSizeArray, CExportIgnore] internal FixedSizeArray1006<int> _data;

    [FieldOffset(0x0)] public int ActiveNamePlateCount;
    [FieldOffset(0x4)] public bool ForceNamePlateRebake;
    [FieldOffset(0x8)] public int NamePlateSize;
    [FieldOffset(0xC)] public bool DisableFixedFontResolution;
    [FieldOffset(0x10)] public bool DoFullUpdate;
    // [FieldOffset(0x14)] public int UnkInt;
    [FieldOffset(0x18)][FixedSizeArray] internal FixedSizeArray50<NamePlateObjectIntArrayData> _objectData;

    [CExportIgnore]
    [StructLayout(LayoutKind.Explicit, Size = 20 * 4)]
    public struct NamePlateObjectIntArrayData {
        [FieldOffset(0x0)] public UIObjectKind NamePlateKind;
        [FieldOffset(0x4)] public int HPLabelState;
        /// <summary>
        /// &amp; 0x1 - Update<br/>
        /// &amp; 0x2 - Update Colors<br/>
        /// </summary>
        [FieldOffset(0x8)] public int UpdateFlags;
        [FieldOffset(0xC)] public int X;
        [FieldOffset(0x10)] public int Y;
        [FieldOffset(0x14)] public float Depth;
        [FieldOffset(0x18)] public int Scale;
        [FieldOffset(0x1C)] public int GaugeFillPercentage;
        [FieldOffset(0x20)] public uint NameTextColor;
        [FieldOffset(0x24)] public uint NameEdgeColor;
        [FieldOffset(0x28)] public uint GaugeFillColor;
        [FieldOffset(0x2C)] public uint GaugeContainerColor; // unused if Disable Alternate Part Id true
        [FieldOffset(0x30)] public int MarkerIconId;
        [FieldOffset(0x34)] public int NameIconId;
        // [FieldOffset(0x38)] public int UnkAdjust;
        [FieldOffset(0x3C)] public int NamePlateObjectIndex;
        // [FieldOffset(0x40)] public int Unk;
        /// <summary>
        /// &amp; 0x1 - Is prefix title<br/>
        /// &amp; 0x8 - Use Depth-based Priority (terrain obstruction)<br/>
        /// &amp; 0x80 - Hide title<br/>
        /// &amp; 0x100 - Disable Alternate Part Id<br/>
        /// </summary>
        [FieldOffset(0x44)] public int DrawFlags;
        // [FieldOffset(0x48)] public int Unk;
        /// <summary>
        /// &amp; 0x1 - Draw name text<br/>
        /// &amp; 0x2 - Draw gauge<br/>
        /// &amp; 0x4 - Unknown, seems to be set 1-2 frames after node appears<br/>
        /// </summary>
        [FieldOffset(0x4C)] public int VisibilityFlags;
    }
}
