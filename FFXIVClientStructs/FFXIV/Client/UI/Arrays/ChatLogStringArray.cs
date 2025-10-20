using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Arrays;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 9 * 8)]
public unsafe partial struct ChatLogStringArray {
    public static ChatLogStringArray* Instance() {
        var stringArray = AtkStage.Instance()->GetStringArrayData(StringArrayType.ChatLog);
        return stringArray == null ? null : (ChatLogStringArray*)stringArray->StringArray;
    }

    [FieldOffset(0), FixedSizeArray, CExporterIgnore] internal FixedSizeArray9<CStringPointer> _data;

    [FieldOffset(1 * 8)] public CStringPointer Tab1VisibleChatText;
    [FieldOffset(3 * 8)] public CStringPointer Tab2VisibleChatText;
    [FieldOffset(5 * 8)] public CStringPointer Tab3VisibleChatText;
    [FieldOffset(7 * 8)] public CStringPointer Tab4VisibleChatText;
}
