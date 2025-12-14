namespace FFXIVClientStructs.FFXIV.Client.System.Scheduler.Instance;

// Client::System::Scheduler::Instance::LightObject
//   Client::System::Scheduler::SchedulerInstanceObject
[GenerateInterop]
[Inherits<SchedulerInstanceObject>]
[StructLayout(LayoutKind.Explicit, Size = 0xB0)]
public unsafe partial struct LightObject {
    [FieldOffset(0xA8)] public Graphics.Scene.Object* Graphics;
}
