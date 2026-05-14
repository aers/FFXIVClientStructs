namespace FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;

/// <summary>
/// Contains depth stencil configuration for the renderer.
/// </summary>
/// <remarks>
/// Rather than manage a bunch of pointers to depth stencil objects, render commands accept a
/// description of the desired depth stencil state packed into 64 bits, which is copied around
/// by value and eventually a real D3D depth stencil object is created within the
/// <see cref="ImmediateContext"/> as needed.
/// </remarks>
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x08)]
public unsafe partial struct PackedDepthStencilDesc {

    //                                          D (DepthEnable)
    //                                         d  (DepthWriteMask) D3D11_DEPTH_WRITE_MASK
    //                                     f ff   (DepthFuncMinusOne)
    //                          - ----  ---       (--masked out--)
    //                       SSS                  (BackFaceStencilFuncMinusOne)
    //                  fff                       (BackFaceStencilFailOpMinusOne)
    //              DD D                          (BackFaceStencilDepthFailOpMinusOne)
    //         P  PP                              (BackFaceStencilPassOpMinusOne)
    //        S                                   (StencilEnable)
    //    s ss                                    (FrontFaceStencilFuncMinusOne)
    // FFF                                        (FrontFaceStencilFailOpMinusOne)
    // xxxx xxxx  xxxx xxxx  xxxx xxxx  xxxx xxxx
    [BitField<bool>(nameof(DepthEnable), 0, 1)]
    [BitField<bool>(nameof(DepthWriteMask), 1, 1)]
    [BitField<byte>(nameof(DepthFuncMinusOne), 2, 3)]
    [BitField<byte>(nameof(BackFaceStencilFuncMinusOne), 13, 3)]
    [BitField<byte>(nameof(BackFaceStencilFailOpMinusOne), 16, 3)]
    [BitField<byte>(nameof(BackFaceStencilDepthFailOpMinusOne), 19, 3)]
    [BitField<byte>(nameof(BackFaceStencilPassOpMinusOne), 22, 3)]
    [BitField<bool>(nameof(StencilEnable), 25, 1)]
    [BitField<byte>(nameof(FrontFaceStencilFuncMinusOne), 26, 3)]
    [BitField<byte>(nameof(FrontFaceStencilFailOpMinusOne), 29, 3)]
    [FieldOffset(0x00)] internal uint _firstPart;

    //                                          - (--masked out--)
    //                                         D  (BackFaceStencilIndependent)
    //                                     d dd   (FrontFaceStencilDepthFailOpMinusOne)
    //                                  ppp       (FrontFaceStencilPassOpMinusOne)
    //                       ???? ????            (--often masked out, unsure--)
    //            RRRR RRRR                       (StencilReadMask)
    // WWWW WWWW                                  (StencilWriteMask)
    // xxxx xxxx  xxxx xxxx  xxxx xxxx  xxxx xxxx
    [BitField<bool>(nameof(BackFaceStencilIndependent), 1, 1)]
    [BitField<byte>(nameof(FrontFaceStencilDepthFailOpMinusOne), 2, 3)]
    [BitField<byte>(nameof(FrontFaceStencilPassOpMinusOne), 5, 3)]
    [FieldOffset(0x04)] internal byte _secondPart;

    [FieldOffset(0x06)] public byte StencilReadMask;
    [FieldOffset(0x07)] public byte StencilWriteMask;

    private partial byte DepthFuncMinusOne { get; set; }
    public byte DepthFunc {
        get => (byte)(DepthFuncMinusOne + 1);
        set => DepthFuncMinusOne = (byte)(value - 1);
    }

    private partial byte BackFaceStencilFuncMinusOne { get; set; }
    public byte BackFaceStencilFunc {
        get => (byte)(BackFaceStencilFuncMinusOne + 1);
        set => BackFaceStencilFuncMinusOne = (byte)(value - 1);
    }

    private partial byte BackFaceStencilFailOpMinusOne { get; set; }
    public byte BackFaceStencilFailOp {
        get => (byte)(BackFaceStencilFailOpMinusOne + 1);
        set => BackFaceStencilFailOpMinusOne = (byte)(value - 1);
    }

    private partial byte BackFaceStencilDepthFailOpMinusOne { get; set; }
    public byte BackFaceStencilDepthFailOp {
        get => (byte)(BackFaceStencilDepthFailOpMinusOne + 1);
        set => BackFaceStencilDepthFailOpMinusOne = (byte)(value - 1);
    }

    private partial byte BackFaceStencilPassOpMinusOne { get; set; }
    public byte BackFaceStencilPassOp {
        get => (byte)(BackFaceStencilPassOpMinusOne + 1);
        set => BackFaceStencilPassOpMinusOne = (byte)(value + 1);
    }

    private partial byte FrontFaceStencilFuncMinusOne { get; set; }
    public byte FrontFaceStencilFunc {
        get => (byte)(FrontFaceStencilFuncMinusOne + 1);
        set => FrontFaceStencilFuncMinusOne = (byte)(value - 1);
    }

    private partial byte FrontFaceStencilFailOpMinusOne { get; set; }
    public byte FrontFaceStencilFailOp {
        get => (byte)(FrontFaceStencilFailOpMinusOne + 1);
        set => FrontFaceStencilFailOpMinusOne = (byte)(value - 1);
    }

    private partial byte FrontFaceStencilDepthFailOpMinusOne { get; set; }
    public byte FrontFaceStencilDepthFailOp {
        get => (byte)(FrontFaceStencilDepthFailOpMinusOne + 1);
        set => FrontFaceStencilDepthFailOpMinusOne = (byte)(value - 1);
    }

    private partial byte FrontFaceStencilPassOpMinusOne { get; set; }
    public byte FrontFaceStencilPassOp {
        get => (byte)(FrontFaceStencilPassOpMinusOne + 1);
        set => FrontFaceStencilPassOpMinusOne = (byte)(value + 1);
    }
}
