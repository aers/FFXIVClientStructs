namespace FFXIVClientStructs.FFXIV.Component.GUI;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public partial struct AtkCursor {
    [FieldOffset(0x00)] public bool ShouldAutoHide;
    [FieldOffset(0x08)] public bool IsAutoHidden;
    [FieldOffset(0x0C)] public CursorType Type;
    [FieldOffset(0x1A)] public bool IsVisible;

    [MemberFunction("48 83 EC ?? 80 79 ?? ?? 74 ?? C6 41")]
    public partial void Hide();

    [MemberFunction("48 83 EC 58 80 79 1A 00 75 6C")]
    public partial void Show();

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 4D B0 49 8B D7")]
    public partial void SetVisible(bool visible);

    [MemberFunction("E9 ?? ?? ?? ?? 41 83 F9 63")]
    public partial void SetCursorType(CursorType type, byte a3 = 0);

    public enum CursorType : byte {
        Arrow,
        Boot,
        Search,
        ChatPointer,
        Interact,
        Attack,
        Hand,
        ResizeWE,
        ResizeNS,
        ResizeNWSR,
        ResizeNESW,
        Clickable,
        TextInput,
        TextClick,
        Grab,
        ChatBubble,
        NoAccess,
        Hidden
    }
}
