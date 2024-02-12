using FFXIVClientStructs.FFXIV.Client.Game.Object;
using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Client.Game;

// Client::Game::ActionManager
[StructLayout(LayoutKind.Explicit, Size = 0x7F0)]
public unsafe partial struct ActionManager {
    [StaticAddress("48 8D 0D ?? ?? ?? ?? F3 0F 10 13", 3)]
    public static partial ActionManager* Instance();

    [FieldOffset(0x60)] public ComboDetail Combo;
    [FieldOffset(0x68)] public bool ActionQueued;
    [FieldOffset(0x6C)] public ActionType QueuedActionType;
    [FieldOffset(0x70)] public uint QueuedActionId;
    [FieldOffset(0x78)] public GameObjectID QueuedTargetId;
    [FieldOffset(0x80)] public uint QueueType;

    [FieldOffset(0x13C)] public fixed uint BlueMageActions[24];

    [MemberFunction("E8 ?? ?? ?? ?? EB 64 B1 01")]
    public partial bool UseAction(ActionType actionType, uint actionID, ulong targetID = 0xE000_0000, uint a4 = 0, uint a5 = 0, uint a6 = 0, void* a7 = null);

    [MemberFunction("E8 ?? ?? ?? ?? 3C 01 0F 85 ?? ?? ?? ?? EB 46")]
    public partial bool UseActionLocation(ActionType actionType, uint actionID, ulong targetID = 0xE000_0000, Vector3* location = null, uint a4 = 0);

    [MemberFunction("E8 ?? ?? ?? ?? 3D ?? ?? ?? ?? 74 42")]
    public partial uint GetActionStatus(ActionType actionType, uint actionID, ulong targetID = 0xE000_0000, bool checkRecastActive = true, bool checkCastingActive = true, uint* outOptExtraInfo = null);

    [MemberFunction("E8 ?? ?? ?? ?? 8B F8 3B DF")]
    public partial uint GetAdjustedActionId(uint actionID);

    [MemberFunction("E8 ?? ?? ?? ?? 83 7F 4C 01 44 0F 28 C8")]
    public partial float GetRecastTime(ActionType actionType, uint actionID);

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

    [MemberFunction("E8 ?? ?? ?? ?? F3 0F 5C F0 49 8B CD")]
    public partial float GetRecastTimeElapsed(ActionType actionType, uint actionID);

    [MemberFunction("E8 ?? ?? ?? ?? 3C 01 74 19 FF C3")]
    public partial bool IsRecastTimerActive(ActionType actionType, uint actionID);

    [MemberFunction("E8 ?? ?? ?? ?? 8B D0 48 8B CD 8B F0")]
    public partial int GetRecastGroup(int type, uint actionID);

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

    [MemberFunction("40 53 48 83 EC ?? 48 63 DA 85 D2")]
    public partial RecastDetail* GetRecastGroupDetail(int recastGroup);

    [MemberFunction("E8 ?? ?? ?? ?? 85 C0 75 94")]
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
    /// <returns>Unknown.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 05 ?? ?? ?? ?? 48 8D 0D ?? ?? ?? ?? FF 50 18")]
    public partial nint StartCooldown(ActionType actionType, uint actionId);

    /// <summary>
    /// Check if a specific action is "off cooldown" and can be used again. This method will account for the slidecast
    /// window.
    /// </summary>
    /// <param name="actionType">The type of action to check.</param>
    /// <param name="actionId">The ID of the action to check.</param>
    /// <returns>Returns true if the action is off-cooldown or slidecastable.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 0F 84 ?? ?? ?? ?? F6 05 ?? ?? ?? ?? ?? 74 2C")]
    public partial bool IsActionOffCooldown(ActionType actionType, uint actionId);

    /// <summary>
    /// Check if the specified action's target is within range, if any. Will not check line of sight (performance reasons?).
    /// </summary>
    /// <param name="actionType">The action type to check against.</param>
    /// <param name="actionId">The action ID to check against.</param>
    /// <returns>Returns true if target constraints are satisfied, false otherwise.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 88 47 40 EB 36")]
    public partial bool IsActionTargetInRange(ActionType actionType, uint actionId);

    [MemberFunction("E8 ?? ?? ?? ?? F3 0F 11 43 ?? 80 3B 00")]
    public static partial float GetActionRange(uint actionId);

    [MemberFunction("E8 ?? ?? ?? ?? 85 C0 75 02 33 C0")]
    public static partial uint GetActionInRangeOrLoS(uint actionId, GameObject* sourceObject, GameObject* targetObject);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 5C 24 ?? 48 83 C4 30 5F C3 33 D2")]
    public static partial int GetActionCost(ActionType actionType, uint actionId, byte a3, byte a4, byte a5, byte a6);

    [MemberFunction("E8 ?? ?? ?? ?? 8B D6 41 8B CF")]
    public static partial int GetAdjustedRecastTime(ActionType actionType, uint actionID, byte a3 = 1);

    [MemberFunction("E8 ?? ?? ?? ?? 85 C0 0F 84 ?? ?? ?? ?? 33 C9")]
    public static partial int GetAdjustedCastTime(ActionType actionType, uint actionID, byte a3 = 1, byte* a4 = null);

    [MemberFunction("E8 ?? ?? ?? ?? 33 DB 8B C8")]
    public static partial ushort GetMaxCharges(uint actionId, uint level); // 0 for current level

    /// <summary>
    /// Gets the number of charges currently accessible to the player for the specified action. For actions that do not
    /// use charges, this method will cap at 1.
    /// </summary>
    /// <param name="actionId">The Action ID to check against.</param>
    /// <returns>Returns a uint.</returns>
    [MemberFunction("48 89 5C 24 ?? 48 89 74 24 ?? 57 48 83 EC 50 8B FA 44 8B C2")]
    public partial uint GetCurrentCharges(uint actionId);

    [MemberFunction("48 8B C4 48 89 68 ?? 48 89 70 ?? 41 56 48 83 EC")]
    public partial void AssignBlueMageActionToSlot(int slot, uint actionId);

    [MemberFunction("E8 ?? ?? ?? ?? 89 06 33 D2")]
    public partial uint GetActiveBlueMageActionInSlot(int slot);

    [MemberFunction("48 89 6C 24 ?? 48 89 74 24 ?? 41 56 48 83 EC ?? 48 63 EA 4C 8B F1")]
    public partial void SwapBlueMageActionSlots(int slotA, int slotB);

    [MemberFunction("40 53 55 57 48 81 EC ?? ?? ?? ?? 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 84 24 ?? ?? ?? ?? 33 DB")]
    public partial bool SetBlueMageActions(uint* actionArray);

    /// <summary>
    /// Check whether this action should be highlighted (showing "ants") in the UI or not.
    /// </summary>
    /// <param name="actionType">The action type to check.</param>
    /// <param name="actionId">The action ID to check.</param>
    /// <returns>Returns true if ants should be drawn, false otherwise.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 48 8B CB 88 47 41")]
    public partial bool IsActionHighlighted(ActionType actionType, uint actionId);

    [MemberFunction("48 89 5C 24 ?? 57 48 83 EC 20 48 8B DA 8B F9 E8 ?? ?? ?? ?? 4C 8B C3")]
    public static partial bool CanUseActionOnTarget(uint actionId, GameObject* target);

    /// <summary>
    /// Returns the ID of the action present at the specified Duty Action slot.
    /// </summary>
    /// <param name="dutyActionSlot">The Duty Action slot number (0 or 1) to look up.</param>
    /// <returns>Returns an Action ID.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? EB 17 33 C9")]
    public static partial uint GetDutyActionId(ushort dutyActionSlot);
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
    [FieldOffset(0x4)] public uint ActionID;

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
