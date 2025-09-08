using UserFileEvent = FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager.UserFileEvent;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::MycItemModule
//   Client::UI::Misc::UserFileManager::UserFileEvent
[GenerateInterop]
[Inherits<UserFileEvent>]
[StructLayout(LayoutKind.Explicit, Size = 0x120)]
public unsafe partial struct MycItemModule {
    public static MycItemModule* Instance() {
        var uiModule = UIModule.Instance();
        return uiModule == null ? null : uiModule->GetMycItemModule();
    }

    [FieldOffset(0x48)] public MycItemModuleData* Data;
    [FieldOffset(0x50)] public MycItemData DefaultItemData;

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0xA49)]
    public partial struct MycItemModuleData {
        [FieldOffset(0x00), FixedSizeArray] internal FixedSizeArray10<MycItemSet> _sets;
        [FieldOffset(0xA3C), FixedSizeArray] internal FixedSizeArray13<byte> _bitflags;
    }

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x106)]
    public partial struct MycItemSet {
        [FieldOffset(0x00), FixedSizeArray(isString: true)] internal FixedSizeArray61<byte> _name;
        [FieldOffset(0x3D)] public MycItemData ItemData;
    }

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0xC9)]
    public partial struct MycItemData {
        [FieldOffset(0x00)] public byte NumItems;
        [FieldOffset(0x01), FixedSizeArray] internal FixedSizeArray100<byte> _itemIds;
        [FieldOffset(0x65), FixedSizeArray] internal FixedSizeArray100<byte> _itemCounts;
    }
}
