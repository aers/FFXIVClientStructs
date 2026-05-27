using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;

// Client::Graphics::Kernel::Device
//   Client::Graphics::Singleton

// Client::Graphics::Kernel::DeviceDX11
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0xE0AC8)]
public unsafe partial struct Device {
    [StaticAddress("48 8B 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 80 7B 08 00", 3, isPointer: true)]
    public static partial Device* Instance();

    [FieldOffset(0x8)] public void* ContextArray; // TODO: We have a struct for this now (breaking change)
    [FieldOffset(0x10)] public void* RenderThread; // Client::Graphics::Kernel::RenderThread
    [FieldOffset(0x28)] private CallbackManager* Unk28;
    [FieldOffset(0x30)] private CallbackManager* Unk30;
    [FieldOffset(0x38)] private CallbackManager* Unk38;
    [FieldOffset(0x40)] public CallbackManager* OnResizeDestroy;
    [FieldOffset(0x48)] public CallbackManager* OnResizeCreate;
    [FieldOffset(0x70)] public SwapChain* SwapChain;
    [FieldOffset(0x7A)] public byte RequestResolutionChange;
    [FieldOffset(0x8C)] public uint Width;
    [FieldOffset(0x90)] public uint Height;
    [FieldOffset(0x94)] public float AspectRatio;
    [FieldOffset(0x98)] public float GammaCorrection;
    [FieldOffset(0x9C)] public int ColorFilter;
    [FieldOffset(0xA0)] public float ColorFilterRange;

    [FieldOffset(0xA8)] public bool IsFrameRateLimited;
    [FieldOffset(0xAE)] public short FrameRateLimit;

    // offset 0x758 contains render commands buffer
    // /// <summary>
    // /// The raw pointer to the start of the render command buffer array.
    // /// Use <see cref="RenderCommandBufferGroups" /> to access a collection of the array.
    // /// </summary>
    // Currently work in progress and will be wrong. Waiting to expose until it has been figured out fully.
    [FieldOffset(0x908)] internal RenderCommandBufferGroup* RenderCommandBuffer;
    [FieldOffset(0x910)] public uint RenderCommandBufferCount;

    [FieldOffset(0x9D8)] public void* hWnd;
    [FieldOffset(0x9E8)] public uint NewWidth;
    [FieldOffset(0x9EC)] public uint NewHeight;
    [FieldOffset(0x9F0)] public int FrameRate;
    [FieldOffset(0xA10)] private CallbackManager* UnkA10;
    [FieldOffset(0xA18)] private CallbackManager* UnkA18;

    [FieldOffset(0xE0A90), CExporterTypeForce("D3D_FEATURE_LEVEL", true)] public int D3DFeatureLevel; // D3D_FEATURE_LEVEL enum
    [FieldOffset(0xE0A98), CExporterTypeForce("IDXGIFactory1*", true)] public void* DXGIFactory; // IDXGIFactory1
    [FieldOffset(0xE0AA0), CExporterTypeForce("IDXGIOutput6*", true)] public void* DXGIOutput; // IDXGIOutput6
    [FieldOffset(0xE0AA8)] public void* D3D11Forwarder; // CID3D11Forwarder (ID3D11Device vtbl present here)
    /// <remarks>
    /// Type: ID3D11DeviceContext5* <br/>
    /// IDA doesn't have a reference for DeviceContext5 so we use the last one possible in the list defined in d3d11_3.h being ID3D11DeviceContext4*
    /// </remarks>
    [FieldOffset(0xE0AB0), CExporterTypeForce("ID3D11DeviceContext4*", true)] public void* D3D11DeviceContext;

    [FieldOffset(0xE0AC0)] public ImmediateContext* ImmediateContext; // Client::Graphics::Kernel::Device::ImmediateContext

    [MemberFunction("E8 ?? ?? ?? ?? 48 89 47 ?? B0")]
    public partial ConstantBuffer* CreateConstantBuffer(int byteSize, uint flags, uint unk);

    [MemberFunction("E8 ?? ?? ?? ?? 48 89 07 48 8D 7F 20")]
    public partial Texture* CreateTexture2D(int* size, byte mipLevel, TextureFormat textureFormat, TextureFlags flags, uint unk);

    // /// <summary>
    // /// A collection of the render command buffer array.
    // /// </summary>
    // public Span<RenderCommandBufferGroup> RenderCommandBufferGroups => new(RenderCommandBuffer, (int)RenderCommandBufferCount);

    // Client::Graphics::Kernel::Device::CallbackManager
    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x40)]
    public partial struct CallbackManager {
        [FieldOffset(0x8)] public void* Lock; // CRITICAL_SECTION

        [FieldOffset(0x30)] public Entry* Entries;
        [FieldOffset(0x38)] public uint Capacity;
        [FieldOffset(0x3C)] public uint Count;

        [MemberFunction("48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 48 89 7C 24 ?? 41 56 48 83 EC ?? 48 8B F1 49 8B E8 48 83 C1")]
        public partial int AddCallback(delegate* unmanaged<void*, bool> func, void* context);

        [MemberFunction("48 89 5C 24 ?? 48 89 74 24 ?? 57 48 83 EC ?? 48 8B F1 8B FA 48 83 C1 ?? FF 15")]
        public partial void RemoveCallback(int index);

        [MemberFunction("E8 ?? ?? ?? ?? 48 8B 5B ?? 48 8B 4B")]
        public partial bool ExecuteCallbacks();

        // Unsure about the names of things inside CallbackManager though
        [StructLayout(LayoutKind.Explicit, Size = 0x10)]
        public struct Entry {
            [FieldOffset(0x0)] public void* Function;
            [FieldOffset(0x8)] public void* Context;
        }
    }
}

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe struct RenderCommandBufferGroup {
    [FieldOffset(0x0)] private int Unk0;
    [FieldOffset(0x4)] private int Unk1;
    [FieldOffset(0x8), CExporterUnion("RenderCommand")] public RenderCommandSetTarget* SetTargetCommand;
    [FieldOffset(0x8), CExporterUnion("RenderCommand")] public RenderCommandViewport* ViewportCommand;
    [FieldOffset(0x8), CExporterUnion("RenderCommand")] public RenderCommandScissorsRect* ScissorsRectCommand;
    [FieldOffset(0x8), CExporterUnion("RenderCommand")] public RenderCommandClearDepth* ClearDepthCommand;
}

public enum RenderCommandType : int {
    SetTarget = 0,
    Viewport = 1,
    MultiViewport = 2,
    ScissorRect = 3,
    Clear = 4,
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x40)]
public unsafe partial struct RenderCommandSetTarget {
    [FieldOffset(0x0)] public RenderCommandType Type;
    [FieldOffset(0x4)] public int RenderTargetCount;
    [FieldOffset(0x8), FixedSizeArray] internal FixedSizeArray5<Pointer<Texture>> _renderTargets;
    [FieldOffset(0x30)] public Texture* DepthBuffer;
    [FieldOffset(0x38)] private float Unk0;
    [FieldOffset(0x3C)] private float Unk1;

    [FieldOffset(0x0), Obsolete("Use Type instead.")] public int SwitchType;
}

[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public struct RenderCommandViewport {
    [FieldOffset(0x0)] public RenderCommandType Type;
    [FieldOffset(0x4)] public IntRectangle ViewportRect;
    [FieldOffset(0x14)] public float MinDepth;
    [FieldOffset(0x18)] public float MaxDepth;

    [FieldOffset(0x0), Obsolete("Use Type instead.")] public int SwitchType;
    [FieldOffset(0x04), Obsolete("Use ViewportRect.Left.")] public int TopLeftY;
    [FieldOffset(0x08), Obsolete("Use ViewportRect.Top.")] public int TopLeftX;
    [FieldOffset(0x0C), Obsolete("Use ViewportRect.Right.")] public int BottomRightY;
    [FieldOffset(0x10), Obsolete("Use ViewportRect.Bottom.")] public int BottomRightX;
}

[StructLayout(LayoutKind.Explicit, Size = 0x80)]
public partial struct RenderCommandMultiViewport {
    [FieldOffset(0x0)] public int SwitchType;
    [FieldOffset(0x4), FixedSizeArray] internal FixedSizeArray5<IntRectangle> _viewportRects;
    [FieldOffset(0x54), FixedSizeArray] internal FixedSizeArray5<float> _minDepths;
    [FieldOffset(0x68), FixedSizeArray] internal FixedSizeArray5<float> _maxDepths;
    [FieldOffset(0x7C)] public uint ViewportCount;
}

[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public struct RenderCommandScissorsRect {
    [FieldOffset(0x0)] public RenderCommandType Type;
    [FieldOffset(0x4)] public IntRectangle ScissorRect;

    [FieldOffset(0x0), Obsolete("Use Type instead.")] public int SwitchType;
    [FieldOffset(0x4), Obsolete("Use ScissorRect.Left.")] public int Left;
    [FieldOffset(0x8), Obsolete("Use ScissorRect.Top.")] public int Top;
    [FieldOffset(0xC), Obsolete("Use ScissorRect.Right.")] public int Right;
    [FieldOffset(0x10), Obsolete("Use ScissorRect.Bottom.")] public int Bottom;
}

public enum ClearFlags : uint {
    None = 0,
    Color = 1 << 0,
    Depth = 1 << 1,
    Stencil = 1 << 2,
}

[StructLayout(LayoutKind.Explicit, Size = 0x40)]
public unsafe struct RenderCommandClearDepth {
    [FieldOffset(0x0)] public RenderCommandType Type;
    [FieldOffset(0x4)] public ClearFlags ClearFlags;
    [FieldOffset(0x8)] public float ColorB;
    [FieldOffset(0xC)] public float ColorG;
    [FieldOffset(0x10)] public float ColorR;
    [FieldOffset(0x14)] public float ColorA;
    [FieldOffset(0x18)] public float ClearDepth;
    [FieldOffset(0x1C)] public byte ClearStencil;
    [FieldOffset(0x1D)] public byte StencilReference;
    [FieldOffset(0x20), CExporterTypeForce("D3D11_RECT*")] public IntRectangle* ClearRectanglePtr; // optional, generally points at ClearRectangle if set
    [FieldOffset(0x28)] public IntRectangle ClearRectangle;
    [FieldOffset(0x38)] public float MinZ;
    [FieldOffset(0x3C)] public float MaxZ;

    [FieldOffset(0x0), Obsolete("Use Type instead.")] public int SwitchType;
    [FieldOffset(0x4), Obsolete("This is incorrect. Use ClearFlags.")] public float ClearType;
    [FieldOffset(0x20), Obsolete("This is incorrect. Use ClearRectanglePtr.")] public int ClearCheck;
    [FieldOffset(0x28), Obsolete("This is incorrect. Use ClearRectangle.Left instead.")] public float Left;
    [FieldOffset(0x2C), Obsolete("This is incorrect. Use ClearRectangle.Top instead.")] public float Top;
    [FieldOffset(0x30), Obsolete("This is incorrect. Use ClearRectangle.Right instead.")] public float Width;
    [FieldOffset(0x34), Obsolete("This is incorrect. Use ClearRectangle.Bottom instead.")] public float Height;
}
