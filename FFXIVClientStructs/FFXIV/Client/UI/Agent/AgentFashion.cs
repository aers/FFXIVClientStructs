using FFXIVClientStructs.FFXIV.Client.UI.Misc;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentFashion
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.Fashion)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x9E0)]
public unsafe partial struct AgentFashion {
    // 0x28 Common::Component::Excel::ExcelSheet *Sheets[3]
    // 0x40 Common::Component::Excel::ExcelSheetWaiter *SheetWaiters[3]
    // 0x58 bool SheetDataLoaded[3] maybe probably
    [FieldOffset(0x5C)] public uint ScoreGaugeAddonId; // AddonId of FashionCheckScoreGauge
    [FieldOffset(0x60)] public AgentFashionOpenType OpenType;
    [FieldOffset(0x64)] public FashionCheckDataStruct FashionCheckData;
    [FieldOffset(0x90)] public Utf8String WeeklyThemeString;
    [FieldOffset(0xF8), FixedSizeArray] internal FixedSizeArray11<Utf8String> _itemThemeStrings;
    [FieldOffset(0x570), FixedSizeArray] internal FixedSizeArray11<ItemData> _items;
    [FieldOffset(0x6A4), FixedSizeArray] internal FixedSizeArray2<ushort> _glassesIds;
    [FieldOffset(0x6A8)] public FashionCharaView CharaView;
    [FieldOffset(0x9D8)] public nint Callback;

    // Client::UI::Agent::AgentFashion::FashionCharaView
    //   Client::UI::Misc::CharaView
    [GenerateInterop]
    [Inherits<CharaView>]
    [StructLayout(LayoutKind.Explicit, Size = 0x328)]
    public partial struct FashionCharaView;

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x2C)] // not sure about the size
    public partial struct FashionCheckDataStruct {
        [FieldOffset(0x00)] public ushort WeeklyTheme;
        [FieldOffset(0x02)] public byte Remaining;
        [FieldOffset(0x03)] public byte HighScore;
        [FieldOffset(0x04), FixedSizeArray] internal FixedSizeArray11<ushort> _itemThemes;
        [FieldOffset(0x1A)] public byte Score;
        [FieldOffset(0x1B), FixedSizeArray] internal FixedSizeArray11<byte> _itemEvaluations;
    }

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x1C)]
    public partial struct ItemData {
        [FieldOffset(0x00)] public uint ItemId;
        [FieldOffset(0x04)] public uint IconId;
        [FieldOffset(0x08)] public uint SlotFlag;
        [FieldOffset(0x0C)] public uint Stain0Color;
        [FieldOffset(0x10)] public uint Stain1Color;
        [FieldOffset(0x14)] public byte Stain0Id;
        [FieldOffset(0x15)] public byte Stain1Id;
        [FieldOffset(0x16)] public bool HasStain0;
        [FieldOffset(0x17)] public bool HasStain1;
        [FieldOffset(0x18)] public bool IsStainUnlocked;
    }

    // used by lua function FashionCheckOpenHighScoreEquipWidget
    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x46)]
    public partial struct FashionCheckItemDataStruct {
        [FieldOffset(0x00), FixedSizeArray] internal FixedSizeArray11<uint> _itemIds;
        [FieldOffset(0x2C), FixedSizeArray] internal FixedSizeArray11<byte> _stain0Ids;
        [FieldOffset(0x37), FixedSizeArray] internal FixedSizeArray11<byte> _stain1Ids;
        [FieldOffset(0x42), FixedSizeArray] internal FixedSizeArray2<ushort> _glassesIds;
    }
}

public enum AgentFashionOpenType {
    None = -1,
    Preview = 0,
    HighScore = 1,
    Result = 2
}
