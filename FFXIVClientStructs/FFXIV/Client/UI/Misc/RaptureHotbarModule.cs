using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

[StructLayout(LayoutKind.Explicit, Size = 0x27278)]
public unsafe partial struct RaptureHotbarModule
{
    [FieldOffset(0x48)] public UIModule* UiModule;
    [FieldOffset(0x90)] public HotBars HotBar;

    [FieldOffset(0x11974)] public SavedHotBars SavedClassJob;

    [MemberFunction("E9 ?? ?? ?? ?? 48 8D 91 ?? ?? ?? ?? E9")]
    public partial byte ExecuteSlot(HotBarSlot* hotbarSlot);

    [MemberFunction("83 FA 12 77 28 41 83 F8 10")]
    public partial byte ExecuteSlotById(uint hotbarId, uint slotId);

    /// <summary>
    /// Retrieve's a hotbar slot's designated appearance (the slot type and slot ID) that will be used for icon display
    /// purposes. This method will resolve adjusted action IDs as appropriate.
    /// </summary>
    /// <remarks>
    /// The result of this method call will generally be written to IconTypeB/IconB, which is then used to
    /// look up the exact icon ID to display on the hotbar. This method appears to be run every frame for every
    /// visible hotbar slot in the game.
    /// </remarks>
    /// <param name="actionType">A pointer to where the slot's appearance action type will be written to.</param>
    /// <param name="actionId">A pointer to where the slot's appearance action ID will be written to.</param>
    /// <param name="UNK_0xC4">A pointer to where the slot's +C4 offset will be written to.</param>
    /// <param name="hotbarModule">A reference to the RaptureHotbarModule of the game.</param>
    /// <param name="slot">A reference to the hotbar slot to calculate the appearance for.</param>
    /// <returns>Returns the same value present in the actionId param.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 54 24 ?? 8B 44 24 30")]
    public static partial uint GetSlotAppearance(HotbarSlotType* actionType, uint* actionId, ushort* UNK_0xC4,
        RaptureHotbarModule* hotbarModule, HotBarSlot* slot);
}

[StructLayout(LayoutKind.Sequential, Size = HotBar.Size * 18)]
public unsafe struct HotBars
{
    private fixed byte data[HotBar.Size * 18];

    public HotBar* this[int i]
    {
        get
        {
            if (i < 0 || i > 17) return null;
            fixed (byte* p = data)
            {
                return (HotBar*) (p + sizeof(HotBar) * i);
            }
        }
    }
}

[StructLayout(LayoutKind.Sequential, Size = Size)]
public struct HotBar
{
    public const int Size = HotBarSlot.Size * 16;

    public HotBarSlots Slot;
}

[StructLayout(LayoutKind.Sequential, Size = HotBarSlot.Size * 16)]
public unsafe struct HotBarSlots
{
    private fixed byte data[HotBarSlot.Size * 16];

    public HotBarSlot* this[int i]
    {
        get
        {
            if (i < 0 || i > 15) return null;
            fixed (byte* p = data)
            {
                return (HotBarSlot*) (p + sizeof(HotBarSlot) * i);
            }
        }
    }
}

[StructLayout(LayoutKind.Explicit, Size = Size)]
public unsafe partial struct HotBarSlot
{
    public const int Size = 0xE0;
    
    /// The string that appears when a hotbar slot is hovered over.
    ///
    /// Calculated by concatenating GetDisplayNameForSlot with PopUpKeybindHint (in most cases).
    [FieldOffset(0x00)] public Utf8String PopUpHelp;
    
    /// The "cost text" to display when 0xCB is in mode 2 or 4.
    ///
    /// This is generally filled with a flexible MP cost (e.g. "All" for certain BLM spells) or "x 123" for items.
    [FieldOffset(0x68)] public fixed byte CostText[0x20];
    
    /// A human-friendly display of the keybind used for this hotbar slot.
    ///
    /// This text will generally lead with a space and have wrapping brackets, e.g. " [Ctrl-3]".
    [FieldOffset(0x88)] public fixed byte PopUpKeybindHint[0x20];
    
    /// A less-friendly version of the keybind used for this hotbar slot.
    ///
    /// The actual use of this field is unknown, but it appears to be related to the hint in the top-left of the hotbar
    /// UI.
    [FieldOffset(0xA8)] public fixed byte KeybindHint[0x10];
    
    /// The ID of the action that will be executed when this slot is triggered. Action type is determined by the
    /// CommandType field.
    [FieldOffset(0xB8)] public uint CommandId;
    
    /// UNKNOWN. Appears to be the original action ID associated with this hotbar slot before adjustment.
    ///
    /// Note that this is *not* a reference to an icon ID; it must be combined with IconTypeA.
    [FieldOffset(0xBC)] public uint IconA;
    
    /// Appears to be the action ID that will be used to generate this hotbar slot icon.
    ///
    /// This field exists to allow a hotbar slot to have the appearance of one action, but in reality trigger a
    /// different action. For example, PvP combos will use this to track the "active" action.
    ///
    /// Note that this is *not* a reference to an icon directly.
    [FieldOffset(0xC0)] public uint IconB;
    
    /// Unknown field with offset 0xC4 (196), possibly overloaded
    ///
    /// Appears to have relation to the following:
    /// - Lost Finds Items appear to set this value to 1
    /// - In PVP actions, the high byte controls combo icon and the low byte counts which action the combo is on
    [FieldOffset(0xC4)] public ushort UNK_0xC4;
    
    // 0xC6 (198) does not appear to be referenced *anywhere*. Nothing ever reads or writes to it, save for a zero-out
    // operation. 
    
    /// The HotbarSlotType of the action that will be executed when this hotbar slot is triggered.
    [FieldOffset(0xC7)] public HotbarSlotType CommandType;
    
    /// UNKNOWN. Appears to be the original action type associated with this hotbar slot before adjustment/loading.
    [FieldOffset(0xC8)] public HotbarSlotType IconTypeA;
    
    /// Appears to be the HotbarSlotType used to determine the icon to display on this hotbar slot.
    ///
    /// See notes on IconB for more information as to how this field is used.
    [FieldOffset(0xC9)] public HotbarSlotType IconTypeB;
    
    /// Appears to be the "primary cost" of this action, mapping down to 0, 1, 2, 4, 5, 6, 7.
    ///
    /// Controls the color of the displayed cost when 0xCB is 1 or 2:
    /// - 0: White
    /// - 1: Green (HP)
    /// - 2: Light Pink (MP)
    /// - 3: Orange
    /// - 4: Pink (DoH - CP)
    /// - 5: Yellow (DoL - GP)
    /// - 6: Blue (Job Gauge?)
    /// - 7: Bright Yellow (Rival Wings - CE)
    /// - All others: Grey
    [FieldOffset(0xCA)] public byte UNK_0xCA;
    
    /// Appears to control display of the primary cost of the action (0xCA). 
    ///
    /// - 1: Displays action cost from 0xD0 in bottom left (e.g. for Actions or Craft Actions)
    /// - 2: Mode 1, but display a custom string from CostText instead (generally "All" on Actions with PrimaryCost = 4)
    /// - 3: Displays the value of 0xD0 in the bottom right (e.g. for Gearsets/UNK_0x17)
    /// - 4: Mode 3, but display a custom string from CostText instead (generally "x {count}" for Items)
    /// - 0/255: No display, all other cases
    [FieldOffset(0xCB)] public byte UNK_0xCB;
    
    /// The icon ID that is currently being displayed on this hotbar slot. 
    [FieldOffset(0xCC)] public int Icon;
    
    /// UNKNOWN. Appears to be the "cost" of an action.
    ///
    /// For items, this field holds the number of items of that type currently present in inventory.
    ///
    /// For actions that have some cost (MP, job bar, etc.), this appears to be the relevant value shown in the bottom
    /// left of the action.
    [FieldOffset(0xD0)] public uint UNK_0xD0;
    
    /// UNKNOWN. Appears to be Recipe specific. References the resulting Item ID of the recipe on the hotbar slot.
    [FieldOffset(0xD4)] public uint UNK_0xD4;
    
    /// UNKNOWN. Appears to be Recipe specific. References the CraftType for the recipe on the hotbar slot
    [FieldOffset(0xD8)] public uint UNK_0xD8;
    
    /// UNKNOWN. Appears to be Recipe specific to check if a recipe is valid.
    ///
    /// Set to 1 when the recipe results in a nonzero number of items (???).
    ///
    /// If 0, the tooltip for this slot will display message noting the recipe is deleted.
    /// If 1, the tooltip for this slot will display the name and crafting class for that recipe.
    [FieldOffset(0xDC)] public byte UNK_0xDC;
    
    /// UNKNOWN. Appears to be Recipe specific.
    ///
    /// Always set to 1, apparently? 
    [FieldOffset(0xDD)] public byte UNK_0xDD;
    
    /// UNKNOWN. Appears to control UI display mode (icon and displayed name) in some way
    ///
    /// Known values so far:
    /// - 2: Appears to be set for adjusted actions (e.g. upgraded spells/weaponskills)
    /// - 3: Appears to mark a PVP combo action
    /// - 4: Set on Squadron Order - Disengage, maybe others
    /// - 5: Set for Lost Finds Items (?)
    /// - 0/255: "generic"
    [FieldOffset(0xDE)] public byte UNK_0xDE;
    
    /// <summary>
    /// A "boolean" representing if this specific hotbar slot has been fully loaded. False for empty slots and slots
    /// that have yet to be loaded in the UI.
    /// </summary>
    /// <remarks>
    /// This appears to initialize as 0 and is set to 1 when the hotbar slot appears on a visible hotbar. It will not
    /// reset if the slot is hidden (and subsequently outdated).
    /// </remarks>
    [FieldOffset(0xDF)] public byte IsLoaded; // ?

    /// <summary>
    /// Check if this hotbar slot is considered "empty" or not.
    /// </summary>
    /// <remarks>
    /// Borrows game logic of checking for a non-zero command ID. Kept as a byte for API compatibility though this
    /// probably should be a bool instead.
    /// </remarks>
    public byte IsEmpty => Convert.ToByte(this.CommandId == 0);

    [MemberFunction("E8 ?? ?? ?? ?? 4C 39 6F 08")]
    public partial void Set(UIModule* uiModule, HotbarSlotType type, uint id);

    public void Set(HotbarSlotType type, uint id)
    {
        Set(Framework.Instance()->UIModule, type, id);
    }
    
    /// <summary>
    /// Populates HotBarSlot.Icon with information from IconB/IconTypeB. 
    /// </summary>
    /// <returns>Returns true if no icon was loaded (??)</returns>
    [MemberFunction("40 53 48 83 EC 20 44 8B 81 ?? ?? ?? ?? 48 8B D9 0F B6 91 ?? ?? ?? ?? E8 ?? ?? ?? ?? 85 C0")]
    public partial bool LoadIconFromSlotB();

    /// <summary>
    /// Get an icon ID for a hotbar slot, with specified appearance slot type and action ID.
    ///
    /// This method appears to exist to allow certain action types (specifically macros it seems?) to have a different
    /// appearance than the actual CommandType/CommandId called by this hotbar slot.
    /// </summary>
    /// <param name="slotType">The appearance slot type to use. Virtually almost always IconTypeB.</param>
    /// <param name="actionId">The appearance action ID to use. Virtually almost always IconB.</param>
    /// <returns>Returns an int of the icon that should be used for this hotbar slot.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 85 C0 89 83 ?? ?? ?? ?? 0F 94 C0")]
    public partial int GetIconIdForSlot(HotbarSlotType slotType, uint actionId);

    /// <summary>
    /// Get the final name for a hotbar slot, taking into account the specified appearance slot type and action ID.
    ///
    /// This method is virtually almost always called using the parameters from IconTypeB and IconB.
    ///
    /// When slot field 0xDE is set to 3, this method will instead override the passed in slotType and actionId with
    /// the values present in IconTypeA and IconA. 
    /// </summary>
    /// <param name="slotType">The appearance slot type to use. Virtually almost always IconTypeB.</param>
    /// <param name="actionId">The appearance action ID to use. Virtually almost always IconB.</param>
    /// <returns>Returns a string representation of the name to be displayed to the user for this hotbar slot.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 48 8B CB 48 85 C0 75 12")]
    public partial byte* GetDisplayNameForSlot(HotbarSlotType slotType, uint actionId);
}

#region Saved Bars

[StructLayout(LayoutKind.Explicit, Size = 0x5A0 * 61)]
public unsafe struct SavedHotBars
{
    [FieldOffset(0x00)] private fixed byte savedHotBars[0x15720];

    public SavedHotBarClassJob* this[int i]
    {
        get
        {
            if (i is < 0 or > 60) return null;
            fixed (byte* p = savedHotBars)
            {
                return (SavedHotBarClassJob*) (p + sizeof(SavedHotBarClassJob) * i);
            }
        }
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x5A0)]
    public struct SavedHotBarClassJob
    {
        [FieldOffset(0x00)] public SavedHotBarClassJobBars Bar;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x5A0)]
    public struct SavedHotBarClassJobBars
    {
        [FieldOffset(0x00)] private fixed byte bars[0x5A0];

        public SavedHotBarClassJobBar* this[int i]
        {
            get
            {
                if (i is < 0 or > 18) return null;
                fixed (byte* p = bars)
                {
                    return (SavedHotBarClassJobBar*) (p + sizeof(SavedHotBarClassJobBar) * i);
                }
            }
        }

        [StructLayout(LayoutKind.Explicit, Size = 0x50)]
        public struct SavedHotBarClassJobBar
        {
            [FieldOffset(0x00)] public SavedHotBarClassJobSlots Slot;
        }
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x50)]
    public struct SavedHotBarClassJobSlots
    {
        [FieldOffset(0x00)] private fixed byte slots[0x50];

        public SavedHotBarClassJobSlot* this[int i]
        {
            get
            {
                if (i is < 0 or > 16) return null;
                fixed (byte* p = slots)
                {
                    return (SavedHotBarClassJobSlot*) (p + sizeof(SavedHotBarClassJobSlot) * i);
                }
            }
        }

        [StructLayout(LayoutKind.Explicit, Size = 0x5)]
        public struct SavedHotBarClassJobSlot
        {
            [FieldOffset(0x00)] public HotbarSlotType Type;
            [FieldOffset(0x01)] public uint ID;
        }
    }
}

#endregion

public enum HotbarSlotType : byte
{
    Empty = 0x00,
    Action = 0x01,
    Item = 0x02,

    EventItem = 0x04,

    Emote = 0x06,
    Macro = 0x07,
    Marker = 0x08,
    CraftAction = 0x09,
    GeneralAction = 0x0A,
    CompanionOrder = 0x0B,
    MainCommand = 0x0C,
    Minion = 0x0D,

    GearSet = 0x0F,
    PetOrder = 0x10,
    Mount = 0x11,
    FieldMarker = 0x12,

    Recipe = 0x14,
    ChocoboRaceAbility = 0x15,
    ChocoboRaceItem = 0x16,
    Unk_0x17 = 0x17, // seems to be a legacy type, possibly PvP related based on associated icon 000785
    ExtraCommand = 0x18,
    PvPQuickChat = 0x19,
    PvPCombo = 0x1A,
    SquadronOrder = 0x1B,
    Unk_0x1C = 0x1C, // seems to be a legacy type, possibly performance instrument related based on associated icon 000782
    PerformanceInstrument = 0x1D,
    Collection = 0x1E,
    FashionAccessory = 0x1F,
    LostFindsItem = 0x20
}