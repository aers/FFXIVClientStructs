using FFXIVClientStructs.FFXIV.Client.Game;
using FFXIVClientStructs.FFXIV.Client.System.String;
using static FFXIVClientStructs.FFXIV.Common.Configuration.ConfigBase;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentItemSearch
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
//   Common::Configuration::ConfigBase::ChangeEventInterface
[Agent(AgentId.ItemSearch)]
[GenerateInterop]
[Inherits<AgentInterface>, Inherits<ChangeEventInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x3880)]
public unsafe partial struct AgentItemSearch {
    [FieldOffset(0x98)] public StringHolder* StringData;
    // [FieldOffset(0xA2C), FixedSizeArray] internal FixedSizeArray100<uint> _unkUints;
    [FieldOffset(0xA29)] public bool ListingPageLoaded;
    [FieldOffset(0xBBC), FixedSizeArray] internal FixedSizeArray100<uint> _listingPageItemIds;
    [FieldOffset(0xD50)] public uint ListingPageItemCount;
    [FieldOffset(0xD58), FixedSizeArray] internal FixedSizeArray100<ListingItem> _listingPageItems;
    [FieldOffset(0x3120)] public byte ListingCurrentPage;
    [FieldOffset(0x3121)] public byte ListingPageCount;
    [FieldOffset(0x3384)] public uint ResultItemId;
    [FieldOffset(0x338C)] public uint ResultSelectedIndex;
    [FieldOffset(0x3398)] public InventoryItem ResultHoveredItem;
    // [FieldOffset(0x3858)] public uint* ItemBuffer;
    // [FieldOffset(0x3860)] public uint ItemCount;
    [FieldOffset(0x3871)] public bool IsPartialSearching;
    // [FieldOffset(0x386D)] public bool IsItemPushPending;

    [StructLayout(LayoutKind.Explicit, Size = 0x98)]
    public struct StringHolder {
        // [FieldOffset(0x10)] public int Unk90Size;
        [FieldOffset(0x28)] public Utf8String SearchParam;
        // [FieldOffset(0x90)] public nint Unk90Ptr;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public struct ListingItem {
        [FieldOffset(0x08)] public uint ItemId;

        [FieldOffset(0x18)] public ushort Index;
        [FieldOffset(0x1A)] public ushort OfferCount;
        [FieldOffset(0x1C)] public ushort Demand;
    }
}
