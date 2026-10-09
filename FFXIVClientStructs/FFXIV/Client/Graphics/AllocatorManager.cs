namespace FFXIVClientStructs.FFXIV.Client.Graphics;

// Client::Graphics::AllocatorManager
//   Client::Graphics::Singleton<Client::Graphics::AllocatorManager>
//   (looks like +1B0 is another vtable with only a dtor)
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x1B8)]
public unsafe partial struct AllocatorManager {

    // Initialize seems to only create 12 of each, but the ctor and cleanup seem to support 13 of each
    [FieldOffset(0x08), FixedSizeArray] internal FixedSizeArray13<Pointer<IAllocator>> _allocators;
    [FieldOffset(0x70), FixedSizeArray] internal FixedSizeArray13<AllocatorLowLevel> _lowLevelAllocators;

    public IAllocator* CommonAllocator => _allocators[0]; // "Client.Graphics.Common.Allocator"
    public IAllocator* TempAllocator => _allocators[1]; // "Client.Graphics.Temp.Allocator"
    public IAllocator* KernelAllocator => _allocators[2]; // "Client.Graphics.Kernel.Allocator"
    public IAllocator* ShaderPackageAllocator => _allocators[3]; // "Client.Graphics.ShaderPackage.Allocator"
    public IAllocator* RenderAllocator => _allocators[4]; // "Client.Graphics.Render.Allocator"
    public IAllocator* SceneAllocator => _allocators[5]; // "Client.Graphics.Scene.Allocator"
    public IAllocator* AnimationAllocator => _allocators[6]; // "Client.Graphics.Animation.Allocator"
    public IAllocator* PhysicsAllocator => _allocators[7]; // "Client.Graphics.Physics.Allocator"
    public IAllocator* KineDriverAllocator => _allocators[8]; // "Client.Graphics.KineDriver.Allocator"
    public IAllocator* BonamikAllocator => _allocators[9]; // "Client.Graphics.Bonamik.Allocator"
    public IAllocator* ResourceAllocator => _allocators[10]; // "Client.Graphics.Resource.Allocator"
    public IAllocator* LuaAllocator => _allocators[11]; // "Client.Game.Lua.Allocator"

    [StaticAddress("74 12 48 8B 05 ?? ?? ?? ?? 48 8B 48 38", 5, isPointer: true)]
    public static partial AllocatorManager* Instance();

    [MemberFunction("E8 ?? ?? ?? ?? 41 0F B6 CD E8")]
    public partial void Initialize();

    [VirtualFunction(0)]
    public partial void Dtor(byte flags);

    [VirtualFunction(1)]
    public partial void Cleanup();
}
