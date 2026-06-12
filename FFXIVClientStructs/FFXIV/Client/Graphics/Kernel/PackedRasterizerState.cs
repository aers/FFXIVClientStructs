namespace FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;

/// <summary>
/// Contains rasterization configuration for the renderer.
/// </summary>
/// <remarks>
/// Rather than manage a bunch of pointers to rasterizer state objects, render commands accept a
/// description of the desired rasterizer state packed into 32 bits, which is copied around
/// by value and eventually a real D3D rasterizer state object is created within the
/// <see cref="ImmediateContext"/> as needed.
/// </remarks>
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x04)]
public unsafe partial struct PackedRasterizerStateDesc {
    private const float _depthBiasScale = 0.0000152587890625f; // 2 ^ -16
    private const float _slopeScaledDepthBiasQuantization = 0.03125f;

    //                                         FF (FillMode)
    //                                        c   (HasCullMode)
    //                                       C    (CullModeBit)
    //                                     S      (ScissorEnable)
    //               B BBBB  BBBB BBBB  BBB       (DepthBiasHalf) (float16 * 2e-16)
    //  LLL LLLL  LLL                             (SlopeScaledDepthBiasQuantized) (uint10 / 0.03125f)
    // -                                          (--masked out--)
    // xxxx xxxx  xxxx xxxx  xxxx xxxx  xxxx xxxx
    [BitField<byte>(nameof(FillMode), 0, 2)]
    [BitField<bool>(nameof(HasCullMode), 2, 1)]
    [BitField<byte>(nameof(CullModeBit), 3, 1)]
    [BitField<bool>(nameof(ScissorEnable), 4, 1)]
    [BitField<ushort>(nameof(DepthBiasHalf), 5, 16)]
    [BitField<ushort>(nameof(SlopeScaledDepthBiasQuantized), 21, 10)]
    [FieldOffset(0x00)] internal uint _value;

    private partial bool HasCullMode { get; set; }
    private partial byte CullModeBit { get; set; }
    public byte CullMode {
        get {
            if (HasCullMode) {
                return (byte)(3 - CullModeBit);
            } else {
                return 1; // D3D11_CULL_NONE
            }
        }
        set {
            if (value == 1) { // D3D11_CULL_NONE
                HasCullMode = false;
                CullModeBit = 0;
            } else {
                HasCullMode = true;
                CullModeBit = (byte)((3 - value) & 1);
            }
        }
    }

    private partial ushort DepthBiasHalf { get; set; }
    public float DepthBias {
        get => (float)BitConverter.UInt16BitsToHalf(DepthBiasHalf) / _depthBiasScale;
        set => DepthBiasHalf = BitConverter.HalfToUInt16Bits((Half)(value * _depthBiasScale));
    }

    private partial ushort SlopeScaledDepthBiasQuantized { get; set; }
    public float SlopeScaledDepthBias {
        get => SlopeScaledDepthBiasQuantized * _slopeScaledDepthBiasQuantization;
        set => SlopeScaledDepthBiasQuantized = (ushort)(value / _slopeScaledDepthBiasQuantization);
    }
}
