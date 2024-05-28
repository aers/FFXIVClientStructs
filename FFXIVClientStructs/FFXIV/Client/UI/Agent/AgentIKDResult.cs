using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.IKDResult)]
[StructLayout(LayoutKind.Explicit, Size = 0x30)]
[GenerateInterop]
[Inherits<AgentInterface>]
public unsafe partial struct AgentIKDResult {
    [FieldOffset(0x28)] public ResultData* Data;

    [StructLayout(LayoutKind.Explicit, Size = 0x17A0)]
    [GenerateInterop]
    public unsafe partial struct ResultData {
        [FieldOffset(0x00)][FixedSizeArray] internal FixedSizeArray60<CatchResult> _catchResults;
        [FieldOffset(0x2D0)] public byte CatchResultCount;

        [FieldOffset(0x2D4)] public fixed uint ContentBonusIds[13];
        [FieldOffset(0x308)] public byte ContentBonusCount;

        [FieldOffset(0x310)] public ResultEntry PlayerResult;

        [FieldOffset(0x388)][FixedSizeArray] internal FixedSizeArray10<ResultEntry> _groupResult;
        [FieldOffset(0x838)] public byte GroupSize;
        [FieldOffset(0x839)] public byte PlayerGroupIndex;

        [FieldOffset(0x83C)] public uint AvarageCaught;
        [FieldOffset(0x840)] public uint LargeCaught;
        [FieldOffset(0x844)] public uint Score;

        [FieldOffset(0x84C)] public uint TotalScore;
        [FieldOffset(0x850)] public uint ExpReward;
        [FieldOffset(0x854)] public ushort WhiteScripReward;
        [FieldOffset(0x856)] public ushort PurpleScripReward;

        [FieldOffset(0x860)][FixedSizeArray] internal FixedSizeArray60<CatchResultInfo> _catchResultsInfo;

        [FieldOffset(0xB30)][FixedSizeArray] internal FixedSizeArray13<ContentBonusEntry> _contentBonus;

        [FieldOffset(0x1690)][FixedSizeArray] internal FixedSizeArray13<Pointer<ContentBonusEntry>> _contentBonusPointer;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x78)]
    public struct ResultEntry {
        [FieldOffset(0x00)] public Utf8String Name;
        [FieldOffset(0x68)] public ushort WorldId;
        [FieldOffset(0x6C)] public ushort Caught;
        [FieldOffset(0x70)] public uint Points;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0xE0)]
    public struct ContentBonusEntry {
        [FieldOffset(0x00)] public Utf8String Objective;
        [FieldOffset(0x68)] public Utf8String Requirement;
        [FieldOffset(0xD0)] public uint IKDContentBonusId;
        [FieldOffset(0xD4)] public uint IconId;
        [FieldOffset(0xD8)] public ushort UnkUShort; //IKDContentBonus Column 2
        [FieldOffset(0xDA)] public byte Order;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x0C)]
    public struct CatchResult {
        [FieldOffset(0x00)] public uint IKDFishParamId;
        [FieldOffset(0x04)] public ushort Average;
        [FieldOffset(0x06)] public ushort Large;
        [FieldOffset(0x08)] public uint Points;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x0C)]
    public struct CatchResultInfo {
        // more info for the catch results
        [FieldOffset(0x00)] public uint FishParameterId;
        [FieldOffset(0x04)] public uint ItemId;
        [FieldOffset(0x08)] public byte UnkByte; //FishParameter Column 3

        [FieldOffset(0x09)] public byte IKDContentBonusId;
        //[FieldOffset(0x0A)] public ushort UnkUShort;
    }
}
