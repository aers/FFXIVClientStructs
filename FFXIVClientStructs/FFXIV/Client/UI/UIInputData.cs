// Suppress Inconsistent Naming due to VirtualKeyCode Names
// ReSharper disable InconsistentNaming
using FFXIVClientStructs.FFXIV.Client.System.Input;
using FFXIVClientStructs.FFXIV.Client.System.String;
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
}
