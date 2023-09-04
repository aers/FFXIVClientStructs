using FFXIVClientStructs.FFXIV.Client.UI.Misc;

namespace FFXIVClientStructs.FFXIV.Client.UI.Shell;

// Client::UI::Shell::RaptureShellModule
// ctor "E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 4C 8B CF"
[StructLayout(LayoutKind.Explicit, Size = 0x1208)]
public unsafe partial struct RaptureShellModule {
    public static RaptureShellModule* Instance() => UIModule.Instance()->GetRaptureShellModule();

    [FieldOffset(0x2C0)] public int MacroCurrentLine;
    [FieldOffset(0x2B3)] public bool MacroLocked;

    [FieldOffset(0x1200)] public uint Flags;

    public bool IsTextCommandUnavailable => (Flags & 1) != 0;

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8D 4D 28")]
    public partial void ExecuteMacro(RaptureMacroModule.Macro* macro);

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 0F 84 ?? ?? ?? ?? 48 8B 4C 24 ?? 48 B8")]
    public partial bool TryGetMacroIconCommand(RaptureMacroModule.Macro* macro, void* resultsOut);
}
