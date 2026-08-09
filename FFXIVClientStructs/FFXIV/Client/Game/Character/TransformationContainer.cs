using FFXIVClientStructs.FFXIV.Client.Graphics.Vfx;

namespace FFXIVClientStructs.FFXIV.Client.Game.Character;

// Reaper Shroud seems to be mostly hardcoded.
// It applies a transformation to NpcEquip row 2161 (which only sets the body slot to 8100,1).
// It also enables the Vfx in this container, and toggles the 'atr_eye_a' attribute in the model (for the red pupils).
// We do not actually know where all the other values come in, nothing except Flags and Vfx is actually used by Reaper Shroud (not even NpcEquipId, strangely).
// This probably is used by other transformations too, but we have not found any yet.

// Client::Game::Character::TransformationContainer
//   Client::Game::Character::ContainerInterface
//   Client::Graphics::Vfx::VfxDataListenner
[GenerateInterop]
[Inherits<ContainerInterface>]
[Inherits<VfxDataListenner>]
[StructLayout(LayoutKind.Explicit, Size = 0x58)]
public unsafe partial struct TransformationContainer {
    [FieldOffset(0x18)] public byte StanceChangeId;
    [FieldOffset(0x1C)] public uint StanceChangeState;
    [FieldOffset(0x20)] public float Timer;
    [FieldOffset(0x28)] public Character* CopyObject;
    [FieldOffset(0x30)] public TransformationFlags Flags;
    // 0 = Reaper Shroud (NpcEquip = 2161, VFX = 1090, ...)
    // 1 = Scholar Seraphism (NpcEquip = 2639, VFX = 2245)
    [FieldOffset(0x34)] public int EffectIndex;
    [FieldOffset(0x38)] public byte Flags2;
    [FieldOffset(0x40)] public VfxData* Vfx;
    [FieldOffset(0x48)] public bool IsEffectPending;
    [FieldOffset(0x49)] public bool IsCharacterNotReady; // no CharacterBase or its LoadState != 3
    [FieldOffset(0x4C)] public ushort NpcEquipId;
    [FieldOffset(0x50)] public bool AreWeaponLoaded;
    [FieldOffset(0x52)] private ushort UnkActionTimelineId;

    [MemberFunction("E8 ?? ?? ?? ?? BF ?? ?? ?? ?? 40 84 7B")]
    public partial void SetTransformation(uint transformationId, bool a3, bool playStartVfx); // passing 0 as transformationId transforms you back

    [Flags]
    public enum TransformationFlags : byte {
        Attacking = 1 << 0, // On when the character is using a skill from reaper shroud, can be on for a short time without shroud itself being on.
        Active = 1 << 1, // On as long as the transformation is enabled.
    }
}
