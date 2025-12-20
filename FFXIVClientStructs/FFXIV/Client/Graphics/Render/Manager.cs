namespace FFXIVClientStructs.FFXIV.Client.Graphics.Render;

// Client::Graphics::Render::Manager
//   Client::Graphics::Singleton<Client::Graphics::Render::Manager>
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x40380)]
public unsafe partial struct Manager {
    [StaticAddress("48 8B 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 84 C0 74 ?? 48 8B 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 33 C9", 3, true)]
    public static partial Manager* Instance();

    [FieldOffset(0x8), FixedSizeArray] internal FixedSizeArray87<View> _views;
    [FieldOffset(0x87F8)] public JobSystem ManagerJobSystem; // Client::Graphics::JobSystem<Client::Graphics::Render::Manager>
    [FieldOffset(0x88B8)] public PostBoneDeformerBaseUpdater PostBoneDeformerBaseUpdater; // Client::Graphics::Render::Updater<Client::Graphics::Render::PostBoneDeformerBase>
    [FieldOffset(0x10908)] public ShaderManager ShaderManager;
    [FieldOffset(0x10AE0)] public ModelRenderer ModelRenderer;
    [FieldOffset(0x10F30)] public BGInstancingRenderer BGInstancingRenderer;
    [FieldOffset(0x31D90)] public TerrainRenderer TerrainRenderer;
    // [FieldOffset(0x47F20)] private UnknownRenderer UnknownRenderer; // 0x230 BGAmbient something?
    [FieldOffset(0x363F0)] public WaterRenderer WaterRenderer;
    [FieldOffset(0x36960)] public VerticalFogRenderer VerticalFogRenderer;

    // [FieldOffset(0x487F8)] private UnknownRenderer1 UnknownRenderer1; // 0xE0
    // [FieldOffset(0x488E0)] private UnknownRenderer2 UnknownRenderer2; // 0x7A10 Grass?
    // [FieldOffset(0x502F0)] private UnknownRenderer3 UnknownRenderer3; // 0xD0 Sky?
    // [FieldOffset(0x503C0)] private UnknownRenderer4 UnknownRenderer4; // 0x480
    // [FieldOffset(0x50840)] private UnknownRenderer5 UnknownRenderer5_1; // 0xE0 Clouds?
    // [FieldOffset(0x50920)] private UnknownRenderer5 UnknownRenderer5_2; // 0xE0
    // [FieldOffset(0x50A00)] private UnknownRenderer5 UnknownRenderer5_3; // 0xE0
    // [FieldOffset(0x50AE0)] private UnknownRenderer6 UnknownRenderer6; // 0x1A8
    // [FieldOffset(0x50C88)] private UnknownRenderer7 UnknownRenderer7; // 0x68
    // [FieldOffset(0x50CF0)] private Unk1 Unk1; // 0x40
    // [FieldOffset(0x50D30)] private Unk2 Unk2; // 0x40

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
