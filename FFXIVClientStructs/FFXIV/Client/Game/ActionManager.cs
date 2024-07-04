using System.Numerics;
using FFXIVClientStructs.FFXIV.Client.Game.Object;

namespace FFXIVClientStructs.FFXIV.Client.Game;

// Client::Game::ActionManager
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x7F0)]
public unsafe partial struct ActionManager {
    [StaticAddress("48 8D 0D ?? ?? ?? ?? F3 0F 10 13", 3)]
    public static partial ActionManager* Instance();

    [FieldOffset(0x08)] public float AnimationLock;
    [FieldOffset(0x0C)] public float CompanionActionCooldown; // companion (minion) summon action has 1.0s cooldown
    [FieldOffset(0x10)] public float BuddyActionCooldown; // buddy (chocobo) actions have 0.5s cooldown
    [FieldOffset(0x14)] public float PetActionCooldown; // pet (carbuncle) actions have 0.5s cooldown
    [FieldOffset(0x18)] public byte NumPetActionsOnCooldown; // you can execute 2 pet actions in short succession

    // the fields below are related to the currently cast spell; there is a substructure at 0x20 with empty constructor with unknown size, they could be part of it
    [FieldOffset(0x24)] public uint CastSpellId; // result of GetSpellIdForAction for used action
    [FieldOffset(0x28)] public ActionType CastActionType;
    [FieldOffset(0x2C)] public uint CastActionId;
    [FieldOffset(0x30)] public float CastTimeElapsed;
    [FieldOffset(0x34)] public float CastTimeTotal;
    [FieldOffset(0x38)] public GameObjectId CastTargetId;
    [FieldOffset(0x40)] public Vector3 CastTargetPosition;
    [FieldOffset(0x50)] public float CastRotation; // in radians

    [FieldOffset(0x60)] public ComboDetail Combo;
    [FieldOffset(0x68)] public bool ActionQueued;
    [FieldOffset(0x6C)] public ActionType QueuedActionType;
    [FieldOffset(0x70)] public uint QueuedActionId;
    [FieldOffset(0x78)] public GameObjectId QueuedTargetId;
    [FieldOffset(0x80)] public UseActionMode QueueType;
    [FieldOffset(0x84)] public uint QueuedComboRouteId;

    // the fields below are related to area-targeting mode
    [FieldOffset(0x88)] public uint AreaTargetingActionId;
    [FieldOffset(0x8C)] public ActionType AreaTargetingActionType;
    [FieldOffset(0x90)] public uint AreaTargetingSpellId;
    // 0x94: int argument to area-targeting start function, always 0?
    [FieldOffset(0x98)] public GameObjectId AreaTargetingExecuteAtObject; // if != 0xE0000000, on the next update area-targeted action will be executed at this object
    // 0xA0: bool related to area targeting
    // 0xA8: vfx* related to area targeting
    // 0xB0: vfx* related to area targeting
    [FieldOffset(0xB8)] public bool AreaTargetingExecuteAtCursor; // if true, on the next update area-targeted action will be executed at cursor
    // 0xBC: uint related to area targeting, can be 0/1/2

    [FieldOffset(0x110)] public ushort LastUsedActionSequence;
    [FieldOffset(0x112)] public ushort LastHandledActionSequence;
    [FieldOffset(0x114), FixedSizeArray] internal FixedSizeArray24<uint> _blueMageActions;
    [FieldOffset(0x174), FixedSizeArray] internal FixedSizeArray80<RecastDetail> _cooldowns;

    [FieldOffset(0x7D8)] public float DistanceToTargetHitbox; // distance to target minus both self & target hitbox radius, clamped to 0

    /// <summary>
    /// Initiate action execution.
    /// </summary>
    /// <remarks>
    /// If called shortly before action is available (due to cooldown or animation lock), action is queued.
    /// If action is area-targeted, starts area targeting mode rather than executing it immediately.
    /// </remarks>
    /// <param name="actionType">Type of action to execute.</param>
    /// <param name="actionId">Id of action to execute.</param>
    /// <param name="targetId">Intended target for the action.</param>
    /// <param name="extraParam">For items - inventory slot to use from (bag id in high byte, slot id in low byte), or 0xFFFF if unspecified (e.g. used from hotbar).</param>
    /// <param name="mode">Special action execution mode.</param>
    /// <param name="comboRouteId"></param>
    /// <param name="outOptAreaTargeted">If non-null, will be set to true if area-targeting mode was started instead of executing an action.</param>
    /// <returns></returns>
    [MemberFunction("E8 ?? ?? ?? ?? B0 01 EB B6")]
    public partial bool UseAction(ActionType actionType, uint actionId, ulong targetId = 0xE000_0000, uint extraParam = 0, UseActionMode mode = UseActionMode.None, uint comboRouteId = 0, bool* outOptAreaTargeted = null);

    /// <summary>
    /// Actually execute the action right now, if possible. This skips queueing, area targeting mode, etc.
    /// </summary>
    /// <remarks>
    /// The function name is a bit misleading - this function is called internally for all actions, not necessarily location-targeted ones.
    /// This function verifies that action can actually be cast (checks LoS, various states that could prevent successful cast, etc).
    /// This expects input action to be already adjusted - i.e. don't pass General actions here, it won't work properly. See code for UseAction for details.
    /// </remarks>
    /// <param name="actionType">Type of action to execute. Should be adjusted.</param>
    /// <param name="actionId">Id of action to execute. Should be adjusted.</param>
    /// <param name="targetId">Intended target for the action. Note that real target can be modified (e.g. replaced with player for self-targeted actions, etc) by ResolveTarget.</param>
    /// <param name="location">Target position, important for area-targeted spells. Be careful if passing null - game doesn't really expect that and might dereference it in some code paths!</param>
    /// <param name="extraParam">See UseAction.</param>
    /// <returns></returns>
    [MemberFunction("E8 ?? ?? ?? ?? 41 3A C5 0F 85 ?? ?? ?? ??")]
    public partial bool UseActionLocation(ActionType actionType, uint actionId, ulong targetId = 0xE000_0000, Vector3* location = null, uint extraParam = 0);

    [MemberFunction("E8 ?? ?? ?? ?? 8B 93 ?? ?? ?? ?? 85 C0")]
    public partial uint GetActionStatus(ActionType actionType, uint actionId, ulong targetId = 0xE000_0000, bool checkRecastActive = true, bool checkCastingActive = true, uint* outOptExtraInfo = null);

    [MemberFunction("E8 ?? ?? ?? ?? 89 03 8B 03")]
    public partial uint GetAdjustedActionId(uint actionId);

    [MemberFunction("40 53 48 83 EC ?? FF C9")]
    public static partial uint GetSpellIdForAction(ActionType actionType, uint actionId);

    [MemberFunction("E8 ?? ?? ?? ?? 83 7F 4C 01 44 0F 28 C8")]
    public partial float GetRecastTime(ActionType actionType, uint actionId);

    /// <summary>
    /// Gets the recast time (see <see cref="RecastDetail.Total"/> for a specific recast group.
    /// </summary>
    /// <remarks>
    /// Compared to reading the struct directly, this method will correct cases where multi-charge actions are still
    /// locked to a single charge at the player's current level.
    /// </remarks>
    /// <param name="recastGroupId">The recast group ID to get the recast time for.</param>
    /// <returns>Returns the time until this action is "fully charged."</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 0F 28 F8 F3 0F 5C FE")]
    public partial float GetRecastTimeForGroup(int recastGroupId);

    [MemberFunction("E8 ?? ?? ?? ?? F3 0F 5C F0 33 F6")]
    public partial float GetRecastTimeElapsed(ActionType actionType, uint actionId);

    [MemberFunction("E8 ?? ?? ?? ?? 3C 01 74 19 FF C3")]
    public partial bool IsRecastTimerActive(ActionType actionType, uint actionId);

    [MemberFunction("E8 ?? ?? ?? ?? 8B D0 48 8B CD 8B F0")]
    public partial int GetRecastGroup(int type, uint actionId);

    /// <summary>
    /// Gets the additional recast group for a specific action.
    /// </summary>
    /// <remarks>
    /// Appears to be used for actions that both have their own cooldown in addition to adhering to GCD.
    /// </remarks>
    /// <param name="actionType">The action type to look up.</param>
    /// <param name="actionId">The action ID to look up.</param>
    /// <returns>A cooldown group ID, or -1 if invalid.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 8B 4F 44 33 D2")]
    public partial int GetAdditionalRecastGroup(ActionType actionType, uint actionId);

    [MemberFunction("40 53 48 83 EC 20 48 63 DA 85 D2 78 50")]
    public partial RecastDetail* GetRecastGroupDetail(int recastGroup);

    [MemberFunction("E8 ?? ?? ?? ?? 85 C0 75 15 4C 8B C6")]
    public partial uint CheckActionResources(ActionType actionType, uint actionId, void* actionData = null);

    /// <summary>
    /// Start a cooldown cycle for the specified action. Upon calling, the game will begin to track state in the
    /// relevant <see cref="RecastDetail"/>, which can be retrieved separately. Consult that struct's documentation for
    /// more information.
    /// </summary>
    /// <remarks>
    /// This method should not be called by developers and is instead provided for hooking and API completeness.
    /// </remarks>
    /// <param name="actionType">The type of action (generally, Spell) to trigger a cooldown for.</param>
    /// <param name="actionId">The ID of the action to trigger a cooldown for.</param>
    [MemberFunction("48 89 6C 24 ?? 56 57 41 56 48 83 EC 30 41 8B F0")]
    public partial void StartCooldown(ActionType actionType, uint actionId);

    /// <summary>
    /// Check if a specific action is "off cooldown" and can be used again. This method will account for the slidecast
    /// window.
    /// </summary>
    /// <param name="actionType">The type of action to check.</param>
    /// <param name="actionId">The ID of the action to check.</param>
    /// <returns>Returns true if the action is off-cooldown or slidecastable.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 ?? 8B 84 24 ?? ?? ?? ?? 89 46")]
    public partial bool IsActionOffCooldown(ActionType actionType, uint actionId);

    /// <summary>
    /// Check if the specified action's target is within range, if any. Will not check line of sight (performance reasons?).
    /// </summary>
    /// <param name="actionType">The action type to check against.</param>
    /// <param name="actionId">The action ID to check against.</param>
    /// <returns>Returns true if target constraints are satisfied, false otherwise.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 88 46 40 EB 2F")]
    public partial bool IsActionTargetInRange(ActionType actionType, uint actionId);

    [MemberFunction("E8 ?? ?? ?? ?? F3 41 0F 11 07 80 3B 00")]
    public static partial float GetActionRange(uint actionId);

    [MemberFunction("E8 ?? ?? ?? ?? 85 C0 75 02 33 C0")]
    public static partial uint GetActionInRangeOrLoS(uint actionId, GameObject* sourceObject, GameObject* targetObject);

    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 CB 3B C8")]
    public static partial int GetActionCost(ActionType actionType, uint actionId, byte a3, byte a4, byte a5, byte a6);

    /// <summary>
    /// Calculate cooldown for an action, in milliseconds, optionally adjusted by various class mechanics.
    /// </summary>
    /// <param name="actionType">The type of action to check.</param>
    /// <param name="actionId">The ID of the action to check.</param>
    /// <param name="applyClassMechanics">If true, applies various class mechanics (traits, etc).</param>
    /// <returns></returns>
    [MemberFunction("E8 ?? ?? ?? ?? 8B D6 8B CD")]
    public static partial int GetAdjustedRecastTime(ActionType actionType, uint actionId, bool applyClassMechanics = true);

    /// <summary>
    /// Calculate cast time for an action, in milliseconds, adjusted by player stats (haste, sks/sps, etc.) and optionally various class mechanics.
    /// </summary>
    /// <param name="actionType">The type of action to check.</param>
    /// <param name="actionId">The ID of the action to check.</param>
    /// <param name="applyProcs">If true, applies various class mechanics (procs, swiftcast, etc).</param>
    /// <param name="outOptProc">If non-null and applyProcs is true, will be set to applied proc.</param>
    /// <returns></returns>
    [MemberFunction("E8 ?? ?? ?? ?? 45 33 C0 33 D2 48 8B CF 66 0F 6E F8")]
    public static partial int GetAdjustedCastTime(ActionType actionType, uint actionId, bool applyProcs = true, CastTimeProc* outOptProc = null);

    [MemberFunction("E8 ?? ?? ?? ?? 33 DB 8B C8")]
    public static partial ushort GetMaxCharges(uint actionId, uint level); // 0 for current level

    /// <summary>
    /// Gets the number of charges currently accessible to the player for the specified action. For actions that do not
    /// use charges, this method will cap at 1.
    /// </summary>
    /// <param name="actionId">The Action ID to check against.</param>
    /// <returns>Returns a uint.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 8B C8 83 E9 01 74 1E")]
    public partial uint GetCurrentCharges(uint actionId);

    [MemberFunction("E8 ?? ?? ?? ?? B0 01 EB D6")]
    public partial void AssignBlueMageActionToSlot(int slot, uint actionId);

    [MemberFunction("E8 ?? ?? ?? ?? 85 C0 74 33 FF C3")]
    public partial uint GetActiveBlueMageActionInSlot(int slot);

    [MemberFunction("48 89 6C 24 ?? 48 89 74 24 ?? 57 48 83 EC 50 48 63 F2")]
    public partial void SwapBlueMageActionSlots(int slotA, int slotB);

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 0F 84 ?? ?? ?? ?? 49 8B 4E 10 48 8B 01 FF 90 ?? ?? ?? ??")]
    public partial bool SetBlueMageActions(uint* actionArray);

    /// <summary>
    /// Check whether this action should be highlighted (showing "ants") in the UI or not.
    /// </summary>
    /// <param name="actionType">The action type to check.</param>
    /// <param name="actionId">The action ID to check.</param>
    /// <returns>Returns true if ants should be drawn, false otherwise.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 88 46 41 80 BF")]
    public partial bool IsActionHighlighted(ActionType actionType, uint actionId);

    [MemberFunction("48 89 5C 24 ?? 57 48 83 EC 20 48 8B DA 8B F9 E8 ?? ?? ?? ?? 4C 8B C3")]
    public static partial bool CanUseActionOnTarget(uint actionId, GameObject* target);

    /// <summary>
    /// Returns the ID of the action present at the specified Duty Action slot.
    /// </summary>
    /// <param name="dutyActionSlot">The Duty Action slot number (0 or 1) to look up.</param>
    /// <returns>Returns an Action ID.</returns>
    [MemberFunction("E9 ?? ?? ?? ?? 33 C9 E9")]
    public static partial uint GetDutyActionId(ushort dutyActionSlot);

    /// <summary>
    /// Calculate target position for area-targeted spell corresponding to current cursor position.
    /// </summary>
    /// <param name="outPosition">If successful, contains coordinates of the point on the ground.</param>
    /// <returns>Whether intersection with ground was found.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 44 8B 84 24 80 00 00 00 33 C0")]
    public partial bool GetGroundPositionForCursor(Vector3* outPosition);

    /// <summary>
    /// If 'auto face target on action execution' config option is enabled, rotate character to face target.
    /// </summary>
    /// <param name="position">Target position</param>
    /// <param name="followTargetId">?</param>
    [MemberFunction("48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 57 48 83 EC ?? 48 8B 3D ?? ?? ?? ?? 49 8B E8")]
    public partial void AutoFaceTargetPosition(Vector3* position, ulong followTargetId = 0xE000_0000);

    /// <summary>
    /// Called every frame, responsible for ticking down timers (cooldowns, animation lock, etc) and executing queued action as soon as possible.
    /// </summary>
    [MemberFunction("48 8B C4 48 89 58 ?? 56 48 81 EC ?? ?? ?? ?? 48 8B 35")]
    public partial void Update();

    /// <summary>
    /// Determine character's category for action targeting purposes; this is used by the game to determine whether a spell can be used on that target.
    /// </summary>
    [MemberFunction("40 53 48 83 EC 20 48 8B 01 48 8B D9 FF 50 08 8B 15")]
    public static partial TargetCategory ClassifyTarget(Character.Character* target);

    public enum CastTimeProc : byte {
        None = 0,
        Firestarter = 1, // THM/BLM
        //Thundercloud = 2, // THM/BLM, gone in 7.0
        Swiftcast = 3,
        Lightspeed = 4, // AST
        Dualcast = 5, // RDM
        Abridged = 6, // AST
        Triplecast = 7, // BLM
        DemiBahamut = 8, // SMN
        Requiescat = 9, // PLD
        DemiPhoenix = 11, // SMN
        EnhancedHarpe = 12, // RPR
        SoulsowOutOfCombat = 13, // RPR
        Acceleration = 14, // RDM
        DivineMight = 15, // PLD
        MotifOutOfCombat = 18, // PCT
        RainbowBright = 19, // PCT
    }

    public enum UseActionMode {
        None = 0, // usual action execution, e.g. a hotbar button press
        Queue = 1, // previously queued action is now ready and is being executed (=> will ignore queue)
        Macro = 2, // action execution originating from a macro (=> won't be queued)
        Combo = 3, // action execution is from a single-button combo
    }

    public enum TargetCategory {
        Self = 0,
        Party = 1,
        Alliance = 2,
        Enemy = 3,
        Friendly = 4,
        OwnPet = 5,
        PartyPet = 6,
        UnkPVP = 7, // ??? something pvp related, can only happen in pvp lobby
    }
}

/// <summary>
/// A struct representing information about recast timers/cooldowns for a specific RecastGroup. A recast group may be
/// shared between one (or more) actions, depending on the group in question.
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 0x14)]
public struct RecastDetail {
    /// <summary>
    /// A byte representing if this recast group is currently "active." When this is a non-zero value (true), this
    /// recast group is actively in cooldown.
    /// </summary>
    [FieldOffset(0x0)] public byte IsActive;

    /// <summary>
    /// The last Action ID that triggered an update for this recast group. 
    /// </summary>
    [FieldOffset(0x4)] public uint ActionId;

    /// <summary>
    /// The current "elapsed" time of this action's recharge. For most actions, this value will be set to zero when the
    /// action is used. For actions with multiple charges, this value will give "credit" for unspent actions.
    /// </summary>  
    /// <remarks>
    /// For multi-charge actions, it helps to think of this field as representing the current value of a resource gauge.
    /// This value represents the "current level" of the resource gauge, with each second adding 1 unit to the gauge up
    /// until the maximum as defined in the <see cref="Total"/> field.
    /// <para />
    /// When a normal action is cast, this gauge is "depleted" to zero. When a multi-charge action is cast, however,
    /// the appropriate value (defined by the action, but generally the recharge time) is subtracted from this value.
    /// </remarks>
    [FieldOffset(0x8)] public float Elapsed;

    /// <summary>
    /// The total number of seconds this recast group takes to go from "fully exhausted" to "fully charged." For most
    /// actions, this will simply be the adjusted recast time from <see cref="ActionManager.GetAdjustedRecastTime"/>
    /// (which displays in the tooltip UI as the "recast time"). Multi-charge actions such as Ninja's Mudra will show
    /// the total charge time (the Adjusted Recast Time multiplied by the number of charges this action has at max
    /// level).
    /// </summary>
    /// <remarks>
    /// Note that the total value shown here depends on the last action used. For example, if a specific action is
    /// bound to the GCD but is faster/slower than the normal GCD, this value will be set accordingly.
    /// <para />
    /// Continuing the resource gauge analogy from <see cref="Elapsed"/>, this field would represent the "cap" of the
    /// resource gauge. For normal actions, the resource gauge must be completely filled before the action can be used
    /// again. Multi-charge actions will instead allow the gauge to charge to the maximum number of actions allowed.
    /// <para />
    /// It is recommended to use <see cref="ActionManager.GetRecastTime"/> over this field, as it handles an edge case
    /// in charge management.
    /// </remarks>
    [FieldOffset(0xC)] public float Total;
}

[StructLayout(LayoutKind.Explicit, Size = 0x8)]
public struct ComboDetail {
    [FieldOffset(0x00)] public float Timer;
    [FieldOffset(0x04)] public uint Action;
}

public enum ActionType : byte {
    None = 0x00,
    Action = 0x01, // Spell, Weaponskill, Ability. Confusing name, I know.
    Item = 0x02,
    KeyItem = 0x03,
    Ability = 0x04, // Not in UseAction (??)
    GeneralAction = 0x05,
    BuddyAction = 0x06,
    MainCommand = 0x07,
    Companion = 0x08,
    CraftAction = 0x09,
    Unk_10 = 0x0A, // Fishing per Sapphire? Something to do with items.
    PetAction = 0x0B,
    Unk_12 = 0x0C, // Not in UseAction. Sapphire says CompanyAction, but not actually triggered.
    Mount = 0x0D,
    PvPAction = 0x0E,
    FieldMarker = 0x0F,
    ChocoboRaceAbility = 0x10,
    ChocoboRaceItem = 0x11,
    Unk_18 = 0x12, // Not in UseAction (?)
    BgcArmyAction = 0x13,
    Ornament = 0x14,
}
