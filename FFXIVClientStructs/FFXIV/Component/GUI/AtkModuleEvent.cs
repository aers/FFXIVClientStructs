namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkModuleEvent
[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 8)]
public unsafe partial struct AtkModuleEvent {
    [VirtualFunction(0)]
    public partial void CallHandler(AtkValue* result, uint handlerIndex, AtkValue* values, uint valueCount);
}
