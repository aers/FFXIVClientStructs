using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.LayoutEngine;

[StructLayout(LayoutKind.Explicit, Size = 0x228)]
public unsafe partial struct LayoutWorld
{
    [StaticAddress("48 89 05 ?? ?? ?? ?? 48 8B 00", 3, isPointer: true)]
    public static partial LayoutWorld* Instance();

    [FieldOffset(0x20)] public LayoutManager* ActiveLayout;
    [FieldOffset(0x218)] public StdMap<Utf8String, Pointer<byte>>* RsvMap;
}