using FFXIVClientStructs.FFXIV.Client.System.Resource;
using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;
using FFXIVClientStructs.FFXIV.Common.Lua;

namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

// Client::Game::Event::LuaScriptLoader
//   Client::System::Resource::ResourceEventListener
[GenerateInterop(true)]
[Inherits<ResourceEventListener>]
[StructLayout(LayoutKind.Explicit, Size = 0x8)]
public unsafe partial struct LuaScriptLoader;


// Client::Game::Event::LuaScriptLoader<T>
//   Client::System::Resource::ResourceEventListener
[StructLayout(LayoutKind.Sequential, Size = 0x28)]
public unsafe struct LuaScriptLoader<T> where T : unmanaged {
    public LuaScriptLoader Loader;
    public LuaState* LuaState;
    public T* Parent;
    public StdMap<uint, Pointer<ResourceHandle>> Handles;
}
