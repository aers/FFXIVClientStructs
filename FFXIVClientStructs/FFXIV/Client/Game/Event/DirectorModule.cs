using FFXIVClientStructs.FFXIV.Client.Game.InstanceContent;

namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

[StructLayout(LayoutKind.Explicit, Size = 0xA0)]
public unsafe struct DirectorModule
{
    [FieldOffset(0x00)] public ModuleBase ModuleBase;
    [FieldOffset(0x40)] public StdVector<Pointer<Director>> DirectorList;
    //id, ctor/dtor wrapper pair, ctor is func(id, contentId*), dtor just calls the dtor
    [FieldOffset(0x58)] public StdMap<ushort, StdPair<nint, nint>> DirectorFactories;
    [FieldOffset(0x98)] public ContentDirector* ActiveContentDirector;
}