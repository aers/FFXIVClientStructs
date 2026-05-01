// Suppress Inconsistent Naming due to VirtualKeyCode Names
// ReSharper disable InconsistentNaming
using FFXIVClientStructs.FFXIV.Client.System.Input;
using UserFileEvent = FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager.UserFileEvent;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::UIInputData
//   Component::GUI::AtkInputData
//     Client::System::Input::InputData
//   Client::UI::Misc::UserFileManager::UserFileEvent
[GenerateInterop]
[Inherits<InputData>, Inherits<UserFileEvent>]
[StructLayout(LayoutKind.Explicit, Size = 0xA30)]
public unsafe partial struct UIInputData {
    public static UIInputData* Instance() {
        var uiModule = UIModule.Instance();
        return uiModule == null ? null : uiModule->GetUIInputData();
    }

    public KeyStateFlags GetKeyState(int key) => KeyboardInputs.KeyState[key];
    public KeyStateFlags GetKeyState(SeVirtualKey key) => GetKeyState((int)key);

    public bool IsKeyPressed(SeVirtualKey key) => IsKeyPressed((int)key);
    public bool IsKeyDown(SeVirtualKey key) => IsKeyDown((int)key);
    public bool IsKeyReleased(SeVirtualKey key) => IsKeyReleased((int)key);
    public bool IsKeyHeld(SeVirtualKey key) => IsKeyHeld((int)key);
    public bool IsKeyPressed(int key) => GetKeyState(key).HasFlag(KeyStateFlags.Pressed);
    public bool IsKeyDown(int key) => GetKeyState(key).HasFlag(KeyStateFlags.Down);
    public bool IsKeyReleased(int key) => GetKeyState(key).HasFlag(KeyStateFlags.Released);
    public bool IsKeyHeld(int key) => GetKeyState(key).HasFlag(KeyStateFlags.Held);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8D 4D A0 8B F8")]
    public partial InputId GetKeybindByName(Utf8String* name, System.Input.Keybind* outKeybind);

    /// <summary>
    /// Strips cursor position and scroll input and the given mouse buttons from this input data.
    /// </summary>
    /// <remarks>
    /// This is called by the UI module when the cursor is over a UI collision node to stop the character/viewport from handling it.
    /// </remarks>
    /// <param name="buttonsToFilter">The mouse buttons to remove from this input data.</param>
    [MemberFunction("44 8B C2 48 81 C1 ?? ?? ?? ?? B2 01")]
    public partial void FilterUICursorInputs(MouseButtonFlags buttonsToFilter);

    /// <summary>
    /// Strips mouse drag input from this input data.
    /// </summary>
    /// <remarks>
    /// This is called by the UI module when the cursor is over a UI collision node to stop the character/viewport from handling it.
    /// </remarks>
    [MemberFunction("E8 ?? ?? ?? ?? 45 84 FF 74 08 49 8B CE")]
    public partial void FilterDragInputs();

    /// <summary>
    /// Strips gamepad inputs from this input data.
    /// </summary>
    /// <remarks>
    /// This is called by the UI module when the cursor is over a UI collision node to stop the character/viewport from handling it.
    /// </remarks>
    [MemberFunction("E8 ?? ?? ?? ?? 80 BE ?? ?? ?? ?? ?? 74 0C")]
    public partial void FilterGamepadInputs();
}
