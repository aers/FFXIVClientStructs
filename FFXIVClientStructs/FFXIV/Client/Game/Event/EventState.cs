using FFXIVClientStructs.FFXIV.Client.Game.Object;

namespace FFXIVClientStructs.FFXIV.Client.Game.Event; 

[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public struct EventState {
    [FieldOffset(0x10)] public GameObjectID ObjectId;
}