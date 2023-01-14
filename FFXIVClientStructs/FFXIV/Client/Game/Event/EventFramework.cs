using FFXIVClientStructs.FFXIV.Client.Game.InstanceContent;
using FFXIVClientStructs.FFXIV.Common.Lua;

namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

[StructLayout(LayoutKind.Explicit, Size = 0x3BC0)]
public unsafe partial struct EventFramework
{
    [FieldOffset(0x00)] public EventHandlerModule EventHandlerModule;
    [FieldOffset(0xC0)] public DirectorModule DirectorModule;
    [FieldOffset(0x160)] public LuaActorModule LuaActorModule;
    [FieldOffset(0x1B0)] public EventSceneModule EventSceneModule;
    [FieldOffset(0x3350)] public int LoadState; //0=Exd, 1=EventHandler, 2=Director, 3=LuaActor, 4=EventScene, 5=Idle?, 6=Ready?

    [FieldOffset(0x3358)] public LuaState* LuaState;
    [FieldOffset(0x3360)] public LuaThread LuaThread;

    [FieldOffset(0x33B8)] public EventState EventState1;
    [FieldOffset(0x3418)] public EventState EventState2;

    [StaticAddress("48 8B 35 ?? ?? ?? ?? 0F B6 EA 4C 8B F1", 3, isPointer: true)]
    public static partial EventFramework* Instance();

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B D0 48 85 C0 74 ?? 8D 43")]
    public partial ContentDirector* GetContentDirector();

    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 98")]
    public partial InstanceContentDirector* GetInstanceContentDirector();

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B D0 48 85 C0 74 ?? 0F B6 88")]
    public partial PublicContentDirector* GetPublicContentDirector();

    public InstanceContentDeepDungeon* GetInstanceContentDeepDungeon() {
	    var director = (EventHandler*)GetContentDirector();
	    if (director == null || director->Info.EventId.Type != EventHandlerType.InstanceContentDirector)
		    return null;
	    var instanceDirector = (InstanceContentDirector*)director;
	    if (instanceDirector->InstanceContentType != 9)
		    return null;
	    return (InstanceContentDeepDungeon*)director;
    }

    [MemberFunction("E8 ?? ?? ?? ?? 32 C9 0F B6 D9")]
    public partial EventHandler* GetEventHandlerById(uint id);
    public EventHandler* GetEventHandlerById(ushort id) => GetEventHandlerById((uint)(id | 0x10000));

    [MemberFunction("E8 ?? ?? ?? ?? 8B D8 3B 86")]
    public static partial uint GetCurrentContentId();
}