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
    
    [FieldOffset(0x3C)] public int WorldCount; // entries in Worlds
    [FieldOffset(0x40)] public World* Worlds; // worlds of the data center selected in the travel window
    
    [FieldOffset(0x40), Obsolete("Use Worlds and WorldCount")]
    public ushort* HomeWorldId;
    
    [FieldOffset(0x48)] public float WorldListTimer; // Worlds, AllWorlds and DataCenters are freed 10 seconds after the travel window was closed
    
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
    [FieldOffset(0x148)] public int AllWorldCount; // entries in AllWorlds, excluding the entries of home world and current world
    
    [FieldOffset(0x14C)] public ushort DataCenterId; // WorldDCGroupType row of the selected data center
    [FieldOffset(0x150)] public uint SelectedDataCenterIndex; // index into DataCenters
    [FieldOffset(0x154)] public byte HomeWorldDataCenterId; // WorldDCGroupType row
    [FieldOffset(0x155)] public byte CurrentWorldDataCenterId; // WorldDCGroupType row
    [FieldOffset(0x158)] public StdVector<DataCenter> DataCenters;

    public Span<World> WorldsSpan => Worlds != null ? new Span<World>(Worlds, WorldCount) : [];
    public Span<World> AllWorldsSpan => AllWorlds != null ? new Span<World>(AllWorlds, AllWorldCount + 2) : [];

    [MemberFunction("48 89 5C 24 ?? 48 89 74 24 ?? 57 48 83 EC ?? 48 8B F9 41 0F B7 F0 48 8B 49")]
    public partial void SetupWorldTravelInfo(ushort currentWorld, ushort targetWorld);

    [MemberFunction("40 53 48 83 EC ?? 48 8B D9 48 8B 49 ?? 48 8B 01 FF 90 ?? ?? ?? ?? 0F B7 53 ?? 48 8B C8 E8 ?? ?? ?? ?? 48 85 C0")]
    public partial CStringPointer GetDestinationWorldName();

    // Client::UI::Agent::AgentWorldTravel::World
    [StructLayout(LayoutKind.Explicit, Size = 0x0C)]
    public struct World {
        [FieldOffset(0x00)] public ushort WorldId;
        [FieldOffset(0x02)] public ushort Flags; // 1 = the world has no message, 2 = home world, 4 = current world
        [FieldOffset(0x04)] public byte DataCenterId; // WorldDCGroupType row
        [FieldOffset(0x08)] public uint MessageId; // shown when this world cannot be visited
    }

    // Client::UI::Agent::AgentWorldTravel::DataCenter
    [StructLayout(LayoutKind.Explicit, Size = 0x70)]
    public struct DataCenter {
        [FieldOffset(0x00)] public ushort DataCenterId; // WorldDCGroupType row
        [FieldOffset(0x08)] public Utf8String Name;
    }
}
