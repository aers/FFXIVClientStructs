using UserFileEvent = FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager.UserFileEvent;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::FieldMarkerModule
//   Client::UI::Misc::UserFileManager::UserFileEvent
[GenerateInterop]
[Inherits<UserFileEvent>]
[StructLayout(LayoutKind.Explicit, Size = 0xC80)]
public unsafe partial struct FieldMarkerModule {
    public static FieldMarkerModule* Instance() {
        var uiModule = UIModule.Instance();
        return uiModule == null ? null : uiModule->GetFieldMarkerModule();
    }

    [FieldOffset(0x48), FixedSizeArray] internal FixedSizeArray30<FieldMarkerPreset> _presets;
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
    [FieldOffset(0x62)] public ushort ContentFinderConditionId;
    [FieldOffset(0x64)] public int Timestamp;

    public bool IsMarkerActive(int index) => (ActiveMarkers & 1 << index) != 0;
    public void SetMarkerActive(int index, bool active) {
        ActiveMarkers = (byte)(active ? ActiveMarkers | 1 << index : ActiveMarkers & ~(1 << index));
    }
}
