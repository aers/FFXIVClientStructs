using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

namespace FFXIVClientStructs.FFXIV.Client.System.Resource;

using CategoryMap = StdMap<uint, Pointer<StdMap<uint, Pointer<ResourceHandle>>>>;

public enum ResourceCategory {
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
public unsafe partial struct ResourceGraph {
    [StructLayout(LayoutKind.Explicit, Size = 0xA0)]
    public partial struct CategoryContainer {
        [FixedSizeArray<Pointer<CategoryMap>>(0x14)]
        [FieldOffset(0x0)] public fixed byte CategoryMaps[0x8 * 0x14];

        [FieldOffset(0x0), Obsolete("Use CategoryMapsSpan[0]")] public CategoryMap* MainMap;
    }

    [FixedSizeArray<CategoryContainer>(0x14)]
    [FieldOffset(0x0)] public fixed byte ContainerArray[0xA0 * 0x14];

    [FieldOffset(0x000), Obsolete("Use ContainerArraySpan[0]")] public CategoryContainer CommonContainer;
    [FieldOffset(0x0A0), Obsolete("Use ContainerArraySpan[1]")] public CategoryContainer BgCommonContainer;
    [FieldOffset(0x140), Obsolete("Use ContainerArraySpan[2]")] public CategoryContainer BgContainer;
    [FieldOffset(0x1E0), Obsolete("Use ContainerArraySpan[3]")] public CategoryContainer CutContainer;
    [FieldOffset(0x280), Obsolete("Use ContainerArraySpan[4]")] public CategoryContainer CharaContainer;
    [FieldOffset(0x320), Obsolete("Use ContainerArraySpan[5]")] public CategoryContainer ShaderContainer;
    [FieldOffset(0x3C0), Obsolete("Use ContainerArraySpan[6]")] public CategoryContainer UiContainer;
    [FieldOffset(0x460), Obsolete("Use ContainerArraySpan[7]")] public CategoryContainer SoundContainer;
    [FieldOffset(0x500), Obsolete("Use ContainerArraySpan[8]")] public CategoryContainer VfxContainer;
    [FieldOffset(0x5A0), Obsolete("Use ContainerArraySpan[9]")] public CategoryContainer UiScriptContainer;
    [FieldOffset(0x640), Obsolete("Use ContainerArraySpan[10]")] public CategoryContainer ExdContainer;
    [FieldOffset(0x6E0), Obsolete("Use ContainerArraySpan[11]")] public CategoryContainer GameScriptContainer;
    [FieldOffset(0x780), Obsolete("Use ContainerArraySpan[12]")] public CategoryContainer MusicContainer;
    [FieldOffset(0xB40), Obsolete("Use ContainerArraySpan[13]")] public CategoryContainer SqpackTestContainer;
    [FieldOffset(0xBE0), Obsolete("Use ContainerArraySpan[14]")] public CategoryContainer DebugContainer;
}
