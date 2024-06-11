namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkExternalInterface
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x8)]
public unsafe partial struct AtkExternalInterface {
    [VirtualFunction(1)]
    public partial void CallHandler(AtkValue* result, uint handlerIndex, uint valueCount, AtkValue* values);

    // [VirtualFunction(2)]
    // public partial void CallTextService(AtkValue* result, uint handlerIndex);  // guessed, so just a comment for now
}
