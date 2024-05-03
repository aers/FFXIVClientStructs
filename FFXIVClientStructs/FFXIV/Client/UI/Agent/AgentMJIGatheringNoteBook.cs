using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.MJIGatheringNoteBook)]
[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public unsafe partial struct AgentMJIGatheringNoteBook {
    [FieldOffset(0)] public AgentInterface AgentInterface;
    [FieldOffset(0x28)] public AgentMJIGatheringNoteBookData* Data;

    [MemberFunction("40 53 48 83 EC 20 48 8B 41 28 48 8B D9 89 90")]
    public readonly partial void SelectItem(uint itemIndex);
}

[StructLayout(LayoutKind.Explicit, Size = 0x1D0)]
public struct AgentMJIGatheringNoteBookData {
    [FieldOffset(0)] public uint Status;

    [FieldOffset(0x70)] public uint ItemCount;

    [FieldOffset(0xC0)] public StdVector<Pointer<GatherItem>> SortedGatherItems;

    [FieldOffset(0x1C8)] public uint SelectedItemIndex;
    [FieldOffset(0x1CC)] public byte Flags;

    [StructLayout(LayoutKind.Explicit, Size = 0x80)]
    public struct GatherItem {
        [FieldOffset(0x00)] public ushort Radius;
        [FieldOffset(0x02)] public short X;
        [FieldOffset(0x04)] public short Y;
        [FieldOffset(0x06)] public byte Unknown2; // from the sheet

        [FieldOffset(0x08)] public uint ItemId;
        [FieldOffset(0x0C)] public byte Sort;

        [FieldOffset(0x10)] public uint Icon;
        [FieldOffset(0x14)] public byte RowId; // offset by 1

        [FieldOffset(0x18)] public Utf8String Name;
    }
}
