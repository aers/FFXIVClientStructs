using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.SteamApi.Callbacks;

namespace FFXIVClientStructs.FFXIV.Component.SteamApi;

/// <summary>
/// This structure represents the game's internal bridge between itself and the Steam API. It contains
/// information retrieved from the Steam API, as well as some wrapper methods around certain Steam API calls.
/// Because this structure is not a direct representation of the Steam API but instead the game's view of
/// the API, not all names will match Steam-provided names perfectly.
/// </summary>
/// <remarks>
/// <em><b>This struct does not have stability guarantees.</b></em> The Steam API appears to be under active
/// construction by Square Enix, and certain things will shift either as we learn more about how the API works
/// or SE makes their own changes. If you're using this struct, you are signing up for breakage.
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

    /// <summary>
    /// Ask the Steam API for the current time according to Steam's servers.
    /// See <a href="https://partner.steamgames.com/doc/api/ISteamUtils#GetServerRealTime">the Steam API docs</a> for more information.
    /// </summary>
    /// <returns>Returns an unsigned integer containing the Unix epoch according to Steam.</returns>
    [MemberFunction("48 83 EC 28 48 8D 0D ?? ?? ?? ?? FF 15 ?? ?? ?? ?? 48 8B 08")]
    public partial uint GetSteamServerTime();

    /// <summary>
    /// Ask the Steam API if Steam is currently running on a Steam Deck.
    /// See <a href="https://partner.steamgames.com/doc/api/ISteamUtils#IsSteamRunningOnSteamDeck">the Steam API docs</a> for more information.
    /// </summary>
    /// <returns>Returns <c>true</c> if on a Steam Deck, <c>false</c> otherwise.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 45 48 8D 15")]
    public partial bool IsRunningOnSteamDeck();

    /// <summary>
    /// Request that Steam show a virtual keyboard over the game. The resulting string will be stored in <see cref="VirtualKeyboardEnteredText"/>.
    /// This method requires Steam to be in Big Picture Mode, and ideally for the Steam Overlay to be enabled.
    /// See <a href="https://partner.steamgames.com/doc/api/ISteamUtils#ShowGamepadTextInput">the Steam API docs</a> for more information.
    /// </summary>
    /// <param name="maxChars">The maximum number of characters to accept in this field.</param>
    /// <returns>Returns <c>true</c> if the virtual keyboard was successfully opened, <c>false</c> otherwise.</returns>
    [MemberFunction("48 89 5C 24 ?? 48 89 74 24 ?? 57 48 83 EC 30 48 8B F1 8B FA 48 81 C1")]
    public partial bool ShowGamepadTextInput(int maxChars);

    /// <summary>
    /// Request that Steam show a floating virtual keyboard over the game, attempting to not obscure the rectangle described in this method's arguments.
    /// Keys pressed via this method will be sent directly to the game process.
    /// This method requires Steam be in Big Picture Mode <em>and</em> the Steam Overlay to be enabled for the game.
    /// See <a href="https://partner.steamgames.com/doc/api/ISteamUtils#ShowFloatingGamepadTextInput">the Steam API docs</a> for more information.
    /// </summary>
    /// <param name="fieldXPosition">The X coordinate of the top left of the focused text field, relative to the center of the game window.</param>
    /// <param name="fieldYPosition">The Y coordinate of the top left of the focused text field, relative to the center of the game window.</param>
    /// <param name="textFieldWidth">The width of the focused text field.</param>
    /// <param name="textFieldHeight">The height of the focused text field.</param>
    /// <returns>Returns <c>true</c> if the virtual keyboard was successfully opened, <c>false</c> otherwise.</returns>
    [MemberFunction("48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 57 48 83 EC 30 48 8B E9 41 8B D9 48 8D 0D ?? ?? ?? ?? 41 8B F8")]
    public partial bool ShowFloatingGamepadTextInput(int fieldXPosition, int fieldYPosition, int textFieldWidth, int textFieldHeight);

    /// <summary>
    /// Method called by <see cref="GamepadTextInputDismissedCallback"/> when the gamepad text input has returned.
    /// Stores results in <see cref="VirtualKeyboardEnteredText"/>, and sets <see cref="VirtualKeyboardOpened"/> to false.
    /// </summary>
    /// <param name="callbackEvent">The callback event that triggered this dump</param>
    [MemberFunction("40 53 48 83 EC 20 80 3A 00")]
    public partial void DumpEnteredGamepadText(SteamTypes.GamepadTextInputDismissedData* callbackEvent);
}
