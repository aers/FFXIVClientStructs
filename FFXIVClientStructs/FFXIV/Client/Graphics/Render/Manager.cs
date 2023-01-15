namespace FFXIVClientStructs.FFXIV.Client.Graphics.Render;
// Client::Graphics::Render::Manager
//  Client::Graphics::Singleton<Client::Graphics::Render::Manager>

// size = 0x2D6C0
// ctor 48 89 01 48 8D 59 08 
[StructLayout(LayoutKind.Explicit, Size = 0x2D710)]
public unsafe partial struct Manager
{
    public enum RenderViews : uint
    {
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

    public enum RenderSubViews : uint
    {
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

    [FieldOffset(0x0)] public void* Vtbl;
    [FixedSizeArray<View>(32)]
    [FieldOffset(0x8)] public fixed byte ViewArray[0x5A0 * 0x20]; // 32 Client::Graphics::Render::View
}