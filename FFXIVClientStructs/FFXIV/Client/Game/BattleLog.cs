using FFXIVClientStructs.FFXIV.Client.Game.Character;
using FFXIVClientStructs.FFXIV.Client.Game.Object;
using FFXIVClientStructs.FFXIV.Client.UI.Misc;

namespace FFXIVClientStructs.FFXIV.Client.Game;

// Client::Game::BattleLog
[GenerateInterop]
public unsafe partial struct BattleLog {
    /// <summary>
    /// Add a battle log message with three formatter parameters.
    /// </summary>
    /// <param name="logMessageId">Id of the LogMessage.</param>
    /// <param name="source">Source character of the message.</param>
    /// <param name="value1">LogMessage formatter param 1.</param>
    /// <param name="value2">LogMessage formatter param 2.</param>
    /// <param name="value3">LogMessage formatter param 3.</param>
    /// <param name="maxDistance">Maximum distance at which the message is shown.</param>
    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 83 B8")]
    public static partial void AddLogMessage3Params(
        uint logMessageId,
        BattleChara* source,
        int value1,
        int value2,
        int value3,
        float maxDistance);

    /// <summary>
    /// Add a battle log message with four formatter parameters.
    /// </summary>
    /// <param name="logMessageId">Id of the LogMessage.</param>
    /// <param name="source">Source character of the message.</param>
    /// <param name="value1">LogMessage formatter param 1.</param>
    /// <param name="value2">LogMessage formatter param 2.</param>
    /// <param name="value3">LogMessage formatter param 3.</param>
    /// <param name="value4">LogMessage formatter param 4.</param>
    /// <param name="maxDistance">Maximum distance at which the message is shown.</param>
    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? F3 0F 11 44 24")]
    public static partial void AddLogMessage(
        uint logMessageId,
        BattleChara* source,
        int value1,
        int value2,
        int value3,
        int value4,
        float maxDistance);

    /// <summary>
    /// Add an action-related battle log message.
    /// </summary>
    /// <param name="logMessageId">Id of the LogMessage.</param>
    /// <param name="source">Source object of the message.</param>
    /// <param name="target">Target object of the message.</param>
    /// <param name="actionKind">Kind used to interpret <paramref name="actionId"/>.</param>
    /// <param name="actionId">Id interpreted according to <paramref name="actionKind"/>.</param>
    /// <param name="value1">LogMessage formatter param 1.</param>
    /// <param name="value2">LogMessage formatter param 2.</param>
    /// <param name="value3">LogMessage formatter param 3.</param>
    /// <param name="value4">LogMessage formatter param 4.</param>
    /// <param name="maxDistance">Maximum distance at which the message is shown.</param>
    [MemberFunction("E8 ?? ?? ?? ?? 41 8B CC 83 E9")]
    public static partial void AddActionLogMessage(
        uint logMessageId,
        GameObject* source,
        GameObject* target,
        ActionType actionKind,
        uint actionId,
        int value1,
        int value2,
        int value3,
        int value4,
        float maxDistance);

    /// <summary>
    /// Add a flytext with the given LogMessageId.
    /// </summary>
    /// <param name="target">Target character of the flytext.</param>
    /// <param name="source">Source character of the flytext.</param>
    /// <param name="logMessageId">Id of the LogMessage.</param>
    /// <param name="actionKind">Kind used to interpret <paramref name="actionId"/>.</param>
    /// <param name="actionId">Id interpreted according to <paramref name="actionKind"/>.</param>
    /// <param name="value1">FlyText formatter param 1.</param>
    /// <param name="value2">FlyText formatter param 2.</param>
    /// <param name="value3">FlyText formatter param 3.</param>
    [MemberFunction("E8 ?? ?? ?? ?? EB ?? 85 F6 0F 84")]
    public static partial void AddToScreenLogWithLogMessageId(
        BattleChara* target,
        BattleChara* source,
        int logMessageId,
        byte actionKind,
        uint actionId,
        int value1,
        int value2,
        int value3);

    /// <summary>
    /// Add a flytext with the given ScreenLogKind.
    /// </summary>
    /// <param name="target">Target character of the flytext.</param>
    /// <param name="source">Source character of the flytext.</param>
    /// <param name="screenLogKind">What kind of log is it?</param>
    /// <param name="option">FlyText display option. See <see cref="ScreenLogOption"/>.</param>
    /// <param name="actionKind">Kind used to interpret <paramref name="actionId"/>.</param>
    /// <param name="actionId">Id interpreted according to <paramref name="actionKind"/>.</param>
    /// <param name="value1">FlyText formatter param 1.</param>
    /// <param name="value2">FlyText formatter param 2.</param>
    /// <param name="value3">FlyText formatter param 3.</param>
    [MemberFunction("E8 ?? ?? ?? ?? BF ?? ?? ?? ?? EB 39")]
    public static partial void AddToScreenLogWithScreenLogKind(
        BattleChara* target,
        BattleChara* source,
        int screenLogKind,
        byte option,
        byte actionKind,
        uint actionId,
        int value1,
        int value2,
        int value3);
}
