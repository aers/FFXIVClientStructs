using FFXIVClientStructs.FFXIV.Client.Game.Character;

namespace FFXIVClientStructs.FFXIV.Client.Game.Object;

// Client::Game::Object::EventObjectManager
// For example, used for HousingEventObject, HousingCombinedObject, ...
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x150)]
public unsafe partial struct EventObjectManager {
    [StaticAddress("48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 85 C0 74 ?? 48 39 B0 ?? ?? ?? ?? 74 ?? FF C3", 3)]
    public static partial EventObjectManager* Instance();

    [FieldOffset(0x00)] public GameObject* EventObjectMemory;
    [FieldOffset(0x08)] public uint EventObjectSize;
    [FieldOffset(0x10), FixedSizeArray] internal FixedSizeArray40<Pointer<GameObject>> _EventObjects;
}
