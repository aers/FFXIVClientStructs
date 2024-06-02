using FFXIVClientStructs.FFXIV.Client.Game.Object;

namespace FFXIVClientStructs.FFXIV.Client.Game.Housing;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0xC98)]
public unsafe partial struct HousingObjectManager {
    [FieldOffset(0x18), FixedSizeArray] internal FixedSizeArray400<Pointer<GameObject>> _objects;
}
