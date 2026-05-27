using FFXIVClientStructs.FFXIV.Client.Graphics.Scene;

namespace FFXIVClientStructs.FFXIV.Client.LayoutEngine.Layer;

// Client::LayoutEngine::Layer::EnvLocationLayoutInstance
//   Client::LayoutEngine::ILayoutInstance
[GenerateInterop]
[Inherits<ILayoutInstance>]
[StructLayout(LayoutKind.Explicit, Size = 0x48)]
public unsafe partial struct EnvLocationLayoutInstance {
    [FieldOffset(0x30)] public EnvLocation* GraphicsObject;
    [FieldOffset(0x38)] private void* _unk_38; // Array of 0x4C structures memcpy'd from the file
    [FieldOffset(0x40)] private int _unk_40; // Count of _unk_38
    [FieldOffset(0x44)] private uint _unk_44;
}
