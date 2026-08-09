using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Arrays;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 397 * 8)]
public unsafe partial struct PartyListStringArray {
    public static PartyListStringArray* Instance() {
        var stringArray = AtkStage.Instance()->GetStringArrayData(StringArrayType.PartyList);
        return stringArray == null ? null : (PartyListStringArray*)stringArray->StringArray;
    }

    [FieldOffset(0), FixedSizeArray, CExporterIgnore] internal FixedSizeArray397<CStringPointer> _data;

    [FieldOffset(0 * 8)] public CStringPointer EnmityLeaderText;
    [FieldOffset(1 * 8)] public CStringPointer EnmityDisabledText;
    [FieldOffset(2 * 8)] public CStringPointer InvalidValueText;
    [FieldOffset(4 * 8)] public CStringPointer PartyTypeText;
    [FieldOffset(6 * 8), FixedSizeArray] internal FixedSizeArray17<PartyListMemberStringArray> _members;

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 23 * 8)]
    public partial struct PartyListMemberStringArray {
        [FieldOffset(0), FixedSizeArray, CExporterIgnore] internal FixedSizeArray23<CStringPointer> _data;

        [FieldOffset(0 * 8)] public CStringPointer GroupSlotIndicator;
        [FieldOffset(1 * 8)] public CStringPointer Name;
        [FieldOffset(2 * 8)] public CStringPointer CastingActionName;
        [FieldOffset(3 * 8), FixedSizeArray] internal FixedSizeArray10<CStringPointer> _statusTexts;
    }
}
