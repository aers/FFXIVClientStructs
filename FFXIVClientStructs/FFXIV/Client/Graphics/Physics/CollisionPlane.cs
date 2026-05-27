namespace FFXIVClientStructs.FFXIV.Client.Graphics.Physics;

// Client::Graphics::Physics::CollisionPlane
//   Client::Graphics::Physics::CollisionBase
//     Client::Graphics::ReferencedClassBase
[GenerateInterop(isInherited: true)]
[Inherits<CollisionBase>]
[StructLayout(LayoutKind.Explicit, Size = 0xE0)]
public unsafe partial struct CollisionPlane {
    [MemberFunction("E8 ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 89 03 B8 ?? ?? ?? ?? 66 89 83 ?? ?? ?? ?? 33 C0")]
    public partial CollisionPlane* Ctor(CollisionShape shape);
}
