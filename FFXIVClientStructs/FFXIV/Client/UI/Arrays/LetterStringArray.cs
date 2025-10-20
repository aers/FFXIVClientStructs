using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Arrays;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 393 * 8)]
public unsafe partial struct LetterStringArray {
    public static LetterStringArray* Instance() {
        var stringArray = AtkStage.Instance()->GetStringArrayData(StringArrayType.Letter);
        return stringArray == null ? null : (LetterStringArray*)stringArray->StringArray;
    }

    [FieldOffset(0), FixedSizeArray, CExporterIgnore] internal FixedSizeArray393<CStringPointer> _data;

    /// <summary>
    /// Ordered based on date received. It doesn't care about which tab.
    /// </summary>
    [FieldOffset(0 * 8), FixedSizeArray] internal FixedSizeArray130<CStringPointer> _mailSenders;

    /// <summary>
    /// Ordered based on date received. It doesn't care about which tab.
    /// </summary>
    [FieldOffset(130 * 8), FixedSizeArray] internal FixedSizeArray130<CStringPointer> _timesPassed;

    /// <summary>
    /// Ordered based on date received. It doesn't care about which tab.
    /// </summary>
    [FieldOffset(260 * 8), FixedSizeArray] internal FixedSizeArray130<CStringPointer> _mailTextPreviews;

    [FieldOffset(391 * 8)] public CStringPointer FullMailText;
    [FieldOffset(392 * 8)] public CStringPointer UnclaimedGoodsCountText;
}
