using UserFileEvent = FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager.UserFileEvent;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::CraftModule
//   Client::UI::Misc::UserFileManager::UserFileEvent
[GenerateInterop]
[Inherits<UserFileEvent>]
[StructLayout(LayoutKind.Explicit, Size = 0x60)]
public unsafe partial struct CraftModule {
    public static CraftModule* Instance() {
        var uiModule = UIModule.Instance();
        return uiModule == null ? null : uiModule->GetCraftModule();
    }

    /// <remarks> Key is ClassJobId </remarks>
    [FieldOffset(0x48)] public StdMap<byte, FavoriteActionsSet> FavoriteActions;
    [FieldOffset(0x58)] public uint Flags;

    [StructLayout(LayoutKind.Explicit, Size = 0x2C)]
    public struct FavoriteActionsSet {
        [FieldOffset(0x00), FixedSizeArray, CExporterIgnore] internal FixedSizeArray9<uint> _favorites;
        [FieldOffset(0x00)] private uint Favorite0;
        [FieldOffset(0x04)] private uint Favorite1;
        [FieldOffset(0x08)] private uint Favorite2;
        [FieldOffset(0x0C)] private uint Favorite3;
        [FieldOffset(0x10)] private uint Favorite4;
        [FieldOffset(0x14)] private uint Favorite5;
        [FieldOffset(0x18)] private uint Favorite6;
        [FieldOffset(0x1C)] private uint Favorite7;
        [FieldOffset(0x20)] private uint Favorite8;
        [FieldOffset(0x24)] public byte NumFavorites;
    }
}
