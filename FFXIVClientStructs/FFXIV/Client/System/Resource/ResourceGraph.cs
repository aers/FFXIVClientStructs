using System.Diagnostics.CodeAnalysis;
using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

namespace FFXIVClientStructs.FFXIV.Client.System.Resource;

using CategoryMap = StdMap<uint, Pointer<StdMap<uint, Pointer<ResourceHandle>>>>;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0xC80)]
public unsafe partial struct ResourceGraph {
    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0xA0)]
    public partial struct CategoryContainer {
        [FieldOffset(0x0), FixedSizeArray] internal FixedSizeArray20<Pointer<CategoryMap>> _categoryMaps;

        public CategoryMap* MainMap => CategoryMaps[0].Value;
        public CategoryMap* this[int index] => CategoryMaps[index].Value;
    }

    [FieldOffset(0x0), FixedSizeArray] internal FixedSizeArray20<CategoryContainer> _containers;

    [UnscopedRef] public ref CategoryContainer GetContainer(ResourceCategory category) => ref Containers[(int)category];

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B D8 48 85 C0 0F 85 ?? ?? ?? ?? 48 8B 84 24")]
    public partial ResourceHandle* FindResourceHandle(ResourceCategory* category, uint* type, uint* hash); // TODO: first arg is `ResourceHandleType*` and renamed to `resourceHandleType` -> this.Containers[resourceHandleType->Category].CategoryMaps[resourceHandleType->CategoryMapIndex]
}
