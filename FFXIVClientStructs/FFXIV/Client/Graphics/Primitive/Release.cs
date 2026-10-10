namespace FFXIVClientStructs.FFXIV.Client.Graphics.Primitive;

// Client::Graphics::Primitive::Release
//   Client::Graphics::Singleton<Client::Graphics::Primitive::Release>
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x58)]
public unsafe partial struct Release {
    [StaticAddress("48 8B 0D ?? ?? ?? ?? 44 2B", 3, isPointer: true)]
    public static partial Release* Instance();

    /// <summary> Each pool thread takes context [i] of both servers when it starts: TLS +0x248 from the first, +0x240 from the second. </summary>
    [FieldOffset(0x08), FixedSizeArray] internal FixedSizeArray2<Pointer<Server>> _servers;
    [FieldOffset(0x18)] public uint ContextCount;
    [FieldOffset(0x1C)] public uint NextContext;
}
