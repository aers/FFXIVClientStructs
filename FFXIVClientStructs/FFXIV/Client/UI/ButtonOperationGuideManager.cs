using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x34)]
public unsafe partial struct ButtonOperationGuideManager {
    [FieldOffset(0x08)] private AtkEventListener AtkEventListener;
    [FieldOffset(0x10)] public AtkUnitBase *Addon;
    [FieldOffset(0x18)] public AtkComponentButton *ButtonComponent;
    [FieldOffset(0x20)] public uint EventParam;
    [FieldOffset(0x24)] public uint InputId;
    [FieldOffset(0x28)] public OperationGuide OperationGuide;
    
    [VirtualFunction(0)]
    public partial byte SetShowsPointer();
    
    [VirtualFunction(1)]
    public partial ulong SetEnabledState(byte enabled);
}
