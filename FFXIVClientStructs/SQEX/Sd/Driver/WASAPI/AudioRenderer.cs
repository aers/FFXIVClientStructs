using FFXIVClientStructs.SQEX.Sd.Driver.Core;

namespace FFXIVClientStructs.SQEX.Sd.Driver.WASAPI;

// SQEX::Sd::Driver::WASAPI::AudioRenderer
//   SQEX::Sd::SeadObject<1,8>
/// <summary>
/// An output endpoint of the mixer. The first plays <see cref="MasterBusId.Bed"/>, the second <see cref="MasterBusId.Pad"/> and only exists
/// while the pad speaker or vibration option is on.
/// </summary>
[GenerateInterop]
[VirtualTable("48 8D 05 ?? ?? ?? ?? 48 8D 8B 08 01 00 00", 3)]
[StructLayout(LayoutKind.Explicit, Size = 0x130)]
public unsafe partial struct AudioRenderer {
    [FieldOffset(0x08)] public int SampleRate;
    [FieldOffset(0x0C)] public int FrameCount;
    [FieldOffset(0x10)] public int ChannelCount;
    [FieldOffset(0x20)] public MasterBusId BusId;

    /// <summary> A <see cref="WASAPIDevice"/>, or a <see cref="MockDevice"/> when the endpoint could not be opened. </summary>
    [FieldOffset(0x28)] public AudioDevice* Device;
    [FieldOffset(0x108)] private fixed byte Lock[0x28]; // CRITICAL_SECTION

    /// <summary> Two entries. </summary>
    [StaticAddress("48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 8B 08 48 83 C4 28", 3)]
    public static partial AudioRenderer** Instances();
}

// SQEX::Sd::Driver::WASAPI::AudioDevice
[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x08)]
public unsafe partial struct AudioDevice;

// SQEX::Sd::Driver::WASAPI::WASAPIDevice
//   SQEX::Sd::Driver::WASAPI::AudioDevice
//   SQEX::Sd::SeadObject<1,8>
[GenerateInterop]
[Inherits<AudioDevice>]
[VirtualTable("48 8D 05 ?? ?? ?? ?? 33 D2 48 89 03 48 8D 4B 28", 3)]
[StructLayout(LayoutKind.Explicit, Size = 0x128)]
public unsafe partial struct WASAPIDevice {
    /// <summary> The <c>WAVEFORMATEX</c> of the shared-mode stream: the mix format of the endpoint, or IEEE float at the mixer rate if that was not usable. </summary>
    [FieldOffset(0x08), CExporterTypeForce("WAVEFORMATEX*", true)] public void* Format;
}

// SQEX::Sd::Driver::WASAPI::MockDevice
//   SQEX::Sd::Driver::WASAPI::AudioDevice
//   SQEX::Sd::SeadObject<1,8>
/// <summary> Discards the output, used when no endpoint could be opened. </summary>
[GenerateInterop]
[Inherits<AudioDevice>]
[VirtualTable("48 8D 05 ?? ?? ?? ?? 48 89 03 33 C0 48 89 43 08 48 89 43 10 89 43 18", 3)]
[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public unsafe partial struct MockDevice;
