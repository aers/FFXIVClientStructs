namespace FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;

/// <summary>
/// Contains blending configuration for the renderer.
/// </summary>
/// <remarks>
/// Rather than manage a bunch of pointers to blend state objects, render commands accept a
/// description of the desired blend state packed into 32 bits, which is copied around
/// by value and eventually a real D3D blend state object is created within the
/// <see cref="ImmediateContext"/> as needed.
/// </remarks>
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x04)]
public unsafe partial struct PackedBlendStateDesc {

    //                                          E (BlendEnabled)
    //                                       OOO  (BlendOpMinusOne)
    //                                  SSSS      (SrcBlendMinusOne)
    //                            DDDD            (DestBlendMinusOne)
    //                        ooo                 (BlendOpAlphaMinusOne)
    //                  sss  s                    (SrcBlendAlphaMinusOne)
    //             ddd d                          (DestBlendAlphaMinusOne)
    //       MMM  M                               (RenderTargetWriteMask)
    // ---- -                                     (--masked out--)
    // xxxx xxxx  xxxx xxxx  xxxx xxxx  xxxx xxxx
    [BitField<bool>(nameof(BlendEnable), 0, 1)]
    [BitField<byte>(nameof(BlendOpMinusOne), 1, 3)]
    [BitField<byte>(nameof(SrcBlendMinusOne), 4, 4)]
    [BitField<byte>(nameof(DestBlendMinusOne), 8, 4)]
    [BitField<byte>(nameof(BlendOpAlphaMinusOne), 12, 3)]
    [BitField<byte>(nameof(SrcBlendAlphaMinusOne), 15, 4)]
    [BitField<byte>(nameof(DestBlendAlphaMinusOne), 19, 4)]
    [BitField<byte>(nameof(RenderTargetWriteMask), 23, 4)]
    [FieldOffset(0x00)] internal uint _value;

    // D3D11_BLEND_OP
    private partial byte BlendOpMinusOne { get; set; }
    public byte BlendOp {
        get => (byte)(BlendOpMinusOne + 1);
        set => BlendOpMinusOne = (byte)(value - 1);
    }

    // D3D11_BLEND
    private partial byte SrcBlendMinusOne { get; set; }
    public byte SrcBlend {
        get => (byte)(SrcBlendMinusOne + 1);
        set => SrcBlendMinusOne = (byte)(value - 1);
    }

    // D3D11_BLEND
    private partial byte DestBlendMinusOne { get; set; }
    public byte DestBlend {
        get => (byte)(DestBlendMinusOne + 1);
        set => DestBlendMinusOne = (byte)(value - 1);
    }

    // D3D11_BLEND_OP
    private partial byte BlendOpAlphaMinusOne { get; set; }
    public byte BlendOpAlpha {
        get => (byte)(BlendOpAlphaMinusOne + 1);
        set => BlendOpAlphaMinusOne = (byte)(value - 1);
    }

    // D3D11_BLEND
    private partial byte SrcBlendAlphaMinusOne { get; set; }
    public byte SrcBlendAlpha {
        get => (byte)(SrcBlendAlphaMinusOne + 1);
        set => SrcBlendAlphaMinusOne = (byte)(value - 1);
    }

    // D3D11_BLEND
    private partial byte DestBlendAlphaMinusOne { get; set; }
    public byte DestBlendAlpha {
        get => (byte)(DestBlendAlphaMinusOne + 1);
        set => DestBlendAlphaMinusOne = (byte)(value - 1);
    }
}
