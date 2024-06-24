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

    [MemberFunction("4C 8B DC 55 57 41 54 41 55 48 81 EC")]
    public partial void GetTodoArgs(BattleChara* localPlayer, byte idx, uint* arg0, uint* arg1, uint* arg2);

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 48 8B 46 08")]
    public partial bool IsTodoChecked(BattleChara* localPlayer, byte idx);
}
