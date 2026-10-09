namespace FFXIVClientStructs.FFXIV.Client.Graphics;

// Client::Graphics::ReferencedClassBase
[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe partial struct ReferencedClassBase {
    [FieldOffset(0x08)] public volatile uint RefCount; // TODO: change to int

    [VirtualFunction(0)]
    public partial ReferencedClassBase* Dtor(byte freeFlags);

    [VirtualFunction(1)]
    public partial void Cleanup();

    [VirtualFunction(2)]
    public partial int IncRef();

    /// <remarks> Will call <see cref="Cleanup"/> and <see cref="Dtor"/> when <see cref="RefCount"/> was <c>1</c>. </remarks>
    [VirtualFunction(3)]
    public partial int DecRef();
}
