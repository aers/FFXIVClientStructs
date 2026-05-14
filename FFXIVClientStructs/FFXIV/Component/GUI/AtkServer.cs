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
    [FieldOffset(0x68)] public ShaderCodeResourceHandle* PrimitiveUResourceIAreaMapPSResource;
    [FieldOffset(0x70)] public ShaderCodeResourceHandle* PrimitiveUICharaViewPSResource;
    [FieldOffset(0x78)] public ShaderCodeResourceHandle* FontPSResource;
    [FieldOffset(0x80)] public ShaderCodeResourceHandle* FontEdgePSResource;
    [FieldOffset(0x88)] public ShaderCodeResourceHandle* FontGlarePSResource;
    [FieldOffset(0x90)] public ShaderCodeResourceHandle* FontHightlightPSResource;
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


    [FieldOffset(0x4C0)] public Texture* WhiteTexture; // 4x4 solid white
    [FieldOffset(0x4C8)] public Texture* BlackTexture; // 4x4 solid black

    [VirtualFunction(0)]
    public partial AtkServer* Dtor(byte flags);

    [MemberFunction("48 89 5C 24 ?? 48 89 6C 24 ?? 56 57 41 54 41 56 41 57 48 83 EC 50 44 8B 05")]
    public partial ulong Draw(bool unk);

    [MemberFunction("E9 ?? ?? ?? ?? CC CC CC CC CC CC CC CC CC CC 48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 7C 24 ?? 41 56")]
    public partial ulong ProcessUICommands(bool unk);

    [MemberFunction("E8 ?? ?? ?? ?? EB 05 E8 ?? ?? ?? ?? 4C 8D 5C 24")]
    public partial ulong ProcessUICommandsAlt(bool unk);
}
