namespace FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;

/// <summary>
/// Records rendering commands to be executed later by the <see cref="ImmediateContext"/>.
/// </summary>
/// <remarks>
/// Threads have their own Context, accessed via <see cref="ThreadLocals.GraphicsKernelContext"/>.
/// </remarks>
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x2F78)]
public unsafe partial struct Context {
    /// <summary>
    /// Sort key stamped onto every command pushed via <see cref="PushBackCommand"/>.
    /// Commands are executed by SortKey ordering rather than submission order.
    /// </summary>
    [BitField<byte>(nameof(CurrentSubViewIndex), 28, 4)]
    [FieldOffset(0x008)] public uint SortKey;
    [FieldOffset(0x00C)] public int ViewIndex;
    [FieldOffset(0x010)] public void* CommandAllocationBase;

    [FieldOffset(0x840)] public ulong CommandAllocationUsedSize;
    [FieldOffset(0x848)] public ulong AllocationBase;
    [FieldOffset(0x850)] public ulong AllocationUsedSize;

    [MemberFunction("4C 8B D1 4C 8D 42 0F")]
    public partial void* AllocateCommand(ulong size);

    [MemberFunction("4C 8B C9 4D 8D 50 0F")]
    public partial void* AllocateSpecificCommand(RenderCommandType commandType, ulong size);

    [MemberFunction("E8 ?? ?? ?? ?? 8B 6E 6C")]
    public partial void PushBackCommand(void* command);

    [MemberFunction("E8 ?? ?? ?? ?? 8B D6 41 B8")]
    public partial void SetRenderTargets(int renderTargetCount, Texture** renderTargetTextures, Texture* depthStencilTexture, short a4, short a5, short a6, short a7); // last params believed to be a rectangle
}
