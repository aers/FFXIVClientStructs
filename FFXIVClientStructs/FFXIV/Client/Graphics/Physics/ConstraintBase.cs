namespace FFXIVClientStructs.FFXIV.Client.Graphics.Physics;

// Client::Graphics::Physics::ConstraintBase
[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public unsafe partial struct ConstraintBase {
    /// <remarks> Set in constructor. </remarks>
    [FieldOffset(0x10)] public ConstraintType Type;

    [MemberFunction("E8 ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? C7 43 ?? ?? ?? ?? ?? ?? ?? ?? 33 C0 48 89 43 ?? 48 89 43 ?? 89 43 ?? 48 8B C3 C7 43")]
    public partial ConstraintBase* Ctor(ConstraintType type);
}

public enum ConstraintType : uint {
    /// <remarks> Corresponds to <see cref="ConstraintSpring"/>. </remarks>
    Spring = 0,
    /// <remarks> Corresponds to <see cref="ConstraintAttract"/>. </remarks>
    Attract = 1,
    /// <remarks> Corresponds to <see cref="ConstraintPin"/>. </remarks>
    Pin = 2,
}
