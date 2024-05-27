namespace FFXIVClientStructs.FFXIV.Component.SteamApi.Interface;

/// <summary>
/// A concrete type of a <see cref="SteamInterfaceContext"/> for accessing the pointer to the
/// <a href="https://partner.steamgames.com/doc/api/ISteamApps"><c>ISteamApps</c></a> instance used by the game.
/// This struct does not provide or define any API surface related to this interface.
/// </summary>
[GenerateInterop, Inherits<SteamInterfaceContext>]
[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public unsafe partial struct ISteamApps {
    /// <summary>
    /// Gets the instance of the context wrapper used for managing the <c>ISteamApps</c> API.
    /// </summary>
    [StaticAddress("48 8D 0D ?? ?? ?? ?? FF 15 ?? ?? ?? ?? C7 44 24", 3)]
    public static partial ISteamApps* Instance();
}
