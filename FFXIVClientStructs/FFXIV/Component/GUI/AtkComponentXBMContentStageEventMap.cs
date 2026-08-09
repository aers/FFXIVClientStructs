using FFXIVClientStructs.FFXIV.Common.Component.Excel;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkComponentXBMContentStageEventMap
//   Component::GUI::AtkComponentBase
//     Component::GUI::AtkEventListener
// common CreateAtkComponent function "E8 ?? ?? ?? ?? 4C 8B F0 48 85 C0 0F 84 ?? ?? ?? ?? 49 8B 4D 08"
// type 27
[GenerateInterop]
[Inherits<AtkComponentBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x968)]
public unsafe partial struct AtkComponentXBMContentStageEventMap {
    [FieldOffset(0xC0), FixedSizeArray] internal FixedSizeArray5<Entry> _entries;

    [FieldOffset(0x930)] public ushort GridSize;
    [FieldOffset(0x932)] public ushort GridHalfSize;
    [FieldOffset(0x934)] public uint XBMContentStageEventMapRowId;
    [FieldOffset(0x938)] public byte LoadState;

    [FieldOffset(0x940)] public AtkComponentBase* CurrentEventMarkerComponent;
    [FieldOffset(0x948)] public EventMapRowEntry* EventMapEntries;
    [FieldOffset(0x950)] public ulong EventMapEntryCapacity;
    [FieldOffset(0x958)] public byte EventMapEntryCount;
    [FieldOffset(0x959)] public byte CurrentEventIndex;
    [FieldOffset(0x95A)] public bool IsEventMapLoaded;
    [FieldOffset(0x95B)] public bool ShouldReloadEventMap;
    [FieldOffset(0x95C)] public bool IsEventMapLoading;
    [FieldOffset(0x95D)] public bool UseEventHandlerState;
    [FieldOffset(0x960)] public ExcelSheetWaiter* SheetWaiter;

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x1B0)]
    public partial struct Entry {
        [FieldOffset(0x00)] public uint TemplateNodeId;
        [FieldOffset(0x04)] public byte ComponentCount;
        [FieldOffset(0x05), FixedSizeArray] internal FixedSizeArray30<byte> _eventMapEntryIndices;
        [FieldOffset(0x28), FixedSizeArray] internal FixedSizeArray30<Pointer<AtkComponentBase>> _components;
        [FieldOffset(0x118), FixedSizeArray] internal FixedSizeArray30<uint> _timelineStates;
        [FieldOffset(0x190), FixedSizeArray] internal FixedSizeArray30<bool> _isCurrentEvent;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0xD)]
    public partial struct EventMapRowEntry {
        [FieldOffset(0x00)] public byte X;
        [FieldOffset(0x01)] public byte Y;
        [FieldOffset(0x02)] public byte Type;
        [FieldOffset(0x03)] public byte EventIndex;
        [FieldOffset(0x04)] public byte LinkedEventIndex;
        [FieldOffset(0x08)] public uint State;
        [FieldOffset(0x0C)] public bool IsStateLoaded;
    }
}
