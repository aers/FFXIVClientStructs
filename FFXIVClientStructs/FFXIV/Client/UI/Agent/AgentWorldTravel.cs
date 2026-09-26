namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentWorldTravel
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.WorldTravel)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x170)]
public unsafe partial struct AgentWorldTravel {
    [FieldOffset(0x30)] public uint YesNo2Id;
    [FieldOffset(0x34)] public uint WorldTravelFinderStatusAddonId;
    [FieldOffset(0x38)] public uint WorldTravelFinderReadyAddonId;
    
    [FieldOffset(0x3C)] public int WorldCount;
    [FieldOffset(0x40)] public World* Worlds; // worlds of the data center selected in the travel addon
    
    [FieldOffset(0x40), Obsolete("Use Worlds and WorldCount")]
    public ushort* HomeWorldId;
    
    [FieldOffset(0x48)] public float WorldListTimer; // Worlds, AllWorlds and DataCenters are freed 10 seconds after the travel addon was closed
    
    [FieldOffset(0x48), Obsolete("Use WorldListTimer")]
    private uint QueueTimer1; // only active during waiting
    
    [FieldOffset(0x4C)] public ushort DestinationWorldId;

    [FieldOffset(0x50)] public Utf8String CurrentWorldName;
    [FieldOffset(0xB8)] public Utf8String DestinationWorldName;

    [FieldOffset(0x120)] public byte IsWorldTraveling;
    [FieldOffset(0x121)] public byte IsInWorldTravelQueue;

    [FieldOffset(0x120), Obsolete("Use IsWorldTraveling and IsInWorldTravelQueue")]
    private ushort TransportFlag; // InQueue vs Ready

    [FieldOffset(0x124)] public uint QueueStartTime; // server time at which the queue was entered
    
    [FieldOffset(0x124), Obsolete("Use QueueStartTime and ElapsedQueueTimeSecond")]
    private void* QueueTimer2; // only resets on each new travel, counts up in ~seconds
    
    [FieldOffset(0x128)] public uint ElapsedQueueTimeSecond;
    [FieldOffset(0x12C)] public uint QueuePosition;
    [FieldOffset(0x130)] public uint EstimatedWaitTimeMinute;
    [FieldOffset(0x134)] public uint LastElapsedQueueTimeSecond; // last value written to the finder status addon

    [FieldOffset(0x138)] public byte BetweenAreas; // Roughly corresponds to the BetweenAreas condition

    [FieldOffset(0x140)] public World* AllWorlds; // every world known to the client
    [FieldOffset(0x148)] public int AllWorldCount; // excluding the entries of home world and current world
    
    [FieldOffset(0x14C)] public ushort DataCenterId; // WorldDCGroupType row of the selected data center
    [FieldOffset(0x150)] public uint SelectedDataCenterIndex;
    [FieldOffset(0x154)] public byte HomeWorldDataCenterId; // WorldDCGroupType row
    [FieldOffset(0x155)] public byte CurrentWorldDataCenterId; // WorldDCGroupType row
    [FieldOffset(0x158)] public StdVector<DataCenter> DataCenters;

    public Span<World> WorldsSpan => Worlds != null ? new Span<World>(Worlds, WorldCount) : [];
    public Span<World> AllWorldsSpan => AllWorlds != null ? new Span<World>(AllWorlds, AllWorldCount + 2) : [];

    [MemberFunction("48 89 5C 24 ?? 55 56 57 41 56 41 57 48 83 EC ?? 0F B7 42")]
    public partial void OnWorldListPacket(WorldListPacket* packet);

    [MemberFunction("48 89 5C 24 ?? 57 48 83 EC ?? 48 8B D9 48 8B FA 0F B6 4A ?? 83 E9")]
    public partial void OnWorldTravelStatusPacket(WorldTravelStatusPacket* packet);

    [MemberFunction("48 89 6C 24 ?? 57 48 81 EC ?? ?? ?? ?? 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 84 24 ?? ?? ?? ?? 33 ED")]
    public partial void StartWorldTravel();

    [MemberFunction("E8 ?? ?? ?? ?? 4C 8B C0 BA ?? ?? ?? ?? 48 8B CB E8 ?? ?? ?? ?? 4C 8B C0 C6 44 24 ?? ?? 45 33 C9 33 D2 48 8B CD")]
    public partial CStringPointer GetDestinationWorldName();

    [MemberFunction("E9 ?? ?? ?? ?? BA ?? ?? ?? ?? 48 8B CB E8 ?? ?? ?? ?? 48 85 C0 74 ?? 48 8B C8 48 83 C4")]
    public partial void UpdateFinderStatusAddon();

    [MemberFunction("E8 ?? ?? ?? ?? B9 ?? ?? ?? ?? 48 89 5C 24 ?? E8 ?? ?? ?? ?? 0F 57 C0")]
    public partial void BuildWorldList(World* worlds, int worldCount, WorldListPacket* packet);

    [MemberFunction("E8 ?? ?? ?? ?? 83 F8 ?? 0F 82 ?? ?? ?? ?? 8B C0")]
    public partial int AddWorldEntry(World* worlds, int* index, ushort homeWorld, ushort currentWorld, WorldListEntry* entry);

    [MemberFunction("4C 8B DC 55 53 41 57 48 8D 6C 24")]
    public partial void UpdateWorldTravelAddon();

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8B 4E ?? 48 8B 01 FF 50 ?? 48 8B C8 BA ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 8B 4E ?? 48 8B 01")]
    public partial void OpenFinderStatusAddon();

    [MemberFunction("40 53 48 83 EC ?? 83 79 ?? ?? 48 8B D9 74 ?? 48 8B 49 ?? 48 8B 01 FF 50 ?? 8B 53 ?? 48 8B C8 4C 8B 00 41 FF 90 ?? ?? ?? ?? C7 43 ?? ?? ?? ?? ?? 48 83 C4 ?? 5B C3 CC CC CC CC CC CC CC CC CC CC 4C 8B DC 56 48 81 EC ?? ?? ?? ?? 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 84 24 ?? ?? ?? ?? 83 79")]
    public partial void CloseFinderStatusAddon();

    [MemberFunction("4C 8B DC 56 48 81 EC ?? ?? ?? ?? 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 84 24 ?? ?? ?? ?? 83 79 ?? ?? 48 8B F1 0F 85 ?? ?? ?? ?? F3 0F 10 05")]
    public partial void OpenFinderReadyAddon();

    [MemberFunction("40 53 48 83 EC ?? 83 79 ?? ?? 48 8B D9 74 ?? 48 8B 49 ?? 48 8B 01 FF 50 ?? 8B 53 ?? 48 8B C8 4C 8B 00 41 FF 90 ?? ?? ?? ?? C7 43 ?? ?? ?? ?? ?? 48 83 C4 ?? 5B C3 CC CC CC CC CC CC CC CC CC CC 40 53 48 83 EC ?? 85 D2")]
    public partial void CloseFinderReadyAddon();

    [MemberFunction("40 53 48 83 EC ?? 85 D2 44 89 81")]
    public partial void SetQueueInfo(int position, int estimatedWaitTimeMinute);

    [MemberFunction("48 89 5C 24 ?? 48 89 74 24 ?? 57 48 83 EC ?? 48 8B F9 41 0F B7 F0 48 8B 49")]
    public partial void SetupWorldTravelInfo(ushort currentWorld, ushort targetWorld);

    [MemberFunction("40 57 44 8B 81")]
    public partial void FilterWorldList(ushort dataCenterId);

    [MemberFunction("40 53 48 83 EC ?? 48 8B 49 ?? 0F B7 DA 48 8B 01 FF 90 ?? ?? ?? ?? 66 85 DB")]
    public partial byte GetWorldDataCenter(ushort worldId);

    [MemberFunction("48 8B 81 ?? ?? ?? ?? 48 8B 91 ?? ?? ?? ?? 48 3B C2 74 ?? 48 2B D0")]
    public partial int GetDataCenterCount();

    [StructLayout(LayoutKind.Explicit, Size = 0x0C)]
    public struct World {
        [FieldOffset(0x00)] public ushort WorldId;
        [FieldOffset(0x02)] public ushort Flags; // 1 = LogMessageId is 0, 2 = home world, 4 = current world
        [FieldOffset(0x04)] public byte DataCenterId; // WorldDCGroupType row
        [FieldOffset(0x08)] public uint LogMessageId; // shown when this world cannot be visited
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x70)]
    public struct DataCenter {
        [FieldOffset(0x00)] public ushort DataCenterId; // WorldDCGroupType row
        [FieldOffset(0x08)] public Utf8String Name;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x410)]
    public struct WorldListPacket {
        /// <summary>
        /// 40 entries or 128 entries
        /// </summary>
        [FieldOffset(0x10), FixedSizeArray] internal FixedSizeArray128<WorldListEntry> _entries;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x08)]
    public struct WorldListEntry {
        [FieldOffset(0x00)] public uint LogMessageId;
        [FieldOffset(0x04)] public ushort WorldId;
        [FieldOffset(0x06)] private ushort Unk06;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x1C)]
    public struct WorldTravelStatusPacket {
        [FieldOffset(0x10)] public byte Status; // 1 = queue updated, 2 = travel started, 3 = travel ended
        [FieldOffset(0x14), CExporterUnion("Queue")] public uint QueuePosition; // status 1
        [FieldOffset(0x18), CExporterUnion("WaitTime")] public uint EstimatedWaitTimeMinute; // status 1
        [FieldOffset(0x14), CExporterUnion("Queue")] public uint LogMessageId1; // status 3
        [FieldOffset(0x18), CExporterUnion("WaitTime")] public uint LogMessageId2; // status 3
    }
}
