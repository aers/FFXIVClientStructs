namespace FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;
// Client::System::Resource::Handle::TextureResourceHandle
//   Client::System::Resource::Handle::ResourceHandle
//     Client::System::Common::NonCopyable

// size = 0x130
// ctor 40 53 48 83 EC 30 48 8B 44 24 ?? 48 8B D9 48 89 44 24 ?? 48 8B 44 24 ?? 48 89 44 24 ?? E8 ?? ?? ?? ?? 81 A3 ?? ?? ?? ?? ?? ?? ?? ??  
[StructLayout(LayoutKind.Explicit, Size = 0x140)]
public struct TextureResourceHandle
{
    [FieldOffset(0x0)] public ResourceHandle ResourceHandle;
}