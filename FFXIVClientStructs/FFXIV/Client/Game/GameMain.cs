namespace FFXIVClientStructs.FFXIV.Client.Game;

[StructLayout(LayoutKind.Explicit, Size = 0x40E0)]
public unsafe partial struct GameMain {
    [StaticAddress("48 8D 0D ?? ?? ?? ?? 38 05", 3)]
    public static partial GameMain* Instance();

    [FieldOffset(0x0)] public fixed uint ActiveFestivals[4]; // TODO: add FixedSizeArray with a struct that splits it into two ushorts, Id and Phase

    [FieldOffset(0x40)] public fixed uint QueuedFestivals[4]; // TODO: add FixedSizeArray with a struct that splits it into two ushorts, Id and Phase

    [FieldOffset(0xAD8)] public JobGaugeManager JobGaugeManager;

    [FieldOffset(0x4080)] public uint TerritoryLoadState; // 1 = loading, 2 = loaded, 3 = unloading/shutting down
    [FieldOffset(0x4084)] public uint NextTerritoryTypeId;
    [FieldOffset(0x4088)] public uint CurrentTerritoryTypeId; // can be 0 during loading screens
    [FieldOffset(0x408C)] public uint CurrentTerritoryIntendedUseId;

    [FieldOffset(0x4094)] public ushort CurrentContentFinderConditionId;

    [FieldOffset(0x40A0)] public uint CurrentMapId;

    [FieldOffset(0x40B0)] public float MilisecondCounter;
    [FieldOffset(0x40B4)] public uint RuntimeSeconds;
    [FieldOffset(0x40B8)] public bool RuntimeSecondsChanged;
    [FieldOffset(0x40BC)] public float Runtime;
    [FieldOffset(0x40C0)] public nint CurrentTerritoryTypeRow;
    [FieldOffset(0x40C8)] public nint CurrentTerritoryIntendedUseRow;
    [FieldOffset(0x40D0)] public nint NextTerritoryTypeRow;
    [FieldOffset(0x40D8)] public nint NextTerritoryIntendedUseRow;

    [MemberFunction("E8 ?? ?? ?? ?? 44 8B B3 ?? ?? ?? ?? 33 FF")]
    public partial bool IsInInstanceArea();

    [MemberFunction("E8 ?? ?? ?? ?? 88 45 F1")]
    public static partial bool IsInPvPArea();

    [MemberFunction("40 53 48 83 EC ?? 48 8B 1D ?? ?? ?? ?? 48 85 DB 75 ?? 32 C0 48 83 C4 ?? 5B C3 48 8D 0D")]
    public static partial bool IsInPvPInstance();

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 75 21 48 8B 4F 10")]
    public static partial bool IsInSanctuary();

    [MemberFunction("E8 ?? ?? ?? ?? 0F 28 74 24 ?? 0F B6 F0")]
    public static partial bool IsInGPose();

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 75 D7")]
    public static partial bool IsInIdleCam();

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 8B 44 24 60 48 8D 8D")]
    public partial void QueueActiveFestivals(uint festival1, uint festival2, uint festival3, uint festival4); // Applies once the current "event" is done (GPose, Cutscene etc)

    [MemberFunction("E8 ?? ?? ?? ?? 80 63 50 FE")]
    public partial void SetActiveFestivals(uint festival1, uint festival2, uint festival3, uint festival4); // Applies immediately regardless of client state
}
