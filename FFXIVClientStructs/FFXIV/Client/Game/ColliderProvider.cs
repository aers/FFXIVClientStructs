using FFXIVClientStructs.FFXIV.Common.Component.BGCollision;

namespace FFXIVClientStructs.FFXIV.Client.Game;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x8C)]
public unsafe partial struct ColliderProvider {
    [StaticAddress("48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 0F 57 FF 3C", 3)]
    public static partial ColliderProvider* Instance();

    [FieldOffset(0x00)] public bool HasColliders;
    [FieldOffset(0x04)] private uint UnkColliderLayer8InstanceKey;
    [FieldOffset(0x08)] public SceneWrapper.ColliderList ColliderList;
}
