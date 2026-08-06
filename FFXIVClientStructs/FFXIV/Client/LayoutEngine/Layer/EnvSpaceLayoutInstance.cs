using FFXIVClientStructs.FFXIV.Client.Graphics.Scene;

namespace FFXIVClientStructs.FFXIV.Client.LayoutEngine.Layer;

// Client::LayoutEngine::Layer::EnvSpaceLayoutInstance
//   Client::LayoutEngine::ILayoutInstance
//     Client::System::Common::NonCopyable
[GenerateInterop]
[Inherits<ILayoutInstance>]
[StructLayout(LayoutKind.Explicit, Size = 0x40)]
public unsafe partial struct EnvSpaceLayoutInstance {
    [FieldOffset(0x30)] public EnvSpace* GraphicsObject;
    [FieldOffset(0x38)] public uint BoundInstanceId;
}
