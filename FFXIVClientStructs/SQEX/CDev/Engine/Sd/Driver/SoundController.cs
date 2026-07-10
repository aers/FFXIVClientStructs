using FFXIVClientStructs.FFXIV.Common.Math;

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

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 41 8B BE")]
    public partial void SetPosition(Vector4 position);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8D 4B 38 40 84 FF")] // 0x141E6D600
    public partial void SetIsNonPositional(bool isPositional);
}
