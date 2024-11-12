using FFXIVClientStructs.FFXIV.Client.Game.Character;
using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

// Client::Game::Event::QuestEventHandler
//   Client::Game::Event::LuaEventHandler
//     Client::Game::Event::EventHandler
[GenerateInterop]
[Inherits<LuaEventHandler>]
[StructLayout(LayoutKind.Explicit, Size = 0x610)]
public unsafe partial struct QuestEventHandler {
    [FieldOffset(0x338)] public ushort QuestId;

    [FieldOffset(0x340)] public Utf8String Title;

    [MemberFunction("E8 ?? ?? ?? ?? 8B 75 D0")]
    public partial void GetTodoArgs(BattleChara* localPlayer, byte idx, uint* arg0, uint* arg1, uint* arg2);

    [MemberFunction("E8 ?? ?? ?? ?? 41 88 07 45 33 D2")]
    public partial bool IsTodoChecked(BattleChara* localPlayer, byte idx);
}
