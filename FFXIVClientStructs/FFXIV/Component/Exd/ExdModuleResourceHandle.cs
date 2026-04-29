using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;
using FFXIVClientStructs.FFXIV.Common.Component.Environment;
using FFXIVClientStructs.FFXIV.Common.Component.Excel;

namespace FFXIVClientStructs.FFXIV.Component.Exd;

[GenerateInterop]
[Inherits<ResourceInterface.ResourceHandleInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0xB8)]
public unsafe partial struct ExdModuleResourceHandle {
    [FieldOffset(0x8)] public Common.Component.Excel.LinkedList<ExdModuleResourceHandle> LinkedList;
    [FieldOffset(0x20)] public ResourceHandle* ResourceHandle;
    [FieldOffset(0x28), FixedSizeArray(true)] internal FixedSizeArray128<byte> _sheetPath;
    [FieldOffset(0xA8)] public ExcelModule* ExcelModule;
    [FieldOffset(0xB0)] private void* UnkPtr;
}