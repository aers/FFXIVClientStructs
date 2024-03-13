namespace FFXIVClientStructs.FFXIV.Client.Graphics.Scene;

// Client::Graphics::Scene::DrawObject
//   Client::Graphics::Scene::Object
// base class for all drawn graphics objects
// ctor "E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? E8 ?? ?? ?? ?? 81 A7"
[StructLayout(LayoutKind.Explicit, Size = 0x90)]
public unsafe struct DrawObject {
    [FieldOffset(0x0)] public Object Object;
    [FieldOffset(0x88)] public byte Flags;

    public bool IsCoveredFromRain {
        get => (Flags & 0x10) == 0x10;
        set => Flags = (byte)(value ? Flags | 0x10 : Flags & ~0x10);
    }

    public bool IsVisible {
        get => (Flags & 0x09) == 0x09; // Unsure why two bits and what exactly they mean.
        set => Flags = (byte)(value ? Flags | 0x09 : Flags & ~0x09);
    }
}
