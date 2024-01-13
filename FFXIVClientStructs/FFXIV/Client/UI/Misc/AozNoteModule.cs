using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::AozNoteModule
//   Client::UI::Misc::UserFileManager::UserFileEvent
// ctor "E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 49 8B D4 E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 49 8B D4 E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 49 8B D4 E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 49 8B D4 E8 ?? ?? ?? ?? 33 C0"
[StructLayout(LayoutKind.Explicit, Size = 0xD28)]
public unsafe partial struct AozNoteModule {
    public static AozNoteModule* Instance() => Framework.Instance()->GetUiModule()->GetAozNoteModule();

    [FieldOffset(0)] public UserFileEvent UserFileEvent;
    [FixedSizeArray<ActiveSet>(5)]
    [FieldOffset(0x40)] public fixed byte ActiveSets[5 * 0x290];

    [StructLayout(LayoutKind.Explicit, Size = 0x290)]
    public partial struct ActiveSet {
        [FieldOffset(0)] public fixed uint ActiveActions[24]; // Action RowIds
        [FieldOffset(0x60), FixedString("CustomName")] public fixed byte CustomNameBytes[61];
        [FixedSizeArray<AozHotBar>(10)]
        [FieldOffset(0x9D)] public fixed byte StandardHotBars[12 * 10];
        [FixedSizeArray<AozCrossHotBar>(8)]
        [FieldOffset(0x115)] public fixed byte CrossHotBars[8 * 16];
        [FixedSizeArray<AozHotBarMacroFlag>(10)]
        [FieldOffset(0x195)] public fixed byte StandardHotBarMacroFlags[12 * 10];
        [FixedSizeArray<AozCrossHotBarMacroFlag>(8)]
        [FieldOffset(0x20D)] public fixed byte CrossHotBarMacroFlags[8 * 16];
    }

    [StructLayout(LayoutKind.Explicit, Size = 12)]
    public struct AozHotBar {
        [FieldOffset(0)] public fixed byte AozActionIds[12];
    }

    [StructLayout(LayoutKind.Explicit, Size = 16)]
    public struct AozCrossHotBar {
        [FieldOffset(0)] public fixed byte AozActionIds[16];
    }

    [StructLayout(LayoutKind.Explicit, Size = 12)]
    public struct AozHotBarMacroFlag {
        [FieldOffset(0)] public fixed bool MacroFlag[12];
    }

    [StructLayout(LayoutKind.Explicit, Size = 16)]
    public struct AozCrossHotBarMacroFlag {
        [FieldOffset(0)] public fixed bool MacroFlag[16];
    }

    [MemberFunction("E8 ?? ?? ?? ?? EB 0B 41 8B 17")]
    public partial byte* GetActiveSetCustomNamePtr(int activeSetIndex);

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 0C 8B D3 48 8B CD")]
    public partial bool HasActiveSetCustomName(int activeSetIndex);

    [MemberFunction("41 0F 10 00 8B C2 48 69 D0 ?? ?? ?? ?? 0F 11 84 0A"), GenerateCStrOverloads]
    public partial void SetActiveSetCustomName(int activeSetIndex, byte* name);

    [MemberFunction("E8 ?? ?? ?? ?? 48 69 F6")]
    public partial void SaveActiveSetHotBars(int activeSetIndex);

    [MemberFunction("E8 ?? ?? ?? ?? 33 D2 48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 3C 24 40 0F 94 C7")]
    public partial void LoadActiveSetHotBars(int activeSetIndex);

    public void ResetActiveSetCustomName(int activeSetIndex)
        => *GetActiveSetCustomNamePtr(activeSetIndex) = 0;
}
