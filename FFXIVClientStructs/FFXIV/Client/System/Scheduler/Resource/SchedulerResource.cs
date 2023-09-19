using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

namespace FFXIVClientStructs.FFXIV.Client.System.Scheduler.Resource;

[StructLayout(LayoutKind.Explicit, Size = 0x88)]
public unsafe partial struct SchedulerResource {
    [FieldOffset(0x00)] public void** vtbl;
    [FieldOffset(0x08)] public SchedulerResource* Next;
    [FieldOffset(0x10)] public SchedulerResource* Previous;
    [FieldOffset(0x20)] public ResourceHandle* Resource;
    [FieldOffset(0x38)] public ResourceName Name;
    [FieldOffset(0x78)] public uint Unk1;
    [FieldOffset(0x7C)] public uint Consumers;

    [StructLayout(LayoutKind.Explicit, Size = 0x40)]
    public partial struct ResourceName {
        [FieldOffset(0x00)] public void** vtbl;
        [FieldOffset(0x08)] public byte* DataPointer;
        [FieldOffset(0x10)] public ushort Unk1;
        [FieldOffset(0x12)] public fixed byte Buffer[0x2E];
    }

    /// <summary>
    /// Returns the data from the contained resource handle or null.
    /// </summary>
    /// <param name="dataLength">The length of the returned data.</param>
    [MemberFunction("E8 ?? ?? ?? ?? 48 8B F0 48 63 83")]
    public partial byte* GetResourceData(uint* dataLength);
}
