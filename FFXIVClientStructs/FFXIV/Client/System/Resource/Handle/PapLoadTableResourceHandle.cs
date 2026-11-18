namespace FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

// Client::System::Resource::Handle::PapLoadTableResourceHandle
//   Client::System::Resource::Handle::DefaultResourceHandle
//     Client::System::Resource::Handle::ResourceHandle
//       Client::System::Common::NonCopyable
// .plt
// This is a sparse table where the AnimationEntries are the columns, the ModelEntries are the rows, and each row has a bitfield of which cells (RedirectEntries) exist.
[GenerateInterop]
[Inherits<DefaultResourceHandle>]
[StructLayout(LayoutKind.Explicit, Size = 0x100)]
public unsafe partial struct PapLoadTableResourceHandle {

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public struct FileHeader {
        /// <summary>
        /// The number of animation entries in the pap load table.
        /// </summary>
        [FieldOffset(0x0)] public ushort AnimationEntryCount;

        /// <summary>
        /// The number of model entries in the pap load table.
        /// </summary>
        [FieldOffset(0x2)] public ushort ModelEntryCount;

        /// <summary>
        /// The number of groups of four animation redirect entries in the pap load table.
        /// </summary>
        [FieldOffset(0x4)] public uint RedirectEntryGroupCount;

        /// <summary>
        /// The offset into the resource data where the pap folder strings start.
        /// </summary>
        [FieldOffset(0x8)] public uint PapFolderStringsOffset;

        /// <summary>
        /// The offset into the resource data where the pap name strings start.
        /// </summary>
        [FieldOffset(0xC)] public uint PapNameStringsOffset;
    }

    /// <summary>
    /// Contains info about an animation.
    /// </summary>
    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0xC)]
    public partial struct AnimationEntry {

        [BitField<bool>(nameof(IsMount08), 18, 1)]
        [BitField<bool>(nameof(IsMount07), 17, 1)]
        [BitField<bool>(nameof(IsMount06), 16, 1)]
        [BitField<bool>(nameof(IsMount05), 15, 1)]
        [BitField<bool>(nameof(IsCommonResidentOrnament), 14, 1)]
        [BitField<bool>(nameof(IsCustomResidentOrnament), 13, 1)]
        [BitField<bool>(nameof(IsMount04), 12, 1)]
        [BitField<bool>(nameof(IsMount03), 11, 1)]
        [BitField<bool>(nameof(IsWildcard), 10, 1)]
        [BitField<bool>(nameof(IsMount02), 9, 1)]
        [BitField<bool>(nameof(IsMount01), 8, 1)]
        [BitField<bool>(nameof(IsMount), 7, 1)]
        [BitField<bool>(nameof(IsCommonResidentMount), 6, 1)]
        [BitField<bool>(nameof(IsHumanResident), 5, 1)]
        [BitField<bool>(nameof(IsMonsterResident), 4, 1)]
        [BitField<bool>(nameof(IsDemihumanResident), 3, 1)]
        //[BitField<bool>(nameof(UnkFlag2), 2, 1)]
        //[BitField<bool>(nameof(UnkFlag1), 1, 1)]
        //[BitField<bool>(nameof(UnkFlag0), 0, 1)]
        [FieldOffset(0x0)] public uint Flags;

        /// <summary>
        /// The offset of the folder the pap resource is in relative to the model's animation variant folder.
        /// </summary>
        /// <remarks>
        /// Pass to <see cref="GetPapFolder(uint)"/> to obtain the string data.
        /// </remarks>
        [FieldOffset(0x4)] public uint PapFolderOffset;

        /// <summary>
        /// The offset of the name of the pap resource within its folder.
        /// </summary>
        /// <remarks>
        /// Pass to <see cref="GetPapName(uint)"/> to obtain the string data.
        /// </remarks>
        [FieldOffset(0x8)] public uint PapNameOffset;
    }

    /// <summary>
    /// Specifies which animation entries are overridden for an animation variant of a character model.
    /// </summary>
    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0xA8)]
    public partial struct ModelEntry {
        /// <summary>
        /// The character type and model ID that this entry affects.
        /// </summary>
        [BitField<ushort>(nameof(CharacterType), sizeof(ushort), sizeof(ushort))] // 0: human, 1: monster, 2: demihuman, 3: weapon, different order from ModelType
        [BitField<ushort>(nameof(ModelId), 0, sizeof(ushort))]
        [FieldOffset(0x0)] public uint AnimationModelId;

        /// <summary>
        /// The animation variant that this entry affects.
        /// </summary>
        [FieldOffset(0x4)] public ushort AnimationVariant;

        /// <summary>
        /// How far into <see cref="RedirectEntries"/> this entry's redirects start at, measured in groups of 4.
        /// </summary>
        [FieldOffset(0x6)] public ushort RedirectStartOffsetGroups;

        /// <summary>
        /// Which of the groups of 4 animation entries are overridden for this character
        /// </summary>
        [FieldOffset(0x8), FixedSizeArray(isBitArray: true, bitCount: 160 * 8)] internal FixedSizeArray160<byte> _animationGroupsOverriddenBits;

        public bool IsAnimationOverridden(int animationEntryIndex) {
            var bit = animationEntryIndex / 4; // Each bit is for four consecutive redirects
            return ((_animationGroupsOverriddenBits[bit / 8] >> (bit % 8)) & 1) != 0;
        }
    }

    /// <summary>
    /// Specifies a pap resource that a character should load rather than having its own.
    /// </summary>
    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x8)]
    public partial struct RedirectEntry {
        /// <summary>
        /// The character type and model ID of the animation pack being redirected to.
        /// </summary>
        [BitField<ushort>(nameof(CharacterType), sizeof(ushort), sizeof(ushort))] // 0: human, 1: monster, 2: demihuman, 3: weapon, different order from ModelType
        [BitField<ushort>(nameof(ModelId), 0, sizeof(ushort))]
        [FieldOffset(0x0)] public uint AnimationModelId;

        /// <summary>
        /// The animation variant of the animation pack being redirected to.
        /// </summary>
        [FieldOffset(0x4)] public ushort AnimationVariant;

        /// <summary>
        /// The offset of the name of the subfolder the replacement pap resource is in.
        /// </summary>
        /// <remarks>
        /// Pass to <see cref="GetPapFolder(uint)"/> to obtain the string data.
        /// </remarks>
        [FieldOffset(0x6)] public ushort PapFolderOffset;
    }

    [FieldOffset(0xC0)] public FileHeader* Header;
    [FieldOffset(0xC8)] private AnimationEntry* _animationEntriesPtr;
    [FieldOffset(0xD0)] private ModelEntry* _modelEntriesPtr;
    [FieldOffset(0xD8)] private RedirectEntry* _redirectEntriesPtr;
    [FieldOffset(0xE0)] public byte* PapFolderData;
    [FieldOffset(0xE8)] public byte* PapNameData;
    //[FieldOffset(0xF0)] looks like a StdMap or StdSet, except neither quite line up how I'd expect. Maps string hashes to their offset in the PapFolderNameData.

    public Span<AnimationEntry> AnimationEntries
        => new(_animationEntriesPtr, Header->AnimationEntryCount);

    public Span<ModelEntry> ModelEntries
        => new(_modelEntriesPtr, Header->ModelEntryCount);

    public Span<RedirectEntry> RedirectEntries
        => new(_redirectEntriesPtr, (int)Header->RedirectEntryGroupCount * 4);

    public CStringPointer GetPapFolder(uint offset)
        => new(&PapFolderData[offset]);

    public CStringPointer GetPapName(uint offset)
        => new(&PapNameData[offset]);

    /// <summary>
    /// Determines the final animation pack to use for a certain animation to be played by a specific model.
    /// </summary>
    /// <param name="outAnimationPackInfo">A pointer to the animation pack details to place the returned info in.</param>
    /// <param name="model">The model that the animation is for.</param>
    /// <param name="animationIndex">The index of the animation to get the pap for, in <see cref="AnimationEntries"/>.</param>
    [MemberFunction("E8 ?? ?? ?? ?? 0F B7 44 24 ?? 4B 8D 0C 64")]
    public partial void GetFinalAnimationPack(RedirectEntry* outAnimationPackInfo, ModelEntry* model, uint animationIndex);

    /// <summary>
    /// Constructs the path to a pap resource based on the given model, animation variant, and folder and pap name.
    /// </summary>
    /// <remarks>
    /// The paths look like so:
    /// <c>chara/[human|monster|demihuman|weapon]/[h|m|d|w]####/animation/a####/????????/???.pap</c>
    /// </remarks>
    /// <param name="buffer">The buffer to fill with the resulting path.</param>
    /// <param name="bufferLength">The length of <paramref name="buffer"/>.</param>
    /// <param name="animationModelId">The character type and model ID of the animation pack.</param>
    /// <param name="animationVariant">The animation variant.</param>
    /// <param name="folder">The folder where the pap resource is stored relative to the model's animation variant folder.</param>
    /// <param name="name">The name of the pap resource.</param>
    [MemberFunction("E8 ?? ?? ?? ?? 48 8D 4D 00 44 89 64 24")]
    public partial void MakeAnimationPackPath(char* buffer, nint bufferLength, uint animationModelId, uint animationVariant, CStringPointer folder, CStringPointer name);
}
