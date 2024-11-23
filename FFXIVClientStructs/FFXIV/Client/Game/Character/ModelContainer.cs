namespace FFXIVClientStructs.FFXIV.Client.Game.Character;

// Client::Game::Character::ModelContainer
//   Client::Game::Character::ContainerInterface
[GenerateInterop]
[Inherits<ContainerInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x58)]
[VirtualTable("48 89 87 ?? ?? ?? ?? 48 89 AF ?? ?? ?? ?? 48 89 AF ?? ?? ?? ?? 66 89 AF ?? ?? ?? ?? 40 88 AF", 3)]
public unsafe partial struct ModelContainer {
    [FieldOffset(0x10)] public int ModelCharaId;
    [FieldOffset(0x14)] public int ModelSkeletonId;

    /// <remarks> If this is -1, returns <seealso cref="ModelCharaId"/>. </remarks>
    [FieldOffset(0x18)] public int ModelCharaId_2;

    /// <remarks> If this is 0, returns <seealso cref="ModelSkeletonId"/>. </remarks>
    [FieldOffset(0x1C)] public int ModelSkeletonId_2;

    /// <remarks> If character is unmounted, it's hitbox radius is calculated to be this value multiplied by scale. </remarks>>
    [FieldOffset(0x24)] public float UnscaledRadius;

    /// <summary> Uses TransformationId, Tribe, BodyType, Sex and Height as well as RSP scaling values to calculate current height of the owner character. </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 0F 28 F8 0F 57 C9")]
    public partial float CalculateHeight();
}
