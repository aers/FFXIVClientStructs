namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::WorldHelper
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

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x22)]
    public partial struct World {
        [FieldOffset(0x00)] public byte DataCenter;
        [FieldOffset(0x00), Obsolete("This field was removed", true)] public bool IsPublic;
        [FieldOffset(0x01), FixedSizeArray(isString: true)] internal FixedSizeArray32<byte> _name;
    }
}
