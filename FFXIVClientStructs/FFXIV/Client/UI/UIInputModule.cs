namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::UIInputModule
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0xF0)]
public unsafe partial struct UIInputModule {
    [FieldOffset(0x08)] public UIModule* UIModulePtr;

    [FieldOffset(0x25)] public bool IsPadMouseModeEnabled;

    [MemberFunction("48 89 5C 24 ?? 55 48 83 EC 20 80 79 25 00")]
    public partial void DisablePadMouseMode(bool playSoundEffect = true);
}
