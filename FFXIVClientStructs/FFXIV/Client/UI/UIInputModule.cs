using FFXIVClientStructs.FFXIV.Client.System.Input;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::UIInputModule
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0xF0)]
public unsafe partial struct UIInputModule {
    [MemberFunction("E8 ?? ?? ?? ?? BD ?? ?? ?? ?? 84 C0 74 ?? BA")]
    public static partial bool IsInputIdPressed(InputId id);

    [FieldOffset(0x08)] public UIModule* UIModulePtr;

    [FieldOffset(0x26)] public bool IsPadMouseModeEnabled;

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 4B ?? ?? ?? ?? FF 90 ?? ?? ?? ?? 48 8B C8 33 D2 48 83 C4")]
    public partial void DisablePadMouseMode(bool playSoundEffect = true);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B CF E8 ?? ?? ?? ?? 48 8B CF E8 ?? ?? ?? ?? 84 C0")]
    public partial void HandleTargetingKeybinds();
}
