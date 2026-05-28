using FFXIVClientStructs.FFXIV.Client.Game;
using FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;
using FFXIVClientStructs.FFXIV.Client.UI.Misc;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentTryon
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
// ctor "48 89 5C 24 ?? 57 48 83 EC 20 48 8B F9 E8 ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 8D 4F 28 48 89 07 E8 ?? ?? ?? ?? 48 C7 87"
[Agent(AgentId.Tryon)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x6E0)]
[VirtualTable("48 8D 05 ?? ?? ?? ?? 48 8D 4F 28 48 89 07 E8 ?? ?? ?? ?? 48 C7 87", 3)]
public unsafe partial struct AgentTryon {
    [FieldOffset(0x28)] public TryonCharaView CharaView;
    [FieldOffset(0x350)] public Texture* Texture;
    [FieldOffset(0x358)] public uint OpenerAddonId;
    [FieldOffset(0x35C)] public uint YesNoAddonId;
    [FieldOffset(0x360)] public uint TryonGlassesSelectAddonId;
    [FieldOffset(0x364)] public bool TryOnItemsChanged;
    [FieldOffset(0x365)] public bool GearItemsChanged;
    [FieldOffset(0x366)] public bool SaveDeleteOutfit;
    [FieldOffset(0x367)] public bool DisplayGear;
    [FieldOffset(0x368)] private bool Unk368;
    [FieldOffset(0x369)] private bool Unk369;
    // 2 bytes gap
    [FieldOffset(0x36C)] public InventoryType EquippedItemsInventoryType;
    [FieldOffset(0x36C), Obsolete("Renamed to EquippedItemsInventoryType")] public InventoryType ItemLevelInventoryType;
    [FieldOffset(0x370), FixedSizeArray] internal FixedSizeArray14<TryOnItem> _tryOnItems; // contains items that are tried on, including the ones for the "Save/Delete Outfit" toggle
    [FieldOffset(0x4F8), FixedSizeArray] internal FixedSizeArray14<TryOnItem> _gearItems; // contains items for the "Display Gear" toggle

    [FieldOffset(0x688)] public TryOnItem* ContextMenuItem;
    [FieldOffset(0x690)] public InventoryItem ColorantInventoryItem;
    [FieldOffset(0x6D8)] public uint RetainerObjectId;

    /// <remarks> Opener AddonId can be left as 0. </remarks>
    [MemberFunction("E8 ?? ?? ?? ?? EB 5B 48 8B 49 10")]
    public static partial bool TryOn(uint openerAddonId, uint itemId, byte stain0Id = 0, byte stain1Id = 0, uint glamourItemId = 0, bool applyCompanyCrest = false);

    // Client::UI::Agent::AgentTryon::TryonCharaView
    //   Client::UI::Misc::CharaView
    [GenerateInterop]
    [Inherits<CharaView>]
    [StructLayout(LayoutKind.Explicit, Size = 0x328)]
    public partial struct TryonCharaView {
        [FieldOffset(0x318)] public bool DoUpdate; // beware: fetches data from agent too, happens in vf10
        [FieldOffset(0x319)] public bool HideOtherEquipment;
        [FieldOffset(0x31A)] public bool HideVisor;
        [FieldOffset(0x31B)] public bool HideWeapon;
        [FieldOffset(0x31C)] public bool CloseVisor;
        [FieldOffset(0x31D)] public bool HideVieraEars;
        [FieldOffset(0x31E)] public bool DrawWeapon;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x1C)]
    public struct TryOnItem {
        [FieldOffset(0x00)] public byte EquipSlotCategory;
        [FieldOffset(0x01)] public byte GlamourEquipSlotCategory;
        [FieldOffset(0x02)] public byte Stain0Id;
        [FieldOffset(0x03)] public byte Stain1Id;
        [FieldOffset(0x04)] public byte GlamourStain0Id;
        [FieldOffset(0x05)] public byte GlamourStain1Id;
        [FieldOffset(0x06)] public byte ClassJobId;
        [FieldOffset(0x07)] public bool ApplyCompanyCrest;
        [FieldOffset(0x08)] public bool HasStain0;
        [FieldOffset(0x09)] public bool HasStain1;
        [FieldOffset(0x0A)] public bool IsDyePreviewEnabled;
        [FieldOffset(0x0B)] public byte IsItemStainConditionLocked;
        /// <remarks> RowId of Item or Glasses sheets, depending on EquipSlotCategory </remarks>
        [FieldOffset(0x0C)] public uint Id;
        [FieldOffset(0x10)] public uint GlamourId;
        [FieldOffset(0x14)] public uint IconId;
        [FieldOffset(0x18)] private uint UnkEquipSlotCategoryFlags;
    }
}
