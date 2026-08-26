using FFXIVClientStructs.FFXIV.Client.Game;
using FFXIVClientStructs.FFXIV.Client.Game.Character;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

[GenerateInterop]
public unsafe partial struct  BattleLog {
    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 81 FB E6 07 00 00")]
    public static partial void AddActionLogMessage(uint logMessageId, BattleChara* target, BattleChara* source, ActionType actionType, uint actionId, int textParameterValue1, int textParameterValue2, int textParameterValue3, int textParameterValue4, int textParameterValue5, float maxLogDistance);
    
    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? F3 0F 11 44 24")]
    public static partial void AddLogMessage(uint logMessageId, BattleChara* source, int textParameterValue1, int textParameterValue2, int textParameterValue3, int textParameterValue4, float maxLogDistance);
}
