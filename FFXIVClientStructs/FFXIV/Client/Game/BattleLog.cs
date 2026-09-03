using FFXIVClientStructs.FFXIV.Client.Game.Character;
using FFXIVClientStructs.FFXIV.Client.Game.Object;

namespace FFXIVClientStructs.FFXIV.Client.Game;

// Client::Game::BattleLog
[GenerateInterop]
public unsafe partial struct BattleLog {
    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 83 B8")]
    public static partial void AddLogMessage3Params(
        uint logMessageId,
        BattleChara* source,
        uint value1,
        uint value2,
        int value3,
        float maxDistance);

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? F3 0F 11 44 24")]
    public static partial void AddLogMessage(
        uint logMessageId,
        BattleChara* source,
        uint value1,
        uint value2,
        int value3,
        uint value4,
        float maxDistance);

    [MemberFunction("E8 ?? ?? ?? ?? 41 8B CC 83 E9")]
    public static partial void AddActionLogMessage(
        uint logMessageId,
        GameObject* source,
        GameObject* target,
        ActionType actionKind,
        uint actionId,
        uint value1,
        int value2,
        int value3,
        uint value4,
        float maxDistance);

    [MemberFunction("E8 ?? ?? ?? ?? EB ?? 85 F6 0F 84")]
    public static partial void AddToScreenLogWithLogMessageId(
        BattleChara* target,
        BattleChara* source,
        int logMessageId,
        byte actionKind,
        uint actionId,
        uint value1,
        int value2,
        int value3,
        int value4);

    [MemberFunction("E8 ?? ?? ?? ?? BF ?? ?? ?? ?? EB 39")]
    public static partial void AddToScreenLogWithScreenLogKind(
        BattleChara* target,
        BattleChara* source,
        int screenLogKind,
        byte option,
        byte actionKind,
        uint actionId,
        uint value1,
        int value2,
        int value3,
        int value4);
}
