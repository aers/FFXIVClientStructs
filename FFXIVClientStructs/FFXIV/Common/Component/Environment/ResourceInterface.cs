namespace FFXIVClientStructs.FFXIV.Common.Component.Environment;

// Common::Component::Environment::ResourceInterface
[GenerateInterop(true)]
[StructLayout(LayoutKind.Explicit, Size = 0x8)]
public unsafe partial struct ResourceInterface {
    [VirtualFunction(0)]
    public partial ResourceInterface* Dtor(byte freeFlags);

    // [VirtualFunction(1)]
    // public partial LoadFile;

    // [VirtualFunction(2)]
    // public partial UnloadFile;

    // Common::Component::Environment::ResourceInterface::ResourceHandleInterface
    [GenerateInterop(true)]
    [StructLayout(LayoutKind.Explicit, Size = 0x8)]
    public unsafe partial struct ResourceHandleInterface {
        [VirtualFunction(0)]
        public partial ResourceHandleInterface* Dtor(byte freeFlags);

        [VirtualFunction(1)]
        public partial CStringPointer GetPath();

        [VirtualFunction(2)]
        public partial bool IsLoadSucceed();

        [VirtualFunction(3)]
        public partial bool IsLoadFail();

        [VirtualFunction(4)]
        public partial byte* GetData();

        [VirtualFunction(5)]
        public partial uint GetSize();

        // [VirtualFunction(6)]
        // public partial ??;
    }
}