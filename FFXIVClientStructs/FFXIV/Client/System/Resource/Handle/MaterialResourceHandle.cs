using FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;
using FFXIVClientStructs.FFXIV.Client.Graphics.Render;

namespace FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

// Client::System::Resource::Handle::MaterialResourceHandle
//   Client::System::Resource::Handle::DefaultResourceHandle
//     Client::System::Resource::Handle::ResourceHandle
//       Client::System::Common::NonCopyable
[GenerateInterop]
[Inherits<DefaultResourceHandle>]
[StructLayout(LayoutKind.Explicit, Size = 0x108)]
public unsafe partial struct MaterialResourceHandle {
    // [FieldOffset(0xB8)] public ulong Length;
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

    public byte ColorTableWidthLog
        => (byte)((DataFlags >> 4) & 0xF);

    public byte ColorTableHeightLog
        => (byte)((DataFlags >> 8) & 0xF);

    /// <summary>Width of the color table, in vectors of 4 <see cref="Half"/>.</summary>
    public int ColorTableWidth
        => HasColorTable ? ((DataFlags & 0xFF0) == 0 ? 4 : 1 << ColorTableWidthLog) : 0;

    public int ColorTableHeight
        => HasColorTable ? ((DataFlags & 0xFF0) == 0 ? 16 : 1 << ColorTableHeightLog) : 0;

    /// <summary>Total length of the color table, in <see cref="Half"/>. This will be the length of <see cref="ColorTableSpan"/>.</summary>
    public int ColorTableLength
        => ColorTableHeight * ColorTableWidth * 4;

    public Half* ColorTable
        => DataSetSize >= ColorTableLength * sizeof(Half) && HasColorTable ? (Half*)DataSet : null;

    public Span<Half> ColorTableSpan
        => ColorTable switch { null => default, var ptr => new(ptr, ColorTableLength) };

    public int StainTableRowByteLength
        => (DataFlags & 0xFF0) == 0 ? 2 : 4;

    public int StainTableByteLength
        => ColorTableHeight * StainTableRowByteLength;

    public byte* StainTable {
        get {
            var offset = HasColorTable ? ColorTableLength * sizeof(Half) : 0;
            return DataSetSize >= offset + StainTableByteLength && HasStainTable ? DataSet + offset : null;
        }
    }

    public Span<byte> StainTableSpan
        => StainTable switch { null => default, var ptr => new(ptr, StainTableByteLength) };

    public CStringPointer ShpkName
        => Strings + ShpkNameOffset;

    public CStringPointer TexturePath(int index) {
        if (index < 0 || index >= TextureCount)
            throw new ArgumentOutOfRangeException(nameof(index));
        return Strings + Textures[index].PathOffset;
    }

    public CStringPointer AttributeSetName(int index) {
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

    /// <remarks><paramref name="stainChannel" /> 0 or 1. With the current MTRL file format, values from 0 to 3 make sense.</remarks>
    [MemberFunction("E8 ?? ?? ?? ?? 48 8B FB EB 07")]
    public partial void ReadStainingTemplate(ushort* stainTable, byte stainId, Half* colorTable, uint stainChannel);

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public partial struct TextureEntry {
        [FieldOffset(0x0)] public TextureResourceHandle* TextureResourceHandle;
        [FieldOffset(0x8)] public ushort PathOffset;
        [BitField<ushort>(nameof(Index1), 0, 5)]
        [BitField<ushort>(nameof(Index2), 5, 5)]
        [BitField<ushort>(nameof(Index3), 10, 5)]
        [BitField<bool>(nameof(IsDX11), 15)]
        [FieldOffset(0xA)] public ushort Flags;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x4)]
    public struct AttributeSetEntry {
        [FieldOffset(0x0)] public ushort NameOffset;
        [FieldOffset(0x2)] public ushort Index;
    }
}
