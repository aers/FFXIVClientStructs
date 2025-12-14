namespace FFXIVClientStructs.FFXIV.Client.System.Scheduler.Instance;

// Client::System::Scheduler::Instance::BgObject
//   Client::System::Scheduler::SchedulerInstanceObject
[GenerateInterop]
[Inherits<SchedulerInstanceObject>]
[StructLayout(LayoutKind.Explicit, Size = 0x90)]
public unsafe partial struct BgObject {
    [FieldOffset(0x80)] public Graphics.Scene.Object* Graphics;
}
