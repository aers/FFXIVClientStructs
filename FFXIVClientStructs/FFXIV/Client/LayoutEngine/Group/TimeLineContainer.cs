namespace FFXIVClientStructs.FFXIV.Client.LayoutEngine.Group;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public unsafe partial struct TimeLineContainer {
    [FieldOffset(0x08)] public StdVector<Pointer<TimeLineLayoutInstance>> Instances;

    [MemberFunction("48 8B 41 08 44 8B CA")]
    public partial TimeLineLayoutInstance* FindInstanceBySubId(uint subId);
}
