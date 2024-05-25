using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Client.UI.Misc;
using FFXIVClientStructs.FFXIV.Common;
using FFXIVClientStructs.FFXIV.Component.Shell;

namespace FFXIVClientStructs.FFXIV.Client.UI.Shell;

// Client::UI::Shell::RaptureShellModule
// ctor "E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 4C 8B CF"
[StructLayout(LayoutKind.Explicit, Size = 0x1208)]
public unsafe partial struct RaptureShellModule {
    public static RaptureShellModule* Instance() => UIModule.Instance()->GetRaptureShellModule();

    [FieldOffset(0x00)] public ShellCommandModule ShellCommandModule;
    [FieldOffset(0x250)] public ShellCommandInterface ShellCommandInterface;
    [FieldOffset(0x258)] public UIModule* UiModule;
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
    [FixedSizeArray<Utf8String>(15)]
    [FieldOffset(0x3A0)] private fixed byte MacroLines[15 * 0x68];
    [FixedSizeArray<Utf8String>(15)]
    [FieldOffset(0x9B8)] private fixed byte SkippedMacroLines[15 * 0x68];
    [FieldOffset(0xFD0)] private uint ShellChannel;

    [FieldOffset(0x1200)] public uint Flags;

    public bool IsTextCommandUnavailable => (Flags & 1) != 0;

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8D 4D 28")]
    public partial void ExecuteMacro(RaptureMacroModule.Macro* macro);

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 0F 84 ?? ?? ?? ?? 48 8B 4C 24 ?? 48 B8")]
    public partial bool TryGetMacroIconCommand(RaptureMacroModule.Macro* macro, void* resultsOut);

    [MemberFunction("E8 ?? ?? ?? ?? 0F B7 44 37 ??")]
    public partial void ChangeChatChannel(int channel, uint linkshellIndex, Utf8String* target, byte unknown); // target can be empty string, unknown = 1

    [MemberFunction("E8 ?? ?? ?? ?? 4C 8B 7C 24 ?? EB 34")]
    public partial byte SetContextTellTarget(Utf8String* playerName, Utf8String* worldName, ushort worldId, ulong contentId, ushort reason, byte unknown);

    [MemberFunction("E8 ?? ?? ?? ?? EB 8A 48 8B 1D")]
    public partial void SetContextTellTargetInForay(Utf8String* playerName, Utf8String* worldName, ushort worldId, ulong contentId, ushort unknown);

    [MemberFunction("48 89 5C 24 ?? 55 56 57 48 81 EC ?? ?? ?? ?? 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 84 24 ?? ?? ?? ?? 48 8B 02")]
    public partial bool SetTellTargetInForay(Utf8String* playerName, Utf8String* worldName, ushort worldId, ulong contentId, ushort unknown1, byte unknown2); // unknown2 = 0

    [MemberFunction("48 89 5C 24 ?? 57 48 83 EC 30 8B B9 ?? ?? ?? ?? 48 8B D9 83 FF FE")]
    public partial void ReplyInSelectedChatMode();
}
