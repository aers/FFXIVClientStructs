namespace FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;

// Client::Graphics::Kernel::Notifier
//   Client::Graphics::Kernel::NotifierBase
/// <summary>
/// Kernel resources link themselves into one global list, walked twice per frame by DeviceDX11.PostTick:
/// <see cref="EndFrame"/> on every notifier before Present, <see cref="BeginFrame"/> after the buffer index advances.
/// </summary>
[GenerateInterop(isInherited: true)]
[Inherits<NotifierBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public unsafe partial struct Notifier {
    [FieldOffset(0x08)] public Notifier* Next;
    [FieldOffset(0x10)] public Notifier* Prev;

    /// <summary> Newest notifier, the walks follow <see cref="Prev"/> from here. </summary>
    [StaticAddress("48 8D 0D ?? ?? ?? ?? FF 15 ?? ?? ?? ?? 48 8B 1D ?? ?? ?? ?? 48 85 DB 74 ?? 48 8B 03 48 8B CB FF 50 10", 16, isPointer: true)]
    public static partial Notifier* ListHead();

    /// <summary> Dynamic buffers map their slot for the new buffer index (0-2). </summary>
    [VirtualFunction(1)]
    public partial void BeginFrame();

    /// <summary> Dynamic buffers unmap, constant buffers upload their staged data. </summary>
    [VirtualFunction(2)]
    public partial void EndFrame();

    /// <summary> Inserts at the head of the list. </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 41 0F B6 C5 E9")]
    public partial void Link();

    [MemberFunction("E8 ?? ?? ?? ?? 45 33 F6 48 8D 5E")]
    public partial void Unlink();
}
