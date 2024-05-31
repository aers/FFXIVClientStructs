namespace FFXIVClientStructs.FFXIV.Client.Game.Character;

[GenerateInterop, Inherits<ContainerInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public unsafe partial struct CompanionContainer {
    [FieldOffset(0x10)] public Companion* CompanionObject;
    //used if minion is summoned but the object slot is taken by a mount
    [FieldOffset(0x18)] public ushort CompanionId;

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 ?? 66 44 89 7F")]
    public partial void SetupCompanion(short companionId, uint param);
}
