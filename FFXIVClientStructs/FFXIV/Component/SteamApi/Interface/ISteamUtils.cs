namespace FFXIVClientStructs.FFXIV.Component.SteamApi.Interface;

/// <summary>
/// A concrete type of a <see cref="SteamInterfaceContext"/> for accessing the pointer to the
/// <a href="https://partner.steamgames.com/doc/api/ISteamUser"><c>ISteamUtils</c></a> instance used by the game.
/// This struct does not provide or define any API surface related to this interface.
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = SteamTypes.SteamInterfaceContext.Size)]
public unsafe partial struct ISteamUtils {
    /// <summary>
    /// Gets the instance of the context wrapper used for managing the <c>ISteamUtils</c> API.
    /// </summary>
    [StaticAddress("48 8D 0D ?? ?? ?? ?? FF 15 ?? ?? ?? ?? 48 8B 08 48 8B 01 48 83 C4 28 48 FF A0 10 01 00 00", 3)]
    public static partial ISteamUtils* Instance();

    /// <inheritdoc cref="SteamTypes.SteamInterfaceContext.GetInterface"/>
    public static nint GetInterface() => Instance()->SteamInterfaceContext.GetInterface();

    [FieldOffset(0x0)] public SteamTypes.SteamInterfaceContext SteamInterfaceContext;
}
