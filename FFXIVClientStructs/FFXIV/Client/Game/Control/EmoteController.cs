using FFXIVClientStructs.FFXIV.Client.Game.Character;
using FFXIVClientStructs.FFXIV.Client.Game.Object;

namespace FFXIVClientStructs.FFXIV.Client.Game.Control;

[StructLayout(LayoutKind.Explicit, Size = 0x40)]
public unsafe partial struct EmoteController {
    [FieldOffset(0x00)] public void** ContainerVTable;
    [FieldOffset(0x08)] public BattleChara* OwnerObject;
    [FieldOffset(0x14)] public ushort EmoteId;
    [FieldOffset(0x16)] public ushort Unk1; // Seems to be 1 when close enough to a target that height adjustment is needed, maybe.
    [FieldOffset(0x18)] public GameObjectID Target;
    [FieldOffset(0x21)] public byte CPoseState;
}
