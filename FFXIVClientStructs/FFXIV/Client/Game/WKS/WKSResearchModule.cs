namespace FFXIVClientStructs.FFXIV.Client.Game.WKS;

// Client::Game::WKS::WKSResearchModule
//   Client::Game::WKS::WKSModuleBase
// Cosmic Research Information
[GenerateInterop]
[Inherits<WKSModuleBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x80)]
public unsafe partial struct WKSResearchModule {
    [FieldOffset(0x08), FixedSizeArray] internal FixedSizeArray11<ushort> _analysis;
    [FieldOffset(0x60), FixedSizeArray] internal FixedSizeArray11<byte> _currentStages;
    [FieldOffset(0x6B), FixedSizeArray] internal FixedSizeArray11<byte> _unlockedStages;
    [FieldOffset(0x76)] public ushort RatePercentage;
    [FieldOffset(0x78)] public bool IsLoaded;

    [MemberFunction("E8 ?? ?? ?? ?? BA ?? ?? ?? ?? 0F B7 D8 48 8B CF E8 ?? ?? ?? ?? 48 8B 4C 24")]
    public partial ushort GetCurrentAnalysis(byte toolClass, byte type);

    [MemberFunction("48 89 5C 24 ?? 48 89 74 24 ?? 48 89 7C 24 ?? 41 56 48 83 EC 20 41 0F B6 D8")]
    public partial ushort GetNeededAnalysis(byte toolClass, byte type);

    [MemberFunction("E8 ?? ?? ?? ?? BA ?? ?? ?? ?? 0F B7 D8 48 8B CF E8 ?? ?? ?? ?? 89 5F ?? 41 FE C4")]
    public partial ushort GetMaxAnalysis(byte toolClass, byte type);

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 0F 84 ?? ?? ?? ?? 48 8B 4C 24 ?? 41 8D 44 24")]
    public partial bool IsTypeAvailable(byte toolClass, byte type);
}
