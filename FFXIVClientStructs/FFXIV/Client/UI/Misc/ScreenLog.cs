using FFXIVClientStructs.FFXIV.Client.Game.Character;
using FFXIVClientStructs.FFXIV.Component.Text;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

[GenerateInterop]
public unsafe partial struct ScreenLog {
    [MemberFunction("C7 02 ?? ?? ?? ?? 81 F9 ?? ?? ?? ??")]
    public static partial int ConvertLogMessageIdToScreenLogKind(int logMessageId, int* unkOption);
    
    [MemberFunction("E8 ?? ?? ?? ?? BF 18 00 00 00 41 F6 87")]
    public static partial void AddToScreenLogWithScreenLogKind(BattleChara* target, BattleChara* source, uint logKind, int logMessageId, byte unk, uint castId, uint statusId, int stackCount, int damageType);
    
    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? F3 0F 11 44 24")]
    public static partial void AddLogMessage(uint logMessageId, BattleChara* source, uint castId, uint statusId, int stackCount, int damageType, float maxLogDistance);
    
    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 81 FB E6 07 00 00")]
    public static partial void AddActionLogMessage(uint logMessageId, BattleChara* target, BattleChara* source, uint unk4, uint unk5, uint unk6, uint unk7, uint unk8, uint unk9, float maxLogDistance);
    
    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? B9 9E 64 00 00")]
    public static partial void AddToScreenLogWithLogMessageId(BattleChara* target, BattleChara* source, int logMessageId, byte unk, uint castId, uint statusId, int stackCount, int damageType);
}
