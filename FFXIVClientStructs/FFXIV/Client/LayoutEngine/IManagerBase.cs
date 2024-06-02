namespace FFXIVClientStructs.FFXIV.Client.LayoutEngine;

// Client::LayoutEngine::IManagerBase
//   Client::System::Common::NonCopyable
[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public unsafe partial struct IManagerBase {
    [FieldOffset(0x08)] public IManagerBase* Owner;
    [FieldOffset(0x10)] public uint Id;

    [VirtualFunction(0)]
    public partial void Dtor(byte freeFlags);

    [VirtualFunction(1)]
    public partial void Initialize();

    [VirtualFunction(2)]
    public partial void Deinitialize();

    [VirtualFunction(3)]
    public partial void Update(float* dt);
}
