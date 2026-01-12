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

    /// <summary>
    /// used in vanilla with Highlight Potential Targets, Housing object outlines
    /// </summary>
    [FieldOffset(0x89)] public Outline OutlineFlags;

    public bool IsVisible {
        get => (Flags & 0x09) == 0x09; // Unsure why two bits and what exactly they mean.
        set => Flags = (byte)(value ? Flags | 0x09 : Flags & ~0x09);
    }


    /// <summary>
    /// certain objects may require Visible bit set in addition to a color, without this they fail to draw entirely
    /// </summary>
    /// <remarks>
    /// 0x70 and higher cause pink heatmap effects with motion, possibly a render glitch?
    /// </remarks>
    [Flags]
    public enum Outline : byte {
        /// <summary>
        /// no color on its own, used in combination with other bits
        /// </summary>
        Default = 0x03,
        Red = 0x10,
        Green = 0x20,
        Blue = 0x30,
        Yellow = 0x40,
        Orange = 0x50,
        Pink = 0x60,
    }
}
