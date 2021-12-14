using System.Runtime.InteropServices;
using FFXIVClientStructs.Attributes;
using FFXIVClientStructs.FFXIV.Client.Game.Object;
using FFXIVClientStructs.FFXIV.Client.Graphics;

namespace FFXIVClientStructs.FFXIV.Client.Game {
    [StructLayout(LayoutKind.Explicit, Size = 0x810)]
    public unsafe partial struct ActionManager {
        [StaticAddress("48 8D 0D ?? ?? ?? ?? F3 0F 10 13")]
        public static partial ActionManager* Instance();

        [MemberFunction("E8 ?? ?? ?? ?? EB 64 B1 01")]
        public partial bool UseAction(ActionType actionType, uint actionID, uint targetID = 0xE000_0000, uint a4 = 0, uint a5 = 0, uint a6 = 0, void* a7 = null);

        [MemberFunction("E8 ?? ?? ?? ?? 3C 01 0F 85 ?? ?? ?? ?? EB 46")]
        public partial bool UseActionLocation(ActionType actionType, uint actionID, uint targetID = 0xE000_0000, Vector3* location = null, uint a4 = 0);
        
        [MemberFunction("E8 ?? ?? ?? ?? 83 BC 24 ?? ?? ?? ?? ?? 8B F0")]
        public partial uint GetActionStatus(ActionType actionType, uint actionID, uint targetID = 0xE000_0000, uint a4 = 1, uint a5 = 1);

        [MemberFunction("E8 ?? ?? ?? ?? 8B F8 3B DF")]
        public partial uint GetAdjustedActionId(uint actionID);

        [MemberFunction("E8 ?? ?? ?? ?? 8B D6 41 8B CF")]
        public partial float GetAdjustedRecastTime(ActionType actionType, uint actionID, byte a3 = 1);

        [MemberFunction("E8 ?? ?? ?? ?? 33 D2 49 8B CE 66 44 0F 6E C0")]
        public partial float GetAdjustedCastTime(ActionType actionType, uint actionID, byte a3 = 1, byte a4 = 0);

        [MemberFunction("E8 ?? ?? ?? ?? 0F 2F C7 0F 28 7C 24")]
        public partial float GetRecastTime(ActionType actionType, uint actionID);

        [MemberFunction("E8 ?? ?? ?? ?? F3 0F 5C F0 49 8B CD")]
        public partial float GetRecastTimeElapsed(ActionType actionType, uint actionID);

        [MemberFunction("E8 ?? ?? ?? ?? 3C 01 74 45")]
        public partial bool IsRecastTimerActive(ActionType actionType, uint actionID);

        [MemberFunction("E8 ?? ?? ?? ?? 8B D0 48 8B CD 8B F0")]
        public partial int GetRecastGroup(int type, uint actionID);

        [MemberFunction("E8 ?? ?? ?? ?? 0F 57 FF 48 85 C0")]
        public partial RecastDetail* GetRecastGroupDetail(int recastGroup);

        [MemberFunction("E8 ?? ?? ?? ?? F3 0F 11 43 ?? 80 3B 00", IsStatic = true)]
        public static partial float GetActionRange(uint actionId);
        
        [MemberFunction("E8 ?? ?? ?? ?? 85 C0 75 02 33 C0", IsStatic = true)]
        public static partial uint GetActionInRangeOrLoS(uint actionId, GameObject* sourceObject, GameObject* targetObject);

        [MemberFunction("E8 ?? ?? ?? ?? 48 8B 5C 24 ?? 48 83 C4 30 5F C3 33 D2", IsStatic = true)]
        public static partial int GetActionCost(ActionType actionType, uint actionId, byte a3, byte a4, byte a5, byte a6);

        [MemberFunction("E8 ?? ?? ?? ?? 85 C0 75 75 83 FF 03")]
        public partial uint CheckActionResources(ActionType actionType, uint actionId, void* actionData = null);

        [MemberFunction("E8 ?? ?? ?? ?? 33 DB 8B C8", IsStatic = true)]
        public static partial ushort GetMaxCharges(uint actionId, uint level); // 0 for current level
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x14)]
    public struct RecastDetail {
        [FieldOffset(0x0)] public byte IsActive;
        [FieldOffset(0x4)] public uint ActionID;
        [FieldOffset(0x8)] public float Elapsed;
        [FieldOffset(0xC)] public float Total;
    }

    public enum ActionType : byte {
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
}