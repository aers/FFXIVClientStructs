namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

// Client::Game::Event::EventSceneModuleTaskManager
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x38)]
public unsafe partial struct EventSceneModuleTaskManager {
    [FieldOffset(0x00)] public StdVector<Pointer<EventSceneTaskInterface>> Tasks;
    [FieldOffset(0x18)] public StdVector<Pointer<EventSceneTaskInterface>> GroupPoseTasks;

    [MemberFunction("E8 ?? ?? ?? ?? 48 8D 8B ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 8B 93 ?? ?? ?? ?? 48 8B CB")]
    public partial void ProcessTasks();

    [MemberFunction("E9 ?? ?? ?? ?? 41 0F B7 D8")]
    public partial void AddTask(EventSceneTaskInterface* task);

    [MemberFunction("E8 ?? ?? ?? ?? 0F 28 74 24 ?? B0 01 48 8B 74 24 ??")]
    public partial void AddGroupPoseTask(EventSceneTaskInterface* task);
}
