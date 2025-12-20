using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Arrays;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 34 * 4)]
public unsafe partial struct ChatLogNumberArray {
    public static ChatLogNumberArray* Instance() {
        var numberArray = AtkStage.Instance()->GetNumberArrayData(NumberArrayType.ChatLog);
        return numberArray == null ? null : (ChatLogNumberArray*)numberArray->IntArray;
    }

    [FieldOffset(0), FixedSizeArray, CExporterIgnore] internal FixedSizeArray34<int> _data;

    [FieldOffset(5 * 4)] public ChatLogChatTabNumberArray Tab1;
    [FieldOffset(12 * 4)] public ChatLogChatTabNumberArray Tab2;
    [FieldOffset(19 * 4)] public ChatLogChatTabNumberArray Tab3;
    [FieldOffset(26 * 4)] public ChatLogChatTabNumberArray Tab4;

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 7 * 4)]
    public partial struct ChatLogChatTabNumberArray {
        [FieldOffset(0 * 4), FixedSizeArray, CExporterIgnore] internal FixedSizeArray7<int> _data;

        [FieldOffset(0 * 4)] private int UnkLastLineVisibleHelper;
        [FieldOffset(1 * 4)] public int LineCountVisible;
        [FieldOffset(2 * 4)] public int LineCountLoaded;
        [FieldOffset(3 * 4)] public int TotalLineCount;
        [FieldOffset(4 * 4)] public int ScrollOffset;
        [FieldOffset(6 * 4)] public int TotalMessageCount;
    }
}
