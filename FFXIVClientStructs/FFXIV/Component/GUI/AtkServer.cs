using FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;
using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

/// <summary>
/// Handles UI rendering by taking UI drawing commands and submitting them as kernel drawing commands.
/// </summary>
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x8680)]
public unsafe partial struct AtkServer {
    [FieldOffset(0x10)] public ShaderCodeResourceHandle* PrimitiveUIVSResource;
    [FieldOffset(0x18)] internal ShaderCodeResourceHandle* _primitiveUIVSResource_2;
    [FieldOffset(0x20)] internal ShaderCodeResourceHandle* _primitiveUIVSResource_3;
    [FieldOffset(0x28)] internal ShaderCodeResourceHandle* _primitiveUIVSResource_4;
    [FieldOffset(0x30)] public ShaderCodeResourceHandle* FontVSResource;
    [FieldOffset(0x38)] public ShaderCodeResourceHandle* FontEdgeVSResource;
    [FieldOffset(0x40)] public ShaderCodeResourceHandle* FontGlareVSResource;
    [FieldOffset(0x48)] public ShaderCodeResourceHandle* FontHighlightVSResource;
    [FieldOffset(0x50)] public ShaderCodeResourceHandle* FontEmbossVSResource;
    [FieldOffset(0x58)] public ShaderCodeResourceHandle* PrimitiveUIPSResource;
    [FieldOffset(0x60)] public ShaderCodeResourceHandle* PrimitiveUINaviMapPSResource;
    [FieldOffset(0x68)] public ShaderCodeResourceHandle* PrimitiveUIAreaMapPSResource;
    [FieldOffset(0x70)] public ShaderCodeResourceHandle* PrimitiveUICharaViewPSResource;
    [FieldOffset(0x78)] public ShaderCodeResourceHandle* FontPSResource;
    [FieldOffset(0x80)] public ShaderCodeResourceHandle* FontEdgePSResource;
    [FieldOffset(0x88)] public ShaderCodeResourceHandle* FontGlarePSResource;
    [FieldOffset(0x90)] public ShaderCodeResourceHandle* FontHighlightPSResource;
    [FieldOffset(0x98)] public ShaderCodeResourceHandle* FontEmbossPSResource;
    [FieldOffset(0xA0)] public ShaderCodeResourceHandle* PrimitiveUIMaskPSResource;

    [FieldOffset(0xE8)] public VertexShader* PrimitiveUIVS;
    [FieldOffset(0xF0)] internal VertexShader* _primitiveUIVS_2;
    [FieldOffset(0xF8)] internal VertexShader* _primitiveUIVS_3;
    [FieldOffset(0x100)] internal VertexShader* _primitiveUIVS_4;
    [FieldOffset(0x108)] public VertexShader* FontVS;
    [FieldOffset(0x110)] public VertexShader* FontEdgeVS;
    [FieldOffset(0x118)] public VertexShader* FontGlareVS;
    [FieldOffset(0x120)] public VertexShader* FontHighlightVS;
    [FieldOffset(0x128)] public VertexShader* FontEmbossVS;
    [FieldOffset(0x130)] public PixelShader* PrimitiveUIPS;
    [FieldOffset(0x138)] public PixelShader* PrimitiveUINaviMapPS;
    [FieldOffset(0x140)] public PixelShader* PrimitiveUIAreaMapPS;
    [FieldOffset(0x148)] public PixelShader* PrimitiveUICharaViewPS;
    [FieldOffset(0x150)] public PixelShader* FontPS;
    [FieldOffset(0x158)] public PixelShader* FontEdgePS;
    [FieldOffset(0x160)] public PixelShader* FontGlarePS;
    [FieldOffset(0x168)] public PixelShader* FontHightlightPS;
    [FieldOffset(0x170)] public PixelShader* FontEmbossPS;
    [FieldOffset(0x178)] public PixelShader* PrimitiveUIMaskPS;

    [FieldOffset(0x1C0)] private void* /* VertexDeclaration */ VertexDeclarationArray; // array size 3
    [FieldOffset(0x1D8)] private void* /* VertexBuffer */ VertexBuffer;
    [FieldOffset(0x1E0)] private void* /* IndexBuffer */ IndexBuffer;

    [FieldOffset(0x4C0)] public Texture* WhiteTexture; // 4x4 solid white
    [FieldOffset(0x4C8)] public Texture* BlackTexture; // 4x4 solid black

    [FieldOffset(0x580)] public AtkUICommandEntry* UICommandList;
    [FieldOffset(0x588)] public uint UICommandCount;
    [FieldOffset(0x590)] public AtkContext* ContextArray; // size 16

    [FieldOffset(0x8670)] public bool IsRenderingToTexture;

    [VirtualFunction(0)]
    public partial AtkServer* Dtor(byte flags);

    [MemberFunction("48 89 5C 24 ?? 48 89 6C 24 ?? 56 57 41 54 41 56 41 57 48 83 EC ?? 44 8B 05")]
    public partial void Draw(bool a2);

    // TODO: ProcessUICommands is used for 16-bit indexes in the index buffer, Alt is used for 32-bit indexes, should rename
    // AtkServer is created with a 16-bit IndexBuffer, unsure if the game ever resizes it
    [MemberFunction("E9 ?? ?? ?? ?? CC CC CC CC CC CC CC CC CC CC 48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 7C 24 ?? 41 56")]
    public partial void ProcessUICommands(bool a2);

    [MemberFunction("E8 ?? ?? ?? ?? EB 05 E8 ?? ?? ?? ?? 4C 8D 5C 24")]
    public partial void ProcessUICommandsAlt(bool a2);

    [MemberFunction("48 85 C9 74 ?? E8 ?? ?? ?? ?? 84 C0 75 ?? B8 FF FF FF FF", 6)]
    public partial bool LoadShaders();

    [MemberFunction("E8 ?? ?? ?? ?? 41 8B 54 24 30 8B 4C 24 4C 4C 8B 45 90 C1 EA 0C")]
    public partial void SetDrawState(DrawState* state, byte textureDivisor);

    [MemberFunction("48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 57 48 83 EC 20 65 48 8B 04 25 58 00 00 00 41 0F B6 F0 44 8B 0D ?? ?? ?? ?? 48 8B D9 8B EA")]
    public partial void BindShaders(ShaderPass pass, bool masked);

    public enum ShaderPass {
        Font = 4,
        FontEdge = 5,
        FontGlare = 6,
        FontHighlight = 7,
        FontEmboss = 8,
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public struct DrawState {
        [FieldOffset(0x00)] public PackedBlendStateDesc BlendState;
        [FieldOffset(0x08)] public Texture* Texture;
    }
}
