using FFXIVClientStructs.FFXIV.Client.Game.Event;

namespace FFXIVClientStructs.FFXIV.Client.Game.InstanceContent;

// Client::Game::InstanceContent::ContentDirector
//   Client::Game::Event::Director
//     Client::Game::Event::LuaEventHandler
//       Client::Game::Event::EventHandler
[GenerateInterop(isInherited: true)]
[Inherits<Director>]
[VirtualTable("48 8D 05 ?? ?? ?? ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 89 87 ?? ?? ?? ?? 48 8D 05", 3, 373)]
[StructLayout(LayoutKind.Explicit, Size = 0xD30)]
public unsafe partial struct ContentDirector {
    [FieldOffset(0x4E6)] public byte ContentTypeRowId;

    [FieldOffset(0x528)] public DutyActionManager DutyActionManager;

    [FieldOffset(0xC88)] public Utf8String* InstanceContentTexts;
    [FieldOffset(0xC90)] public MapEffectList* MapEffects;
    [FieldOffset(0xC98)] private DynamicEventContainer* DynamicEvents;

    /// <remarks> This might also be a countdown until the content starts (e.g. Frontlines), then the actual time left of the content. </remarks>
    [FieldOffset(0xCF0)] public float ContentTimeLeft;
    [FieldOffset(0xCFC)] public uint InstanceContentTextStartRowId;
    [FieldOffset(0xD00)] public uint InstanceContentTextRowCount;

    [VirtualFunction(303)]
    public partial uint GetCurrentLevel();

    [VirtualFunction(304)]
    public partial uint GetMaxLevel();

    /// <summary>Processes updates specific for this director. This handles the categories between 0 and 0x80000000.</summary>
    [VirtualFunction(325)]
    public partial void ProcessDirectorSpecificDirectorUpdate(uint category, uint* parameters);

    /// <summary>
    /// Gets the max time for the content in seconds
    /// </summary>
    /// <returns>Time in seconds</returns>
    [VirtualFunction(329)]
    public partial uint GetContentTimeMax();

    [VirtualFunction(354)]
    public partial Utf8String* GetInstanceContentText(uint rowId);

    [MemberFunction("40 55 56 41 57 48 83 EC ?? 44 8B FA 4C 89 74 24")]
    public partial void* LoadInstanceContentTexts(uint startRowId, uint rowCount);

    [MemberFunction("2B 91 FC 0C 00 00 4C 8B C9 8B C2 49 8B D0 48 6B C8 68 49 03 89 88 0C 00 00 E9 ?? ?? ?? ??")]
    public partial void SetInstanceContentText(uint rowId, CStringPointer text);

    /// <summary>Changes the state of a map effect.</summary>
    /// <param name="index">Index into MapEffects.</param>
    /// <param name="state">The new state for this MapEffect.</param>
    /// <param name="timelineIndex">Which timeline to play.</param>
    [MemberFunction("48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 57 48 83 EC ?? 8B FA 41 0F B7 E8")]
    public partial void ApplyMapEffect(uint index, ushort state, ushort timelineIndex);

    /// <summary>Handles changes the timeline for a map effect</summary>
    /// <param name="index">Index into MapEffects.</param>
    /// <param name="timelineIndex">Which timeline to play.</param>
    [MemberFunction("E8 ?? ?? ?? ?? 3A C3 74 ?? 44 0F B7 C5")]
    public partial bool PlayMapEffectTimeline(uint index, ushort timelineIndex);

    /// <summary>Processes updates shared between all content (e.g. setting the background music). This handles categories above 0x80000000.</summary>
    [MemberFunction("48 89 6C 24 ?? 48 89 74 24 ?? 57 48 83 EC ?? 81 C2 ?? ?? ?? ?? 41 8B E9")]
    public partial void ProcessCommonDirectorUpdate(uint category, uint arg1, uint arg2, uint arg3, uint arg4);

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x608)]
    public partial struct MapEffectList {
        [FieldOffset(0x00), FixedSizeArray] internal FixedSizeArray128<MapEffectItem> _items;
        [FieldOffset(0x600)] public ushort ContentDirectorManagedSGRowId;
        [FieldOffset(0x602)] public ushort ItemCount;
        [FieldOffset(0x604)] public byte Dirty;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0xC)]
    public struct MapEffectItem {
        [FieldOffset(0x00)] public uint LayoutId;
        [FieldOffset(0x05)] public byte Unknown1; // ContentDirectorManagedSG.Unknown1
        [FieldOffset(0x08)] public ushort State;
        [FieldOffset(0x0A)] public byte Flags;
    }
}
