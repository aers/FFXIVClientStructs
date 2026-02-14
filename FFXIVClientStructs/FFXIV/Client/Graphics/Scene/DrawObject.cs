using FFXIVClientStructs.FFXIV.Client.Game.Object;

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

    [BitField<ObjectHighlightColor>(nameof(OutlineColor), 4, 4)]
    [FieldOffset(0x89)] public byte OutlineFlags;

    /// <summary>
    /// Used to highlight potential targets and housing object outlines.<br/>
    /// To set the color it is recommended to use <see cref="GameObject.Highlight" />, as it makes sure that it also highlights a characters weapon(s), mount and ornament, if available.
    /// </summary>
    public partial ObjectHighlightColor OutlineColor { get; set; }

    public bool IsVisible {
        get => (Flags & 0x09) == 0x09; // Unsure why two bits and what exactly they mean.
        set => Flags = (byte)(value ? Flags | 0x09 : Flags & ~0x09);
    }
}
