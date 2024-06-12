using FFXIVClientStructs.FFXIV.Client.System.Resource;
using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;
using FFXIVClientStructs.FFXIV.Common.Lua;

namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

// Client::Game::Event::LuaScriptLoader
//   Client::System::Resource::ResourceEventListener
[GenerateInterop(true)]
[Inherits<ResourceEventListener>]
[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public unsafe partial struct LuaScriptLoader<T> {
    [FieldOffset(0x08)] public LuaState* LuaState; // unsure if its LuaState or lua_state but is being set with the same state as ModuleBase
    [FieldOffset(0x10)] public T* Parent;
    // [FieldOffset(0x18)] public StdMap<> UnkMap // unsure of the type of map but is being called in multiple places where this struct is used. one which is sub_1409173E0
}
