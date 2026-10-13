using FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;
using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;
using FFXIVClientStructs.FFXIV.Component.Text;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x90)]
public unsafe partial struct AtkFontManager {
    [FieldOffset(0x00)] public FontSet* FontSets;
    [FieldOffset(0x08)] public Font* Fonts;
    [FieldOffset(0x10)] public ushort FontCount;
    [FieldOffset(0x18)] public GfdFont* Gfd;
    [FieldOffset(0x20)] public AtkFontCodeModule* AtkFontCodeModule;
    [FieldOffset(0x28)] public TextChecker* TextChecker;
    [FieldOffset(0x30)] public AtkTextureResourceManager* AtkTextureResourceManager;
    [FieldOffset(0x38)] public AtkFontAnalyzer* AtkFontAnalyzer;
    /// <summary> An array that maps icon IDs used in <c>&lt;icon2(id)&gt;</c> macros to their remapped equivalents based on the controller's button mappings. </summary>
    [FieldOffset(0x40)] public Icon2RemapEntry* Icon2RemapTable; // 30 * 0x08
    [FieldOffset(0x50)] public uint SetupState;

    public const int FontSetCount = 6;
    public Span<FontSet> FontSetSpan => FontSets is null ? Span<FontSet>.Empty : new(FontSets, FontSetCount);
    public Span<Font> FontSpan => Fonts is null ? Span<Font>.Empty : new(Fonts, FontCount);

    [MemberFunction("40 56 48 83 EC 60 66 3B 51 10 0F 83 ?? ?? ?? ?? 0F B7 C2 48 69 F0 F8 00 00 00")]
    public partial int BuildFont(ushort index);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B CF 4C 89 BF ?? ?? ?? ?? E8")]
    public partial int UnloadFonts();

    [StaticAddress("48 8D 1D ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 0F 45 D8 EB 07 48 8D 1D ?? ?? ?? ??", 23)]
    public static partial FontTableEntry* GameFontTable();

    [StaticAddress("48 8D 1D ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 0F 45 D8 EB 07 48 8D 1D ?? ?? ?? ??", 3)]
    public static partial FontTableEntry* LobbyFontTableStandardResolution();

    [StaticAddress("48 8D 1D ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 0F 45 D8 EB 07 48 8D 1D ?? ?? ?? ??", 10)]
    public static partial FontTableEntry* LobbyFontTableHighResolution();

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0xF8)]
    public partial struct Font {
        public const int MaxTextures = 10;

        [FieldOffset(0x00), FixedSizeArray] internal FixedSizeArray10<Pointer<TextureResourceHandle>> _textureResourceHandles;
        [FieldOffset(0x50)] public ResourceHandle* FontdataResourceHandle;
        [FieldOffset(0x58), FixedSizeArray] internal FixedSizeArray10<Pointer<Texture>> _textures;
        [FieldOffset(0xA8)] public uint GlyphCount;
        [FieldOffset(0xAC)] public uint KerningCount;
        [FieldOffset(0xB4)] public ushort TextureWidth;
        [FieldOffset(0xB6)] public ushort TextureHeight;
        [FieldOffset(0xB8)] public float Size;
        [FieldOffset(0xBC)] public int LineHeight;
        [FieldOffset(0xC0)] public int Ascent;
        [FieldOffset(0xC8)] public Glyph* Glyphs;
        [FieldOffset(0xD0)] public StdUnorderedMap<uint, Pointer<Glyph>>* GlyphMap;
        [FieldOffset(0xD8)] public KerningEntry* Kerning;
        [FieldOffset(0xE0)] public Font* Secondary;
        [FieldOffset(0xE8)] public float SecondaryRatio;
        [FieldOffset(0xF0)] public ushort TextureCount;
        [FieldOffset(0xF2)] public FontFlags Flags;
        /// <summary>The first codepoint of the glyphs looked up by index rather than in <see cref="GlyphMap"/>, up to 0xFF, when <see cref="FontFlags.DirectIndex"/> is set.</summary>
        [FieldOffset(0xF3)] public byte DirectIndexFirst;
        /// <summary>How far the glyph after italic text moves right, for the overhang of the sheared glyphs before it.</summary>
        [FieldOffset(0xF4)] public sbyte ItalicCorrection;
        /// <summary>Extra spacing between consecutive CJK glyphs.</summary>
        [FieldOffset(0xF5)] public sbyte CjkSpacing;
    }

    [Flags]
    public enum FontFlags : byte {
        Built = 1 << 0,
        Ready = 1 << 1,
        DirectIndex = 1 << 2,
    }

    /// <summary> The fonts of one <see cref="FontType"/>, and the state of the text being drawn with them. </summary>
    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x278)]
    public partial struct FontSet {
        [FieldOffset(0x12C)] public float ScaledSizeY;
        [FieldOffset(0x130)] public float NodeScaleX;
        [FieldOffset(0x134)] public float NodeScaleY;
        [FieldOffset(0x158)] public DrawFlags DrawFlags;
        [FieldOffset(0x250)] public Font* CurrentFont;
        [FieldOffset(0x258)] public float CurrentFontSize;

        /// <summary>Picks the font of the set for the requested size.</summary>
        [MemberFunction("83 B9 58 01 00 00 00 4C 8B C1 F3 0F 10 91 2C 01 00 00")]
        public partial Font* PickFont(bool useCache);

        /// <summary>Looks a glyph up in a font of the set.</summary>
        /// <returns><c>null</c> if the font has none.</returns>
        [MemberFunction("89 54 24 10 48 83 EC 38 41 F6 80 F2 00 00 00 04")]
        public partial Glyph* GetGlyph(uint utf8Value, Font* font);
    }

    [Flags]
    public enum DrawFlags : uint {
        Italic = 1 << 27,
    }

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x0C)]
    public partial struct Glyph {
        [FieldOffset(0x00)] public uint Utf8Value; // imagine a UTF-8 byte sequence, reverse it, and pad before with zeroes
        [BitField<int>(nameof(X), 0, 12)]
        [BitField<int>(nameof(Y), 12, 12)]
        [BitField<int>(nameof(Channel), 24, 2)]
        [BitField<int>(nameof(TextureIndex), 26, 6)]
        [FieldOffset(0x04)] private uint _packed;
        [FieldOffset(0x08)] public byte Width;
        [FieldOffset(0x09)] public byte Height;
        [FieldOffset(0x0A)] public sbyte OffsetX;
        [FieldOffset(0x0B)] public sbyte OffsetY;

        public partial int X { readonly get; set; }
        public partial int Y { readonly get; set; }
        public partial int Channel { readonly get; set; }
        public partial int TextureIndex { readonly get; set; }

        public (int X, int Y, int Channel, int TextureIndex) Packed {
            readonly get => (X, Y, Channel, TextureIndex);
            set {
                ArgumentOutOfRangeException.ThrowIfLessThan(value.X, 0);
                ArgumentOutOfRangeException.ThrowIfGreaterThan(value.X, 0xFFF);
                ArgumentOutOfRangeException.ThrowIfLessThan(value.Y, 0);
                ArgumentOutOfRangeException.ThrowIfGreaterThan(value.Y, 0xFFF);
                ArgumentOutOfRangeException.ThrowIfLessThan(value.Channel, 0);
                ArgumentOutOfRangeException.ThrowIfGreaterThan(value.Channel, 3);
                ArgumentOutOfRangeException.ThrowIfLessThan(value.TextureIndex, 0);
                ArgumentOutOfRangeException.ThrowIfGreaterThan(value.TextureIndex, 0x3F);
                _packed = (uint)(value.X & 0xFFF) | ((uint)(value.Y & 0xFFF) << 12) | ((uint)(value.Channel & 3) << 24) | ((uint)value.TextureIndex << 26);
            }
        }
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x0C)]
    public struct KerningEntry {
        [FieldOffset(0x00)] public uint Left;
        [FieldOffset(0x04)] public uint Right;
        [FieldOffset(0x08)] public int Adjustment;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public struct FontTableEntry {
        public const int Count = 41;

        [FieldOffset(0x00)] public ulong TextureCount;
        [FieldOffset(0x08)] public CStringPointer TextureNameFormat;
        [FieldOffset(0x10)] public CStringPointer FdtName;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x30)]
    public struct GfdFont {
        [FieldOffset(0x00)] public TextureResourceHandle* TextureResourceHandle;
        // TODO: use GaijiFontdataResourceHandle*
        [FieldOffset(0x08)] private ResourceHandle* GfdResourceHandle; // probably only available during setup, because it's null afterwards
        [FieldOffset(0x10)] public Texture* Texture;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x08)]
    public struct Icon2RemapEntry {
        /// <summary> The ID passed to the icon2 macro. </summary>
        [FieldOffset(0x00)] public uint IconId;
        /// <summary> The GFD Icon ID that should be displayed. </summary>
        [FieldOffset(0x04)] public uint RemappedIconId;
    }
}
