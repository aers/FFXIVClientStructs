using FFXIVClientStructs.FFXIV.Component.GUI;
using System.Diagnostics.CodeAnalysis;

namespace FFXIVClientStructs.FFXIV.Client.UI.Arrays;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 22 * 8)]
public unsafe partial struct TradeStringArray {
    public static TradeStringArray* Instance() {
        var stringArray = AtkStage.Instance()->GetStringArrayData(StringArrayType.Trade);
        return stringArray == null ? null : (TradeStringArray*)stringArray->StringArray;
    }

    [FieldOffset(0 * 8), FixedSizeArray, CExporterIgnore] internal FixedSizeArray1002<CStringPointer> _data;

    /// <remarks>
    /// 0 -> 4 = Trade Away Items <br/>
    /// 5 -> 9 = Trade Receive Items
    /// </remarks>
    [FieldOffset(0 * 8), FixedSizeArray] internal FixedSizeArray10<CStringPointer> _itemNames; // There seems to be space for 20 items so maybe at some point SE adds 5 more slots for tradeing on each side

    [FieldOffset(10 * 8)] public CStringPointer OwnName;
    [FieldOffset(11 * 8)] public CStringPointer TradePartnerName;

    // the next 10 values are not used but could be for expanded _itemNames array

    [UnscopedRef] 
    public Span<CStringPointer> ItemsGive => ItemNames[..5];

    [UnscopedRef] 
    public Span<CStringPointer> ItemsReviece => ItemNames[5..];
}
