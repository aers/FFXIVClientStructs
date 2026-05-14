using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;

// Client::Graphics::Kernel::ImmediateContext

// Client::Graphics::Kernel::ImmediateContextDX11
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x1858)]
public unsafe partial struct ImmediateContext {
    // Offset 0 is ID3D11DeviceContext

    [FieldOffset(0x08)] public Rectangle CurrentScissorRect;

    /// <summary>
    /// The currently bound render targets.
    /// </summary>
    [FieldOffset(0x28)] internal FixedSizeArray5<Pointer<Texture>> _currentRenderTargets;
    /// <summary>
    /// The currently bound depth stencil buffer, if any.
    /// </summary>
    [FieldOffset(0x50)] public Texture* CurrentDepthStencilBuffer;

    [FieldOffset(0xAC)] public uint CurrentDepthStateObfuscated; // The 5 bits of depth state in PackedDepthStencilDesc but sometimes obfuscated for some reason
    [FieldOffset(0xB0)] public PackedDepthStencilDesc CurrentStencilState; // With the depth fields masked out
    // 0xC8: InputLayoutDesc

    [FieldOffset(0xD0)] public VertexShader* CurrentVertexShader;
    [FieldOffset(0x1B8)] public PixelShader* CurrentPixelShader;

    // Certain types of complex clearing needs to be done by manually drawing to the render targets & depth buffer.
    [FieldOffset(0x700)] public VertexShader* ManualClearQuadVertexShader;
    [FieldOffset(0x708)] public PixelShader* ManualClearQuadPixelShader;
    // 0x710: ManualClearQuad???
    // 0x718: ManualClearQuadInputLayoutDesc
    [FieldOffset(0x730)] public GeometryShader* CurrentGeometryShader;
    [FieldOffset(0xB20)] public HullShader* CurrentHullShader;

    [CExporterTypeForce("ID3D11DeviceContext*", true)]
    [FieldOffset(0xBE8)] public void* D3D11DeviceContext;

    [FieldOffset(0xF10)] public DomainShader* CurrentDomainShader;

    [FieldOffset(0x17B3)] public byte BlendStateFlag; // Might be a bool to force creation of an underlying ID3D11BlendState*
    [FieldOffset(0x17B4)] public PackedBlendStateDesc CurrentBlendState;
    [CExporterTypeForce("ID3D11DeviceContext*", true)]
    [FieldOffset(0x17B8)] public void* D3D11DeviceContext_2;

    //[FieldOffset(0x1D70)] public InputLayout* CurrentInputLayout;
    [CExporterTypeForce("D3D11_PRIMITIVE_TOPOLOGY")]
    [FieldOffset(0x17D8)] public int CurrentPrimitiveTopology;

    [MemberFunction("E8 ?? ?? ?? ?? 49 8D 47 58")]
    public partial void SetBlendState(PackedBlendStateDesc blendState);

    [MemberFunction("E8 ?? ?? ?? ?? 41 8B 56 1C 48 8B CE")]
    public partial void SetDepthStencilState(byte obfuscatedDepthState, PackedDepthStencilDesc stencilState);

    // Along with the given packed rasterizer state, the following constant values are also used:
    // FrontCounterClockwise = true
    // DepthClipEnable = true
    // DepthBiasClamp = 100.0f
    // AntialiasedLineEnable = false
    [MemberFunction("E8 ?? ?? ?? ?? 49 8B 46 20 48 8B CE")]
    public partial void SetRasterizerState(PackedRasterizerStateDesc rasterizerState);

    [MemberFunction("E8 ?? ?? ?? ?? 4D 8B 46 68")]
    public partial ulong SetVertexShader(VertexShader* vertexShader, void** constantBuffers);

    [MemberFunction("E8 ?? ?? ?? ?? 4D 8B 46 78")]
    public partial ulong SetPixelShader(PixelShader* pixelShader, void** constantBuffers);

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 8B 57 7C")]
    public partial void SetViewport(Rectangle* viewportRectangle);

    [MemberFunction("E9 ?? ?? ?? ?? 48 8B 4A 10")]
    public partial void SetDefaultState();

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 83 7F ?? ?? 0F 84 ?? ?? ?? ?? 48 83 7F")] // 0x14022ACE0
    public partial void DoClearCommandViaDraw(RenderCommandClearDepth* clearCommand);

    [MemberFunction("48 89 6C 24 ?? 56 48 83 EC 40 48 83 7A")] // inlined in some places
    public partial void DoClearCommand(RenderCommandClearDepth* clearCommand);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 7B 18 45 33 FF")]
    public partial void ProcessCommands(RenderCommandBufferGroup* renderCommands, uint renderCommandCount);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 7B 18 45 33 FF")]
    public partial void PreprocessCommands(RenderCommandBufferGroup* renderCommands, uint renderCommandCount);

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 0F B6 83 ?? ?? ?? ?? 3C 01 73 70")]
    public partial RenderCommandBufferGroup* ExecuteCommands();
}
