using FFXIVClientStructs.FFXIV.Client.Game.Character;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

[GenerateInterop]
public unsafe partial struct ScreenLog {
    [MemberFunction("C7 02 ?? ?? ?? ?? 81 F9 ?? ?? ?? ??")]
    public static partial int ConvertLogMessageIdToScreenLogKind(int logMessageId, int* unkOption);
    
    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? B9 9E 64 00 00")]
    public static partial void AddToScreenLogWithLogMessageId(BattleChara* target, BattleChara* caster, int logMessageId, byte unk, int castId, int statusId, int stackCount, int damageType);
}
