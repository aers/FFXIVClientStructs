using FFXIVClientStructs.FFXIV.Client.Game;
using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// ToDo: Wrap in RaptureHotbarModule partial struct for namespacing (API 10)
[StructLayout(LayoutKind.Explicit, Size = Size)]
public unsafe partial struct HotBarSlot {
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
    [FieldOffset(0xC0)] public uint IconB; // TODO? (apiX): Rename to `ApparentIcon`, `GetApparentIconId` etc. 

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
    [FieldOffset(0xCA)] public byte CostType;

    /// Appears to control display of the primary cost of the action (0xCA). 
    ///
    /// - 1: Displays action cost from 0xD0 in bottom left (e.g. for Actions or Craft Actions)
    /// - 2: Mode 1, but display a custom string from CostText instead (generally "All" on Actions with PrimaryCost = 4)
    /// - 3: Displays the value of 0xD0 in the bottom right (e.g. for Gearsets/UNK_0x17)
    /// - 4: Mode 3, but display a custom string from CostText instead (generally "x {count}" for Items)
    /// - 0/255: No display, all other cases
    [FieldOffset(0xCB)] public byte CostDisplayMode;

    /// The icon ID that is currently being displayed on this hotbar slot. 
    [FieldOffset(0xCC)] public int Icon;

    /// UNKNOWN. Appears to be the "cost" of an action.
    ///
    /// For items, this field holds the number of items of that type currently present in inventory.
    ///
    /// For actions that have some cost (MP, job bar, etc.), this appears to be the relevant value shown in the bottom
    /// left of the action.
    [FieldOffset(0xD0)] public uint CostValue;

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
    /// - 128: Appears as a flag?
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
    public bool IsEmpty => this.CommandId == 0;

    [MemberFunction("E8 ?? ?? ?? ?? 4C 39 6F 08")]
    public partial void Set(UIModule* uiModule, HotbarSlotType type, uint id);

    /// <summary>
    /// Update the command of this hotbar slot to the specified value. This will not trigger a file save and will only
    /// update the in-memory struct defined here.
    /// </summary>
    /// <param name="type">The <see cref="HotbarSlotType"/> that this slot should trigger.</param>
    /// <param name="id">The ID of the command that this slot should trigger.</param>
    public void Set(HotbarSlotType type, uint id) =>
        Set(Framework.Instance()->GetUiModule(), type, id);

    /// <summary>
    /// Populates HotBarSlot.Icon with information from IconB/IconTypeB. 
    /// </summary>
    /// <returns>Returns true if no icon was loaded (??)</returns>
    [MemberFunction("40 53 48 83 EC 20 44 8B 81 ?? ?? ?? ?? 48 8B D9 0F B6 91 ?? ?? ?? ?? E8 ?? ?? ?? ?? 85 C0")]
    public partial bool LoadIconFromSlotB();

    /// <summary>
    /// Loads in cost data (value or text) for this target hotbar slot.
    /// </summary>
    /// <returns></returns>
    [MemberFunction("E8 ?? ?? ?? ?? 40 0A F0 44 8B 83")]
    public partial bool LoadCostDataForSlot(bool isLoaded = true);

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

    /// <summary>
    /// Gets the <see cref="CostValue"/> for a specific hotbar slot, taking account the specified appearance slot type
    /// and action ID.
    ///
    /// This method is always called using the parameters from <see cref="IconTypeB"/> and <see cref="IconB"/>.
    /// </summary>
    /// <param name="slotType">The slot type to look up and return information for.</param>
    /// <param name="actionId">The action ID to look up and return information for.</param>
    /// <returns>Returns the cost value for this HotBarSlot.</returns>
    [MemberFunction("48 89 5C 24 ?? 57 48 83 EC 30 0F B6 C2 41 8B D8")]
    public partial uint GetCostValueForSlot(HotbarSlotType slotType, uint actionId);

    /// <summary>
    /// Gets the <see cref="CostText"/> for a specific hotbar slot, taking account the specified appearance slot type
    /// and action ID. This will normally match the result from <see cref="GetCostValueForSlot"/> but may differ for
    /// Items and certain actions (e.g. Black Mage's Flare).
    ///
    /// This method is always called using the parameters from <see cref="IconTypeB"/> and <see cref="IconB"/>.
    /// </summary>
    /// <param name="slotType">The slot type to look up and return information for.</param>
    /// <param name="actionId">The action ID to look up and return information for.</param>
    /// <returns>Returns the cost text for this HotBarSlot.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 48 85 C0 74 26 80 38 00")]
    public partial uint GetCostTextForSlot(HotbarSlotType slotType, uint actionId);

    /// <summary>
    /// Retrieves a <see cref="ActionType"/> for the specified hotbar slot type.
    /// </summary>
    /// <remarks>
    /// This method doesn't actually read any data from the HotBarSlot it's a member of.
    /// </remarks>
    /// <param name="type">A HotbarSlotType to check against.</param>
    /// <returns>Returns an ActionType if found, else 0xFFFFFFFF.</returns>
    [MemberFunction("FF CA 83 FA 1E")]
    public partial ActionType GetActionTypeForSlotType(HotbarSlotType type);

    /// <summary>
    /// Gets the number of charges currently available for the specified hotbar slot (based on the icon present in
    /// IconB). If this hotbar slot references an action that does not use charges, this will return either 0 or 1.
    /// </summary>
    /// <returns>Returns a uint.</returns>
    [MemberFunction("40 53 48 83 EC 40 8B 99 ?? ?? ?? ??")]
    public partial uint GetRecastChargesFromSlotB();

    /// <summary>
    /// Check whether the action contained in this slot is considered usable or not. When set to false, the respective
    /// slot in the UI is greyed out (though is still interactable). 
    /// </summary>
    /// <param name="slotType">The slot type to check against - always IconTypeB.</param>
    /// <param name="actionId">The actionID to check against - always IconB.</param>
    /// <returns>Returns a bool indicating if the action within this slot is usable.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 88 47 3E E9")]
    public partial bool IsSlotUsable(HotbarSlotType slotType, uint actionId);

    /// <summary>
    /// Check if the hotbar slot's action's target is currently in range. When set to false, the UI will show an X
    /// on the hotbar slot.
    /// </summary>
    /// <returns>Returns a bool indicating whether the action's range constraints are met.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 88 47 40 48 8B D7")]
    public partial bool IsSlotActionTargetInRange();

    /// <summary>
    /// Check if an arbitrary slot type/action ID's target is currently in range. Overload to allow for any slot type
    /// or action ID to be checked. Use <see cref="IsSlotActionTargetInRange()"/> to target the current slot.
    /// </summary>
    /// <remarks>
    /// This method can realistically be static, I'm unsure why it's not...
    /// </remarks>
    /// <param name="slotType">The slot type (normally <see cref="IconTypeB"/>) to check.</param>
    /// <param name="actionId">The action ID (normally <see cref="IconB"/>) to check.</param>
    /// <returns>Returns a bool indicating whether the action's range constraints are met.</returns>
    [MemberFunction("40 53 48 83 EC 20 41 8B D8 80 FA 11")]
    public partial bool IsSlotActionTargetInRange2(HotbarSlotType slotType, uint actionId);

    /// <summary>
    /// Gets the action's cooldown percentage. This value is displayed as a white circle overlaid on the hotbar slot. An action that
    /// is not currently in cooldown will be 0. Actions that do not have a cooldown will also return 0.
    /// </summary>
    /// <param name="outCooldownSecondsLeft">An out parameter representing the seconds left in cooldown. Unused if cooldown is GCD.</param>
    /// <param name="a3">Unknown, appears to be a UI-related field for forcing values if the percentage is 0.</param>
    /// <returns>Returns a range from 0 to 100.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 89 47 24 E9")]
    public partial int GetSlotActionCooldownPercentage(int* outCooldownSecondsLeft, int a3 = 0);
}

/// <summary>
/// A special extended <see cref="HotBarSlot"/> used for duty actions
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = Size)]
public unsafe partial struct DutyActionSlot {
    public const int Size = HotBarSlot.Size + 8;

    [FieldOffset(0x00)] public HotBarSlot Slot;

    /// <summary>
    /// The PrimaryCostType from the Action EXD (+0x29).
    /// </summary>
    [FieldOffset(0xE0)] public byte PrimaryCostType;

    [FieldOffset(0xE1)] public bool IsActive;
}
