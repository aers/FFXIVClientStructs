using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;
using FFXIVClientStructs.FFXIV.Common.Component.Excel;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentXBMPetParty
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.XBMPetParty)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x158)]
public unsafe partial struct AgentXBMPetParty {
    [FieldOffset(0x28)] public ExcelSheet* PetParamGrowSheet; // XBMPetParamGrow
    [FieldOffset(0x30)] public ExcelSheetWaiter* PetParamGrowSheetWaiter;
    [FieldOffset(0x38)] public uint PetParamGrowLoadState; // 0 = not requested, 1 = loading, 2 = all main rows read
    [FieldOffset(0x3C)] public uint PetParamGrowRowId; // main row that is currently read, 0 to 50
    [FieldOffset(0x40)] public StdVector<XBMPetParamGrowValues> PetParamGrowValues;

    [FieldOffset(0x58)] public bool RequestRefresh;
    [FieldOffset(0x59)] public bool RequestSecondaryRefresh;
    [FieldOffset(0x5A)] public bool RequestPetListRefresh;
    [FieldOffset(0x5C)] private uint Unk5C; // addon id closed in Hide, never written by this agent
    [FieldOffset(0x60)] public uint PetListAddonId;
    [FieldOffset(0x64)] public uint Mode; // 0 = pet list, 1 = party preview, 2 = party preview from content, 3 = buy feed, 4 = buy feed result, 5 = feed detail
    [FieldOffset(0x68)] public uint SubMode; // 0 for modes 3 and 4, 1 otherwise
    [FieldOffset(0x6C)] public bool UsesContentPetData; // read from the XBM event handler
    [FieldOffset(0x6D)] private bool Unk6D;
    [FieldOffset(0x6E)] public byte StatIndex; // XBMPetParamGrow column, 6 = remaining points
    [FieldOffset(0x70)] public uint ContentId; // XBMContent row
    [FieldOffset(0x74)] private bool Unk74; // recomputes and pushes the pet data in Update when set

    [FieldOffset(0x78)] public StdVector<XBMPetPartyEntry> SelectedPets;
    [FieldOffset(0x90)] public StdVector<XBMPetPartyEntry> SelectedPetIds;
    [FieldOffset(0xA8)] public StdVector<XBMPetPartyEntry> CandidatePets;

    [FieldOffset(0xC0), FixedSizeArray] internal FixedSizeArray15<uint> _petCurrentHealth;
    [FieldOffset(0xFC), FixedSizeArray] internal FixedSizeArray15<uint> _petMaxHealth;

    [FieldOffset(0x138)] private uint Unk138; // value passed by SetMode(3)
    [FieldOffset(0x13C)] private uint Unk13C; // value passed by SetMode(5)
    [FieldOffset(0x140)] public uint SelectedPetIndex;
    [FieldOffset(0x148)] public SoundResourceHandle* BuyFeedSoundEffect; // "sound/battle/etc/SE_Bt_Etc_XBM_03_BuyFeed.scd"
    [FieldOffset(0x150)] private bool Unk150;
    [FieldOffset(0x154)] public uint PetListSource; // 0 = CandidatePets, 1 = SelectedPetIds, 2 = pets unlocked in XBMNoteModule

    [MemberFunction("48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 57 B8 90 4A 00 00 E8 ?? ?? ?? ?? 48 2B E0 48 8B 05")]
    public partial void SetMode(uint mode, int* param);

    [MemberFunction("40 56 57 48 83 EC ?? 83 79 ?? ?? 8B F2")]
    public partial void TogglePet(uint petId);

    [MemberFunction("40 53 55 57 48 83 EC ?? 83 79")]
    public partial void OpenPetListAddon(int source);

    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 E8 84 C0 74 ?? 48 8B CB E8 ?? ?? ?? ?? 4C 8D 9C 24")]
    public partial bool ConfirmSelection(AtkValue* value);

    [MemberFunction("40 53 48 83 EC ?? 83 79 ?? ?? 48 8D 51 ?? 48 8B D9 76 ?? E8 ?? ?? ?? ?? C7 83")]
    public partial void ClosePetListAddon();

    [MemberFunction("E8 ?? ?? ?? ?? 33 C9 44 8B E9")]
    public partial uint GetSyncedRank(uint petId);

    [MemberFunction("48 89 5C 24 ?? 48 89 74 24 ?? 57 48 83 EC ?? 8D 42 ?? 8B FA 48 8B D9 83 F8 ?? 0F 87")]
    public partial bool IsPetOverSyncedRank(uint petId);

    [MemberFunction("48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 57 48 83 EC ?? 8B 41 ?? 48 8B F1 FF C8")]
    public partial bool HasUnlockedPets();

    [MemberFunction("E8 ?? ?? ?? ?? 89 43 ?? 48 83 C3 ?? 48 3B DF 75 ?? 48 8B 5D")]
    public partial uint GetPetHealth(uint petId, byte index);

    [MemberFunction("48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 57 48 83 EC ?? 48 8B 59 ?? 0F B6 EA")]
    public partial void UpdatePetsHealth(byte index);

    [MemberFunction("48 89 5C 24 ?? 48 89 74 24 ?? 57 48 83 EC ?? 8B 41 ?? 48 8B F9")]
    public partial bool IsPetAvailable(uint petId);

    [MemberFunction("48 83 EC ?? 83 79 ?? ?? 75 ?? 8B 49")]
    public partial uint GetTeamSize();

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B CB E8 ?? ?? ?? ?? 33 FF 89 7B")]
    public partial void ApplyPetSelection();
}

[StructLayout(LayoutKind.Explicit, Size = 0x1C)]
public struct XBMPetParamGrowValues {
    [FieldOffset(0x00)] public uint ParamGrowId;
    [FieldOffset(0x04)] public uint Rank; // subrow id, XBMPet.ParamGrow subrow is Rank - 1
    [FieldOffset(0x08)] public uint Strength;
    [FieldOffset(0x0C)] public uint PhysicalResistance;
    [FieldOffset(0x10)] public uint Constitution;
    [FieldOffset(0x14)] public uint Intelligence;
    [FieldOffset(0x18)] public uint MagicalResistance;
}

[StructLayout(LayoutKind.Explicit, Size = 0x8)]
public struct XBMPetPartyEntry {
    [FieldOffset(0x00)] public uint PetId; // XBMPet row
    [FieldOffset(0x04)] public uint SortKey;
}
