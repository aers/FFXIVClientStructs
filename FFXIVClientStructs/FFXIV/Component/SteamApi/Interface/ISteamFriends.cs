namespace FFXIVClientStructs.FFXIV.Component.SteamApi.Interface;

/// <summary>
/// A concrete type of a <see cref="SteamInterfaceContext"/> for accessing the pointer to the
/// <a href="https://partner.steamgames.com/doc/api/ISteamFriends"><c>ISteamFriends</c></a> instance used by the game.
/// This struct does not provide or define any API surface related to this interface.
/// </summary>
[GenerateInterop]
[Inherits<SteamInterfaceContext>]
[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public unsafe partial struct ISteamFriends {
    /// <summary>
    /// Gets the instance of the context wrapper used for managing the <c>ISteamFriends</c> API.
    /// </summary>
    [StaticAddress("48 8D 0D ?? ?? ?? ?? 48 8B 10 48 89 93", 3)]
    public static partial ISteamFriends* Instance();
}
