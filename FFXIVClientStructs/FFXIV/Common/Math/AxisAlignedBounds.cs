using System;
using System.Collections.Generic;
using System.Text;

namespace FFXIVClientStructs.FFXIV.Common.Math;

/// <summary>
/// An axis-aligned bounding box specified as minimum and maximum corners.
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public struct AxisAlignedBounds {

    /// <summary>
    /// The minimum corner of the bounding box.
    /// </summary>
    [FieldOffset(0x00)] public Vector3 Min;

    /// <summary>
    /// The maximum corner of the bounding box.
    /// </summary>
    [FieldOffset(0x10)] public Vector3 Max;

    /// <summary>
    /// The center point of the bounding box.
    /// </summary>
    public readonly Vector3 Center => (Min + Max) * 0.5f;

    /// <summary>
    /// Half the size of the bounding box.
    /// </summary>
    /// <remarks>
    /// Half extents are often used in various hit testing algorithms.
    /// </remarks>
    public readonly Vector3 HalfExtents => (Max - Min) * 0.5f;

    /// <summary>
    /// Constructs a new axis-aligned bounding box from the given two corners.
    /// </summary>
    /// <param name="min">The minimum corner of the bounding box.</param>
    /// <param name="max">The maximum corner of the bounding box.</param>
    public AxisAlignedBounds(Vector3 min, Vector3 max) {
        Min = new Vector3(MathF.Min(min.X, max.X), MathF.Min(min.Y, max.Y), MathF.Min(min.Z, max.Z));
        Max = new Vector3(MathF.Max(min.X, max.X), MathF.Max(min.Y, max.Y), MathF.Max(min.Z, max.Z));
    }

    /// <summary>
    /// Determines whether the given point in 3D space lies within this
    /// axis-aligned bounding box.
    /// </summary>
    /// <param name="x">The X coordinate of the point to test.</param>
    /// <param name="y">The Y coordinate of the point to test.</param>
    /// <param name="z">The Z coordinate of the point to test.</param>
    /// <returns>True if the point lies within or on the bounding box, or false otherwise.</returns>
    public readonly bool ContainsPoint(float x, float y, float z)
        => x >= Min.X && x <= Max.X
        && y >= Min.Y && y <= Max.Y
        && z >= Min.Z && z <= Max.Z;

    /// <summary>
    /// Determines whether the given point in 3D space lies within this
    /// axis-aligned bounding box.
    /// </summary>
    /// <param name="point">The point to test.</param>
    /// <returns>True if the point lies within or on the bounding box, or false otherwise.</returns>
    public readonly bool ContainsPoint(Vector3 point) => ContainsPoint(point.X, point.Y, point.Z);

    public override string ToString() => $"{Min}, {Max}";
}
