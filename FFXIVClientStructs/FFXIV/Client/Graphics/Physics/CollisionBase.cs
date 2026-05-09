namespace FFXIVClientStructs.FFXIV.Client.Graphics.Physics;

// Client::Graphics::Physics::CollisionBase
//   Client::Graphics::ReferencedClassBase
[Inherits<ReferencedClassBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x90)]
[GenerateInterop(isInherited: true)]
public unsafe partial struct CollisionBase {
    /// <remarks> Set in constructor. </remarks>
    [FieldOffset(0x80)] public CollisionShape Shape;

    public enum CollisionShape : byte {
        /// <remarks> Corresponds to CollisionCapsule. </remarks>
        Capsule = 0,
        /// <remarks> Corresponds to CollisionEllipsoid. </remarks>
        Ellipsoid = 1,
        /// <remarks> Corresponds to CollisionNormalPlane. </remarks>
        NormalPlane = 2,
        /// <remarks> Corresponds to CollisionThreePointPlane. </remarks>
        ThreePointPlane = 3,
        /// <remarks> Corresponds to CollisionSphere. </remarks>
        Sphere = 4,
    }

    [MemberFunction("C7 41 ?? ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 89 01 48 8B C1")]
    public partial CollisionBase* Ctor(CollisionShape shape);
}
