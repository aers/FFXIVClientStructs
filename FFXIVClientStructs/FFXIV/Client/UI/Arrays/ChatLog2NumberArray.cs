using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Arrays;

[CExportIgnore]
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 2000 * 4)]
public unsafe partial struct ChatLog2NumberArray {
    public static ChatLog2NumberArray* Instance() => (ChatLog2NumberArray*)AtkStage.Instance()->GetNumberArrayData(NumberArrayType.ChatLog2)->IntArray;

    [FieldOffset(0), FixedSizeArray, CExportIgnore] internal FixedSizeArray2000<int> _data;

    [FieldOffset(0 * 4), FixedSizeArray] internal FixedSizeArray250<ChatLog2ChatMessageNumberArray> _tab1Messages;
    [FieldOffset(500 * 4), FixedSizeArray] internal FixedSizeArray250<ChatLog2ChatMessageNumberArray> _tab2Messages;
    [FieldOffset(1000 * 4), FixedSizeArray] internal FixedSizeArray250<ChatLog2ChatMessageNumberArray> _tab3Messages;
    [FieldOffset(1500 * 4), FixedSizeArray] internal FixedSizeArray250<ChatLog2ChatMessageNumberArray> _tab4Messages;

    [CExportIgnore]
    [StructLayout(LayoutKind.Explicit, Size = 2 * 4)]
    public partial struct ChatLog2ChatMessageNumberArray {
        [FieldOffset(0 * 4), FixedSizeArray, CExportIgnore] internal FixedSizeArray2<int> _data;

        [FieldOffset(0 * 4)] public int MessageIndex;
        [FieldOffset(1 * 4)] public bool UpdateLineSpacing;
    }
}
