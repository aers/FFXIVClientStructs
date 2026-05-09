namespace FFXIVClientStructs.FFXIV.Client.Graphics.Physics;

// Client::Graphics::Physics::ConstraintBase
[StructLayout(LayoutKind.Explicit, Size = 0x18)]
[GenerateInterop(isInherited: true)]
public unsafe partial struct ConstraintBase {
    /// <remarks> Set in constructor. </remarks>
    [FieldOffset(0x10)] public ConstraintType Shape;

    public enum ConstraintType : uint {
        /// <remarks> Corresponds to ConstraintSpring. </remarks>
        Spring = 0,
        /// <remarks> Corresponds to ConstraintAttract. </remarks>
        Attract = 1,
        /// <remarks> Corresponds to ConstraintPin. </remarks>
        Pin = 2,
    }

    [MemberFunction("48 C7 41 ?? ?? ?? ?? ?? 48 89 01 48 8B C1 89 51 ?? C3")] // don't use the lea instruction sig
    public partial ConstraintBase* Ctor(ConstraintType type);
}
