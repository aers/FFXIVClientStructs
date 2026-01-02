using FFXIVClientStructs.FFXIV.Component.GUI;
using System.Diagnostics.CodeAnalysis;

namespace FFXIVClientStructs.FFXIV.Client.UI.Arrays;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 133 * 4)]
public unsafe partial struct TradeNumberArray {
    public static TradeNumberArray* Instance() {
        var numberArray = AtkStage.Instance()->GetNumberArrayData(NumberArrayType.Trade);
        return numberArray == null ? null : (TradeNumberArray*)numberArray->IntArray;
    }

    [FieldOffset(0), FixedSizeArray, CExporterIgnore] internal FixedSizeArray133<int> _data;

    /// <remarks>
    /// 0 -> 4 = Trade Away Items <br/>
    /// 5 -> 9 = Trade Receive Items
    /// </remarks>
    [FieldOffset(0), FixedSizeArray] internal FixedSizeArray10<TradeItem> _itemData; // There seems to be space for 20 items so maybe at some point SE adds 5 more slots for tradeing on each side
    [FieldOffset(60 * 4)] public uint SendGilCount;
    [FieldOffset(61 * 4)] public uint ReceiveGilCount;
    /// <remarks>
    /// 2 = Adding Items
    /// 3 = Locked In
    /// </remarks>
    [FieldOffset(62 * 4)] public int SelfState;
    /// <remarks>
    /// 2 = Adding Items
    /// 3 = Locked In
    /// </remarks>
    [FieldOffset(63 * 4)] public int OtherState;

    [FieldOffset(64 * 4)] public bool IsLockedIn;

    // the next 69 values are not used but could be in relation to expanded _itemDatas array

    [UnscopedRef] 
    public Span<TradeItem> ItemsGive => ItemData[..5];

    [UnscopedRef] 
    public Span<TradeItem> ItemsReviece => ItemData[5..];

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 6 * 4)]
    public partial struct TradeItem {
        [FieldOffset(0 * 4)] public int IconId;
        [FieldOffset(1 * 4)] public uint Quantity;
        [FieldOffset(2 * 4)] public int EquipSlotCategory;
        /// <remarks>
        /// 0 = None <br/>
        /// 1 = Equipment <br/>
        /// 2 = CanExtractMateria <br/>
        /// 4 = NoCondition <br/>
        /// 16 = MaxStackQuantity <br/>
        /// 32 = IsCollectable <br/>
        /// 64 = CanStackWithSomeOtherStackInInventory
        /// </remarks>
        [FieldOffset(3 * 4)] public int ItemFlags;
        /// <summary>
        /// 0x000000FF = Flags mask <br/>
        /// 0xFFFFFF00 = Color mask
        /// </summary>
        /// <remarks>
        /// Flags: <br/>
        /// 0 = None <br/>
        /// 1 = ContainsData <br/>
        /// 2 = HasUnlockedStainSlot <br/>
        /// 4 = IsGlamoured <br/>
        /// <br/>
        /// 2nd stain only has flag component 0 and 1
        /// </remarks>
        [FieldOffset(4 * 4), FixedSizeArray] internal FixedSizeArray2<int> _stainFlagsAndColor;
    }
}
