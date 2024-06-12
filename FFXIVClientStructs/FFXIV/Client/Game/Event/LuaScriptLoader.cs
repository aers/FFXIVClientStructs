using FFXIVClientStructs.FFXIV.Client.System.Resource;
using FFXIVClientStructs.FFXIV.Common.Lua;

namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

// Client::Game::Event::LuaScriptLoader<Client::Game::Event::LuaEventHandler>
//   Client::System::Resource::ResourceEventListener
[GenerateInterop(true)]
[Inherits<ResourceEventListener>]
[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public unsafe partial struct LuaScriptLoaderLuaEventHandler {
    [FieldOffset(0x08)] public LuaState* LuaState; // unsure if its LuaState or lua_state but is being set with the same state as ModuleBase
    [FieldOffset(0x10)] public LuaEventHandler* Parent;
    // [FieldOffset(0x18)] public StdMap<> UnkMap // unsure of the type of map but is being called in multiple places where this struct is used. one which is sub_1409173E0
}

// Client::Game::Event::LuaScriptLoader<Client::Game::Event::ModuleBase>
//   Client::System::Resource::ResourceEventListener
[GenerateInterop(true)]
[Inherits<ResourceEventListener>]
[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public unsafe partial struct LuaScriptLoaderModuleBase {
    [FieldOffset(0x08)] public LuaState* LuaState; // unsure if its LuaState or lua_state but is being set with the same state as ModuleBase
    [FieldOffset(0x10)] public ModuleBase* Parent;
    // [FieldOffset(0x18)] public StdMap<> UnkMap // unsure of the type of map but is being called in multiple places where this struct is used. one which is sub_1409173E0
}
