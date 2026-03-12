namespace FFXIVClientStructs.FFXIV.Common.Math;

/// <summary>
/// A bounding box oriented in 3D space, specified by a transformation
/// with identity scale and its half extents.
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 0x50)]
public struct OrientedBounds {
    /// <summary>
    /// The transformation of the bounding box in 3D space.
    /// </summary>
    /// <remarks>
    /// The scale along each axis should be 1.
    /// </remarks>
    [FieldOffset(0x00)] public Matrix4x4 Transform;

    /// <summary>
    /// The half size of the bounding box along its transformed axes.
    /// </summary>
    [FieldOffset(0x40)] public Vector3 HalfExtents;

    /// <summary>
    /// Determines whether the given point in 3D space lies within this
    /// oriented bounding box.
    /// </summary>
    /// <param name="x">The X coordinate of the point to test.</param>
    /// <param name="y">The Y coordinate of the point to test.</param>
    /// <param name="z">The Z coordinate of the point to test.</param>
    /// <returns>True if the point lies within or on the bounding box, or false otherwise.</returns>
    public readonly bool ContainsPoint(float x, float y, float z) => ContainsPoint(new Vector3(x, y, z));

    /// <summary>
    /// Determines whether the given point in 3D space lies within this
    /// oriented bounding box.
    /// </summary>
    /// <param name="point">The point to test.</param>
    /// <returns>True if the point lies within or on the bounding box, or false otherwise.</returns>
    public readonly bool ContainsPoint(Vector3 point) {
        // Check for invalid transform. This means the transform matrix is somehow damaged/degenerate
        // and does not represent an affine transformation.
        if (!Matrix4x4.Invert(Transform, out var inverseTransform))
            return false;

        // Transform the point by the inverse transform to get it in local space.
        // If you're going to do this en masse, consider doing the matrix inversion once.
        var localPoint = Vector3.Transform(point, inverseTransform);

        return MathF.Abs(localPoint.X) <= HalfExtents.X
            && MathF.Abs(localPoint.Y) <= HalfExtents.Y
            && MathF.Abs(localPoint.Z) <= HalfExtents.Z;
    }

    public override string ToString() => $"{HalfExtents * 2.0f} at {Transform}";
}
