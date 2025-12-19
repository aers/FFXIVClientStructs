using FFXIVClientStructs.FFXIV.Client.System.Resource;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::UserFileManager
[GenerateInterop(isInherited: true)]
[Inherits<ResourceEventListener>]
[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public partial struct UserFileManager {
    // Client::UI::Misc::UserFileManager::UserFileEvent
    // ctor inlined
    [GenerateInterop(isInherited: true)]
    [StructLayout(LayoutKind.Explicit, Size = 0x48)]
    public unsafe partial struct UserFileEvent {
        [FieldOffset(0x08)] public ulong CharacterContentId;
        [FieldOffset(0x10)] public nint UserFileManager;
        [FieldOffset(0x18)] public nint TempDataPtr;
        [FieldOffset(0x20)] public uint TempDataBytesWritten;

        [FieldOffset(0x30), FixedSizeArray(isString: true)] internal FixedSizeArray12<byte> _fileName;
        [FieldOffset(0x3C)] public bool Unk3C;
        [FieldOffset(0x40)] private int Unk40; // new 7.1, defaults to 1
        [FieldOffset(0x44)] public bool HasChanges;
        [FieldOffset(0x45)] public bool IsSavePending;
        [FieldOffset(0x46)] public bool IsVirtual; // if true this won't be written to disk, because it's part of another file (for example ADDON.DAT)

        [VirtualFunction(1)]
        public partial bool ReadFile(bool decrypt, byte* ptr, ushort version, uint length);

        [VirtualFunction(2)]
        public partial uint WriteFile(byte* ptr, uint length);

        // vf3 calls vf1

        // vf4 new patch 7.1
        // if new field Unk40 is 1, calls vf9 and vf3

        [VirtualFunction(5)]
        public partial uint GetFileSize();

        [VirtualFunction(6)]
        public partial uint GetDataSize(); // + 0x20 = file size

        [VirtualFunction(7)]
        public partial ushort GetFileVersion();

        [VirtualFunction(8)]
        public partial ushort GetFileType();

        // vf9?

        [VirtualFunction(10)]
        public partial bool GetHasChanges();

        [VirtualFunction(11)]
        public partial bool GetIsSavePending();

        [VirtualFunction(12)]
        public partial void SetCharacterContentId(ulong contentId);

        [VirtualFunction(13)]
        public partial void SaveFile(bool force);
    }
}

// these are only valid for files inside FFXIV_CHR<ContentId> folder
public enum UserFileType : ushort {
    ADDON = 0x00,
    MACRO = 0x01, // RaptureMacroModule
    HOTBAR = 0x02, // RaptureHotbarModule
    KEYBIND = 0x03,
    LOGFLTR = 0x04,
    GEARSET = 0x05, // RaptureGearsetModule
    ACQ = 0x06, // AcquaintanceModule
    ITEMODR = 0x07, // ItemOrderModule
    ITEMFDR = 0x08, // ItemFinderModule
    UISAVE = 0x09, // UiSavePackModule
    GS = 0x0A,
    CONTROL = 0x0D, // CONTROL0 and CONTROL1
}
