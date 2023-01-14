using FFXIVClientStructs.FFXIV.Client.Game.Object;
using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Client.Game;

[StructLayout(LayoutKind.Explicit, Size = 0x7F0)]
public unsafe partial struct ActionManager
{
    [FieldOffset(0x60)] public ComboDetail Combo;
    [FieldOffset(0x13C)] public fixed uint BlueMageActions[24];

    [StaticAddress("48 8D 0D ?? ?? ?? ?? F3 0F 10 13", 3)]
    public static partial ActionManager* Instance();

    [MemberFunction("E8 ?? ?? ?? ?? EB 64 B1 01")]
    public partial bool UseAction(ActionType actionType, uint actionID, long targetID = 0xE000_0000, uint a4 = 0, uint a5 = 0, uint a6 = 0, void* a7 = null);

    [MemberFunction("E8 ?? ?? ?? ?? 3C 01 0F 85 ?? ?? ?? ?? EB 46")]
    public partial bool UseActionLocation(ActionType actionType, uint actionID, long targetID = 0xE000_0000, Vector3* location = null, uint a4 = 0);

    [MemberFunction("E8 ?? ?? ?? ?? 3D ?? ?? ?? ?? 74 42")]
    public partial uint GetActionStatus(ActionType actionType, uint actionID, long targetID = 0xE000_0000, bool checkRecastActive = true, bool checkCastingActive = true, uint* outOptExtraInfo = null);

    [MemberFunction("E8 ?? ?? ?? ?? 8B F8 3B DF")]
    public partial uint GetAdjustedActionId(uint actionID);

    [MemberFunction("E8 ?? ?? ?? ?? 83 7F 4C 01 44 0F 28 C8")]
    public partial float GetRecastTime(ActionType actionType, uint actionID);

    [MemberFunction("E8 ?? ?? ?? ?? F3 0F 5C F0 49 8B CD")]
    public partial float GetRecastTimeElapsed(ActionType actionType, uint actionID);

    [MemberFunction("E8 ?? ?? ?? ?? 3C 01 74 19 FF C3")]
    public partial bool IsRecastTimerActive(ActionType actionType, uint actionID);

    [MemberFunction("E8 ?? ?? ?? ?? 8B D0 48 8B CD 8B F0")]
    public partial int GetRecastGroup(int type, uint actionID);

    [MemberFunction("40 53 48 83 EC ?? 48 63 DA 85 D2")]
    public partial RecastDetail* GetRecastGroupDetail(int recastGroup);

    [MemberFunction("E8 ?? ?? ?? ?? 85 C0 75 ?? 83 FF ?? 0F 85")]
    public partial uint CheckActionResources(ActionType actionType, uint actionId, void* actionData = null);

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

    [MemberFunction("48 8B C4 48 89 68 ?? 48 89 70 ?? 41 56 48 83 EC")]
    public partial void AssignBlueMageActionToSlot(int slot, uint actionId);

    [MemberFunction("E8 ?? ?? ?? ?? 89 06 33 D2")]
    public partial uint GetActiveBlueMageActionInSlot(int slot);

    [MemberFunction("48 89 6C 24 ?? 48 89 74 24 ?? 41 56 48 83 EC ?? 48 63 EA 4C 8B F1")]
    public partial void SwapBlueMageActionSlots(int slotA, int slotB);

    [MemberFunction("40 53 55 57 48 81 EC ?? ?? ?? ?? 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 84 24 ?? ?? ?? ?? 33 DB")]
    public partial bool SetBlueMageActions(uint* actionArray);
}

[StructLayout(LayoutKind.Explicit, Size = 0x14)]
public struct RecastDetail
{
    [FieldOffset(0x0)] public byte IsActive;
    [FieldOffset(0x4)] public uint ActionID;
    [FieldOffset(0x8)] public float Elapsed;
    [FieldOffset(0xC)] public float Total;
}

[StructLayout(LayoutKind.Explicit, Size = 0x8)]
public struct ComboDetail {
    [FieldOffset(0x00)] public float Timer;
    [FieldOffset(0x04)] public uint Action;
}

public enum ActionType : byte
{
    None = 0x00,
    Spell = 0x01,
    Item = 0x02,
    KeyItem = 0x03,
    Ability = 0x04,
    General = 0x05,
    Companion = 0x06,
    Unk_7 = 0x07,
    Unk_8 = 0x08, //something with Leve?
    CraftAction = 0x09,
    MainCommand = 0x0A,
    PetAction = 0x0B,
    Unk_12 = 0x0C,
    Mount = 0x0D,
    PvPAction = 0x0E,
    Waymark = 0x0F,
    ChocoboRaceAbility = 0x10,
    ChocoboRaceItem = 0x11,
    Unk_18 = 0x12,
    SquadronAction = 0x13,
    Accessory = 0x14
}
