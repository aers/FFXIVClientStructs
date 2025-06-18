using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Client.UI;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

[GenerateInterop]
[Inherits<AtkEventListener>]
[StructLayout(LayoutKind.Explicit, Size = 0xC8)]
public unsafe partial struct AtkDragDropManager {
    [FieldOffset(0x08)] public AtkDragDropPayloadContainer PayloadContainer;
    [FieldOffset(0x90)] public AtkStage* AtkStage;
    //the first 2 seem to point to some subclass of DragDrop, maybe some temp thing
    [FieldOffset(0x98)] public AtkDragDropInterface* DragDrop1;
    // vvv Not set in some cases where DragDropS isn't used (like with hotbars)
    [FieldOffset(0xA0)] public AtkDragDropInterface* DragDrop2;
    [FieldOffset(0xA8)] public AtkComponentDragDrop* DragDropS;
    // ^^^
    [FieldOffset(0xB0)] public delegate* unmanaged<DragDropType, ulong> DragDropTypeMaskGetter;
    [FieldOffset(0xB8)] public short DragStartX;
    [FieldOffset(0xBA)] public short DragStartY;
    [FieldOffset(0xBC)] public bool IsDragging;
    // True if the item was clicked on (user must click again to drop it somewhere)
    [FieldOffset(0xBD)] public bool ReclickToDrop;
    // Set to true once the mouse moves during a drag
    [FieldOffset(0xBE)] public bool MouseMoved;
    // False if dropping on anything not ui (like the world)
    // Can't be false if ReclickToDrop is false
    [FieldOffset(0xBF)] public bool IsNotDiscarding;

    /// <remarks> Check if not <see cref="IsDragging"/> before calling. </remarks>
    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 24 06")]
    public partial void StartDragDrop(AtkDragDropInterface* dragDropInterface, short dragStartX, short dragStartY);

    [MemberFunction("E8 ?? ?? ?? ?? EB 48 48 8B 03")]
    public partial void Drop(AtkEventData.AtkDragDropData* data, AtkComponentNode* componentNode, DragDropType acceptedType, bool canNotAccept);

    [MemberFunction("80 B9 ?? ?? ?? ?? ?? 45 0F B6 D0")]
    public partial void CancelDragDrop(bool allowSoundEffect = true, bool suppressFlyBack = false);

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 4C 8D 46 06")]
    public partial void EndDragDrop(bool flyBack, bool playSoundEffect, int soundEffectId);
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x88)]
public unsafe partial struct AtkDragDropPayloadContainer {
    // usage depends on implementation
    [FieldOffset(0x00)] public int Int1; // Index (like AtkDragDropInterface.ReferenceIndex), InventoryType, etc.
    [FieldOffset(0x04)] public int Int2; // ActionId, ItemId, EmoteId, InventorySlotIndex, ListIndex, MacroIndex etc.
    [FieldOffset(0x08)] public ulong Unk8;
    [FieldOffset(0x10)] public AtkValue* AtkValue;
    [FieldOffset(0x18)] public Utf8String Text; // MacroName, ...?
    [FieldOffset(0x80)] public uint Flags;

    [MemberFunction("E8 ?? ?? ?? ?? 49 63 FD")]
    public partial void Clear();
}

/// <remarks>
/// This enum mixes values for what is being dragged and what <see cref="AtkComponentDragDrop"/> can accept as drop.<br/>
/// The game uses bitmasks to check whether the dragged payload is accepted by the component it's dragged on to.<br/>
/// You can use the extension method <see cref="DragDropTypeExtension.Accepts"/> if you want to check the dragged type against what you want to accept.
/// </remarks>
public enum DragDropType : uint {
    Nothing = 1,
    Everything = 2,
    ActionBar = 3, // ActionBar_Macro to ActionBar_Glasses, and Unknown81
    Unknown4 = 4,
    Item = 5,
    Macro = 6,
    Action = 7,
    Emote = 8,
    Unknown9 = 9,
    EventItem = 10,
    Marker = 11,
    CraftingAction = 12,
    GeneralAction = 13,
    Unknown14 = 14,
    Crystal = 15,
    Unknown16 = 16, // LinkedItem?
    Unknown17 = 17, // LinkedEventItem?
    Unknown18 = 18,
    BuddyAction = 19,
    MainCommand = 20,
    GearSet = 21,
    Companion = 22,
    PetAction = 23,
    Mount = 24,
    Unknown25 = 25,
    FieldMarker = 26,
    Recipe = 27,
    Unknown28 = 28,
    Unknown29 = 29,
    Unknown30 = 30,
    ExtraCommand = 31,
    QuickChat = 32,
    ActionComboRoute = 33,
    BgcArmyAction = 34,
    Unknown35 = 35,
    Perform = 36,
    Unknown37 = 37, // EurekaLogosShardSynthesis
    Unknown38 = 38, // AOZNotebook
    Unknown39 = 39,
    Ornament = 40,
    MYCTemporaryItem = 41,
    Glasses = 42,
    EquipmentSlot = 43, // used as AcceptedType in Character, ArmouryBoard. presumably slot-filtered
    Unknown44 = 44,
    ActionBar_Macro = 45,
    ActionBar_Action = 46,
    ActionBar_Emote = 47,
    ActionBar_Item = 48,
    Unknown49 = 49,
    ActionBar_EventItem = 50,
    Unknown51 = 51,
    Unknown52 = 52,
    ActionBar_Marker = 53,
    ActionBar_CraftingAction = 54,
    ActionBar_GeneralAction = 55,
    ActionBar_BuddyAction = 56,
    ActionBar_MainCommand = 57,
    ActionBar_Companion = 58,
    ActionBar_GearSet = 59,
    ActionBar_PetAction = 60,
    ActionBar_Mount = 61,
    ActionBar_FieldMarker = 62,
    ActionBar_Recipe = 63,
    Unknown64 = 64,
    Unknown65 = 65,
    Unknown66 = 66,
    ActionBar_ExtraCommand = 67,
    ActionBar_QuickChat = 68,
    Unknown69 = 69,
    ActionBar_BgcArmyAction = 70,
    Unknown71 = 71,
    ActionBar_Perform = 72,
    ActionBar_McGuffin = 73,
    ActionBar_Ornament = 74,
    ActionBar_MYCTemporaryItem = 75,
    ActionBar_Glasses = 76,
    Unknown77 = 77,
    Unknown78 = 78,
    AOZNotebook_Action = 79,
    Unknown80 = 80,
    Macro_Text = 81, // used as AcceptedType. you can drag items, spells etc. onto the text box and it will insert the name, or the /-command for emotes and markers
    Unknown82 = 82,
    Inventory_Item = 83, // used as AcceptedType
    Inventory_Crystal = 84, // used as AcceptedType
    RemoteInventory_Item = 85, // used as AcceptedType. Retainer, InventoryBuddy
    Unknown86 = 86,
    Unknown87 = 87,
    LetterEditor_Item = 88 // used as AcceptedType. also the end of this enum
}

/* potentially missing for ActionBar:
    - BuddyOrder
    - Trait
    - CompanyAction
    - ChocoboRaceAction
    - ChocoboRaceItem
    - DeepDungeonEquipment
    - DeepDungeonEquipment2
    - DeepDungeonItem
    - ActionComboRoute
    - PvPSelectTrait
    - DeepDungeonMagicStone
    - DeepDungeonDemiclone
    - EurekaMagiaAction
*/

public static class DragDropTypeExtension {
    /// <summary>
    /// Determines whether <paramref name="type1"/> accepts <paramref name="type2"/> based on their drag-and-drop type masks.
    /// </summary>
    /// <returns><see langword="true"/> if the masks are compatible; otherwise, <see langword="false"/>.</returns>
    public static bool Accepts(this DragDropType type1, DragDropType type2)
        => (UIGlobals.GetDragDropTypeMask(type1) & UIGlobals.GetDragDropTypeMask(type2)) != 0;
}
