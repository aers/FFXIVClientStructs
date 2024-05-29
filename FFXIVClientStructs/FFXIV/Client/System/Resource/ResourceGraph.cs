using System.Diagnostics.CodeAnalysis;
using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

namespace FFXIVClientStructs.FFXIV.Client.System.Resource;

using CategoryMap = StdMap<uint, Pointer<StdMap<uint, Pointer<ResourceHandle>>>>;

[StructLayout(LayoutKind.Explicit, Size = 0xC80)]
[GenerateInterop]
public unsafe partial struct ResourceGraph {
    [StructLayout(LayoutKind.Explicit, Size = 0xA0)]
    [GenerateInterop]
    public partial struct CategoryContainer {
        [FieldOffset(0x0)][FixedSizeArray] internal FixedSizeArray20<Pointer<CategoryMap>> _categoryMaps;

        public CategoryMap* MainMap => CategoryMaps[0].Value;
        public CategoryMap* this[int index] => CategoryMaps[index].Value;
    }

    [FieldOffset(0x0)][FixedSizeArray] internal FixedSizeArray20<CategoryContainer> _containerArray;
    
    [UnscopedRef] public ref CategoryContainer GetContainer(ResourceCategory category) => ref ContainerArray[(int)category];
}
