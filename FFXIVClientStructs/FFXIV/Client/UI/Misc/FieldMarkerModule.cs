using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::FieldMarkerModule
//   Client::UI::Misc::UserFileManager::UserFileEvent
// ctor "E8 ?? ?? ?? ?? 33 C0 33 D2 41 B8 ?? ?? ?? ?? 48 89 87"
[GenerateInterop, Inherits<UserFileEvent>]
[StructLayout(LayoutKind.Explicit, Size = 0xC78)]
public unsafe partial struct FieldMarkerModule {
    public static FieldMarkerModule* Instance() => Framework.Instance()->GetUIModule()->GetFieldMarkerModule();

    [FieldOffset(0x40), FixedSizeArray] internal FixedSizeArray30<FieldMarkerPreset> _presets;
}

[StructLayout(LayoutKind.Explicit, Size = 0x0C)]
public struct GamePresetPoint {
    [FieldOffset(0x00)] public int X;
    [FieldOffset(0x04)] public int Y;
    [FieldOffset(0x08)] public int Z;
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x68)]
public partial struct FieldMarkerPreset {
    [FieldOffset(0x00), FixedSizeArray] internal FixedSizeArray8<GamePresetPoint> _markers;
    [FieldOffset(0x60)] public byte ActiveMarkers;
    [FieldOffset(0x61)] private byte Reserved;
    [FieldOffset(0x62)] public ushort ContentFinderConditionId;
    [FieldOffset(0x64)] public uint TimeStamp;

    public bool IsMarkerActive(int index) => (ActiveMarkers & 1 << index) != 0;
}
