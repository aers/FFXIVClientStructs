using UserFileEvent = FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager.UserFileEvent;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::EmjModule
//   Client::UI::Misc::UserFileManager::UserFileEvent
[GenerateInterop]
[Inherits<UserFileEvent>]
[StructLayout(LayoutKind.Explicit, Size = 0xD0)]
public unsafe partial struct EmjModule {
    public static EmjModule* Instance() {
        var uiModule = UIModule.Instance();
        return uiModule == null ? null : uiModule->GetEmjModule();
    }

    [FieldOffset(0x48)] public byte TileSet;
    [FieldOffset(0x49)] public bool HideHints;
    [FieldOffset(0x4A)] public bool HideDangerousTileMarker;
    [FieldOffset(0x4B)] public bool HideChatLog;
    [FieldOffset(0x4C)] private byte Unk4C;
    [FieldOffset(0x4D)] private byte Unk4D;
    [FieldOffset(0x4E)] public bool HideTileNames;
    [FieldOffset(0x4F)] public bool ShowHighResolutionLayout;
    [FieldOffset(0x50)] public bool ShowTraditionalDoraIndicator;
    [FieldOffset(0x51)] public byte OwnPlayerNameSetting;
    [FieldOffset(0x52)] public byte OthersPlayerNameSetting;
    [FieldOffset(0x53)] public bool DisableCharacterVoices;
    [FieldOffset(0x54)] private byte Unk54;
    [FieldOffset(0x55)] private byte Unk55;

    [FieldOffset(0x58)] private int Unk58;
    [FieldOffset(0x5C)] private int Unk5C; // set to current time

    [FieldOffset(0x68), FixedSizeArray] internal FixedSizeArray16<int> _unk68; // Unk58 history?
    [FieldOffset(0xA8), FixedSizeArray] internal FixedSizeArray3<short> _unkA8;

    [FieldOffset(0xC8), FixedSizeArray] internal FixedSizeArray4<byte> _seenVoiceBitflags;
    [FieldOffset(0xCC), FixedSizeArray] internal FixedSizeArray4<byte> _seenCostumeBitflags;
}
