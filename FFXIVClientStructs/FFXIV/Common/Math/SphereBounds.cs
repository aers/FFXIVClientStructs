using System;
using System.Collections.Generic;
using System.Text;

namespace FFXIVClientStructs.FFXIV.Common.Math;

/// <summary>
/// A bounding sphere in 3D space, specified by a center point and a radius.
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public struct SphereBounds {

    /// <summary>
    /// The center point of the bounding sphere.
    /// </summary>
    [FieldOffset(0x00)] public Vector3 CenterPoint;

    /// <summary>
    /// The radius of the bounding sphere.
    /// </summary>
    [FieldOffset(0x0C)] public float Radius;

    /// <summary>
    /// Determines whether the given point in 3D space lies within this
    /// bounding sphere.
    /// </summary>
    /// <param name="x">The X coordinate of the point to test.</param>
    /// <param name="y">The Y coordinate of the point to test.</param>
    /// <param name="z">The Z coordinate of the point to test.</param>
    /// <returns>True if the point lies within or on the bounding sphere, or false otherwise.</returns>
    public readonly bool ContainsPoint(float x, float y, float z)
        => ContainsPoint(new Vector3(x, y, z));

    /// <summary>
    /// Determines whether the given point in 3D space lies within this
    /// bounding sphere.
    /// </summary>
    /// <param name="point">The point to test.</param>
    /// <returns>True if the point lies within or on the bounding sphere, or false otherwise.</returns>
    public readonly bool ContainsPoint(Vector3 point)
        => (point - CenterPoint).SqrMagnitude <= Radius * Radius;

    public override string ToString() => $"{CenterPoint}, {Radius}";
}
