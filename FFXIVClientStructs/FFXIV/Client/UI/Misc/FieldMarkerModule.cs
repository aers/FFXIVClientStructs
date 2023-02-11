using FFXIVClientStructs.FFXIV.Client.System.Framework;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

[StructLayout(LayoutKind.Explicit, Size = 0xC78)]
public unsafe partial struct FieldMarkerModule
{
    public static FieldMarkerModule* Instance() => Framework.Instance()->UIModule->GetFieldMarkerModule();
    
    [FixedSizeArray<FieldMarkerPreset>(30)]
    [FieldOffset(0x40)] public fixed byte PresetArray[30 * 0x68];
}

[StructLayout(LayoutKind.Sequential, Pack = 0, Size = 0x0C)]
public struct GamePresetPoint
{
    public int X;
    public int Y;
    public int Z;
}

[StructLayout(LayoutKind.Sequential, Pack = 0, Size = 0x68)]
public struct FieldMarkerPreset
{
    public GamePresetPoint A;
    public GamePresetPoint B;
    public GamePresetPoint C;
    public GamePresetPoint D;
    public GamePresetPoint One;
    public GamePresetPoint Two;
    public GamePresetPoint Three;
    public GamePresetPoint Four;
    public byte ActiveMarkers;
    public byte Reserved;
    public ushort ContentFinderConditionId;
    public int Timestamp;
}