namespace FFXIVClientStructs.FFXIV.Client.Graphics.Physics;

// Client::Graphics::Physics::ConstraintBase
[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public unsafe partial struct ConstraintBase {
    /// <remarks> Set in constructor. </remarks>
    [FieldOffset(0x10)] public ConstraintType Type;

    [MemberFunction("48 C7 41 ?? ?? ?? ?? ?? 48 89 01 48 8B C1 89 51 ?? C3")] // don't use the lea instruction sig
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
