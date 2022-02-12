using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Client.UI.Misc;

namespace FFXIVClientStructs.FFXIV.Client.UI.Shell;

// Client::UI::Shell::RaptureShellModule
// ctor E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 4C 8B CF
[StructLayout(LayoutKind.Explicit, Size = 0x1208)]
public unsafe partial struct RaptureShellModule
{
    [FieldOffset(0x2C0)] public int MacroCurrentLine;
    [FieldOffset(0x2B3)] public bool MacroLocked;

    public static RaptureShellModule* Instance => Framework.Instance()->GetUiModule()->GetRaptureShellModule();

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8D 4D 28")]
    public partial void ExecuteMacro(RaptureMacroModule.Macro* macro);
}