using FFXIVClientStructs.FFXIV.Client.Graphics.Render;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Physics;

// Client::Graphics::Physics::ConstraintBase
[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public unsafe partial struct ConstraintBase {
    [FieldOffset(0x08)] public Skeleton* Skeleton;

    /// <remarks> Set in constructor. </remarks>
    [FieldOffset(0x10)] public ConstraintType Type;

    [MemberFunction("E8 ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? C7 43 ?? ?? ?? ?? ?? ?? ?? ?? 33 C0 48 89 43 ?? 48 89 43 ?? 89 43 ?? 48 8B C3 C7 43")]
    public partial ConstraintBase* Ctor(ConstraintType type);

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 ?? F3 0F 10 44 24 ?? B0 ?? F3 0F 10 4C 24 ?? F3 0F 11 43")]
    public partial bool SetSkeleton(Skeleton* skeleton);

    [VirtualFunction(0)]
    public partial ConstraintBase* Dtor(byte freeFlags);

    /// <summary> Sets Skeleton back to null, decreases refcount if applicable. </summary>
    [VirtualFunction(1)]
    public partial void ResetSkeleton();
}

public enum ConstraintType : uint {
    /// <remarks> Corresponds to <see cref="ConstraintSpring"/>. </remarks>
    Spring = 0,
    /// <remarks> Corresponds to <see cref="ConstraintAttract"/>. </remarks>
    Attract = 1,
    /// <remarks> Corresponds to <see cref="ConstraintPin"/>. </remarks>
    Pin = 2,
}
