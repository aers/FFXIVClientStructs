using UserFileEvent = FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager.UserFileEvent;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::AozNoteModule
//   Client::UI::Misc::UserFileManager::UserFileEvent
[GenerateInterop]
[Inherits<UserFileEvent>]
[StructLayout(LayoutKind.Explicit, Size = 0xD30)]
public unsafe partial struct AozNoteModule {
    public static AozNoteModule* Instance() {
        var uiModule = UIModule.Instance();
        return uiModule == null ? null : uiModule->GetAozNoteModule();
    }

    [FieldOffset(0x48), FixedSizeArray] internal FixedSizeArray5<ActiveSet> _activeSets;

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x290)]
    public partial struct ActiveSet {
        [FieldOffset(0), FixedSizeArray] internal FixedSizeArray24<uint> _activeActions;
        [FieldOffset(0x60), FixedSizeArray(isString: true)] internal FixedSizeArray61<byte> _customName;
        [FieldOffset(0x9D), FixedSizeArray] internal FixedSizeArray10<AozHotBar> _standardHotBars;
        [FieldOffset(0x115), FixedSizeArray] internal FixedSizeArray8<AozCrossHotBar> _crossHotBars;
        [FieldOffset(0x195), FixedSizeArray] internal FixedSizeArray10<AozHotBarMacroFlag> _standardHotBarMacroFlags;
        [FieldOffset(0x20D), FixedSizeArray] internal FixedSizeArray8<AozCrossHotBarMacroFlag> _crossHotBarMacroFlags;
    }

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 12)]
    public partial struct AozHotBar {
        [FieldOffset(0), FixedSizeArray] internal FixedSizeArray12<byte> _aozActionIds;
    }

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 16)]
    public partial struct AozCrossHotBar {
        [FieldOffset(0), FixedSizeArray] internal FixedSizeArray16<byte> _aozActionIds;
    }

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 12)]
    public partial struct AozHotBarMacroFlag {
        [FieldOffset(0), FixedSizeArray] internal FixedSizeArray12<bool> _macroFlags;
    }

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 16)]
    public partial struct AozCrossHotBarMacroFlag {
        [FieldOffset(0), FixedSizeArray] internal FixedSizeArray16<bool> _macroFlags;
    }

    [MemberFunction("E9 ?? ?? ?? ?? 48 8D 0D ?? ?? ?? ?? 8B 14 99")]
    public partial StringPointer GetActiveSetCustomNamePtr(int activeSetIndex);

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 19 8B D3")]
    public partial bool HasActiveSetCustomName(int activeSetIndex);

    [MemberFunction("41 0F 10 00 8B C2 48 69 D0 ?? ?? ?? ?? 0F 11 84 0A"), GenerateStringOverloads]
    public partial void SetActiveSetCustomName(int activeSetIndex, byte* name);

    [MemberFunction("E8 ?? ?? ?? ?? 49 69 F6")]
    public partial void SaveActiveSetHotBars(int activeSetIndex);

    [MemberFunction("E8 ?? ?? ?? ?? 33 D2 48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 3C 24 40 0F 94 C7")]
    public partial void LoadActiveSetHotBars(int activeSetIndex);

    public void ResetActiveSetCustomName(int activeSetIndex)
        => *GetActiveSetCustomNamePtr(activeSetIndex).Value = 0;
}
