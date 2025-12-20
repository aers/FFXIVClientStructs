namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

// Client::Game::Event::BattleLeveDirector
//   Client::Game::Event::LeveDirector
//     Client::Game::Event::Director
//       Client::Game::Event::LuaEventHandler
//         Client::Game::Event::EventHandler
[GenerateInterop(isInherited: true)]
[Inherits<LeveDirector>]
[StructLayout(LayoutKind.Explicit, Size = 0x690)]
public partial struct BattleLeveDirector {
    [FieldOffset(0x4C0 + 0x00), CExporterExcelBegin("BattleLeve")] private byte _rowStart;
    [FieldOffset(0x4C0 + 0x00), FixedSizeArray] internal FixedSizeArray8<ushort> _time;
    [FieldOffset(0x4C0 + 0x10), FixedSizeArray] internal FixedSizeArray8<LeveDataStruct> _leveData;
    [FieldOffset(0x4C0 + 0x190), FixedSizeArray] internal FixedSizeArray8<byte> _toDoSequence;
    [FieldOffset(0x4C0 + 0x198)] public int Rule;
    [FieldOffset(0x4C0 + 0x19C), FixedSizeArray] internal FixedSizeArray3<ushort> _objectiveIds;
    [FieldOffset(0x4C0 + 0x1A2), FixedSizeArray] internal FixedSizeArray2<ushort> _help;
    [FieldOffset(0x4C0 + 0x1A6), CExporterExcelEnd] public byte Variant;

    [FieldOffset(0x670)] public ushort RecommendedLevel;

    [GenerateInterop]
    [CExporterIgnore]
    [StructLayout(LayoutKind.Explicit, Size = 0x30)]
    public partial struct LeveDataStruct {
        [FieldOffset(0x00)] public uint BNpcName;
        [FieldOffset(0x04)] public uint ToDoNumberInvolved;
        [FieldOffset(0x08), FixedSizeArray] internal FixedSizeArray5<uint> _toDoParam;
        [FieldOffset(0x1C)] public int BaseID;
        [FieldOffset(0x20)] public int ItemsInvolved;
        [FieldOffset(0x24)] public ushort EnemyLevel;
        [FieldOffset(0x26)] public byte ItemsInvolvedQty;
        [FieldOffset(0x27)] public byte ItemDropRate;
        [FieldOffset(0x28), FixedSizeArray] internal FixedSizeArray5<byte> _numOfAppearance;
    }
}
