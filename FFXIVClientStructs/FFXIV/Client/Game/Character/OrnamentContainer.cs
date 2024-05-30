namespace FFXIVClientStructs.FFXIV.Client.Game.Character;

[GenerateInterop, Inherits<ContainerInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x78)]
public unsafe partial struct OrnamentContainer {
    [FieldOffset(0x10)] public Ornament* OrnamentObject;
    [FieldOffset(0x18)] public ushort OrnamentId;

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 7B ?? 0F B7 97")]
    public partial void SetupOrnament(short ornamentId, uint param);
}
