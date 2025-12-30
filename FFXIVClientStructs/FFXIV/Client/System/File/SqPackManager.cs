using System;
using System.Collections.Generic;
using System.Text;
using FFXIVClientStructs.FFXIV.Client.System.Resource;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.System.File;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0xAF0)]
public unsafe partial struct SqPackManager {
    [FieldOffset(0x000)] public FileManager* FileManager;
    [FieldOffset(0x014)] public SqPackIndexHeader IndexHeader;
    [FieldOffset(0x414)] public SqPackHeader SqPackHeader;
    [FieldOffset(0x814)] public ResourceCategory ResourceCategory;
    [FieldOffset(0x818)] public int PackId;
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
    [FieldOffset(0xAE8)] public void* GetOffset;

    [MemberFunction("E8 ?? ?? ?? ?? EB 03 49 8B C7 48 89 03 48 83 C3 08")]
    public partial void Ctor();

    [MemberFunction("E8 ?? ?? ?? ?? 49 8D 55 70 49 8B CF")]
    public partial bool LoadIndexFile(ResourceCategory category, int packId);

    [MemberFunction("48 89 6C 24 ?? 56 57 41 56 48 81 EC ?? ?? ?? ?? 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 84 24 ?? ?? ?? ?? 8B 69 64")]
    public partial bool LoadDataFiles();

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 8B ?? ?? ?? ?? 44 38 69 20")]
    public partial ulong GetSqPackPath(FileAccessPath* path, int fileId, ResourceCategory category, int packId, byte* platform, byte* a7);

    [MemberFunction("40 55 41 54 41 56 41 57 48 81 EC ?? ?? ?? ?? 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 84 24 ?? ?? ?? ?? 80 79 0A 00")]
    public partial bool GetOffsetFromIndex(CStringPointer path, uint* offset, uint* fileId);

    [MemberFunction("40 53 55 56 57 41 54 41 55 41 56 41 57 48 81 EC ?? ?? ?? ?? 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 84 24 ?? ?? ?? ?? 48 8B EA"), GenerateStringOverloads]
    public partial bool GetOffsetFromIndex2(CStringPointer path, uint* offset, uint* fileId);

    [StaticAddress("48 8D 0D ?? ?? ?? ?? 80 3C 08 ?? 0F 85", 3, isPointer: true)]
    public static partial byte* GetIndex2Table();
}


