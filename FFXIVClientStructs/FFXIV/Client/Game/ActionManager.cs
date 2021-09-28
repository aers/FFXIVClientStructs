using System.Runtime.InteropServices;
using FFXIVClientStructs.Attributes;
using FFXIVClientStructs.FFXIV.Client.Game.Object;
using FFXIVClientStructs.FFXIV.Client.Graphics;

namespace FFXIVClientStructs.FFXIV.Client.Game {
    [StructLayout(LayoutKind.Explicit, Size = 0x810)]
    public unsafe partial struct ActionManager {
        [StaticAddress("48 8D 0D ?? ?? ?? ?? 33 C0 89 44 24 30")]
        public static partial ActionManager* Instance();

        [MemberFunction("E8 ?? ?? ?? ?? EB 64 B1 01")]
        public partial bool UseAction(ActionType actionType, uint actionID, uint targetID = 0xE000_0000, uint a4 = 0, uint a5 = 0, uint a6 = 0);

        [MemberFunction("E8 ?? ?? ?? ?? 3C 01 0F 85 ?? ?? ?? ?? EB 46")]
        public partial bool UseActionLocation(ActionType actionType, uint actionID, uint targetID = 0xE000_0000, Vector3* location = null, uint a4 = 0);
        
        [MemberFunction("E8 ?? ?? ?? ?? 83 BC 24 ?? ?? ?? ?? ?? 8B F0")]
        public partial uint GetActionStatus(ActionType actionType, uint actionID, uint targetID = 0xE000_0000, uint a4 = 1, uint a5 = 1);

        [MemberFunction("E8 ?? ?? ?? ?? 8B F8 3B DF")]
        public partial uint GetAdjustedActionId(uint actionID);

        [MemberFunction("E8 ?? ?? ?? ?? 8B D6 41 8B CF")]
        public partial float GetAdjustedRecastTime(ActionType actionType, uint actionID, byte a3 = 1);

        [MemberFunction("E8 ?? ?? ?? ?? 33 D2 49 8B CF 66 44 0F 6E C0")]
        public partial float GetAdjustedCastTime(ActionType actionType, uint actionID, byte a3 = 1, byte a4 = 0);

        [MemberFunction("E8 ?? ?? ?? ?? 0F 2F C7 0F 28 7C 24")]
        public partial float GetRecastTime(ActionType actionType, uint actionID);

        [MemberFunction("E8 ?? ?? ?? ?? F3 0F 5C F0 49 8B CD")]
        public partial float GetRecastTimeElapsed(ActionType actionType, uint actionID);

        [MemberFunction("E8 ?? ?? ?? ?? 3C 01 74 45")]
        public partial bool IsRecastTimerActive(ActionType actionType, uint actionID);

        [MemberFunction("E8 ?? ?? ?? ?? 8B CD 0F 28 F0", IsStatic = true)]
        public static partial float GetActionRange(uint actionId);
        
        [MemberFunction("E8 ?? ?? ?? ?? 85 C0 75 02 33 C0", IsStatic = true)]
        public static partial uint GetActionInRangeOrLoS(uint actionId, GameObject* sourceObject, GameObject* targetObject);

        [MemberFunction("E8 ?? ?? ?? ?? 0F B6 55 26", IsStatic = true)]
        public static partial int GetActionCost(ActionType actionType, uint actionId, byte a3, byte a4, byte a5, byte a6);

        [MemberFunction("E8 ?? ?? ?? ?? 85 C0 75 8C")]
        public partial uint CheckActionResources(ActionType actionType, uint actionId, void* actionData = null);
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