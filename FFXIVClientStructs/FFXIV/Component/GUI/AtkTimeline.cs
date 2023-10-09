namespace FFXIVClientStructs.FFXIV.Component.GUI;

[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public unsafe partial struct AtkTimeline {
    [FieldOffset(0x00)] public AtkTimelineResource* Resource;
    // Used when Resource->LabelSetCount is 0
    [FieldOffset(0x08)] public AtkTimelineResource* LabelResource;
    [FieldOffset(0x10)] public AtkTimelineAnimation* ActiveAnimation;
    [FieldOffset(0x18)] public AtkResNode* OwnerNode;
    [FieldOffset(0x20)] public float FrameTime;
    [FieldOffset(0x24)] public float ParentFrameTime;
    [FieldOffset(0x28)] public ushort LabelFrameIdxDuration;
    [FieldOffset(0x2A)] public ushort LabelEndFrameIdx;
    [FieldOffset(0x2C)] public ushort ActiveLabelId;
    // Properties that aren't modified are put into this mask
    [FieldOffset(0x2E)] public AtkTimelineMask Mask;
    [FieldOffset(0x2F)] public AtkTimelineFlags Flags;

    [MemberFunction("E8 ?? ?? ?? ?? 0F BF 4B 10")]
    public partial void PlayAnimation(AtkTimelineJumpBehavior behavior, byte labelId, float startTime = 0, float endTime = 0);

    [MemberFunction("E9 ?? ?? ?? ?? C3 48 83 EC 48")]
    public partial void UpdateChildTimelines(float frameTime);

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 7D 48 8B 43 20")]
    public partial void GetInterpolatedValue(int keyGroupId, AtkTimelineKeyGroupType keyGroupType, AtkTimelineKeyValue* output);
}
