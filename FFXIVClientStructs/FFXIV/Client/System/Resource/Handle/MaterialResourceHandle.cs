using System.Text;
using FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;
using FFXIVClientStructs.FFXIV.Client.Graphics.Render;

namespace FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

// Client::System::Resource::Handle::MaterialResourceHandle
//   Client::System::Resource::Handle::ResourceHandle
//     Client::System::Common::NonCopyable
[GenerateInterop]
[Inherits<ResourceHandle>]
[StructLayout(LayoutKind.Explicit, Size = 0x108)]
public unsafe partial struct MaterialResourceHandle
{
    public const int TableRows = 16;

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public struct TextureEntry
    {
        [FieldOffset(0x0)]
        public TextureResourceHandle* TextureResourceHandle;
        [FieldOffset(0x8)]
        public ushort PathOffset;
        [FieldOffset(0xA)]
        public ushort Flags;

        public bool IsDX11
        {
            get => (Flags & 0x8000) != 0;
            set => Flags = value ? (ushort)(Flags | 0x8000) : (ushort)(Flags & ~0x8000);
        }

        public ushort Index1
        {
            get => (ushort)(Flags & 0x001F);
            set => Flags = (ushort)((Flags & ~0x001F) | (value & 0x001F));
        }

        public ushort Index2
        {
            get => (ushort)((Flags & 0x03E0) >> 5);
            set => Flags = (ushort)((Flags & ~0x03E0) | ((value & 0x001F) << 5));
        }

        public ushort Index3
        {
            get => (ushort)((Flags & 0x7C00) >> 10);
            set => Flags = (ushort)((Flags & ~0x7C00) | ((value & 0x001F) << 10));
        }
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x4)]
    public struct AttributeSetEntry
    {
        [FieldOffset(0x0)]
        public ushort NameOffset;
        [FieldOffset(0x2)]
        public ushort Index;
    }

    /// <remarks>
    /// All RGB values in this structure are pre-squared.
    /// </remarks>
    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public struct ColorTableRow
    {
        [FieldOffset(0x0)] public Half DiffuseRed;
        [FieldOffset(0x2)] public Half DiffuseGreen;
        [FieldOffset(0x4)] public Half DiffuseBlue;
        [FieldOffset(0x6)] public Half SpecularStrength;
        [FieldOffset(0x8)] public Half SpecularRed;
        [FieldOffset(0xA)] public Half SpecularGreen;
        [FieldOffset(0xC)] public Half SpecularBlue;
        [FieldOffset(0xE)] public Half GlossStrength;
        [FieldOffset(0x10)] public Half EmissiveRed;
        [FieldOffset(0x12)] public Half EmissiveGreen;
        [FieldOffset(0x14)] public Half EmissiveBlue;
        [FieldOffset(0x16)] public Half TileIndexW;
        [FieldOffset(0x18)] public Half TileScaleUU;
        [FieldOffset(0x1A)] public Half TileScaleUV;
        [FieldOffset(0x1C)] public Half TileScaleVU;
        [FieldOffset(0x1E)] public Half TileScaleVV;

        public ushort TileIndex
        {
            get => (ushort)((float)TileIndexW * 64.0f);
            set => TileIndexW = (Half)((value + 0.5f) / 64.0f);
        }

        public Span<Half> AsSpan()
        {
            fixed (Half* ptr = &DiffuseRed)
            {
                return new(ptr, 16);
            }
        }

        public ReadOnlySpan<Half> AsReadOnlySpan()
        {
            fixed (Half* ptr = &DiffuseRed)
            {
                return new(ptr, 16);
            }
        }
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x2)]
    public struct StainTableRow
    {
        [FieldOffset(0x0)]
        public ushort RawData;

        public ushort Template
        {
            get => (ushort)(RawData >> 5);
            set => RawData = (ushort)((RawData & 0x1F) | (value << 5));
        }

        public bool Diffuse
        {
            get => (RawData & 0x01) != 0;
            set => RawData = (ushort)(value ? RawData | 0x01 : RawData & 0xFFFE);
        }

        public bool Specular
        {
            get => (RawData & 0x02) != 0;
            set => RawData = (ushort)(value ? RawData | 0x02 : RawData & 0xFFFD);
        }

        public bool Emissive
        {
            get => (RawData & 0x04) != 0;
            set => RawData = (ushort)(value ? RawData | 0x04 : RawData & 0xFFFB);
        }

        public bool Gloss
        {
            get => (RawData & 0x08) != 0;
            set => RawData = (ushort)(value ? RawData | 0x08 : RawData & 0xFFF7);
        }

        public bool SpecularStrength
        {
            get => (RawData & 0x10) != 0;
            set => RawData = (ushort)(value ? RawData | 0x10 : RawData & 0xFFEF);
        }
    }

    [FieldOffset(0xB8)] public ulong Length;
    /// <summary>
    /// The instantiated material. Its <see cref="Material.MaterialResourceHandle"/> will be the current structure.
    /// </summary>
    [FieldOffset(0xC0)] public Material* Material;
    [FieldOffset(0xC8)] public ShaderPackageResourceHandle* ShaderPackageResourceHandle;
    [FieldOffset(0xD0)] public TextureEntry* Textures;
    [FieldOffset(0xD8)] public AttributeSetEntry* AttributeSets;
    [FieldOffset(0xE0)] public byte* Strings;
    [FieldOffset(0xE8)] public byte* AdditionalData;
    [FieldOffset(0xF0)] public byte* DataSet;
    [FieldOffset(0xF8)] public ushort ShpkNameOffset;
    [FieldOffset(0xFA)] public byte TextureCount;
    [FieldOffset(0xFB)] public byte UvSetCount;
    [FieldOffset(0xFC)] public byte ColorSetCount;
    [FieldOffset(0xFD)] public byte AdditionalDataSize;
    [FieldOffset(0xFE)] public ushort DataSetSize;
    /// <summary>
    /// Size of the memory block that contains the texture and attribute set entries, the strings, the additional data and the data set.
    /// </summary>
    [FieldOffset(0x100)] public ushort TotalDataSize;

    public Span<TextureEntry> TexturesSpan
        => new(Textures, TextureCount);

    public Span<AttributeSetEntry> AttributeSetsSpan
        => new(AttributeSets, UvSetCount + ColorSetCount);

    public uint DataFlags
        => AdditionalDataSize >= 4 ? *(uint*)AdditionalData : 0u;

    public bool HasColorTable
        => (DataFlags & 0x4) != 0;

    public bool HasStainTable
        => (DataFlags & 0x8) != 0;

    public ColorTableRow* ColorTable
        => DataSetSize >= TableRows * sizeof(ColorTableRow) && HasColorTable ? (ColorTableRow*)DataSet : null;

    public Span<ColorTableRow> ColorTableSpan
        => ColorTable switch { null => default, var ptr => new(ptr, TableRows) };

    public StainTableRow* StainTable
    {
        get
        {
            var offset = HasColorTable ? TableRows * sizeof(ColorTableRow) : 0;
            return DataSetSize >= offset + TableRows * sizeof(StainTableRow) && HasStainTable ? (StainTableRow*)(DataSet + offset) : null;
        }
    }

    public Span<StainTableRow> StainTableSpan
        => StainTable switch { null => default, var ptr => new(ptr, TableRows) };

    public StringPointer ShpkName
        => Strings + ShpkNameOffset;

    public StringPointer TexturePath(int index)
    {
        if (index < 0 || index >= TextureCount)
            throw new ArgumentOutOfRangeException(nameof(index));
        return Strings + Textures[index].PathOffset;
    }

    public StringPointer AttributeSetName(int index)
    {
        if (index < 0 || index >= UvSetCount + ColorSetCount)
            throw new ArgumentOutOfRangeException(nameof(index));
        return Strings + AttributeSets[index].NameOffset;
    }

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 4A 0F B7 46 02")]
    public partial byte LoadTexFiles();

    [MemberFunction("48 89 5C 24 ?? 57 48 81 EC ?? ?? ?? ?? 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 84 24 ?? ?? ?? ?? 44 0F B7 89")]
    public partial byte LoadShpkFiles();

    [MemberFunction("E8 ?? ?? ?? ?? 49 89 04 3E")]
    public partial Texture* PrepareColorTable(byte stain0Id, byte stain1Id); // aka PrepareColorSet

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B FB EB 07")]
    public partial void ReadStainingTemplate(Half* colorTable, byte stainId, byte* a4);
}
