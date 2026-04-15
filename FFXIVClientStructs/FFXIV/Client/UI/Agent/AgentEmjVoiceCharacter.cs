using FFXIVClientStructs.FFXIV.Client.Sound;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentEmjVoiceCharacter
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.EmjVoiceCharacter)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x90)]
public unsafe partial struct AgentEmjVoiceCharacter {
    [FieldOffset(0x28)] private byte Unk28;
    [FieldOffset(0x29)] private byte Unk29;
    [FieldOffset(0x2A)] private byte Unk2A;
    [FieldOffset(0x2B)] private byte Unk2B;
    /// <summary>
    /// If EmjCharacter has extra costumes to use
    /// </summary>
    [FieldOffset(0x2C)] public uint AttireAddon;
    [FieldOffset(0x30)] private uint Unk30;
    [FieldOffset(0x34)] private uint Unk34;
    [FieldOffset(0x38)] public SoundData* VoLine;
    [FieldOffset(0x40)] public uint CurrentCharacterPage;
    [FieldOffset(0x44)] public uint CharacterPages;
    [FieldOffset(0x48)] public uint HighlightedEmjVoiceNpc;
    [FieldOffset(0x4C)] public uint SelectedEmjVoiceNpc;
    /// <summary>
    /// Id mappes to subrow id of EmjCostume
    /// </summary>
    [FieldOffset(0x50)] public uint SelectedAttire;
    [FieldOffset(0x54)] private uint Unk54;
    /// <summary>
    /// Ids mappes to subrow id of EmjCostume
    /// </summary>
    [FieldOffset(0x58)] public StdVector<uint> SelectedAttires;
    [FieldOffset(0x70)] public StdVector<EmjCostume> SelectedCostumeRows;

    /// <summary>
    /// This is a full copy of the Exd structure for EmjCostume
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public struct EmjCostume {
        [FieldOffset(0x0)] public float Scale;
        [FieldOffset(0x4)] public float OffsetX;
        [FieldOffset(0x8)] public float OffsetY;
        [FieldOffset(0xC)] public uint Image;
        [FieldOffset(0x10)] public uint UnlockQuest;
        [FieldOffset(0x14)] public ushort Data;
        [FieldOffset(0x16)] public byte Sort;
    }
}
