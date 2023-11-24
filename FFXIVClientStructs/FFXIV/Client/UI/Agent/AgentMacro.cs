using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Client.UI.Misc;
using FFXIVClientStructs.FFXIV.Component.Excel;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.Macro)]
[StructLayout(LayoutKind.Explicit, Size = 0xEB18)]
public unsafe partial struct AgentMacro {
    [FieldOffset(0x00)] public AgentInterface AgentInterface;
    [FieldOffset(0x28)] public RaptureMacroModule.Macro ClipboardMacro;
    [FieldOffset(0x6B0)] public ExcelSheet* TextCommandParamSheet;

    /// <summary>
    /// The currently selected macro set.
    /// </summary>
    [FieldOffset(0x6B8)] public uint SelectedMacroSet;

    /// <summary>
    /// The index of the current selected macro. Must be between 0-99.
    /// </summary>
    [FieldOffset(0x6BC)] public uint SelectedMacroIndex;

    [FieldOffset(0x6C0)] public Utf8String RawMacroString;
    [FieldOffset(0x728)] public Utf8String ParsedMacroString;
    [FieldOffset(0x790)] public int MacroIconCount;
    [FieldOffset(0x794)] public fixed uint MacroIconArray[250];
    [FieldOffset(0xB7C)] public uint IconListAddonId;

    [FieldOffset(0xB84)] public uint TextCommandListAddonId;

    [FieldOffset(0xBD0)] public StdVector<TextCommandEntry> TextCommands;
    [FieldOffset(0xBE8)] public int FocusedTextCommandIndex;

    [FixedSizeArray<MacroHistoryEvent>(17)]
    [FieldOffset(0xBF0)] public fixed byte ChangeHistory[17 * 0xD20];
    [FieldOffset(0xEB10)] public int CurrentHistoryIndex;

    /// <summary>
    /// Open the Macro UI, focused on the given macro set and index.
    /// </summary>
    /// <remarks>
    /// If the edtior is already open it will stay open and only change focus.
    /// <br/>
    /// This is the same behaviour as right-clicking on a Macro in the hotbar and selecting "Edit Macro".
    /// </remarks>
    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8B 49 ?? 0F B7 9E")]
    public partial void OpenMacro(uint macroSet, uint macroIndex);

    [StructLayout(LayoutKind.Explicit, Size = 0xD20)]
    public struct MacroHistoryEvent {
        [FieldOffset(0x00)] public RaptureMacroModule.Macro OldMacro;
        [FieldOffset(0x688)] public RaptureMacroModule.Macro NewMacro;
        [FieldOffset(0xD10)] public uint EventKind;
        [FieldOffset(0xD14)] public uint Set;
        [FieldOffset(0xD18)] public uint Index;
        [FieldOffset(0xD1C)] public bool IsValid;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x70)]
    public struct TextCommandEntry {
        [FieldOffset(0x00)] public Utf8String Command;
        [FieldOffset(0x68)] public ushort TextCommandId;
    }
}
