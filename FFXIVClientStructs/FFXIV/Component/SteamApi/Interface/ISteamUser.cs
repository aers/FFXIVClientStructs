namespace FFXIVClientStructs.FFXIV.Component.SteamApi.Interface;

/// <summary>
/// A concrete type of a <see cref="SteamInterfaceContext"/> for accessing the pointer to the
/// <a href="https://partner.steamgames.com/doc/api/ISteamUser"><c>ISteamUser</c></a> instance used by the game.
/// This struct does not provide or define any API surface related to this interface.
/// </summary>
[GenerateInterop]
[Inherits<SteamInterfaceContext>]
[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public unsafe partial struct ISteamUser {
    /// <summary>
    /// Gets the instance of the context wrapper used for managing the <c>ISteamUser</c> API.
    /// </summary>
    [StaticAddress("48 8D 0D ?? ?? ?? ?? FF 15 ?? ?? ?? ?? 48 8D 54 24 ?? 48 8B 08", 3)]
    public static partial ISteamUser* Instance();
}
