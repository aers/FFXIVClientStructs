namespace FFXIVClientStructs.FFXIV.Client.Game.Character;

[GenerateInterop]
[Inherits<ContainerInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x50)]
public unsafe partial struct EffectContainer {

    [FieldOffset(0x30)] public StatusEffect StatusEffects;

    [Flags]
    public enum StatusEffect : byte {
        IsGPoseWet = 0x01,
    }
}
