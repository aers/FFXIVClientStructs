namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::WorldHelper
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x40)]
public unsafe partial struct WorldHelper {
    public static WorldHelper* Instance() {
        var uiModule = UIModule.Instance();
        return uiModule == null ? null : uiModule->GetWorldHelper();
    }

    [FieldOffset(0x08)] public StdMap<ushort, World> AllWorlds;
    /// <summary> Contains all worlds of the current data center. </summary>
    [FieldOffset(0x18)] public StdMap<ushort, World> DataCenterWorlds;
    // [FieldOffset(0x28)] public ClassThatLoadsWorlds WorldLoader; // size: 0x10
    [FieldOffset(0x38)] public bool IsLoaded;

    [MemberFunction("E8 ?? ?? ?? ?? 48 85 F6 75 17")]
    public partial World GetWorldById(ushort world);

    [MemberFunction("E8 ?? ?? ?? ?? 49 63 F5")]
    public partial CStringPointer GetWorldNameById(ushort world);

    [MemberFunction("E8 ?? ?? ?? ?? 66 41 89 07 66 85 C0")]
    public partial ushort GetWorldIdByName(CStringPointer worldName);


    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x24)]
    public partial struct World {
        [FieldOffset(0x00)] public ushort RowId;
        [FieldOffset(0x02)] public byte DataCenter;
        [FieldOffset(0x03), FixedSizeArray(isString: true)] internal FixedSizeArray32<byte> _name;
    }
}
