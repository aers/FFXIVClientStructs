using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkComponentInputBase
//   Component::GUI::AtkComponentBase
//     Component::GUI::AtkEventListener
// ctor "E8 ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 C7 86 ?? ?? ?? ?? ?? ?? ?? ?? 48 89 06"
[GenerateInterop(isInherited: true)]
[Inherits<AtkComponentBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x1E0)]
public unsafe partial struct AtkComponentInputBase {
    public delegate InputCallbackResult CallbackDelegate(AtkUnitBase* thisPtr, InputCallbackType type, CStringPointer rawString, CStringPointer evaluatedString, int eventKind);

    [FieldOffset(0xC0)] public bool IsActive; // Possibly IsFocused
    [FieldOffset(0xC8)] public AtkTextNode* AtkTextNode;
    [FieldOffset(0xD0)] public AtkResNode* CursorContainer;
    [FieldOffset(0xE0)] public Utf8String EvaluatedString;
    [FieldOffset(0xE0), Obsolete("Renamed to EvaluatedString", true)] public Utf8String UnkText1;
    [FieldOffset(0xD8)] public AtkCollisionNode* CollisionNode;
    /// <remarks> Can contain unevaluated fixed macros. </remarks>
    [FieldOffset(0x148)] public Utf8String RawString;
    [FieldOffset(0x148), Obsolete("Renamed to RawString", true)] public Utf8String UnkText2;
    [FieldOffset(0x1B0)] public AtkUnitBase* OwnerAddon;
    [FieldOffset(0x1B0), Obsolete("Renamed to OwnerAddon", true)] public AtkUnitBase* ContainingAddon;
    [FieldOffset(0x1B8)] public delegate* unmanaged<AtkUnitBase*, InputCallbackType, CStringPointer, CStringPointer, int, InputCallbackResult> Callback;
    [FieldOffset(0x1C0)] public int CallbackEventKind;
    [FieldOffset(0x1C4)] public int SelectionStart;
    [FieldOffset(0x1C8)] public int SelectionEnd;
    [FieldOffset(0x1CC)] public int CursorPos;
    [FieldOffset(0x1D0)] public AtkUldComponentDataInputBase InputDataBase;
}

/// <summary>
/// Specifies the type of user interaction that triggered an input callback.
/// </summary>
public enum InputCallbackType {
    /// <summary> The user pressed the <c>Enter</c> key. </summary>
    Enter = 0,
    /// <summary> The user pressed the <c>Escape</c> key. </summary>
    Escape = 1,
    /// <summary> The user clicked outside the input area, causing it to lose focus. </summary>
    FocusLost = 2,
    /// <summary> The user modified the input text. </summary>
    TextChanged = 3,
    /// <summary> The user pressed the <c>Tab</c> key. </summary>
    Tab = 4
}

/// <summary>
/// Specifies the action to take after an input callback has been invoked.
/// </summary>
public enum InputCallbackResult {
    /// <summary> No action. </summary>
    None = 0,
    /// <summary> Clears the current input text. </summary>
    /// <remarks> Does not update the character count. </remarks>
    ClearText = 1,
    Unknown2 = 2,
}
