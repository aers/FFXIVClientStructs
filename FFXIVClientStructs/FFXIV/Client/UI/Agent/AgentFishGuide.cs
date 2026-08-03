namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentFishGuide
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.FishGuide)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x1A8)]
public unsafe partial struct AgentFishGuide {
    [FieldOffset(0x28)] public uint SelectedItemId;
    [FieldOffset(0x2C), FixedSizeArray] internal FixedSizeArray2<TabSelection> _tabSelections; // index w/ IsSpearfishing
    [FieldOffset(0x30)] private byte Unk30;
    [FieldOffset(0x31)] public bool IsSpearfishing;
    [FieldOffset(0x32)] public bool IsSpearfishingUnlocked; // checks quest 2922

    [FieldOffset(0x40)] private uint Unk40; // some addonid

    [FieldOffset(0x48)] public FishGuideData* Data;

    // some filter stuff
    [FieldOffset(0x50)] private ushort Unk50;
    [FieldOffset(0x52)] private ushort Unk52;
    [FieldOffset(0x54)] private byte Unk54;
    [FieldOffset(0x55)] private byte Unk55;
    [FieldOffset(0x56)] private byte Unk56;

    [FieldOffset(0x60)] private nint Unk60;
    [FieldOffset(0x68)] private nint Unk68;

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 44 0F B6 C3 33 D2")]
    public partial void OpenForItemId(uint itemId, bool isSpearfishing);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B CB E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8B 4B 48")]
    public partial void UpdateFishList(); // sets entries to NumberArray #67 and then refreshes the icons

    [StructLayout(LayoutKind.Explicit, Size = 0x02)]
    public struct TabSelection {
        [FieldOffset(0x00)] public byte PageIndex;
        [FieldOffset(0x01)] public sbyte SelectedIndex;
    }

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x5A0)]
    public unsafe partial struct FishGuideData {
        [FieldOffset(0x08)] public AgentFishGuide* Agent;
        [FieldOffset(0x10)] public StdVector<FishGuideListEntry> Entries;
        [FieldOffset(0x28)] public StdVector<Pointer<FishGuideListEntry>> EntryPointers;
        [FieldOffset(0x40), FixedSizeArray] internal FixedSizeArray100<int> _pageIcons;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x14)]
    public struct FishGuideListEntry {
        [FieldOffset(0x00)] public uint ItemId;
        [FieldOffset(0x04)] public ushort FishParameterId;
        [FieldOffset(0x06)] private ushort Unk6;
        [FieldOffset(0x08)] public ushort GatheringSubCategoryId;
        [FieldOffset(0x0A)] private ushort UnkA;
        [FieldOffset(0x0E)] public bool IsCaught;
        [FieldOffset(0x10)] public bool HasItem;
        [FieldOffset(0x11)] private bool Unk11;
    }
}
