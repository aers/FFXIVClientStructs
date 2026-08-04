namespace FFXIVClientStructs.FFXIV.Client.Graphics.Vfx;

// Client::Graphics::Vfx::VfxData
//   Apricot::ApricotInstanceListenner
//     Apricot::IInstanceListenner
//   Client::Graphics::Vfx::VfxResourceInstanceListenner
[StructLayout(LayoutKind.Explicit, Size = 0x1E0)]
public unsafe struct VfxData {
    [FieldOffset(0x1C0)] public VfxDataListenner* DataListenner;
}
