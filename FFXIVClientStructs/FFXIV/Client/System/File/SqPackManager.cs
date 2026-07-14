using FFXIVClientStructs.FFXIV.Client.System.Resource;

namespace FFXIVClientStructs.FFXIV.Client.System.File;

// Client::System::File::SqPackManager
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0xAF0)]
public unsafe partial struct SqPackManager {
    [FieldOffset(0x00)] public FileManager* FileManager;
    [FieldOffset(0x08)] public bool IsLoaded;
    [FieldOffset(0x09)] public bool IsLoading;
    [FieldOffset(0x0C)] public ResourceCategory LoadedResourceCategory;
    [FieldOffset(0x10)] public uint LoadedExpansionId;
    [FieldOffset(0x14)] public SqPackIndexHeader IndexHeader;
    [FieldOffset(0x414)] public SqPackHeader SqPackHeader;
    [FieldOffset(0x814)] public ResourceCategory ResourceCategory;
    [FieldOffset(0x818)] public uint ExpansionId;
    [FieldOffset(0x81C)] public uint DataCount;
    [FieldOffset(0x820)] public uint SynonymDataCount;
    [FieldOffset(0x824)] public uint DirIndexDataCount;
    [FieldOffset(0x834)] public uint FileSize;
    [FieldOffset(0x840)] public FileAccessPath FilePath;

    [FieldOffset(0xA50)] public void* IndexData;
    [FieldOffset(0xA58)] public void* SynonymData;
    [FieldOffset(0xA60)] public void* DirIndexData;
    [FieldOffset(0xA88), FixedSizeArray] internal FixedSizeArray10<Pointer<FileInterface>> _dataFiles;
    [FieldOffset(0xAD8)] public FileInterface* IndexFile;
    [FieldOffset(0xAE8)] public void* GetOffsetPtr; // a pointer to either TryGetOffsetFromIndex or TryGetOffsetFromIndex2 depending on IndexHeader.IndexType

    [MemberFunction("E8 ?? ?? ?? ?? 49 8D 55 ?? 49 8B CF")]
    public partial bool LoadSqPack(ResourceCategory category, uint expansionId);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 8B ?? ?? ?? ?? 44 38 69")]
    public partial void ResolveSqPackPath(FileAccessPath* path, int fileId, ResourceCategory category, uint expansionId, byte* platform, byte* a7);

    [MemberFunction("48 8D 05 ?? ?? ?? ?? 44 88 6B")]
    public partial bool TryGetOffsetFromIndex(CStringPointer path, uint* outOffset, uint* outFileId);

    [MemberFunction("48 8D 3D ?? ?? ?? ?? 75 ?? 48 89 BB"), GenerateStringOverloads]
    public partial bool TryGetOffsetFromIndex2(CStringPointer path, uint* outOffset, uint* outFileId);
}
