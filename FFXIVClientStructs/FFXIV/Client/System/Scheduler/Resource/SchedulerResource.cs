using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

namespace FFXIVClientStructs.FFXIV.Client.System.Scheduler.Resource;

// Client::System::Scheduler::Resource::SchedulerResource
//   Client::System::Scheduler::Base::LinkList<Client::System::Scheduler::Resource::SchedulerResource>
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x88)]
public unsafe partial struct SchedulerResource {
    [FieldOffset(0x08)] public SchedulerResource* Next;
    [FieldOffset(0x10)] public SchedulerResource* Previous;
    [FieldOffset(0x20)] public ResourceHandle* Resource;
    [FieldOffset(0x38)] public ResourceName Name;
    [FieldOffset(0x78)] public uint Unk1;
    [FieldOffset(0x7C)] public uint Consumers;

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x40)]
    public partial struct ResourceName {
        [FieldOffset(0x08)] public byte* DataPointer;
        [FieldOffset(0x10)] public ushort Unk1;
        [FieldOffset(0x12), FixedSizeArray(isString: true)] internal FixedSizeArray46<byte> _buffer;
    }

    /// <summary>
    /// Returns the data from the contained resource handle or null.
    /// </summary>
    /// <param name="dataLength">The length of the returned data.</param>
    [MemberFunction("E8 ?? ?? ?? ?? 48 8B E8 48 63 87 ?? ?? ?? ??")]
    public partial byte* GetResourceData(uint* dataLength);
}
