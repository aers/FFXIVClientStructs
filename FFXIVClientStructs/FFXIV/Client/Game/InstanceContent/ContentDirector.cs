using FFXIVClientStructs.FFXIV.Client.Game.DynamicEvent;
using FFXIVClientStructs.FFXIV.Client.Game.Event;

namespace FFXIVClientStructs.FFXIV.Client.Game.InstanceContent;

[StructLayout(LayoutKind.Explicit, Size = 0xC48)]
public unsafe struct ContentDirector {
    [FieldOffset(0x00)] public Director Director;

    [FieldOffset(0xBB8)] public DynamicEventManager* DynamicEventManager;

    [FieldOffset(0xC08)] public float ContentTimeLeft;
}
