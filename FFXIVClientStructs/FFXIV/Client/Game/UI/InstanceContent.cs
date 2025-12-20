using FFXIVClientStructs.FFXIV.Client.System.Memory;

namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

// Client::Game::UI::InstanceContent
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x78)]
public unsafe partial struct InstanceContent {
    [StaticAddress("48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 84 C0 0F 94 C3", 3)]
    public static partial InstanceContent* Instance();

    [FieldOffset(0x70)] public bool IsLimitedTimeBonusActive;

    /// <summary>
    /// Provides the number of minutes remaining on the penalty.
    /// </summary>
    /// <param name="index">
    /// 0 = Duty Finder penalty<br/>
    /// 1 = Inactivity penalty, presumably (e.g. for Crystalline Conflict Ranked Match)
    /// </param>
    /// <returns>Number of minutes left</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 8B 0E 3B C8")]
    public partial uint GetPenaltyRemainingInMinutes(byte index);

    [MemberFunction("48 83 EC 28 84 D2 74 33")]
    public partial bool IsRouletteIncomplete(byte roulette);

    public bool IsRouletteComplete(byte roulette) => !IsRouletteIncomplete(roulette);

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x80)]
    public partial struct ContentUI : ICreatable {
        [FieldOffset(0x08)] public ContentLookupInfo LookupInfo;
        [FieldOffset(0x10)] public InstanceContentExcelWrapper InstanceContent;
        [FieldOffset(0x28)] public ContentRoulette ContentRoulette;
        [FieldOffset(0x38)] public PartyContent PartyContent;
        [FieldOffset(0x50)] public PublicContent PublicContent;
        [FieldOffset(0x68)] public GoldSaucerContent GoldSaucerContent;

        [MemberFunction("45 33 C0 C6 41 08 00")]
        public partial void Ctor();

        [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 ?? 48 8D 4E ?? 48 8B 5C 24")]
        public partial bool LoadByContentLookupInfo(ContentLookupInfo* lookupInfo);

        [MemberFunction("E9 ?? ?? ?? ?? 44 0F B6 43 ?? 48 8D 51")]
        public partial bool LoadByContentFinderConditionId(uint rowId);

        [MemberFunction("E8 ?? ?? ?? ?? 89 BB ?? ?? ?? ?? 8B CD")]
        public partial ContentInterface* GetContentInterface();

        [VirtualFunction(0)]
        public partial ContentUI* Dtor(byte freeFlags);
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x08)]
    public partial struct ContentLookupInfo {
        [FieldOffset(0x00)] public ContentLookupType Type;
        [FieldOffset(0x04)] public uint RowId;
    }

    public enum ContentLookupType : byte {
        ContentRoulette = 1,
        ContentFinderCondition = 2,
    }
}
