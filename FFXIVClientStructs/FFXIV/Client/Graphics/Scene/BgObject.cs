using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;
using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Scene;

[GenerateInterop]
[Inherits<DrawObject>]
[StructLayout(LayoutKind.Explicit, Size = 0xE0)]
public unsafe partial struct BgObject {
    [FieldOffset(0x90)] public ModelResourceHandle* ModelResourceHandle;

    [FieldOffset(0xA0)] internal Matrix4x4* CachedTransformMatrices;
    [FieldOffset(0xA8)] public BgObjectStainBuffer* StainBuffer;
    [FieldOffset(0xB0)] internal Transform* CachedTransform;

    [MemberFunction("E8 ?? ?? ?? ?? 48 89 43 30 48 8B D7")]
    public static partial BgObject* Create(byte* modelGamePath, byte* pool, BgObject* existingAllocation);

    public bool TrySetStainColor(ByteColor srgbStainColor) {
        if (StainBuffer != null) {
            StainBuffer->SrgbByteColor = srgbStainColor;

            // This is the same 2.0 power approximation used when the BgPartsLayoutInstance creates stained BgObjects
            var srgbFloatColor = new Vector4(srgbStainColor.R, srgbStainColor.G, srgbStainColor.B, srgbStainColor.A) / byte.MaxValue;
            StainBuffer->LinearFloatColor = new Vector4(
                srgbFloatColor.X * srgbFloatColor.X,
                srgbFloatColor.Y * srgbFloatColor.Y,
                srgbFloatColor.Z * srgbFloatColor.Z,
                srgbFloatColor.W);

            return true;
        } else {
            return false;
        }
    }
}

[StructLayout(LayoutKind.Explicit, Size = 0x14)]
public struct BgObjectStainBuffer {
    /// <summary>
    /// The original byte color for the stain.
    /// </summary>
    [FieldOffset(0x00)] public ByteColor SrgbByteColor;

    /// <summary>
    /// An approximate linear conversion of the <see cref="SrgbByteColor"/>.
    /// </summary>
    /// <remarks>
    /// The formula is: <c>pow(value / 255.0f, 2.0f)</c>
    /// </remarks>
    [FieldOffset(0x04)] public Vector4 LinearFloatColor;
}
