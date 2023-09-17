using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::AcquaintanceModule
//   Client::UI::Misc::UserFileManager::UserFileEvent
// ctor "48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 48 89 7C 24 ?? 41 54 41 56 41 57 48 83 EC 20 45 33 E4 48 89 51 10"
[VTableAddress("48 8D 05 ?? ?? ?? ?? 41 BF ?? ?? ?? ?? 48 89 06", 3)]
[StructLayout(LayoutKind.Explicit, Size = 0x10F8)]
public unsafe partial struct AcquaintanceModule {
    public static AcquaintanceModule* Instance() => Framework.Instance()->GetUiModule()->GetAcquaintanceModule();

    [FieldOffset(0)] public UserFileEvent UserFileEvent;
    [FixedSizeArray<Acquaintance>(16)]
    [FieldOffset(0x40)] public fixed byte TellHistory[0xE0 * 16];
    [FieldOffset(0xE40)] public uint NumTellHistoryEntries;

    [StructLayout(LayoutKind.Explicit, Size = 0xE0)]
    public struct Acquaintance {
        [FieldOffset(0x00)] public Utf8String Name;
        [FieldOffset(0x68)] public Utf8String WorldName;
        [FieldOffset(0xD0)] public ushort WorldId;
        // [FieldOffset(0xD2)] public ushort Flags;

        [FieldOffset(0xD8)] public ulong ContentId;
    }

    [MemberFunction("E8 ?? ?? ?? ?? 49 8B 45 00 49 8B CD FF 50 48")]
    public partial void ClearTellHistory(bool save = true);
}
