using System.Runtime.CompilerServices;
using FFXIVClientStructs.FFXIV.Client.Game;
using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::RaptureHotbarModule
//   Client::UI::Misc::UserFileManager::UserFileEvent
// ctor "E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 4C 8B C7 49 8B D4 E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 49 8B D4"
[StructLayout(LayoutKind.Explicit, Size = 0x288F8)]
public unsafe partial struct RaptureHotbarModule {
    public static RaptureHotbarModule* Instance() => Framework.Instance()->GetUiModule()->GetRaptureHotbarModule();

    [FieldOffset(0)] public UserFileEvent UserFileEvent; // to 0x40
    [FieldOffset(0x48)] public UIModule* UiModule;

    /// <summary>
    /// The ID of the ClassJob associated with the currently-active hotbars.
    /// </summary>
    [FieldOffset(0x51)] public byte ActiveHotbarClassJobId;

    /// <summary>
    /// A bitfield representing whether a specific hotbar is to be considered "shared" or not.
    /// </summary>
    [FieldOffset(0x7C)] public fixed byte HotbarShareStateBitmask[4];

    /// <summary>
    /// An array of all active hotbars loaded and available to the player. This field tracks both normal hotbars
    /// (indices 0 to 9) and cross hotbars (indices 10 to 17).
    /// </summary>
    [FixedSizeArray<HotBar>(18)]
    [FieldOffset(0x90)] public fixed byte HotBars[18 * HotBar.Size];

    public Span<HotBar> StandardHotBars => this.HotBarsSpan[..10];
    public Span<HotBar> CrossHotBars => this.HotBarsSpan[10..];

    [FieldOffset(0xFC90)] public HotBar PetHotBar;
    [FieldOffset(0x10A90)] public HotBar PetCrossHotBar;

    /// <summary>
    /// A scratch hotbar slot used for temporary operations such as saving and temporary rewrites.
    /// </summary>
    [FieldOffset(0x11890)] public HotBarSlot ScratchSlot;


    /// <summary>
    /// A field containing all saved hotbars, as persisted to disk. This field tracks both normal and cross hotbars, at
    /// their appropriate sub-indices.
    /// </summary>
    /// <remarks>
    /// To retrieve PvE hotbar information, pass in either 0 for the shared hotbar or the ID of the ClassJob to retrieve.
    /// To retrieve PvP hotbar information, pass in the result of the <see cref="GetPvPSavedHotbarIndexForClassJobId"/>
    /// method.
    /// </remarks>
    [FixedSizeArray<SavedHotBarGroup>(65)]
    [FieldOffset(0x11974)] public fixed byte SavedHotBars[65 * SavedHotBarGroup.Size];

    [MemberFunction("E9 ?? ?? ?? ?? 48 8D 91 ?? ?? ?? ?? E9")]
    public partial byte ExecuteSlot(HotBarSlot* hotbarSlot);

    [MemberFunction("83 FA 12 77 28 41 83 F8 10")]
    public partial byte ExecuteSlotById(uint hotbarId, uint slotId);

    /// <summary>
    /// Search through the hotbar module and delete all hotbar slots associated with the specified macro. Used when a user
    /// deletes a specific macro from their list, and should affect saved (but unloaded) hotbars as well.
    /// </summary>
    /// <param name="macroSet">The macro set to scan for.</param>
    /// <param name="macroIndex">The macro index to scan for.</param>
    [MemberFunction("E8 ?? ?? ?? ?? EB 1A FF 50 68 44 0F B6 83")]
    public partial void DeleteMacroSlots(byte macroSet, byte macroIndex);

    /// <summary>
    /// Search through the hotbar module and reloads all hotbar slots associated with the specified macro. Used when
    /// a user updates a specific macro in any way that would change its hotbar display (e.g. new icon or name). This
    /// method will reload data from the saved hotbar information, overwriting any prior manual (unsaved)
    /// <see cref="HotBarSlot.Set(HotbarSlotType, uint)"/> operations.
    /// </summary>
    /// <param name="macroSet">The macro set to scan for.</param>
    /// <param name="macroIndex">The macro index to scan for.</param>
    [MemberFunction("E8 ?? ?? ?? ?? 8B 83 ?? ?? ?? ?? 39 87")]
    public partial void ReloadMacroSlots(byte macroSet, byte macroIndex);

    /// <summary>
    /// Search through the hotbar module and reload all hotbar slots associated with a specific gearset. Used when
    /// a user updates a gearset in any a way that would change its hotbar display (e.g. new name). This
    /// method will reload data from the saved hotbar information, overwriting any prior manual (unsaved)
    /// <see cref="HotBarSlot.Set(HotbarSlotType, uint)"/> operations.
    /// </summary>
    /// <param name="gearsetId">The gearset ID to refresh.</param>
    [MemberFunction("E8 ?? ?? ?? ?? 49 8B 4D 40 48 8B 01 FF 50 40")]
    public partial void ReloadGearsetSlots(int gearsetId);

    /// <summary>
    /// Search through the hotbar module and reassign all hotbar slots associated with a specific gearset to a new target gearset.
    /// Used when the user reorders or updates their gearset configurations.
    /// </summary>
    /// <remarks>
    /// This method is typically called immediately after <see cref="RaptureGearsetModule.ReassignGearsetId"/>.
    /// </remarks>
    /// <param name="gearsetId">The ID of the new gearset to be assigned.</param>
    /// <param name="oldGearsetId">The ID of the gearset to be replaced.</param>
    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 4E 10 48 8B 01 FF 50 40 48 8B 5C 24")]
    public partial void ReassignGearsetId(int gearsetId, int oldGearsetId);

    /// <summary>
    /// Search through the hotbar module and delete any hotbar slots associated with a specific gearset. Used when the user
    /// deletes a gearset.
    /// </summary>
    /// <param name="gearsetId">The gearset ID to search for and delete.</param>
    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 9C 24 ?? ?? ?? ?? 32 C0 48 8B 4C 24")]
    public partial void DeleteGearsetSlots(int gearsetId);

    /// <summary>
    /// Search through the hotbar module and reload <em>all</em> macro hotbar slots. This method will reload data
    /// from the saved hotbar information, overwriting any prior manual (unsaved)
    /// <see cref="HotBarSlot.Set(HotbarSlotType, uint)"/> operations.
    /// </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 8B C5 48 8B 4C 24 ?? 48 33 CC E8 ?? ?? ?? ?? 48 8B 9C 24")]
    public partial void ReloadAllMacroSlots();

    /// <summary>
    /// Retrieves a pointer to a specific hotbar slot via hotbar ID or slot ID. If the hotbar slot specified is out of
    /// bounds, return the <see cref="ScratchSlot"/>. 
    /// </summary>
    /// <param name="hotbarId">The hotbar ID (0 to 17) to select.</param>
    /// <param name="slotId">The slot ID (0 to 15) to select.</param>
    /// <returns>Returns a pointer to the specified HotBarSlot.</returns>
    [MemberFunction("83 FA 12 77 23")]
    public partial HotBarSlot* GetSlotById(uint hotbarId, uint slotId);

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

    /// <summary>
    /// Helper method to check if a specific hotbar is to be shared between all classes or not.
    /// </summary>
    /// <remarks>
    /// This method does not enforce bounding on the <c>hotbarId</c> field, consumers are responsible for this
    /// themselves.
    /// </remarks>
    /// <param name="hotbarId">The hotbar ID (bounded between 0 and 17) to check.</param>
    /// <returns>Returns true if the hotbar is shared, false otherwise.</returns>
    public bool IsHotbarShared(uint hotbarId) {
        return ((1 << ((int)hotbarId & 7)) & this.HotbarShareStateBitmask[hotbarId >> 3]) > 0;
    }

    /// <summary>
    /// Dumps a hotbar slot into a specific save slot within <see cref="SavedHotBars"/> and prepares a file save. Used
    /// to persist hotbar changes to disk. This method will attempt to resolve the proper index for saving depending on
    /// shared hotbar configuration and specified PvP state.
    /// </summary>
    /// <param name="classJobId">The ID of the ClassJob to persist this hotbar slot to.</param>
    /// <param name="hotbarId">The hotbar ID to modify.</param>
    /// <param name="slotId">The slot ID to modify.</param>
    /// <param name="slotSource">The source slot to dump to disk.</param>
    /// <param name="ignoreSharedHotbars">Unclear use, default to false. </param>
    /// <param name="isPvpSlot">If true, will save to the classJob's PvP SavedHotBars slots.</param>
    [MemberFunction("E8 ?? ?? ?? ?? EB 57 48 8D 9F ?? ?? ?? ??")]
    public partial void WriteSavedSlot(uint classJobId, uint hotbarId, uint slotId, HotBarSlot* slotSource,
        bool ignoreSharedHotbars, bool isPvpSlot);

    /// <summary>
    /// Get the Saved Hotbar Index for the PVP hotbar for a specific ClassJob, for use in <see cref="SavedHotBarsSpan"/>. 
    /// </summary>
    /// <param name="classJobId">The ClassJob to look up, or 0 for the shared PVP hotbar.</param>
    /// <param name="negOneOnInvalid">Return -1 if the ClassJob can't have a PVP variant.</param>
    /// <returns>Returns an index for the requested ClassJob's PVP hotbar.</returns>
    [MemberFunction("48 89 5C 24 ?? 57 48 83 EC 20 8B CA 41 0F B6 F8")]
    public partial int GetPvPSavedHotbarIndexForClassJobId(uint classJobId, bool negOneOnInvalid = true);

    /// <summary>
    /// Get the ClassJob EXD Row ID for a specific saved hotbar's index. This method is PVP-aware and will resolve
    /// accordingly.
    /// </summary>
    /// <param name="savedHotbarIndex">The saved hotbar index to check.</param>
    /// <returns>The EXD Row ID for the ClassJob this hotbar is intended for. If zero, this is a shared hotbar.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 41 0F B6 CD BA")]
    public partial uint GetClassJobIdForSavedHotbarIndex(int savedHotbarIndex);
}

[StructLayout(LayoutKind.Explicit, Size = Size)]
public unsafe partial struct HotBar {
    public const int Size = HotBarSlot.Size * 16;

    [FixedSizeArray<HotBarSlot>(16)]
    [FieldOffset(0x00)] public fixed byte Slots[16 * HotBarSlot.Size];

    /// <summary>
    /// Helper method to return a pointer to a specific HotBarSlot, as certain APIs are much happier with a
    /// pointer rather than a fixed reference.
    /// </summary>
    /// <param name="id">A hotbar slot ID between 0 and 15.</param>
    /// <returns>Returns a pointer to a HotBarSlot, or null if an invalid ID was passed.</returns>
    public HotBarSlot* GetHotbarSlot(uint id) {
        if (id > 15) return null;

        return (HotBarSlot*)Unsafe.AsPointer(ref SlotsSpan[(int)id]);
    }
}

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
    [MemberFunction("48 89 5C 24 ?? 57 48 83 EC 30 0F B6 C2 41 8B D8")]
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
}

#region Saved Bars

[StructLayout(LayoutKind.Explicit, Size = Size)]
public unsafe partial struct SavedHotBarGroup {
    public const int Size = SavedHotBar.Size * 18;

    [FixedSizeArray<SavedHotBar>(18)]
    [FieldOffset(0x00)] public fixed byte HotBars[SavedHotBar.Size * 18];
}

[StructLayout(LayoutKind.Explicit, Size = Size)]
public unsafe partial struct SavedHotBar {
    public const int Size = SavedHotBarSlot.Size * 16;

    [FixedSizeArray<SavedHotBarSlot>(16)]
    [FieldOffset(0x00)] public fixed byte Slots[SavedHotBarSlot.Size * 16];

    /// <summary>
    /// Helper method to return a pointer to a specific HotBarSlot, as certain APIs are much happier with a
    /// pointer rather than a fixed reference.
    /// </summary>
    /// <param name="id">A hotbar slot ID between 0 and 15.</param>
    /// <returns>Returns a pointer to a HotBarSlot, or null if an invalid ID was passed.</returns>
    public SavedHotBarSlot* GetSavedHotBarSlot(uint id) {
        if (id > 15) return null;

        return (SavedHotBarSlot*)Unsafe.AsPointer(ref this.Slots[id]);
    }
}

[StructLayout(LayoutKind.Explicit, Size = Size)]
public struct SavedHotBarSlot {
    public const int Size = 0x05;

    [FieldOffset(0x00)] public HotbarSlotType CommandType;
    [FieldOffset(0x01)] public uint CommandId;
}

#endregion

/// <summary>
/// An intermediate struct used to translate from a <see cref="HotBarSlot"/> to the UI String/NumberArrays. 
/// </summary>
/// <remarks>
/// <b>Do not consider this struct stable (yet).</b>
/// </remarks>
[StructLayout(LayoutKind.Explicit, Size = 0x43)]
internal unsafe struct HotBarUiIntermediate {
    // Converts to array in E8 ?? ?? ?? ?? EB 34 E8

    [FieldOffset(0x00)] public Utf8String* PopUpHelpText; // to StringArray idx slotBase + 14
    [FieldOffset(0x08)] public nint CostTextPtr; // to StringArray idx slotBase + 1
    [FieldOffset(0x10)] public uint IntermediateActionType; // to NumberArray idx slotBase + 0
    [FieldOffset(0x14)] public uint ActionId; // to NumberArray idx slotBase + 3
    [FieldOffset(0x18)] public uint IconId; // to NumberArray idx slotBase + 4
    [FieldOffset(0x1C)] public uint Unk_0x1C; // to NumberArray idx slotBase + 7
    [FieldOffset(0x20)] public uint Unk_0x20;
    [FieldOffset(0x24)] public uint CooldownPercent; // to NumberArray idx slotBase + 8
    [FieldOffset(0x28)] public uint Unk_0x28; // related to cooldown calculation.
    [FieldOffset(0x2C)] public uint Unk_0x2C; // to NumberArray idx slotBase + 9
    [FieldOffset(0x30)] public uint Unk_0x30;
    [FieldOffset(0x34)] public uint Unk_0x34; // to NumberArray idx slotBase + 13
    [FieldOffset(0x38)] public uint CostValue; // to NumberArray idx slotBase + 10
    [FieldOffset(0x3C)] public byte CostType; // to NumberArray idx slotBase + 1
    [FieldOffset(0x3D)] public byte CostDisplayMode; // to NumberArray idx slotBase + 2
    [FieldOffset(0x3E)] public bool ActionAvailable1; // to NumberArray idx slotBase + 5
    [FieldOffset(0x3F)] public bool ActionAvailable2; // to NumberArray idx slotBase + 6
    [FieldOffset(0x40)] public bool ActionTargetSatisfied; // to NumberArray idx slotBase + 15
    [FieldOffset(0x41)] public bool DrawAnts; // to NumberArray idx slotBase + 14
    [FieldOffset(0x42)] public byte Unk_0x42;
}

public enum HotbarSlotType : byte {
    Empty = 0x00,
    Action = 0x01,
    Item = 0x02,

    EventItem = 0x04,

    Emote = 0x06,
    Macro = 0x07,
    Marker = 0x08,
    CraftAction = 0x09,
    GeneralAction = 0x0A,
    BuddyAction = 0x0B,
    MainCommand = 0x0C,
    Companion = 0x0D,

    GearSet = 0x0F,
    PetAction = 0x10,
    Mount = 0x11,
    FieldMarker = 0x12,

    Recipe = 0x14,
    ChocoboRaceAbility = 0x15,
    ChocoboRaceItem = 0x16,
    Unk_0x17 = 0x17, // seems to be a legacy type, possibly PvP related based on associated icon 000785
    ExtraCommand = 0x18,
    PvPQuickChat = 0x19,
    PvPCombo = 0x1A,
    BgcArmyAction = 0x1B,
    Unk_0x1C = 0x1C, // seems to be a legacy type, possibly performance instrument related based on associated icon 000782
    PerformanceInstrument = 0x1D,
    Collection = 0x1E, // TODO (apiX): Rename to McGuffin to match EXD name
    Ornament = 0x1F,
    LostFindsItem = 0x20
}
