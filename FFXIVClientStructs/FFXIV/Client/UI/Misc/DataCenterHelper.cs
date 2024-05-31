using FFXIVClientStructs.FFXIV.Client.System.Framework;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::DataCenterHelper
[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public unsafe partial struct DataCenterHelper {
    public static DataCenterHelper* Instance() => Framework.Instance()->GetUIModule()->GetDataCenterHelper();

    /// <summary>
    /// Contains all data centers of the current region.
    /// </summary>
    [FieldOffset(0x08)] public StdVector<DataCenter> DataCenters;

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x22)]
    public partial struct DataCenter {
        [FieldOffset(0x00)] public ushort Region;
        /// <remarks> RowId of sheet WorldDCGroupType </remarks>
        [FieldOffset(0x02)] public uint RowId;
        [FieldOffset(0x06), FixedSizeArray(isString: true)] internal FixedSizeArray32<byte> _name;
    }
}
