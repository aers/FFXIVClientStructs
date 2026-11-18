using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.SQEX.CDev.Engine.Sd.Driver;

// SQEX::CDev::Engine::Sd::Driver::SoundController
//   SQEX::CDev::Engine::Sd::SdMemoryAllocator
[GenerateInterop(isInherited: true)]
[Inherits<SdMemoryAllocator>]
[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public unsafe partial struct SoundController {
    /// <summary> The id the driver finds the sound by, the result of virtual function 63 of the sound. </summary>
    [FieldOffset(0x08)] public int SoundId;
    [FieldOffset(0x10)] private nint Unk10; // CDev.Engine.Sd.SoundLayout*?
    [FieldOffset(0x18)] private nint SharedMutex; // std::shared_mutex?

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 41 8B BE")]
    public partial void SetPosition(Vector4* position);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8D 4B 38 40 84 FF")]
    public partial void SetIsNonPositional(bool isNonPositional);

    /// <summary> Sets <see cref="RootSound.LayoutVolume"/> of the sound. Used by the layout sounds. </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 48 8D 55 88 49 8D 4E 08")]
    public partial void SetLayoutVolume(float volume);

    /// <summary> Calls <see cref="RootSound.SetLevel"/> on the sound. </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 8B 96 D4 00 00 00 48 8B CD")]
    public partial void SetLevel(uint level);
}
