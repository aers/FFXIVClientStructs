using FFXIVClientStructs.FFXIV.Client.Game.Object;
using FFXIVClientStructs.FFXIV.Client.Graphics.Vfx;

namespace FFXIVClientStructs.FFXIV.Client.Game.Character;

// Client::Game::Character::VfxContainer
//   Client::Game::Character::ContainerInterface
[GenerateInterop]
[Inherits<ContainerInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0xF0)]
public partial struct VfxContainer {
    [FieldOffset(0x18), FixedSizeArray] internal FixedSizeArray14<Pointer<VfxData>> _vfxData;

    [FieldOffset(0xA0), FixedSizeArray] internal FixedSizeArray2<Tether> _tethers;
    [FieldOffset(0xD0)] public ushort VoiceId;

    [MemberFunction("E8 ?? ?? ?? ?? EB 6A 0F BE 83 ?? ?? ?? ??")]
    public partial nint LoadCharacterSound(
        int soundNumber,
        int unk2,
        nint unkGameObject, // TODO: change type to GameObject*
        ulong autoRelease, // TODO: change type to bool
        int weaponDataIndex,
        int unk6, // TODO: change type to SoundVolumeCategory
        ulong unk7); // TODO: change type to bool

    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public struct Tether {
        [FieldOffset(0x00)] public ushort Id; // Channeling sheet row id
        [FieldOffset(0x02)] public byte Progress; // 0-100
        // 0x8: vfx*
        [FieldOffset(0x10)] public GameObjectId TargetId;
    }
}
