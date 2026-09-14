using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Common.Component.Excel;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentXBMMonsterNotebook
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.XBMMonsterNotebook)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x128)]
public unsafe partial struct AgentXBMMonsterNotebook {
    [FieldOffset(0x28)] public ExcelSheet* PetParamGrowSheet; // XBMPetParamGrow
    [FieldOffset(0x30)] public ExcelSheetWaiter* PetParamGrowSheetWaiter;
    [FieldOffset(0x38)] public uint PetParamGrowLoadState; // 0 = not requested, 1 = loading, 2 = all main rows read
    [FieldOffset(0x3C)] public uint PetParamGrowRowId; // currently read, 0 to 50
    [FieldOffset(0x40)] public StdVector<XBMPetParamGrowValues> PetParamGrowValues;

    [FieldOffset(0x58)] public uint Source; // 0 = opened from the notebook itself, 1 = opened from the pet party window
    [FieldOffset(0x5C)] private bool NewPetListReceived;
    [FieldOffset(0x5D)] private bool RequestPetListRebuild;
    [FieldOffset(0x5E)] private bool RequestNotebookRebuild; // XBMMonsterNotebook left panel
    [FieldOffset(0x5F)] private bool RequestNotebookDetailRebuild; // XBMMonsterNotebook right panel (XBMMonsterBookDetail)
    [FieldOffset(0x60)] private bool ActivePetAddonOpened;
    [FieldOffset(0x64)] public uint ActivePetAddonId; // AddonXBMActivePet
    [FieldOffset(0x68)] public uint FilterAddonId; // AddonXBMMonsterNotebookFilterSetting

    // Both bitfields are received in the same pet list packet as XBMManager.UnlockedPets.
    [FieldOffset(0x70), FixedSizeArray(isBitArray: true, bitCount: 50)] internal FixedSizeArray7<byte> _unlockedPets;
    [FieldOffset(0x77), FixedSizeArray(isBitArray: true, bitCount: 50)] internal FixedSizeArray7<byte> _mirageUnlockedPets;
    [FieldOffset(0x7E)] private ushort Unk7E;

    [FieldOffset(0x80)] public StdVector<XBMMonsterNotebookEntry> PetList; // 25 entries per page
    [FieldOffset(0x98)] public uint PageIndex;
    [FieldOffset(0x9C)] public uint SelectedPetId; // XBMPet row
    [FieldOffset(0xA0)] public uint HoveredPetId;
    [FieldOffset(0xA4)] public uint DetailPetId;
    [FieldOffset(0xA8)] public uint ContentId; // XBMContent row, set by AgentXBMPetParty
    [FieldOffset(0xAC)] public bool UsesContentPetData; // set by AgentXBMPetParty
    [FieldOffset(0xB0)] public Utf8String SearchText;

    [FieldOffset(0x118)] public uint ClassificationFilter; // XBMPet.Classification bitfield
    [FieldOffset(0x11C)] public uint AttackTypeFilter; // Action.AttackType and Action.Aspect bitfield
    [FieldOffset(0x120)] public uint StatusFilter; // XBMPet.InflictsStatus bitfield
    [FieldOffset(0x124)] private byte Unk124;
    [FieldOffset(0x125)] private byte Unk125;
    [FieldOffset(0x126)] private byte Unk126;

    [MemberFunction("48 83 EC ?? 0F 10 02 C6 41")]
    public partial void HandlePetListPacket(nint packet);

    /// <summary>Opens AddonXBMMonsterNotebook, reloading XBMPetParamGrow when <paramref name="source"/> is not 0.</summary>
    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? BA ?? ?? ?? ?? 48 89 BE")]
    public partial void OpenAddon(int source);

    [MemberFunction("48 89 5C 24 ?? 57 48 83 EC ?? 83 79 ?? ?? 48 8B D9 76 ?? 48 8D 51 ?? E8 ?? ?? ?? ?? C6 43")]
    public partial void ToggleActivePetAddon();

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 ?? 40 0F B6 D6 48 8B CF E8 ?? ?? ?? ?? 84 C0")]
    public partial bool IsPetUnlocked(uint petId);

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 0F 84 ?? ?? ?? ?? 40 0F B6 D7 48 8B CE")]
    public partial bool IsPetMirageUnlocked(uint petId);

    [MemberFunction("48 89 5C 24 ?? 48 89 74 24 ?? 57 48 83 EC ?? 48 8B F1 0F B6 DA 48 8B 49 ?? 48 8B 01")]
    public partial uint GetPetMirage(uint petId);

    [MemberFunction("E8 ?? ?? ?? ?? C6 43 ?? ?? 48 8B 03")]
    public partial void RebuildPetList();
}

[StructLayout(LayoutKind.Explicit, Size = 0x8)]
public struct XBMMonsterNotebookEntry {
    [FieldOffset(0x00)] public uint PetId; // XBMPet row
    [FieldOffset(0x04)] public uint SortKey;
}
