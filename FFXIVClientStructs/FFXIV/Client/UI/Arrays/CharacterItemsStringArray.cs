using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Arrays;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 27 * 8)]
public unsafe partial struct CharacterItemsStringArray {
    public static CharacterItemsStringArray* Instance() {
        var stringArray = AtkStage.Instance()->GetStringArrayData(StringArrayType.CharacterItems);
        return stringArray == null ? null : (CharacterItemsStringArray*)stringArray->StringArray;
    }

    [FieldOffset(0), FixedSizeArray, CExporterIgnore] internal FixedSizeArray27<CStringPointer> _data;

    [FieldOffset(0 * 8), FixedSizeArray] internal FixedSizeArray13<CStringPointer> _itemNames;
    [FieldOffset(26 * 8)] public CStringPointer DisplayedItemLevelText;
}
