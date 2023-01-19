using FFXIVClientStructs.FFXIV.Client.Game.Object;

namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

[StructLayout(LayoutKind.Explicit)]
public unsafe partial struct EventGPoseController
{
    [MemberFunction("E8 ?? ?? ?? ?? E8 ?? ?? ?? ?? 80 BE 8C 00 00 00 02")]
    public partial void AddObjectToGPose(GameObject* gameObject, ulong a1 = 0);

    [MemberFunction("45 33 D2 4C 8D 81 38 2A 00 00 41 8B C2 4C 8B C9 49 3B 10 ?? ?? FF C0 49 83 C0 18 83 F8 1E ?? ?? ?? 8B")]
    public partial void RemoveObjectFromGPose(GameObject* gameObject);
}
