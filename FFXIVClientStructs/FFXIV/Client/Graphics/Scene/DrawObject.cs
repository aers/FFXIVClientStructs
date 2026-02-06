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
    /// used in vanilla with Highlight Potential Targets, Housing object outlines. can be set by GameObject.Highlight
    /// </summary>
    /// <remarks>
    /// (&amp; 0xF0) >> 4 == ObjectHighlightColor
    /// &amp; 0x0F == other state (3 = Default)
    /// </remarks>
    [FieldOffset(0x89)] public byte OutlineFlags;

    public bool IsVisible {
        get => (Flags & 0x09) == 0x09; // Unsure why two bits and what exactly they mean.
        set => Flags = (byte)(value ? Flags | 0x09 : Flags & ~0x09);
    }
}
