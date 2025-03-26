using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Client.UI.Misc;
using FFXIVClientStructs.FFXIV.Component.Text;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.Configkey)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x2220)]
public unsafe partial struct AgentConfigkey {
    [FieldOffset(0x40)] public ConfigModule* ConfigModule;
    [FieldOffset(0x78)] public UIInputData* UIInputData;

    [FieldOffset(0x84)] public int SelectedTab; // 1 - 7

    [FieldOffset(0x88)] public bool HasChanges;
    [FieldOffset(0x89)] public bool IsUserEditing;
    [FieldOffset(0x8B)] public bool DirectChatChecked1;
    [FieldOffset(0x8C)] public bool DirectChatChecked2;

    [FieldOffset(0xC0)] public TextChecker TextChecker;

    [FieldOffset(0x1B8)] public Utf8String LastFilledKeybind;
}
