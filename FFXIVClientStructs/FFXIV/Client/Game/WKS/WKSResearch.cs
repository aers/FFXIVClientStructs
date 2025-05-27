namespace FFXIVClientStructs.FFXIV.Client.Game.WKS;

// Client::Game::WKS::WKSResearch
//   Client::Game::WKS::WKSModuleBase
// Cosmic Research Information
[GenerateInterop]
[Inherits<WKSModuleBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x80)]
public unsafe partial struct WKSResearch {
    [FieldOffset(0x08), FixedSizeArray] internal FixedSizeArray11<ushort> _analysis;
    [FieldOffset(0x60), FixedSizeArray] internal FixedSizeArray11<byte> _currentStages;
    [FieldOffset(0x6B), FixedSizeArray] internal FixedSizeArray11<byte> _unlockedStages;
    [FieldOffset(0x76)] public ushort RatePercentage;
    [FieldOffset(0x78)] public bool IsLoaded;

    [MemberFunction("48 89 5C 24 ?? 48 89 74 24 ?? 57 48 83 EC 20 41 0F B6 D8 0F B6 FA 48 8B F1 E8 ?? ?? ?? ?? 80 78 1D 00 74 36")]
    public partial ushort GetCurrentAnalysis(byte toolClass, byte type);

    [MemberFunction("48 89 5C 24 ?? 48 89 74 24 ?? 48 89 7C 24 ?? 41 56 48 83 EC 20 41 0F B6 D8")]
    public partial ushort GetNeededAnalysis(byte toolClass, byte type);

    [MemberFunction("E8 ?? ?? ?? ?? 49 C1 E6 04 48 8D BD ?? ?? ?? ??")]
    public partial ushort GetMaxAnalysis(byte toolClass, byte type);

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 0F 84 ?? ?? ?? ?? 48 8B 4C 24 ?? 41 8D 45")]
    public partial bool IsTypeAvailable(byte toolClass, byte type);
}
