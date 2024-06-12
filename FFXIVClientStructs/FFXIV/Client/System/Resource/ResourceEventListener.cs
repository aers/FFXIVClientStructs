namespace FFXIVClientStructs.FFXIV.Client.System.Resource;

// Client::System::Resource::ResourceEventListener
[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 8)]
public unsafe partial struct ResourceEventListener {
    [VirtualFunction(0)]
    public partial void Dtor();

    // vfuncs 1-4 are virtuals that are specific to the classes that inherits this
    
    // unsure of what the function does but its specific to this class from what I find in the vtable references
    // [VirtualFunction(3)]
    // public partial void vf3(ResourceHandle* handle);

    // looks similar to vf3 but seems to be a different function
    // [VirtualFunction(4)]
    // public partial void vf4(ResourceHandle* handle);

}
