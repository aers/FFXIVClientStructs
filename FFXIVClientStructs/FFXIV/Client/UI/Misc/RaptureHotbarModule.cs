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
    
    /// <summary>
    /// The action name currently loaded into this Hotbar Slot (if any).
    /// </summary>
    [FieldOffset(0x00)] public Utf8String PopUpHelp;

    /// <summary>
    /// The ID of the action that will be executed when this slot is triggered. Action type is determined by the
    /// CommandType field.
    /// </summary>
    [FieldOffset(0xB8)] public uint CommandId;
    
    /// <summary>
    /// UNKNOWN. Appears to be the original action ID associated with this hotbar slot before adjustment.
    ///
    /// Note that this is *not* a reference to an icon ID; it must be combined with IconTypeA.
    /// </summary>
    [FieldOffset(0xBC)] public uint IconA;
    
    /// <summary>
    /// Appears to be the action ID that will be used to generate this hotbar slot icon.
    ///
    /// This field exists to allow a hotbar slot to have the appearance of one action, but in reality trigger a
    /// different action. For example, macros with a set /micon will leverage this field to show a specific action ID.
    ///
    /// Note that this is *not* a reference to an icon directly.
    /// </summary>
    [FieldOffset(0xC0)] public uint IconB;
    
    /// <summary>
    /// Unknown field with offset 0xC4 (196), possibly overloaded
    ///
    /// Appears to have relation to the following:
    /// - Lost Finds Items appear to set this value to 1
    /// - In PVP actions, the high byte controls combo icon and the low byte counts which action the combo is on
    /// </summary>
    [FieldOffset(0xC4)] public ushort UNK_0xC4;
    
    // 0xC6 (198) does not appear to exist.

    /// <summary>
    /// The HotbarSlotType of the action that will be executed when this hotbar slot is triggered.
    /// </summary>
    [FieldOffset(0xC7)] public HotbarSlotType CommandType;
    
    /// <summary>
    /// UNKNOWN. Appears to be the original action type associated with this hotbar slot before adjustment/loading.
    /// </summary>
    [FieldOffset(0xC8)] public HotbarSlotType IconTypeA;
    
    /// <summary>
    /// Appears to be the HotbarSlotType used to determine the icon to display on this hotbar slot.
    ///
    /// See notes on IconB for more information as to how this field is used.
    /// </summary>
    [FieldOffset(0xC9)] public HotbarSlotType IconTypeB;
    
    /// <summary>
    /// Appears to be the "primary cost" of this action, mapping down to 0, 1, 2, 4, 5, 7
    /// </summary>
    [FieldOffset(0xCA)] public byte UNK_0xCA;
    
    /// <summary>
    /// Appears to control display of the primary cost of the action (0xCA). 
    ///
    /// - 1: Displays action cost in bottom left for Actions or Craft Actions
    /// - 2: Appears to display text "all", appears on Actions with PrimaryCost = 4
    /// - 3: Displays an ID in the bottom right of the slot for Gearsets/UNK_0x17
    /// - 4: Displays "x {num}" for Items
    /// - 0/255: No display, all other cases
    /// </summary>
    [FieldOffset(0xCB)] public byte UNK_0xCB;
    
    /// <summary>
    /// The icon ID that is currently being displayed on this hotbar slot. 
    /// </summary>
    [FieldOffset(0xCC)] public int Icon;
    
    // D0-DD appear to be used on recipes in code
    
    /// <summary>
    /// UNKNOWN. Appears to be the "cost" of an action.
    ///
    /// For items, this field holds the number of items of that type currently present in inventory.
    ///
    /// For actions that have some cost (MP, job bar, etc.), this appears to be the relevant value shown in the bottom
    /// left of the action.
    /// </summary>
    [FieldOffset(0xD0)] public uint UNK_0xD0;
    
    /// <summary>
    /// UNKNOWN. Appears to be Recipe specific and references the resulting Item ID of the recipe on the hotbar slot.
    /// </summary>
    [FieldOffset(0xD4)] public uint UNK_0xD4;
    
    /// <summary>
    /// UNKNOWN. Appears to be Recipe specific and references the class which can craft the recipe.
    ///
    /// Retrieve the ClassJob by adding 10 to this value.
    ///
    /// ERRATA: Items that can be crafted by either BSM/ARM show as BSM. 
    /// </summary>
    [FieldOffset(0xD8)] public uint UNK_0xD8;
    [FieldOffset(0xDC)] public byte UNK_OxDC;
    [FieldOffset(0xDD)] public byte UNK_OxDD;

    /// <summary>
    /// UNKNOWN. Appears to control UI display mode (icon and displayed name) in some way
    ///
    /// Known values so far:
    /// - 2: Appears to be set for adjusted actions (e.g. upgraded spells/weaponskills)
    /// - 3: Appears to mark a PVP combo action
    /// - 4: Set on Squadron Order - Disengage, maybe others
    /// - 5: Set for Lost Finds Items (?)
    /// - 0/255: "generic"
    /// </summary>
    [FieldOffset(0xDE)] public byte UNK_0xDE;
    
    [FieldOffset(0xDF)] public byte IsEmpty; // ?

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