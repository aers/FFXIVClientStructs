namespace FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;
// Client::System::Resource::Handle::MaterialResourceHandle
//   Client::System::Resource::Handle::ResourceHandle
//     Client::System::Common::NonCopyable

// ctor 40 53 48 83 EC ?? 48 8B 44 24 ?? 48 8B D9 48 89 44 24 ?? 48 8B 44 24 ?? 48 89 44 24 ?? E8 ?? ?? ?? ?? 33 C9 
[StructLayout(LayoutKind.Explicit, Size = 0x108)]
public unsafe partial struct MaterialResourceHandle
{
    [FieldOffset(0x0)] public ResourceHandle ResourceHandle;

    [MemberFunction("4C 8B DC 49 89 5B ?? 49 89 73 ?? 55 57 41 55")]
    public partial byte LoadTexFiles();

    [MemberFunction("48 89 5C 24 ?? 57 48 81 EC ?? ?? ?? ?? 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 84 24 ?? ?? ?? ?? 44 0F B7 89")]
    public partial byte LoadShpkFiles();
}