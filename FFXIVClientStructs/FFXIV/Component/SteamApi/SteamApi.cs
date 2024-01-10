using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.SteamApi.Callbacks;

namespace FFXIVClientStructs.FFXIV.Component.SteamApi;

/// <remarks>
/// This struct <b><em>WILL</em></b> break! I make no guarantees about the API of this struct <em>at all</em>.
/// You are on your own.
/// </remarks>
[StructLayout(LayoutKind.Explicit, Size = 0x4D0)]
public unsafe partial struct SteamApi {
    // 0x0 to 0x400 appears to be blank space, though some references to AuthTicket and FriendsList do exist.
    
    [FieldOffset(0x408)] public bool SteamApiInitialized;

    [FieldOffset(0x40C)] public float TimeSinceLastCallbackRun;
    [FieldOffset(0x410)] public uint SteamAppId;
    [FieldOffset(0x414)] public SteamTypes.CSteamId SteamLocalUserId;
    
    // invalid ptr - steam says not to store the byte* ptr they return. SE does.
    [FieldOffset(0x420)] public void* PersonaNamePtr;

    [FieldOffset(0x428)] public bool AuthTicketPresent;
    [FieldOffset(0x42C)] public SteamTypes.AuthSessionTicketResponse AuthTicket;

    // set to true if the virtual keyboard was opened but a callback that it's closed has yet to be received
    [FieldOffset(0x434)] public bool VirtualKeyboardOpened;
    
    // only populated by GamepadTextInputDismissed
    [FieldOffset(0x438)] public Utf8String VirtualKeyboardEnteredText;

    [FieldOffset(0x4A0)] public AuthSessionTicketResponseCallback AuthSessionTicketResponseCallback;
    [FieldOffset(0x4B0)] public FloatingGamepadTextInputDismissedCallback FloatingGamepadTextInputDismissedCallback;
    [FieldOffset(0x4C0)] public GamepadTextInputDismissedCallback GamepadTextInputDismissedCallback;
    
    [MemberFunction("E8 ?? ?? ?? ?? 48 8B D8 48 8B CB 48 89 9F")]
    public partial void Ctor();

    [MemberFunction("48 89 5C 24 ?? 57 48 83 EC 20 48 8B D9 FF 15 ?? ?? ?? ?? 48 8D 8B")]
    public partial void Dtor();

    [MemberFunction("48 83 EC 28 48 8D 0D ?? ?? ?? ?? FF 15 ?? ?? ?? ?? 48 8B 08")]
    public partial int GetSteamServerTime();

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 45 48 8D 15")]
    public partial bool IsRunningOnSteamDeck();

    [MemberFunction("48 89 5C 24 ?? 48 89 74 24 ?? 57 48 83 EC 30 48 8B F1 8B FA 48 81 C1")]
    public partial bool ShowGamepadTextInput(int maxChars);

    [MemberFunction("48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 57 48 83 EC 30 48 8B E9 41 8B D9 48 8D 0D ?? ?? ?? ?? 41 8B F8")]
    public partial bool ShowFloatingGamepadTextInput(int fieldXPosition, int fieldYPosition, int textFieldWidth, int textFieldHeight);
}
