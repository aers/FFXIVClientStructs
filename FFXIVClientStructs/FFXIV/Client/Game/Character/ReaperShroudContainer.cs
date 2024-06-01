using FFXIVClientStructs.FFXIV.Client.Graphics.Vfx;

namespace FFXIVClientStructs.FFXIV.Client.Game.Character;

// Reaper Shroud seems to be mostly hardcoded.
// It applies a transformation to NpcEquip row 2161 (which only sets the body slot to 8100,1).
// It also enables the Vfx in this container, and toggles the 'atr_eye_a' attribute in the model (for the red pupils).
// We do not actually know where all the other values come in, nothing except Flags and Vfx is actually used by Reaper Shroud (not even NpcEquipId, strangely).
// This probably is used by other transformations too, but we have not found any yet.

[GenerateInterop]
[Inherits<ContainerInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x50)]
public unsafe partial struct ReaperShroudContainer {
    [FieldOffset(0x18)] public ushort StanceChangeId;
    [FieldOffset(0x1C)] public uint StanceChangeState;
    [FieldOffset(0x20)] public float Timer;
    [FieldOffset(0x28)] public void* CopyObject;
    [FieldOffset(0x30)] public ShroudFlags Flags;
    [FieldOffset(0x40)] public VfxData* Vfx;
    [FieldOffset(0x3C)] public ushort NpcEquipId;

    [Flags]
    public enum ShroudFlags : uint {
        ShroudAttacking = 0x01, // On when the character is using a skill from reaper shroud, can be on for a short time without shroud itself being on.
        ShroudActive = 0x02, // On as long as the transformation is enabled.
        ShroudLoading = 0x0100, // On at the start before the VFX is loaded.
    }
}
