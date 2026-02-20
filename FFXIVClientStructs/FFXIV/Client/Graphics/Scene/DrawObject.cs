using FFXIVClientStructs.FFXIV.Client.Game.Object;
using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Scene;

// Client::Graphics::Scene::DrawObject
//   Client::Graphics::Scene::Object
// base class for all drawn graphics objects
[GenerateInterop(isInherited: true)]
[Inherits<Object>]
[StructLayout(LayoutKind.Explicit, Size = 0x90)]
public unsafe partial struct DrawObject {
    [BitField<bool>(nameof(IsCoveredFromRain), 4)]
    [FieldOffset(0x88)] public byte Flags;

    [BitField<ObjectHighlightColor>(nameof(OutlineColor), 4, 4)]
    [FieldOffset(0x89)] public byte OutlineFlags;

    /// <summary>
    /// Used to highlight potential targets and housing object outlines.<br/>
    /// To set the color it is recommended to use <see cref="GameObject.Highlight" />, as it makes sure that it also highlights a characters weapon(s), mount and ornament, if available.
    /// </summary>
    public partial ObjectHighlightColor OutlineColor { get; set; }

    public bool IsVisible {
        get => (Flags & 0x09) == 0x09; // Unsure why two bits and what exactly they mean.
        set => Flags = (byte)(value ? Flags | 0x09 : Flags & ~0x09);
    }

    [VirtualFunction(6)]
    public partial void UpdateCulling();
    
    [VirtualFunction(7)]
    public partial void UpdateTransforms(bool a2_unk);
    
    // vf8: void UpdateCullingForced(this) // For BgObjects same as UpdateCulling, but sets CullingManager+8 to zero before updating culling, and then restores it
    
    // vf9: // Goes through the modelResource of each model and applies a distance plus five to the given index. Could be some sort of streaming or LOD priority?
    // vf10: // Also iterates through the modelResources like vf9
    
    [VirtualFunction(11)]
    public partial void UpdateMaterials();

    /// <summary>
    /// Computes a sphere that fully encloses this draw object.
    /// </summary>
    /// <param name="outSphereBounds">The location in which to store the resulting sphere bounds.</param>
    /// <returns>The given location where the sphere bounds were stored.</returns>
    [VirtualFunction(12)]
    public partial SphereBounds* ComputeSphereBounds(SphereBounds* outSphereBounds);
    
    [VirtualFunction(13)]
    public partial AxisAlignedBounds* ComputeAxisAlignedBounds(AxisAlignedBounds* outAlignedBounds);
    
    [VirtualFunction(14)]
    public partial OrientedBounds* ComputeOrientedBounds(OrientedBounds* outOrientedBounds);

    /// <summary>
    /// Computes whether the given ray intersects the axix-aligned bounds of this draw object,
    /// and outputs the closest point (to the ray origin) where the intersection begins.
    /// </summary>
    /// <param name="ray">The ray to hit test against, specified as a starting location and a direction.</param>
    /// <param name="outIntersectionPoint">The vector in which to store the intersection point, if any.</param>
    /// <returns>Whether the ray intersected this draw object's bounds.</returns>
    [VirtualFunction(15)]
    public partial bool HitTestBounds(Ray* ray, Vector3* outIntersectionPoint);

    /// <summary>
    /// Computes whether the given ray intersects the axis-aligned bounds of this draw object.
    /// </summary>
    /// <param name="ray">The ray to hit test against, specified as a starting location and a direction.</param>
    /// <returns>Whether the ray intersected this draw object's bounds.</returns>
    [VirtualFunction(16)]
    public partial bool HitTestBoundsNoOutput(Ray* ray);

    [VirtualFunction(17)]
    public partial Matrix4x4* GetAttachBoneWorldTransform(Matrix4x4* outTransform, int attachBoneIndex);

    [VirtualFunction(18)]
    public partial Vector3* GetAttachBoneWorldLocation(int attachBoneIndex);

    [VirtualFunction(19)]
    public partial Vector3* GetAttachBoneLocalLocation(Vector3* outLocation, int attachBoneIndex);
    
    /// <summary>
    /// Determines whether the bone with the given bone index is a valid attach bone.
    /// </summary>
    /// <param name="attachBoneIndex">The bone index of the bone to check.</param>
    /// <returns>True if the bone is an attach bone, or false if the bone is not an attach bone or does not exist on this draw object.</returns>
    [VirtualFunction(21)]
    public partial bool HasAttachBone(int attachBoneIndex);

    /// <summary>
    /// Sets the dither transparency of this draw object.
    /// </summary>
    /// <remarks>Has no effect on <see cref="ObjectType.CharacterBase"/> objects or <see cref="ObjectType.Light"/> objects.</remarks>
    /// <param name="transparency">How transparent the draw object should be, from 0.0 being fully opaque to 1.0 being fully transparent.</param>
    [VirtualFunction(26)]
    public partial void SetTransparency(float transparency);

    /// <summary>
    /// Gets the dither transparency of this draw object, or 0.0 if dither transparency is not supported by this type of draw object.
    /// </summary>
    /// <returns>How transparent this draw object is, from 0.0 being fully opaque to 1.0 being fully transparent.</returns>
    [VirtualFunction(27)]
    public partial float GetTransparency();
}
