using FFXIVClientStructs.FFXIV.Client.System.Input;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::UIClipboard
// ctor "E8 ?? ?? ?? ?? EB 03 48 8B C6 4C 8B 87"
[StructLayout(LayoutKind.Explicit, Size = 0xF8)]
public unsafe partial struct UIClipboard {
    [FieldOffset(0x8)] public UIModule* UIModule;
    [FieldOffset(0x10)] public ClipBoard Data;
    [FieldOffset(0xE8)] public nint ThisHwnd;
    [FieldOffset(0xF0)] public nint NextHwnd;

    /// <summary>
    /// Called when the content of the clipboard changes (WM_DRAWCLIPBOARD (0x308)).
    /// </summary>
    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 80 3D ?? ?? ?? ?? ?? 74 29")]
    public partial void OnClipboardDataChanged();

    /// <summary>
    /// Called when a window is being removed from the chain (WM_CHANGECBCHAIN (0x30D)).
    /// </summary>
    /// <param name="wParam">A handle to the window being removed from the clipboard viewer chain.</param>
    /// <param name="lParam">
    /// A handle to the next window in the chain following the window being removed.<br/>
    /// This parameter is NULL if the window being removed is the last window in the chain.
    /// </param>
    [MemberFunction("48 8B C1 48 8B 89 ?? ?? ?? ?? 48 3B D1")]
    public partial void OnClipboardViewerChainChanged(nint wParam, nint lParam);
}
