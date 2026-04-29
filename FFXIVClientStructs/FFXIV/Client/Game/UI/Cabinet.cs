namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

// Client::Game::UI::Cabinet
// Armoire
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public unsafe partial struct Cabinet {
    [FieldOffset(0x00)] public CabinetState State;
    // [FieldOffset(0x04), FixedSizeArray] internal FixedSizeArray132<byte> _unlockedItems; // TODO: 7.5 - this changed to a pointer, StdVector?

    /// <summary>
    /// Check if an item is stored in the player's armoire.
    /// </summary>
    /// <param name="cabinetId">The Cabinet RowId to check against.</param>
    /// <returns>Returns true if the armoire contains the specified item.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 75 0F 85 DB")]
    public partial bool IsItemInCabinet(uint cabinetId);

    [MemberFunction("E8 ?? ?? ?? ?? 45 33 E4 41 C6 46 ?? ?? 4D 89 66")]
    public partial bool StoreCabinetItem(uint cabinetId);

    /// <summary>
    /// Check if the armoire is reporting as "loaded" from the server.
    /// </summary>
    /// <remarks>
    /// The armoire will only load when requested (so, when a player goes to an inn room and chooses to add/remove an
    /// item or performs certain glamour operations). As such, before any check can take place, a developer must first
    /// validate that the armoire is loaded. Generally, this will be when State == CabinetState.Loaded
    /// </remarks>
    /// <returns>Returns true if the armoire has been retrieved.</returns>
    public bool IsCabinetLoaded()
        => this.State is CabinetState.Loaded;

    /// <summary> Represents the loaded state of Cabinet </summary>
    public enum CabinetState : int {
        Invalid = 0, // Cabinet is initialized at this state
        Requested = 1, // This state is set between the client request and receiving the data from the server
        Loaded = 2, // Set upon data being received
    }
}
