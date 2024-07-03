using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Client.UI.Misc;
using FFXIVClientStructs.FFXIV.Common;
using FFXIVClientStructs.FFXIV.Component.Shell;

namespace FFXIVClientStructs.FFXIV.Client.UI.Shell;

// Client::UI::Shell::RaptureShellModule
// ctor "E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 4C 8B CF"
[GenerateInterop]
[Inherits<ShellCommandModule>]
[StructLayout(LayoutKind.Explicit, Size = 0x1218)]
public unsafe partial struct RaptureShellModule {
    public static RaptureShellModule* Instance() => Framework.Instance()->GetUIModule()->GetRaptureShellModule();

    [FieldOffset(0x250)] public ShellCommandInterface ShellCommandInterface;
    [FieldOffset(0x258)] public UIModule* UIModule;
    [FieldOffset(0x260)] public ShellCommandInterface ShellCommandEmote;
    [FieldOffset(0x268)] public ShellCommandInterface* ShellCommandLinkshellIndex;
    [FieldOffset(0x270)] public ShellCommandInterface* ShellCommandChatCrossWorldLinkshell;
    [FieldOffset(0x278)] public ShellCommandInterface* ShellCommandConfigToggle;
    [FieldOffset(0x280)] public ShellCommandInterface* ShellCommandGraphicPresets;
    [FieldOffset(0x288)] public ShellCommandInterface* ShellCommandAgent;
    [FieldOffset(0x290)] public TimePoint WaitStartTime;
    [FieldOffset(0x2A8)] public uint WaitTimeMs;
    [FieldOffset(0x2B3)] public bool MacroLocked;
    [FieldOffset(0x2C0)] public int MacroCurrentLine;
    [FieldOffset(0x2C8)] public Utf8String MacroLineText;
    [FieldOffset(0x338)] public Utf8String MacroName;
    [FieldOffset(0x3A0), FixedSizeArray] internal FixedSizeArray15<Utf8String> _macroLines;
    [FieldOffset(0x9B8), FixedSizeArray] internal FixedSizeArray15<Utf8String> _skippedMacroLines;
    [FieldOffset(0xFD0)] public int ChatType;
    [FieldOffset(0xFD8)] public Utf8String TellName;
    [FieldOffset(0x1040)] public Utf8String TellWorld;
    [FieldOffset(0x10A8)] public ulong ContentId;
    [FieldOffset(0x10B0)] public ulong AccountId;
    [FieldOffset(0x10B8)] public ushort TellWorldId;
    [FieldOffset(0x10BA)] public ushort TellReason;
    [FieldOffset(0x10BC)] public int TempChatType;
    [FieldOffset(0x10C0)] public Utf8String TempChatCommand;
    [FieldOffset(0x1128)] public Utf8String TempTellName;
    [FieldOffset(0x1190)] public Utf8String TempTellWorld;
    [FieldOffset(0x11F8)] public ulong TempContentId;
    [FieldOffset(0x1200)] public ulong TempAccountId;
    [FieldOffset(0x1208)] public ushort TempTellWorldId;
    [FieldOffset(0x120A)] public ushort TempTellReason;

    [FieldOffset(0x1210)] public uint Flags;

    public bool IsTextCommandUnavailable => (Flags & 1) != 0;

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8D 4D 28")]
    public partial void ExecuteMacro(RaptureMacroModule.Macro* macro);

    [MemberFunction("E8 ?? ?? ?? ?? 48 BA ?? ?? ?? ?? ?? ?? ?? ?? 84 C0")]
    public partial bool TryGetMacroIconCommand(RaptureMacroModule.Macro* macro, void* resultsOut);

    [MemberFunction("E8 ?? ?? ?? ?? 0F B7 44 37 ??")]
    public partial void ChangeChatChannel(int channel, uint linkshellIndex, Utf8String* target, bool setChatType);

    [MemberFunction("E8 ?? ?? ?? ?? 4C 8B 7C 24 ?? EB 34")]
    public partial bool SetContextTellTarget(Utf8String* playerName, Utf8String* worldName, ushort worldId, ulong accountId, ulong contentId, ushort reason, bool setChatType);

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 41 BF ?? ?? ?? ?? 66 83 F9 01")]
    public partial void SetContextTellTargetInForay(Utf8String* playerName, Utf8String* worldName, ushort worldId, ulong accountId, ulong contentId, ushort reason);

    [MemberFunction("48 89 5C 24 ?? 55 56 57 48 81 EC ?? ?? ?? ?? 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 84 24 ?? ?? ?? ?? 48 8B 02 41 0F B7 E9")]
    public partial bool SetTellTargetInForay(Utf8String* playerName, Utf8String* worldName, ushort worldId, ulong accountId, ulong contentId, ushort reason, bool setChatType);

    [MemberFunction("48 89 5C 24 ?? 57 48 83 EC 30 8B B9 ?? ?? ?? ?? 48 8B D9 83 FF FE")]
    public partial void ReplyInSelectedChatMode();
}
