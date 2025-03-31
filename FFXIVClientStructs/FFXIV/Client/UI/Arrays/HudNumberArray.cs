using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Arrays;

[CExportIgnore]
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 163 * 4)]
public unsafe partial struct HudNumberArray {
    public static HudNumberArray* Instance() => (HudNumberArray*)AtkStage.Instance()->GetNumberArrayData(NumberArrayType.Hud)->IntArray;

    [FieldOffset(0), FixedSizeArray, CExportIgnore] internal FixedSizeArray163<int> _data;

    [FieldOffset(0 * 4)] public int CurrentHealth;
    [FieldOffset(1 * 4)] public int MaxHealth;
    [FieldOffset(2 * 4)] public int CurrentMana;
    [FieldOffset(3 * 4)] public int MaxMana;
    [FieldOffset(4 * 4)] public int CurrentTp;
    [FieldOffset(5 * 4)] public int MaxTp;
    [FieldOffset(6 * 4)] public int CurrentCp;
    [FieldOffset(7 * 4)] public int MaxCp;
    [FieldOffset(8 * 4)] public int CurrentGp;
    [FieldOffset(9 * 4)] public int MaxGp;
    [FieldOffset(10 * 4)] public int CurrentMana2;
    [FieldOffset(11 * 4)] public int MaxMana2;
    [FieldOffset(12 * 4)] public int Unk12;
    [FieldOffset(13 * 4)] public int Unk13;
    [FieldOffset(14 * 4)] public int Unk14;
    [FieldOffset(15 * 4)] public int PlayerEntityId;
    [FieldOffset(16 * 4)] public int CurrentExp;
    /// <summary>
    /// Range is 0 - 10,000
    /// </summary>
    [FieldOffset(17 * 4)] public int ExpGaugeFillPercent;
    [FieldOffset(18 * 4)] public int MaxExp;
    [FieldOffset(19 * 4)] public int TotalRestedExp;
    /// <summary>
    /// Range is 0 - 10,000
    /// </summary>
    [FieldOffset(20 * 4)] public int RestedExpGaugeFillPercent;
    [FieldOffset(21 * 4)] public bool ShowRestedAreaIndicator;
    [FieldOffset(22 * 4)] public bool ShowCombatAreaIndicator;
    [FieldOffset(23 * 4)] public bool ShowExpBar;
    [FieldOffset(24 * 4)] public uint CurrentLevel;
    [FieldOffset(25 * 4)] public uint CurrentLevel2;
    [FieldOffset(26 * 4)] public uint CurrentJobId;
    [FieldOffset(27 * 4)] public uint CurrentJobId2;
    [FieldOffset(28 * 4)] public uint CurrentJobIconId;
    [FieldOffset(29 * 4)] public HudJobType JobType;
    [FieldOffset(30 * 4)] public HudJobType JobType2;
    [FieldOffset(31 * 4)] public HudStatusElementLayout StatusElementLayout;
    [FieldOffset(32 * 4), FixedSizeArray] internal FixedSizeArray20<int> _positiveStatusIndexes;
    [FieldOffset(52 * 4), FixedSizeArray] internal FixedSizeArray20<int> _negativeStatusIndexes;
    [FieldOffset(72 * 4), FixedSizeArray] internal FixedSizeArray20<int> _otherStatusIndexes;
    [FieldOffset(92 * 4), FixedSizeArray] internal FixedSizeArray8<int> _comboStatusIndexes;
    [FieldOffset(100 * 4), FixedSizeArray] internal FixedSizeArray30<uint> _statusIconIds;
    [FieldOffset(130 * 4), FixedSizeArray] internal FixedSizeArray30<bool> _statusDispellables;
    [FieldOffset(160 * 4)] public uint GrandCompanyIconId;
    [FieldOffset(161 * 4)] public uint GrandCompanyRankIconId;
    [FieldOffset(162 * 4)] public uint ChainCount;

    public enum HudJobType : byte {
        CombatJob = 1,
        GathererJob = 2,
        CrafterJob = 4,
    }

    public enum HudStatusElementLayout : byte {
        ThreeElements = 0,
        OneElement = 1,
        FourElements = 2,
    }
}


