using FFXIVClientStructs.FFXIV.Client.Game.Character;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

[GenerateInterop]
public unsafe partial struct ScreenLog {
    [MemberFunction("C7 02 ?? ?? ?? ?? 81 F9 ?? ?? ?? ??")]
    public static partial int ConvertLogMessageIdToScreenLogKind(int logMessageId, int* unkOption);
    
    /// <summary>
    /// Add a flytext with the given LogKind.
    /// </summary>
    /// <param name="target">Target of the flytext.</param>
    /// <param name="source">Source of the flytext.</param>
    /// <param name="logKind">What kind of log is it?</param>
    /// <param name="unkOption">Unk.</param>
    /// <param name="param1">FlyText formatter param 1.</param>
    /// <param name="param2">FlyText formatter param 2.</param>
    /// <param name="param3">FlyText formatter param 3.</param>
    /// <param name="param4">FlyText formatter param 4.</param>
    /// <param name="param5">FlyText formatter param 5.</param>
    [MemberFunction("E8 ?? ?? ?? ?? BF 18 00 00 00 41 F6 87")]
    public static partial void AddToScreenLogWithScreenLogKind(BattleChara* target, BattleChara* source, uint logKind, int unkOption, int param1, int param2, int param3, int param4, int param5);
    
    /// <summary>
    /// Add a flytext with the given LogMessageId.
    /// </summary>
    /// <param name="target">Target of the flytext.</param>
    /// <param name="source">Source of the flytext.</param>
    /// <param name="logMessageId">Id of the LogMessage.</param>
    /// <param name="param1">FlyText formatter param 1.</param>
    /// <param name="param2">FlyText formatter param 2.</param>
    /// <param name="param3">FlyText formatter param 3.</param>
    /// <param name="param4">FlyText formatter param 4.</param>
    /// <param name="param5">FlyText formatter param 5.</param>
    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? B9 9E 64 00 00")]
    public static partial void AddToScreenLogWithLogMessageId(BattleChara* target, BattleChara* source, int logMessageId, int param1, int param2, int param3, int param4, int param5);
}
