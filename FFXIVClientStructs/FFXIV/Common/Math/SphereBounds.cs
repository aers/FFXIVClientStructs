using System;
using System.Collections.Generic;
using System.Text;
using FFXIVClientStructs.FFXIV.Client.Graphics;

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

    /// <summary>
    /// Determines whether the given ray intersects this bounding sphere,
    /// and if so, where the first hit is.
    /// </summary>
    /// <param name="ray">The ray to test.</param>
    /// <param name="hitPoint">The location of the first hit on this bounding sphere.</param>
    /// <returns>
    /// True if the ray intersects this bounding sphere (and hitPoint contains
    /// the nearest intersection location), or false otherwise.
    /// </returns>
    public readonly bool IntersectsRay(Ray ray, out Vector3 hitPoint) {
        // Geometric solution from https://www.scratchapixel.com/lessons/3d-basic-rendering/minimal-ray-tracer-rendering-simple-shapes/ray-sphere-intersection.html
        Vector3 L = CenterPoint - ray.Origin;
        float tca = Vector3.Dot(L, ray.Direction);

        float d2 = Vector3.Dot(L, L) - tca * tca;
        if (d2 > Radius * Radius) {
            hitPoint = Vector3.Zero;
            return false;
        }
        float thc = MathF.Sqrt(Radius * Radius - d2);
        float t0 = tca - thc;
        float t1 = tca + thc;

        float t = MathF.Min(t0, t1);
        hitPoint = ray.Origin + ray.Direction * t;
        return true;
    }

    public override string ToString() => $"{CenterPoint}, {Radius}";
}
