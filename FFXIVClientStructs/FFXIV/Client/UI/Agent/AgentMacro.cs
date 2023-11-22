using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.Macro)]
[StructLayout(LayoutKind.Explicit, Size = 0xEB18)]
public unsafe partial struct AgentMacro {
    [FieldOffset(0x0)]
    public AgentInterface AgentInterface;

    /// <summary>
    /// The currently selected macro set.
    /// </summary>
    [FieldOffset(0x6b8)]
    public MacroSet SelectedMacroSet;

    /// <summary>
    /// The index of the current selected macro. Must be between 0-99.
    /// </summary>
    [FieldOffset(0x6bc)]
    public uint SelectedMacroIndex;

    /// <summary>
    /// Open the Macro UI, focused on the given macro set and index.
    /// </summary>
    /// <remarks>
    /// If the edtior is already open it will stay open and only change focus.
    /// <br/>
    /// This is the same behaviour as right-clicking on a Macro in the hotbar and selecting "Edit Macro".
    /// </remarks>
    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8B 49 ?? 0F B7 9E")]
    public partial void OpenMacro(MacroSet macroSet, uint macroIndex);

    public enum MacroSet : uint {
        Individual = 0,
        Shared = 1
    }
}
