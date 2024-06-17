using FFXIVClientStructs.FFXIV.Client.Game;
using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

public partial struct RaptureHotbarModule {
    [GenerateInterop(isInherited: true)]
    [StructLayout(LayoutKind.Explicit, Size = Size)]
    public unsafe partial struct HotBarSlot {
        public const int Size = 0xE0;

        /// The string that appears when a hotbar slot is hovered over.
        ///
        /// Calculated by concatenating <see cref="GetDisplayNameForSlot"/> with <see cref="PopUpKeybindHint"/> (in most cases).
        [FieldOffset(0x00)] public Utf8String PopUpHelp;

        /// <summary>
        /// The cost text to display on the slot when <see cref="CostDisplayMode"/> is 2 or 4.
        /// </summary>
        ///  <remarks>
        /// This is generally used for actions with a flexible MP cost (e.g. "All" for Flare), or "x 123" for items.
        /// </remarks>
        [FieldOffset(0x68), FixedSizeArray(isString: true)]
        internal FixedSizeArray32<byte> _costText;

        /// A human-friendly display of the keybind used for this hotbar slot.
        ///
        /// This text will generally lead with a space and have wrapping brackets, e.g. " [Ctrl-3]".
        [FieldOffset(0x88), FixedSizeArray(isString: true)]
        internal FixedSizeArray32<byte> _popUpKeybindHint;

        /// A less-friendly version of the keybind used for this hotbar slot.
        ///
        /// The actual use of this field is unknown, but it appears to be related to the hint in the top-left of the hotbar
        /// UI.
        [FieldOffset(0xA8), FixedSizeArray(isString: true)]
        internal FixedSizeArray16<byte> _keybindHint;

        /// The ID of the action that will be executed when this slot is triggered. Action type is determined by the
        /// <see cref="CommandType"/> field.
        [FieldOffset(0xB8)] public uint CommandId;

        /// <summary>
        /// This field is used to track the "base" action ID used for display purposes. Unlike <see cref="ApparentActionId"/>,
        /// this value will not update with refreshes/combos. As such, it is used when an action has been "upgraded", or for
        /// systems like PvP combos where the original action name is still necessary.</summary>
        /// <remarks>
        /// Curiously, this value does not apply to macros as their substitution happens much earlier in the process.
        /// </remarks>
        [FieldOffset(0xBC)] public uint OriginalApparentActionId;
        
        [Obsolete($"Renamed to {nameof(OriginalApparentActionId)}.", true)]
        [FieldOffset(0xBC)] public uint IconA;

        /// <summary>
        /// The action ID that is used to determine this hotbar slot's icon (and usually display text).
        ///
        /// This field (and its related <see cref="ApparentSlotType"/>) allows a hotbar slot to have the appearance of one
        /// action, but in reality trigger a different action. See also <see cref="OriginalApparentActionId"/> for cases
        /// where this field would be used.
        /// </summary>
        [FieldOffset(0xC0)] public uint ApparentActionId;
        
        [Obsolete($"Renamed to {nameof(ApparentActionId)}.", true)]
        [FieldOffset(0xC0)] public uint IconB;

        /// Unknown field with offset 0xC4 (196), possibly overloaded
        ///
        /// Appears to have relation to the following:
        /// - Lost Finds Items appear to set this value to 1
        /// - In PVP actions, the high byte controls combo icon and the low byte counts which action the combo is on
        [FieldOffset(0xC4)] public ushort UNK_0xC4;

        // 0xC6 (198) does not appear to be referenced *anywhere*. Nothing ever reads or writes to it, save for a zero-out
        // operation. 

        /// The <see cref="HotbarSlotType"/> of the <see cref="CommandId"/> that will be executed when this hotbar slot
        /// is triggered.
        [FieldOffset(0xC7)] public HotbarSlotType CommandType;

        /// <summary>
        /// The <see cref="HotbarSlotType"/> initially assigned to this hotbar slot for display purposes.
        /// </summary>
        /// <seealso cref="OriginalApparentActionId"/>
        [FieldOffset(0xC8)] public HotbarSlotType OriginalApparentSlotType;
        
        [Obsolete($"Renamed to {nameof(OriginalApparentSlotType)}.", true)] 
        [FieldOffset(0xC8)] public uint IconTypeA;
        
        /// <summary>
        /// The <see cref="HotbarSlotType"/> assigned to this hotbar slot for display purposes.
        /// </summary>
        /// <seealso cref="ApparentActionId"/>
        [FieldOffset(0xC9)] public HotbarSlotType ApparentSlotType;
        
        [Obsolete($"Renamed to {nameof(ApparentSlotType)}.", true)]
        [FieldOffset(0xC9)] public uint IconTypeB;

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

        /// <summary>
        /// The current Icon ID (usually used in form <c>ui/icon/{ID}.tex</c>) that this hotbar slot should display. Loaded
        /// with <see cref="LoadIconId"/> based on information in <see cref="ApparentActionId"/>.
        /// </summary>
        [FieldOffset(0xCC)] public uint IconId;

        /// <summary>
        /// The "cost" of an action, usually in MP/TP/CP/GP or similar. The specific display type depends on the value in
        /// <see cref="CostType"/>. This value is normally shown in the bottom left of the hotbar slot.
        ///
        /// For items, this contains the quantity currently present in the player's inventory.
        /// </summary>
        [FieldOffset(0xD0)] public uint CostValue;

        /// <summary>
        /// The ID of the item that this hotbar slot contains a recipe for.
        /// </summary>
        /// <remarks>
        /// This field <em>may</em> be used for other purposes, but they have not been found yet.
        /// </remarks>
        [FieldOffset(0xD4)] public uint RecipeItemId;

        /// <summary>
        /// The CraftType of the recipe currently in this hotbar slot.
        /// </summary>
        /// <remarks>
        /// This field <em>may</em> be used for other purposes, but they have not been found yet.
        /// </remarks>
        [FieldOffset(0xD8)] public uint RecipeCraftType;

        /// <summary>
        /// A boolean representing if the recipe in this hotbar slot is valid or not. Set to 1 when the recipe would result
        /// in a nonzero number of items.
        ///
        /// If not set, the game will indicate that the referenced recipe has been deleted.
        /// </summary>
        /// <remarks>
        /// This field <em>may</em> be used for other purposes, but they have not been found yet.
        /// </remarks>
        [FieldOffset(0xDC)] public byte RecipeValid;

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
        /// Check if this hotbar slot is considered "empty" or not, based on whether this hotbar slot has a <see cref="CommandId"/>
        /// defined. This is a convenience method borrowed from the game's code.
        /// </summary>
        public bool IsEmpty => CommandId == 0;

        [MemberFunction("E8 ?? ?? ?? ?? 48 39 7E 08")]
        public partial void Set(UIModule* uiModule, HotbarSlotType type, uint id);

        /// <summary>
        /// Update the <see cref="CommandType"/> and <see cref="CommandId"/> of this hotbar slot. This method will only affect
        /// the current working hotbar slot and will not be persisted unless the user takes additional action that would trigger
        /// a save, such as swapping this slot for a different one. Use <see cref="RaptureHotbarModule.SetAndSaveSlot"/> to
        /// update a hotbar slot with persistence.
        /// </summary>
        /// <param name="type">The <see cref="HotbarSlotType"/> that this slot should trigger.</param>
        /// <param name="id">The ID of the command that this slot should trigger.</param>
        public void Set(HotbarSlotType type, uint id) => Set(Framework.Instance()->GetUIModule(), type, id);

        /// <summary>
        /// Populates <see cref="IconId"/> with the apparent information in <see cref="ApparentActionId"/> and <see cref="ApparentSlotType"/>.
        /// </summary>
        /// <returns>Returns true if no icon was loaded (??)</returns>
        [MemberFunction("40 53 48 83 EC 20 44 8B 81 ?? ?? ?? ?? 48 8B D9 0F B6 91 ?? ?? ?? ?? E8 ?? ?? ?? ?? 85 C0")]
        public partial bool LoadIconId();

        /// <summary>
        /// Loads cost data to <see cref="CostText"/> or <see cref="CostValue"/> for this hotbar slot.
        /// </summary>
        [MemberFunction("E8 ?? ?? ?? ?? 40 0A E8 C6 46 3E 00")]
        public partial bool LoadCostDataForSlot(bool isLoaded = true);

        /// <summary>
        /// Get an icon ID for a hotbar slot, with specified appearance slot type and action ID.
        ///
        /// This method appears to exist to allow certain action types (specifically macros it seems?) to have a different
        /// appearance than the actual CommandType/CommandId called by this hotbar slot.
        /// </summary>
        /// <param name="slotType">The appearance slot type to use. Virtually almost always <see cref="ApparentSlotType"/>.</param>
        /// <param name="actionId">The appearance action ID to use. Virtually almost always <see cref="ApparentActionId"/>.</param>
        /// <returns>Returns an int of the icon that should be used for this hotbar slot.</returns>
        [MemberFunction("E8 ?? ?? ?? ?? 85 C0 89 83 ?? ?? ?? ?? 0F 94 C0")]
        public partial int GetIconIdForSlot(HotbarSlotType slotType, uint actionId);

        /// <summary>
        /// Get the final name for a hotbar slot, taking into account the specified appearance slot type and action ID.
        ///
        /// This method is virtually almost always called using the parameters from <see cref="ApparentSlotType"/> and <see cref="ApparentActionId"/>.
        ///
        /// When <see cref="UNK_0xDE"/> is set to 3, this method will instead override the passed in slotType and actionId with
        /// the values present in <see cref="OriginalApparentSlotType"/> and <see cref="OriginalApparentActionId"/>. 
        /// </summary>
        /// <param name="slotType">The appearance slot type to use. Virtually almost always <see cref="ApparentSlotType"/>.</param>
        /// <param name="actionId">The appearance action ID to use. Virtually almost always <see cref="ApparentActionId"/>.</param>
        /// <returns>Returns a string representation of the name to be displayed to the user for this hotbar slot.</returns>
        [MemberFunction("E8 ?? ?? ?? ?? 48 8B CB 48 85 C0 75 12")]
        public partial byte* GetDisplayNameForSlot(HotbarSlotType slotType, uint actionId);

        /// <summary>
        /// Gets the <see cref="CostValue"/> for a specific hotbar slot, taking account the specified appearance slot type
        /// and action ID.
        ///
        /// This method is always called using the parameters from <see cref="ApparentSlotType"/> and <see cref="ApparentActionId"/>.
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
        /// This method is always called using the parameters from <see cref="ApparentSlotType"/> and <see cref="ApparentActionId"/>.
        /// </summary>
        /// <param name="slotType">The slot type to look up and return information for.</param>
        /// <param name="actionId">The action ID to look up and return information for.</param>
        /// <returns>Returns the cost text for this HotBarSlot.</returns>
        [MemberFunction("E8 ?? ?? ?? ?? 48 85 C0 74 29 80 38 00")]
        public partial uint GetCostTextForSlot(HotbarSlotType slotType, uint actionId);

        /// <summary>
        /// Retrieves a <see cref="ActionType"/> for the specified hotbar slot type.
        /// </summary>
        /// <remarks>
        /// This method doesn't actually read any data from the HotBarSlot it's a member of.
        /// </remarks>
        /// <param name="type">A <see cref="HotbarSlotType"/> to check against.</param>
        /// <returns>Returns an ActionType if found, else 0xFFFFFFFF.</returns>
        [MemberFunction("FF CA 83 FA 1E")]
        public partial ActionType GetActionTypeForSlotType(HotbarSlotType type);

        /// <summary>
        /// Gets the number of charges currently available for the specified hotbar slot (based on the icon present in
        /// <see cref="ApparentActionId"/>). If this hotbar slot references an action that does not use charges, this will return either 0 or 1.
        /// </summary>
        /// <returns>Returns a uint.</returns>
        [MemberFunction("40 53 48 83 EC 40 8B 99 ?? ?? ?? ??")]
        public partial uint GetApparentIconRecastCharges();

        /// <summary>
        /// Check whether the action contained in this slot is considered usable or not. When set to false, the respective
        /// slot in the UI is greyed out (though is still interactable). 
        /// </summary>
        /// <param name="slotType">The slot type to check against - always <see cref="ApparentSlotType"/>.</param>
        /// <param name="actionId">The actionID to check against - always <see cref="ApparentActionId"/>.</param>
        /// <returns>Returns a bool indicating if the action within this slot is usable.</returns>
        [MemberFunction("E8 ?? ?? ?? ?? 88 46 3E EB AC")]
        public partial bool IsSlotUsable(HotbarSlotType slotType, uint actionId);

        /// <summary>
        /// Check if the hotbar slot's action's target is currently in range. When set to false, the UI will show an X
        /// on the hotbar slot.
        /// </summary>
        /// <returns>Returns a bool indicating whether the action's range constraints are met.</returns>
        [MemberFunction("40 53 48 83 EC 20 44 0F B6 81 ?? ?? ?? ?? 48 8B D9")]
        public partial bool IsSlotActionTargetInRange();

        /// <summary>
        /// Check if an arbitrary slot type/action ID's target is currently in range. Overload to allow for any slot type
        /// or action ID to be checked. Use <see cref="IsSlotActionTargetInRange()"/> to target the current slot.
        /// </summary>
        /// <remarks>
        /// This method can realistically be static, I'm unsure why it's not...
        /// </remarks>
        /// <param name="slotType">The slot type (normally <see cref="ApparentSlotType"/>) to check.</param>
        /// <param name="actionId">The action ID (normally <see cref="ApparentActionId"/>) to check.</param>
        /// <returns>Returns a bool indicating whether the action's range constraints are met.</returns>
        [MemberFunction("40 53 48 83 EC ?? 44 0F B6 CA 41 8B D8 41 8B D1 83 EA ?? 74 ?? 83 EA")]
        public partial bool IsSlotActionTargetInRange2(HotbarSlotType slotType, uint actionId);

        /// <summary>
        /// Gets the action's cooldown percentage. This value is displayed as a white circle overlaid on the hotbar slot. An action that
        /// is not currently in cooldown will be 0. Actions that do not have a cooldown will also return 0.
        /// </summary>
        /// <param name="outCooldownSecondsLeft">An out parameter representing the seconds left in cooldown. Unused if cooldown is GCD.</param>
        /// <param name="a3">Unknown, appears to be a UI-related field for forcing values if the percentage is 0.</param>
        /// <returns>Returns a range from 0 to 100.</returns>
        [MemberFunction("E8 ?? ?? ?? ?? 48 8B 5C 24 ?? 89 47 24")]
        public partial int GetSlotActionCooldownPercentage(int* outCooldownSecondsLeft, int a3 = 0);

        /// <summary>
        /// Gets whether the specified action should be highlighted with ants in the UI.
        /// Internally calls <see cref="ActionManager.IsActionHighlighted"/>.
        /// </summary>
        /// <remarks>
        /// This method does not appear in any code paths.
        /// </remarks>
        /// <param name="commandType">The type of the command to look up.</param>
        /// <param name="commandId">The ID of the command to look up.</param>
        /// <returns>Returns <c>true</c> if the action would be highlighted, <c>false</c> otherwise.</returns>
        [MemberFunction("40 53 48 83 EC 20 44 0F B6 CA 41 8B D8 41 8B D1 83 EA 01 74 0D")]
        public partial bool IsActionHighlighted(HotbarSlotType commandType, uint commandId);
    }

    /// <summary>
    /// A special extended <see cref="HotBarSlot"/> used for duty actions
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = Size)]
    [Inherits<HotBarSlot>]
    public struct DutyActionSlot {
        public const int Size = HotBarSlot.Size + 8;

        /// <summary>
        /// The PrimaryCostType from the Action EXD (+0x29).
        /// </summary>
        [FieldOffset(0xE0)] public byte PrimaryCostType;

        [FieldOffset(0xE1)] public bool IsActive;
    }
}
