namespace FFXIVClientStructs.FFXIV.Client.Game.Character;

[GenerateInterop, Inherits<ContainerInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x68)]
public unsafe partial struct MountContainer {
    [FieldOffset(0x10)] public Character* MountObject;
    [FieldOffset(0x18)] public ushort MountId;
    [FieldOffset(0x1C)] public float DismountTimer;
    //1 in dismount animation, 4 = instant delete mount when dismounting (used for npcs and such)
    [FieldOffset(0x20)] public byte Flags;
    [FieldOffset(0x24)] public fixed uint MountedObjectIds[7];

    [MemberFunction("E8 ?? ?? ?? ?? 8B 43 ?? 41 89 46")]
    public partial void CreateAndSetupMount(short mountId, uint buddyModelTop, uint buddyModelBody, uint buddyModelLegs, byte buddyStain, byte unk6, byte unk7);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 43 ?? 80 B8 ?? ?? ?? ?? ?? 74 ?? 0F B6 90")]
    public partial void SetupMount(short mountId, uint buddyModelTop, uint buddyModelBody, uint buddyModelLegs, byte buddyStain);
}
