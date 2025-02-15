namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::UIInputModule
[StructLayout(LayoutKind.Explicit, Size = 0xF0)]
public unsafe partial struct UIInputModule {
    [FieldOffset(0x08)] public UIModule* UIModulePtr;
}
