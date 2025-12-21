namespace FFXIVClientStructs.FFXIV.Client.UI.Arrays.Common;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 17 * 4)]
public partial struct ActionBarSlotNumberArray {
    [FieldOffset(0), FixedSizeArray, CExporterIgnore] internal FixedSizeArray17<int> _data;

    [FieldOffset(0 * 4)] public int ActionType;
    [FieldOffset(1 * 4)] private bool Unk1;
    [FieldOffset(3 * 4)] public uint ActionId;
    [FieldOffset(4 * 4)] public uint IconId;
    [FieldOffset(5 * 4)] public bool Executable;
    [FieldOffset(6 * 4)] public bool Executable2;
    [FieldOffset(7 * 4)] public int MaxCharges;
    /// <summary>
    /// Range is 0 to 100
    /// </summary>
    [FieldOffset(8 * 4)] public int GlobalCoolDownPercentage;
    /// <summary>
    /// Range is 0 to 100
    /// </summary>
    [FieldOffset(9 * 4)] public int ChargesCooldownPercent;
    [FieldOffset(10 * 4)] public int RechargeTime;              // Same slot as ManaCost            (The game reuses this)
    [FieldOffset(10 * 4), CExporterIgnore] public int ManaCost;                  // Same slot as RechargeTime        (The game reuses this)
    [FieldOffset(12 * 4)] public bool DisplayDot;
    [FieldOffset(13 * 4)] public int CurrentCharges;
    [FieldOffset(14 * 4)] public bool Glows;
    [FieldOffset(15 * 4)] public bool Pulses;
    [FieldOffset(16 * 4)] public bool InRange;
}
