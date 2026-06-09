namespace FFXIVClientStructs.FFXIV.Client.Graphics.Physics;

// Client::Graphics::Physics::CollisionBase
//   Client::Graphics::ReferencedClassBase
[GenerateInterop(isInherited: true)]
[Inherits<ReferencedClassBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x90)]
public unsafe partial struct CollisionBase {
    /// <remarks> Set in constructor. </remarks>
    [FieldOffset(0x80)] public CollisionShape Shape;

    [MemberFunction("C7 41 ?? ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 89 01 48 8B C1")]
    public partial CollisionBase* Ctor(CollisionShape shape);
}

public enum CollisionShape : byte {
    /// <remarks> Corresponds to <see cref="CollisionCapsule"/>. </remarks>
    Capsule = 0,
    /// <remarks> Corresponds to <see cref="CollisionEllipsoid"/>. </remarks>
    Ellipsoid = 1,
    /// <remarks> Corresponds to <see cref="CollisionNormalPlane"/>. </remarks>
    NormalPlane = 2,
    /// <remarks> Corresponds to <see cref="CollisionThreePointPlane"/>. </remarks>
    ThreePointPlane = 3,
    /// <remarks> Corresponds to <see cref="CollisionSphere"/>. </remarks>
    Sphere = 4,
}
