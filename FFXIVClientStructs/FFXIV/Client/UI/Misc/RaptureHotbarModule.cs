using System.Runtime.CompilerServices;
using FFXIVClientStructs.FFXIV.Client.Game;
using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::RaptureHotbarModule
//   Client::UI::Misc::UserFileManager::UserFileEvent
// ctor "E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 4C 8B C7 49 8B D4 E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 49 8B D4"
[GenerateInterop]
[Inherits<UserFileEvent>]
[StructLayout(LayoutKind.Explicit, Size = 0x288F8)]
public unsafe partial struct RaptureHotbarModule {
    public static RaptureHotbarModule* Instance() => Framework.Instance()->GetUIModule()->GetRaptureHotbarModule();

    [FieldOffset(0x48)] public UIModule* UIModule;

    /// <summary>
    /// Set in RaptureHotbarModule's ReadFile after all processing/loading appears to have been completed.
    /// Might also (probably does?) signify all migrations and version checks have been completed and everything
    /// is stable.
    /// </summary>
    [FieldOffset(0x50)] public bool ModuleReady;

    /// <summary>
    /// The ID of the ClassJob associated with the currently-active hotbars.
    /// </summary>
    /// <remarks>
    /// Can have a bit set at 0x80 if <see cref="ModuleReady"/> is false, though the meaning of this flag is unclear.
    /// </remarks>
    [FieldOffset(0x51)] public byte ActiveHotbarClassJobId;

    /// <summary>
    /// Appears to be set if <c>HOTBAR.DAT</c> was loaded from disk successfully. Set to 0 if decryption fails or
    /// the file read errors out. Does not appear to track migration state. Set in ReadFile.
    /// </summary>
    [FieldOffset(0x52)] public bool DatFileLoadedSuccessfully;

    // PvE hotbars starting from MCH onwards, appears to track whether a hotbar was initialized?
    [FieldOffset(0x54), FixedSizeArray] internal FixedSizeArray12<bool> _expacJobHotbarsCreated;

    // PvP hotbars for all jobs, appears to track if it's been initialized. 
    [FieldOffset(0x60), FixedSizeArray] internal FixedSizeArray22<bool> _pvPHotbarsCreated;

    // ????? maybe AllowResets?
    [FieldOffset(0x76)] internal bool ClearCallbackPresent;

    /// <summary>
    /// A state field to track the current materia melding state (locked - 1 / standard - 2 / advanced - 3), and whether
    /// the hotbars were migrated to replace actions or not.
    /// </summary>
    [FieldOffset(0x78)] internal uint MateriaMeldState;

    /// <summary>
    /// A bitfield representing whether a specific hotbar is to be considered "shared" or not.
    /// </summary>
    [FieldOffset(0x7C), FixedSizeArray] internal FixedSizeArray4<byte> _hotbarShareStateBitmask;

    /// <summary>
    /// Another bitmask that appears to be related to hotbar sharing state.
    /// Initialized to 0x3E3F8 (default share state) on game start, but doesn't ever appear to be updated or read elsewhere.
    /// Dead field?
    /// </summary>
    [FieldOffset(0x80), FixedSizeArray] internal FixedSizeArray4<byte> _hotbarShareStateBitmask2;

    [FieldOffset(0x88)] public ClearCallback* ClearCallbackPtr;

    /// <summary>
    /// An array of all active hotbars loaded and available to the player. This field tracks both normal hotbars
    /// (indices 0 to 9) and cross hotbars (indices 10 to 17).
    /// </summary>
    [FieldOffset(0x90), FixedSizeArray] internal FixedSizeArray18<Hotbar> _hotbars;

    public Span<Hotbar> StandardHotbars => new(Unsafe.AsPointer(ref Hotbars[0]), 10);
    public Span<Hotbar> CrossHotbars => new(Unsafe.AsPointer(ref Hotbars[10]), 8);

    [FieldOffset(0xFC90)] public Hotbar PetHotbar;
    [FieldOffset(0x10A90)] public Hotbar PetCrossHotbar;

    /// <summary>
    /// A scratch hotbar slot used for temporary operations such as saving and temporary rewrites.
    /// </summary>
    [FieldOffset(0x11890)] public HotbarSlot ScratchSlot;

    // No idea how this field works. Observed so far:
    // 15 (0x0E) - Quest mount (?)
    // 18 (0x12) - Mount/FashionAccessory
    // 34 (0x22) - Carbuncle up
    // Seems to control something with overriding the main bar too?
    [FieldOffset(0x11970)] public uint PetHotbarMode;

    /// <summary>
    /// A field containing all saved hotbars, as persisted to disk. This field tracks both normal and cross hotbars, at
    /// their appropriate sub-indices.
    /// </summary>
    /// <remarks>
    /// To retrieve PvE hotbar information, pass in either 0 for the shared hotbar or the ID of the ClassJob to retrieve.
    /// To retrieve PvP hotbar information, pass in the result of the <see cref="GetPvPSavedHotbarIndexForClassJobId"/>
    /// method.
    /// </remarks>
    [FieldOffset(0x11974), FixedSizeArray] internal FixedSizeArray65<SavedHotbarGroup> _savedHotbars;

    [FieldOffset(0x28714)] public CrossHotbarFlags CrossHotbarFlags;

    /// <summary>
    /// Field to track the player's current Grand Company. Used for emote refresh/update purposes.
    /// </summary>
    /// <remarks>
    /// If this field is out of sync with game state, it will be updated on the next frame. Setting
    /// this field manually appears to have no effect (?).
    /// </remarks>
    [FieldOffset(0x28718)] public uint GrandCompanyId;

    /// <summary>
    /// Field to indicate whether the PvP hotbar is currently active or not.
    /// </summary>
    /// <remarks>
    /// If this field is out of sync with the game's PVP state, it will be updated on the next frame. Setting
    /// this field manually will not enable the PvP hotbars.
    /// </remarks>
    [FieldOffset(0x2871C)] public bool PvPHotbarsActive;

    /// <summary>
    /// Field to indicate that the PvP hotbar swap notification (AgentPvpScreenInformation) needs to be shown.
    /// This field is set to <c>false</c> after the agent has been shown.
    /// </summary>
    [FieldOffset(0x2871D)] public bool ShowPvPHotbarSwapNotification;

    /// <summary>
    /// Hotbar slots representing available Duty Actions (see also <see cref="ActionManager.GetDutyActionId"/>).
    /// </summary>
    [FieldOffset(0x28720), FixedSizeArray] internal FixedSizeArray2<DutyActionSlot> _dutyActionSlots;

    /// <summary>
    /// Sets whether Duty Actions are present or not. Controls whether to show the appropriate UI element and whether
    /// to rewrite the special DutyAction General Actions.
    /// </summary>
    [FieldOffset(0x288F0)] public bool DutyActionsPresent;

    [MemberFunction("E9 ?? ?? ?? ?? 48 8D 91 ?? ?? ?? ?? E9")]
    public partial byte ExecuteSlot(HotbarSlot* hotbarSlot);

    [MemberFunction("83 FA 12 77 28 41 83 F8 10")]
    public partial byte ExecuteSlotById(uint hotbarId, uint slotId);

    /// <summary>
    /// Search through the hotbar module and delete all hotbar slots associated with the specified macro. Used when a user
    /// deletes a specific macro from their list, and should affect saved (but unloaded) hotbars as well.
    /// </summary>
    /// <param name="macroSet">The macro set to scan for.</param>
    /// <param name="macroIndex">The macro index to scan for.</param>
    [MemberFunction("E8 ?? ?? ?? ?? EB 13 FF 52 68 44 0F B6 C6")]
    public partial void DeleteMacroSlots(byte macroSet, byte macroIndex);

    /// <summary>
    /// Search through the hotbar module and reloads all hotbar slots associated with the specified macro. Used when
    /// a user updates a specific macro in any way that would change its hotbar display (e.g. new icon or name). This
    /// method will reload data from the saved hotbar information, overwriting any prior manual (unsaved)
    /// <see cref="HotbarSlot.Set(HotbarSlotType, uint)"/> operations.
    /// </summary>
    /// <param name="macroSet">The macro set to scan for.</param>
    /// <param name="macroIndex">The macro index to scan for.</param>
    [MemberFunction("E8 ?? ?? ?? ?? EB 13 FF 52 68 44 0F B6 C3")]
    public partial void ReloadMacroSlots(byte macroSet, byte macroIndex);

    /// <summary>
    /// Search through the hotbar module and reload all hotbar slots associated with a specific gearset. Used when
    /// a user updates a gearset in any a way that would change its hotbar display (e.g. new name). This
    /// method will reload data from the saved hotbar information, overwriting any prior manual (unsaved)
    /// <see cref="HotbarSlot.Set(HotbarSlotType, uint)"/> operations.
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
    /// <see cref="HotbarSlot.Set(HotbarSlotType, uint)"/> operations.
    /// </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 8B C5 48 8B 4C 24 ?? 48 33 CC E8 ?? ?? ?? ?? 48 8B 9C 24")]
    public partial void ReloadAllMacroSlots();

    /// <summary>
    /// Retrieves a pointer to a specific hotbar slot via hotbar ID or slot ID. If the hotbar slot specified is out of
    /// bounds, return the <see cref="ScratchSlot"/>. 
    /// </summary>
    /// <param name="hotbarId">The hotbar ID (0 to 17) to select.</param>
    /// <param name="slotId">The slot ID (0 to 15) to select.</param>
    /// <returns>Returns a pointer to the specified HotbarSlot.</returns>
    [MemberFunction("83 FA 12 77 23")]
    public partial HotbarSlot* GetSlotById(uint hotbarId, uint slotId);

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
    [MemberFunction("48 89 5C 24 ?? 48 89 74 24 ?? 57 48 83 EC 30 48 8B DA 49 8B F0")]
    public static partial uint GetSlotAppearance(HotbarSlotType* actionType, uint* actionId, ushort* UNK_0xC4,
        RaptureHotbarModule* hotbarModule, HotbarSlot* slot);

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
        return ((1 << ((int)hotbarId & 7)) & this.HotbarShareStateBitmask[(int)hotbarId >> 3]) > 0;
    }

    /// <summary>
    /// Sets a hotbar slot and triggers a save for it automatically via <see cref="WriteSavedSlot"/>. This will
    /// trigger a save against the currently-active hotbar group.
    /// </summary>
    /// <remarks>
    /// Caution must be taken to ensure invalid hotbar/slot IDs are not passed into this method, as game-provided
    /// sanity checks seem to not be present for this method.
    /// </remarks>
    /// <param name="hotbarId">The hotbar ID to set and write.</param>
    /// <param name="slotId">The slot ID to set and write.</param>
    /// <param name="commandType">The command type to set.</param>
    /// <param name="commandId">The command ID to set.</param>
    /// <param name="ignoreSharedHotbars">Unclear use, appears to ignore writing to shared slots if set.</param>
    /// <param name="allowSaveToPvP">If in PVP mode, allow saving to PVP hotbars. No effect if not in PVP mode.</param>
    [MemberFunction("E8 ?? ?? ?? ?? B0 01 EB BA")]
    public partial void SetAndSaveSlot(uint hotbarId, uint slotId, HotbarSlotType commandType, uint commandId,
        bool ignoreSharedHotbars = false, bool allowSaveToPvP = true);

    /// <summary>
    /// Attempt to add the specified action to the first free slot of the specified hotbar.
    /// </summary>
    /// <param name="hotbarId">The hotbar ID to save this action to. Is not validated; must be between 0 and 9 inclusive.</param>
    /// <param name="commandType">The command type to save.</param>
    /// <param name="commandId">The command ID to save.</param>
    /// <returns>Returns <c>true</c> if the save is successful, false otherwise.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? EB 62 83 7C 24")]
    public partial bool SetAndSaveFirstAvailableNormalSlot(uint hotbarId, HotbarSlotType commandType, uint commandId);

    /// <summary>
    /// Attempt to add the specified action to the first free slot of the specified cross hotbar.
    /// </summary>
    /// <param name="hotbarId">The cross hotbar ID to save this action to. is not validated; must be 0 to 8 inclusive.</param>
    /// <param name="commandType">The command type to save.</param>
    /// <param name="commandId">The command ID to save.</param>
    /// <returns>Returns <c>true</c> if the save is successful, false otherwise.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? EB 5D 83 7C 24")]
    public partial bool SetAndSaveFirstAvailableCrossSlot(uint hotbarId, HotbarSlotType commandType, uint commandId);

    /// <summary>
    /// Attempt to add the specified action to the first free slot of *any* normal hotbar.
    /// </summary>
    /// <param name="commandType">The command type to save.</param>
    /// <param name="commandId">The command ID to save.</param>
    /// <returns>Returns <c>true</c> if the save is successful, false otherwise.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 83 FD 0A")]
    public partial bool SetAndSaveFirstGloballyAvailableNormalSlot(HotbarSlotType commandType, uint commandId);

    /// <summary>
    /// Attempt to add the specified action to the first free slot of *any* normal hotbar.
    /// </summary>
    /// <inheritdoc cref="SetAndSaveFirstGloballyAvailableNormalSlot"/>
    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 83 FD 08")]
    public partial bool SetAndSaveFirstGloballyAvailableCrossSlot(HotbarSlotType commandType, uint commandId);

    /// <summary>
    /// Dumps a hotbar slot into a specific save slot within <see cref="SavedHotbars"/> and prepares a file save. Used
    /// to persist hotbar changes to disk. This method will attempt to resolve the proper index for saving depending on
    /// shared hotbar configuration and specified PvP state.
    /// </summary>
    /// <param name="classJobId">The ID of the ClassJob to persist this hotbar slot to.</param>
    /// <param name="hotbarId">The hotbar ID to modify.</param>
    /// <param name="slotId">The slot ID to modify.</param>
    /// <param name="slotSource">The source slot to dump to disk.</param>
    /// <param name="ignoreSharedHotbars">Unclear use, default to false. </param>
    /// <param name="isPvpSlot">If true, will save to the classJob's PvP SavedHotbars slots.</param>
    [MemberFunction("E8 ?? ?? ?? ?? EB 50 48 8B CF")]
    public partial void WriteSavedSlot(uint classJobId, uint hotbarId, uint slotId, HotbarSlot* slotSource,
        bool ignoreSharedHotbars, bool isPvpSlot);

    /// <summary>
    /// Clears the specified hotbar slot <em>and</em> the backing saved hotbar slot in the same ClassJob ID. 
    /// </summary>
    /// <param name="hotbarId">The saved hotbar ID to select.</param>
    /// <param name="slotId">The saved slot ID to clear.</param>
    [MemberFunction("E8 ?? ?? ?? ?? FF C3 83 FB 10 7C E3")]
    public partial void ClearSavedSlotById(uint hotbarId, uint slotId);

    /// <summary>
    /// Loads the specified saved hotbar from <see cref="SavedHotbars"/> into the live hotbar. Will automatically
    /// respect PVP mode. Will not reload from disk.
    /// </summary>
    /// <param name="classJobId">The ClassJob ID to retrieve a hotbar from.</param>
    /// <param name="hotbarId">The hotbar ID to retrieve.</param>
    [MemberFunction("E8 ?? ?? ?? ?? FF C7 83 FF 12 7C EA")]
    public partial void LoadSavedHotbar(uint classJobId, uint hotbarId);

    /// <summary>
    /// Get the Saved Hotbar Index for the PVP hotbar for a specific ClassJob, for use in <see cref="SavedHotbars"/>. 
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
    [MemberFunction("E8 ?? ?? ?? ?? 23 77 7C")]
    public partial uint GetClassJobIdForSavedHotbarIndex(int savedHotbarIndex);

    /// <summary>
    /// Sets the value of <see cref="DutyActionsPresent"/>.
    /// </summary>
    /// <param name="present">Whether to show/enable duty actions or not.</param>
    [MemberFunction("E8 ?? ?? ?? ?? 80 7B 28 01 75 1C")]
    public partial void SetDutyActionsPresent(bool present);

    /// <summary>
    /// Gets the specified <see cref="DutyActionSlot"/>, returning slot 0 if an invalid ID is passed in.
    /// </summary>
    /// <param name="index">The index of the slot (0 or 1) to retrieve.</param>
    /// <returns>Returns a pointer to the DutyActionSlot.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 4A 63 3C FB")]
    public partial DutyActionSlot* GetDutyActionSlot(uint index);

    /// <summary>
    /// Sets the specified DutyAction slot to hold the target action ID. Only takes effect if index is 0 or 1.
    /// </summary>
    /// <param name="index">The index of the DutyAction slot to edit.</param>
    /// <param name="actionId">The ID of the action to set in this slot.</param>
    [MemberFunction("E8 ?? ?? ?? ?? 40 FE C5 4D 8D 76 04")]
    public partial void SetDutyActionSlot(uint index, uint actionId);

    /// <summary>
    /// Executes the specified DutyAction slot. Does not appear to validate that the slot is in an executable state.
    /// </summary>
    /// <param name="index">The index of the slot to execute. If greater than 1, slot 0 is executed.</param>
    /// <returns>Returns true always (?)</returns>
    [MemberFunction("48 83 EC 28 85 D2 78 25")]
    public partial bool ExecuteDutyActionSlot(uint index);
}

[Flags]
public enum CrossHotbarFlags : ushort {
    ChangeSetActive = 1 << 0,
    Active = 1 << 1,
    LeftSideToggleFocus = 1 << 2,
    RightSideToggleFocus = 1 << 3,
    LeftSideHoldFocus = 1 << 4,
    RightSideHoldFocus = 1 << 5,
    FadeRestOfScreen = 1 << 6,
    PetHotbarActive = 1 << 7,
    ExpandedHoldLeftFocus = 1 << 8,
    ExpandedHoldRightFocus = 1 << 9,
    WXHBLeftFocus = 1 << 10,

    WXHBRightFocus = 1 << 14,
    EditMode = 1 << 15,

    // helpers
    LeftSideFocus = LeftSideHoldFocus | LeftSideToggleFocus,
    RightSideFocus = RightSideHoldFocus | RightSideToggleFocus,
}
