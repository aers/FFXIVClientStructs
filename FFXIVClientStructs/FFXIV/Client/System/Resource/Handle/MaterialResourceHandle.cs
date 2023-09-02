using FFXIVClientStructs.FFXIV.Client.Graphics.Render;
using System.Text;

namespace FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;
// Client::System::Resource::Handle::MaterialResourceHandle
//   Client::System::Resource::Handle::ResourceHandle
//     Client::System::Common::NonCopyable

// ctor 40 53 48 83 EC ?? 48 8B 44 24 ?? 48 8B D9 48 89 44 24 ?? 48 8B 44 24 ?? 48 89 44 24 ?? E8 ?? ?? ?? ?? 33 C9 
[StructLayout(LayoutKind.Explicit, Size = 0x108)]
public unsafe partial struct MaterialResourceHandle
{
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
            readonly get => (Flags & 0x8000) != 0;
            set => Flags = value ? (ushort)(Flags | 0x8000) : (ushort)(Flags & ~0x8000);
        }

        public ushort Index1
        {
            readonly get => (ushort)(Flags & 0x001F);
            set => Flags = (ushort)((Flags & ~0x001F) | (value & 0x001F));
        }

        public ushort Index2
        {
            readonly get => (ushort)((Flags & 0x03E0) >> 5);
            set => Flags = (ushort)((Flags & ~0x03E0) | ((value & 0x001F) << 5));
        }

        public ushort Index3
        {
            readonly get => (ushort)((Flags & 0x7C00) >> 10);
            set => Flags = (ushort)((Flags & ~0x7C00) | ((value & 0x001F) << 10));
        }
    }

    [FieldOffset(0x0)] public ResourceHandle ResourceHandle;
    /// <summary>
    /// The instantiated material. Its <see cref="Material.MaterialResourceHandle"/> will be the current structure.
    /// </summary>
    [FieldOffset(0xC0)] public Material* Material;
    [FieldOffset(0xC8)] public ShaderPackageResourceHandle* ShaderPackageResourceHandle;
    [FieldOffset(0xD0)] public TextureEntry* Textures;
    [FieldOffset(0xE0)] public byte* Strings;
    [FieldOffset(0xF8)] public ushort ShpkNameOffset;
    [FieldOffset(0xFA)] public byte TextureCount;

    public readonly Span<TextureEntry> TexturesSpan
        => new(Textures, TextureCount);

    public readonly byte* ShpkName
        => Strings + ShpkNameOffset;

    public readonly ReadOnlySpan<byte> ShpkNameSpan
        => MemoryMarshal.CreateReadOnlySpanFromNullTerminated(ShpkName);

    public readonly string ShpkNameString
        => Encoding.UTF8.GetString(ShpkNameSpan);

    public readonly byte* TexturePath(int index)
    {
        if (index < 0 || index >= TextureCount)
            throw new ArgumentOutOfRangeException(nameof(index));
        return Strings + Textures[index].PathOffset;
    }

    public readonly ReadOnlySpan<byte> TexturePathSpan(int index)
        => MemoryMarshal.CreateReadOnlySpanFromNullTerminated(TexturePath(index));

    public readonly string TexturePathString(int index)
        => Encoding.UTF8.GetString(TexturePathSpan(index));

    [MemberFunction("4C 8B DC 49 89 5B ?? 49 89 73 ?? 55 57 41 55")]
    public partial byte LoadTexFiles();

    [MemberFunction("48 89 5C 24 ?? 57 48 81 EC ?? ?? ?? ?? 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 84 24 ?? ?? ?? ?? 44 0F B7 89")]
    public partial byte LoadShpkFiles();
}