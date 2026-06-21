namespace FFXIVClientStructs.FFXIV.Client.Graphics.Render;

// Client::Graphics::Render::Manager
//   Client::Graphics::Singleton<Client::Graphics::Render::Manager>
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x38390)]
public unsafe partial struct Manager {
    [StaticAddress("48 8B 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 84 C0 74 ?? 48 8B 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 33 C9", 3, true)]
    public static partial Manager* Instance();

    [FieldOffset(0x8), FixedSizeArray] internal FixedSizeArray87<View> _views;
    [FieldOffset(0x87F8)] public JobSystem ManagerJobSystem; // Client::Graphics::JobSystem<Client::Graphics::Render::Manager>
    [FieldOffset(0x88B8)] public PostBoneDeformerBaseUpdater PostBoneDeformerBaseUpdater; // Client::Graphics::Render::Updater<Client::Graphics::Render::PostBoneDeformerBase>
    [FieldOffset(0x10908)] public ShaderManager ShaderManager;
    [FieldOffset(0x10AF8)] public ModelRenderer ModelRenderer;
    [FieldOffset(0x10F40)] public BGInstancingRenderer BGInstancingRenderer;
    [FieldOffset(0x29D40)] public TerrainRenderer TerrainRenderer;
    // [FieldOffset(0x2E160)] private UnknownRenderer UnknownRenderer; // 0x230 BGAmbient something?
    [FieldOffset(0x2E390)] public WaterRenderer WaterRenderer;
    [FieldOffset(0x2E910)] public VerticalFogRenderer VerticalFogRenderer;
    [FieldOffset(0x2EA68)] public LightShaftRenderer LightShaftRenderer;
    [FieldOffset(0x2EB50)] public GrassRenderer GrassRenderer;
    [FieldOffset(0x36570)] public StarRenderer StarRenderer;
    [FieldOffset(0x36640)] public CloudRenderer CloudRenderer;
    [FieldOffset(0x36AC0)] public WeatherRenderer RainRenderer;
    [FieldOffset(0x36BB0)] private WeatherRenderer UnkWeatherRenderer; // unused?!
    [FieldOffset(0x36CA0)] public WeatherRenderer DustRenderer;
    [FieldOffset(0x36D90)] public ShadowMaskRenderer ShadowMaskRenderer;
    [FieldOffset(0x36F38)] public FigureRenderer FigureRenderer;
    // [FieldOffset(0x36FA0)] private UnknownRenderer36FA0 UnknownRenderer; // 0x148, BGGlass renderer? unused?!
    [FieldOffset(0x370E8)] public Footprint Footprint;
    [FieldOffset(0x37128)] public Raindrop Raindrop;

    // [FieldOffset(0x381C0)] private ReflectionStruct Reflection; // 0x140?

    [FieldOffset(0x38358)] public bool Is3DRenderingDisabled;

    // TODO check and update for 7.2
    public enum RenderViews : uint {
        OmniShadow0 = 0,
        OmniShadow1,
        OmniShadow2,
        OmniShadow3,
        OmniShadow4,
        OmniShadow5,
        OmniShadow6,
        OmniShadow7,
        OmniShadow8,
        OmniShadow9,
        OmniShadow10,
        OmniShadow11,
        OmniShadow12,
        OmniShadow13,
        OmniShadow14,
        OmniShadow15,
        OmniShadow16,
        OmniShadow17,
        OmniShadow18,
        OmniShadow19,
        OmniShadow20,
        OmniShadow21,
        OmniShadow22,
        OmniShadow23,
        Environment,
        View25,
        OffscreenRenderer0,
        OffscreenRenderer1,
        OffscreenRenderer2,
        OffscreenRenderer3,
        Main,
        Unused // unused in retail
    }

    public enum RenderSubViews : uint {
        Shadow0 = 0,
        Shadow1,
        Shadow2,
        Shadow3,
        Roof,
        Cube1,
        Cube2,
        Cube3,
        Cube4,
        Cube5,
        OmniShadow0,
        OmniShadow1,
        OmniShadow2,
        OmniShadow3,
        Shadow,
        Main,
        Query,
        Hud
    }
}
