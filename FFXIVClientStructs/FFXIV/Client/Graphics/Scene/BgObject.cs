using FFXIVClientStructs.FFXIV.Client.System.Resource;
using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;
using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Scene;

// Client::Graphics::Scene::BgObject
//   Client::Graphics::Scene::DrawObject
//     Client::Graphics::Scene::Object
[GenerateInterop]
[Inherits<DrawObject>]
[StructLayout(LayoutKind.Explicit, Size = 0xE0)]
public unsafe partial struct BgObject {
    [FieldOffset(0x90)] public ModelResourceHandle* ModelResourceHandle;

    [FieldOffset(0xA0)] internal Matrix4x4* CachedTransformMatrices;
    [FieldOffset(0xA8)] public BgObjectStainBuffer* StainBuffer;
    [FieldOffset(0xB0)] internal Transform* CachedTransform;
    [FieldOffset(0xB8)] public BgObjectAnimationData* LoadedAnimationData; // Not null even if no skeleton or animation were found

    /// <summary>
    /// Loads the skeleton and animation for this BgObject, if any.
    /// </summary>
    /// <remarks>
    /// The skeleton and animation resources are found by changing the extension of the given model resource path
    /// to <c>.sklb</c> and <c>.pap</c>, respectively, and are loaded async.
    /// </remarks>
    /// <param name="modelResourcePath">The path of the model resource.</param>
    /// <returns>Whether a skeleton and animation were found.</returns>
    [GenerateStringOverloads]
    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 8B ?? ?? ?? ?? 84 C0 74 21")]
    public partial bool LoadAnimationData(CStringPointer modelResourcePath);

    /// <summary>
    /// Resets the <see cref="BgObject.Flags"/>, <see cref="BgObject.OutlineFlags"/>, and <see cref="BgObject.ObjectFlags"/>
    /// for this BgObject during its creation.
    /// </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 0D ?? ?? ?? ?? 48 8B D3 E8 ?? ?? ?? ?? 48 8B CB E8 ?? ?? ?? ?? 48 8D 4C 24 ??")]
    public partial void ResetFlags();

    /// <summary>
    /// Loads the model resource at the given path.
    /// </summary>
    /// <param name="modelResourceCategory">The resource category that contains the model resource.</param>
    /// <param name="modelResourcePath">The path of the model resource.</param>
    /// <returns>Success or failure.</returns>
    [MemberFunction("48 89 5C 24 ?? 57 48 83 EC 30 48 8B C2 C7 44 24 ?? ?? ?? ?? ??")]
    [GenerateStringOverloads]
    public partial bool SetModel(ResourceCategory* modelResourceCategory, CStringPointer modelResourcePath);

    [GenerateStringOverloads]
    [MemberFunction("E8 ?? ?? ?? ?? 48 89 43 30 48 8B D7")]
    public static partial BgObject* Create(CStringPointer modelGamePath, CStringPointer poolName, BgObject* existingAllocation = null);

    public bool TrySetStainColor(ByteColor srgbStainColor) {
        if (StainBuffer == null)
            return false;

        StainBuffer->SrgbByteColor = srgbStainColor;

        // This is the same 2.0 power approximation used when the BgPartsLayoutInstance creates stained BgObjects
        var srgbFloatColor = new Vector4(srgbStainColor.R, srgbStainColor.G, srgbStainColor.B, srgbStainColor.A) / byte.MaxValue;

        StainBuffer->LinearFloatColor = new Vector4(
            srgbFloatColor.X * srgbFloatColor.X,
            srgbFloatColor.Y * srgbFloatColor.Y,
            srgbFloatColor.Z * srgbFloatColor.Z,
            srgbFloatColor.W);

        return true;
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

[StructLayout(LayoutKind.Explicit, Size = 0x120)]
public unsafe struct BgObjectAnimationData {
    [FieldOffset(0x00)] public CharacterBase.SkeletonAnimationContainer SkeletonAnimationContainer;
    [FieldOffset(0x100)] public SkeletonResourceHandle* AsyncSkeletonResourceHandle;
    [FieldOffset(0x108)] public ResourceHandle* AsyncPapResourceHandle;
}
