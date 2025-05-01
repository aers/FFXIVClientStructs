namespace FFXIVClientStructs.FFXIV.Client.Game.WKS;

[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe partial struct WKSMechaEventStageHandlerBase {
    [FieldOffset(0x08)] public WKSMechaEvent* OwnerEvent;

    [VirtualFunction(4)]
    public partial int GetStageIndex();
}
