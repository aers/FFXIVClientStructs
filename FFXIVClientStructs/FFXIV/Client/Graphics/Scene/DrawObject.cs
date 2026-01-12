namespace FFXIVClientStructs.FFXIV.Client.Graphics.Scene;

// Client::Graphics::Scene::DrawObject
//   Client::Graphics::Scene::Object
// base class for all drawn graphics objects
[GenerateInterop(isInherited: true)]
[Inherits<Object>]
[StructLayout(LayoutKind.Explicit, Size = 0x90)]
public unsafe partial struct DrawObject {
    [BitField<bool>(nameof(IsCoveredFromRain), 4)]
    [FieldOffset(0x88)] public byte Flags;
    [FieldOffset(0x89)] public Outline OutlineFlags; // used in vanilla with Highlight Potential Targets, Housing object outlines

    public bool IsVisible {
        get => (Flags & 0x09) == 0x09; // Unsure why two bits and what exactly they mean.
        set => Flags = (byte)(value ? Flags | 0x09 : Flags & ~0x09);
    }


    [Flags]
    public enum Outline : byte {
        Visible = 0x03, // default, no outline
        Red = 0x10,
        Green = 0x20,
        Blue = 0x30,
        Yellow = 0x40,
        Orange = 0x50,
        Pink = 0x60,
        // 0x70 and higher cause heatmap-style glitching
        // certain ObjectTypes may require Visible bit set in addition to an outline color, or else the object loses all visibility
    }
}
