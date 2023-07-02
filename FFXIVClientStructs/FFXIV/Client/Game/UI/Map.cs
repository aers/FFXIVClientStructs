using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

[StructLayout(LayoutKind.Explicit)]
public unsafe partial struct Map
{
    [Obsolete("Use QuestDataSpan instead", false)]
    [FieldOffset(0x90)] public QuestMarkerArray QuestMarkers;

    [FieldOffset(0x90)] public MapMarkerInfo QuestData;
    [FieldOffset(0x1170)] public MapMarkerInfo LevequestData;
    [FieldOffset(0x1AE8)] public StdVector<QuestMarkerInfo> LevequestMarkerData;
    [FieldOffset(0x1B20)] public MapMarkerDataContainer QuestMarkerData;
    [FieldOffset(0x1BA0)] public SpecialMarkerContainer GuildOrderGuideMarkerData;
    [FieldOffset(0x1B68)] public MapMarkerDataContainer GuildLeveAssignmentMarkerData;
    [FieldOffset(0x3EB0)] public MapMarkerDataContainer CustomTalkMarkerData;
    [FieldOffset(0x3E90)] public SpecialMarkerContainer TripleTriadMarkerData;
    
    [Obsolete("Use QuestDataSpan instead", false)]
    [StructLayout(LayoutKind.Sequential, Size = 0x10E0)]
    public struct QuestMarkerArray
    {
        private fixed byte data[30 * 0x90];

        public MapMarkerInfo* this[int index]
        {
            get
            {
                if (index is < 0 or > 30) return null;

                fixed (byte* pointer = data)
                {
                    return (MapMarkerInfo*) (pointer + sizeof(MapMarkerInfo) * index);
                }
            }
        }
    }
    
    public Span<MapMarkerInfo> QuestDataSpan
    {
        get
        {
            fixed (MapMarkerInfo* pointer = &QuestData)
            {
                return new Span<MapMarkerInfo>(pointer, 30);
            }
        }
    }

    public Span<MapMarkerInfo> LevequestDataSpan
    {
        get
        {
            fixed (MapMarkerInfo* pointer = &LevequestData)
            {
                return new Span<MapMarkerInfo>(pointer, 30);
            }
        }
    }
    
    [StructLayout(LayoutKind.Explicit, Size = 0x90)]
    public struct MapMarkerInfo
    {
        [FieldOffset(0x04)] public uint QuestID;
        [FieldOffset(0x08)] public Utf8String Name;
        [FieldOffset(0x70)] public StdVector<QuestMarkerInfo> MarkerData;
        [FieldOffset(0x8B)] public byte ShouldRender;
        [FieldOffset(0x88)] public ushort RecommendedLevel;
    }

    [StaticAddress("48 8D 0D ?? ?? ?? ?? 41 8B D4 66 89 44 24", 3)]
    public static partial Map* Instance();
}

[StructLayout(LayoutKind.Explicit)]
public unsafe partial struct MapMarkerDataContainer
{
    [FieldOffset(0x08)] public MapMarkerData** MarkerData;
    [FieldOffset(0x10)] public int MarkerCount;

    public Span<Pointer<MapMarkerData>> MarkerDataSpan => new(MarkerData, MarkerCount);
}
    
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe partial struct MapMarkerData
{
    [FieldOffset(0x00)] public uint IconId;
    [FieldOffset(0x04)] public uint LevelId; // RowId into the 'Level' sheet
    [FieldOffset(0x08)] public uint ObjectiveId; // RowId for whichever type of data this specific marker is representing, QuestId in the case of quests
    [FieldOffset(0x0C)] public int Flags;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe partial struct SpecialMarkerContainer
{
    [FieldOffset(0x00)] public SpecialMarker** SpecialMarkerData;
    [FieldOffset(0x08)] public int DataCount;
        
    public Span<Pointer<SpecialMarker>> DataSpan => new(SpecialMarkerData, DataCount);
}

[StructLayout(LayoutKind.Explicit)]
public unsafe partial struct SpecialMarker
{
    [FieldOffset(0x14)] public uint ObjectiveId;
    [FieldOffset(0x18)] public Utf8String Tooltip;
    [FieldOffset(0x80)] public SpecialMarkerData* MarkerData;
}

[StructLayout(LayoutKind.Explicit, Size = 0x48)]
public unsafe partial struct SpecialMarkerData
{
    [FieldOffset(0x00)] public uint LevelId;
    [FieldOffset(0x04)] public uint ObjectiveId;
    [FieldOffset(0x10)] public uint IconId;
}

[StructLayout(LayoutKind.Explicit, Size = 0x48)]
public unsafe partial struct QuestMarkerInfo
{
    [FieldOffset(0x00)] public uint LevelId;
    [FieldOffset(0x08)] public Utf8String* Tooltip;
    [FieldOffset(0x10)] public uint IconId;
}
