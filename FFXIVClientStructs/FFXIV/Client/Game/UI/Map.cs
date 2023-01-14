using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

[StructLayout(LayoutKind.Explicit)]
public unsafe partial struct Map
{
    [FieldOffset(0x88)] public QuestMarkerArray QuestMarkers;

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

    [StructLayout(LayoutKind.Explicit, Size = 0x90)]
    public struct MapMarkerInfo
    {
        [FieldOffset(0x04)] public uint QuestID;
        [FieldOffset(0x08)] public Utf8String Name;
        [FieldOffset(0x8B)] public byte ShouldRender;
        [FieldOffset(0x88)] public ushort RecommendedLevel;
    }

    [StaticAddress("48 8D 0D ?? ?? ?? ?? 41 8B D4 66 89 44 24", 3)]
    public static partial Map* Instance();
}