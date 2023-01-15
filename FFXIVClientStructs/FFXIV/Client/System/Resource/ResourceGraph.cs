using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

namespace FFXIVClientStructs.FFXIV.Client.System.Resource;

using CategoryMap = StdMap<uint, Pointer<StdMap<uint, Pointer<ResourceHandle>>>>;

public enum ResourceCategory
{
    Common = 0,
    BgCommon = 1,
    Bg = 2,
    Cut = 3,
    Chara = 4,
    Shader = 5,
    Ui = 6,
    Sound = 7,
    Vfx = 8,
    UiScript = 9,
    Exd = 10,
    GameScript = 11,
    Music = 12,
    SqpackTest = 18,
    Debug = 19,
    MaxCount = 20
}

[StructLayout(LayoutKind.Explicit, Size = 0xC80)]
public unsafe partial struct ResourceGraph
{
    [StructLayout(LayoutKind.Explicit, Size = 0xA0)]
    public partial struct CategoryContainer
    {
        [FixedSizeArray<Pointer<CategoryMap>>(0x14)]
        [FieldOffset(0x0)] public fixed byte CategoryMaps[0x8 * 0x14];

        [FieldOffset(0x0)] public CategoryMap* MainMap;
    }

    [FixedSizeArray<CategoryContainer>(0x14)]
    [FieldOffset(0x0)] public fixed byte ContainerArray[0xA0 * 0x14];

    [FieldOffset(0x000)] public CategoryContainer CommonContainer;
    [FieldOffset(0x0A0)] public CategoryContainer BgCommonContainer;
    [FieldOffset(0x140)] public CategoryContainer BgContainer;
    [FieldOffset(0x1E0)] public CategoryContainer CutContainer;
    [FieldOffset(0x280)] public CategoryContainer CharaContainer;
    [FieldOffset(0x320)] public CategoryContainer ShaderContainer;
    [FieldOffset(0x3C0)] public CategoryContainer UiContainer;
    [FieldOffset(0x460)] public CategoryContainer SoundContainer;
    [FieldOffset(0x500)] public CategoryContainer VfxContainer;
    [FieldOffset(0x5A0)] public CategoryContainer UiScriptContainer;
    [FieldOffset(0x640)] public CategoryContainer ExdContainer;
    [FieldOffset(0x6E0)] public CategoryContainer GameScriptContainer;
    [FieldOffset(0x780)] public CategoryContainer MusicContainer;
    [FieldOffset(0xB40)] public CategoryContainer SqpackTestContainer;
    [FieldOffset(0xBE0)] public CategoryContainer DebugContainer;
}