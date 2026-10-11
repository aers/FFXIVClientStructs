namespace FFXIVClientStructs.FFXIV.Client.Graphics.Primitive;

// Client::Graphics::Primitive::Server
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0xC8)]
public unsafe partial struct Server {
    [FieldOffset(0xB8)] public Context* Contexts; // one per pool thread
}
