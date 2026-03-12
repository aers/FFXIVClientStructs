namespace FFXIVClientStructs.SQEX.CDev.Engine.Sd.Driver;

// SQEX::CDev::Engine::Sd::Driver::SoundController
//   SQEX::CDev::Engine::Sd::SdMemoryAllocator
[GenerateInterop(isInherited: true)]
[Inherits<SdMemoryAllocator>]
[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public partial struct SoundController {
    [FieldOffset(0x08)] private int Unk08;
    [FieldOffset(0x10)] private nint Unk10; // CDev.Engine.Sd.SoundLayout*?
    [FieldOffset(0x18)] private nint SharedMutex; // std::shared_mutex?
}
