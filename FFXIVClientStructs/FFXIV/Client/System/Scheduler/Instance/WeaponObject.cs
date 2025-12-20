namespace FFXIVClientStructs.FFXIV.Client.System.Scheduler.Instance;

// Client::System::Scheduler::Instance::WeaponObject
//   Client::System::Scheduler::SchedulerInstanceObject
[GenerateInterop]
[Inherits<SchedulerInstanceObject>]
[StructLayout(LayoutKind.Explicit, Size = 0xD0)]
public unsafe partial struct WeaponObject {
    [FieldOffset(0x80)] public Graphics.Scene.Object* Graphics;
}
