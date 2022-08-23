namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

/// <summary>
/// A struct representing the UIState Cabinet (otherwise known as the "Armoire" in-game) and the bitfield for stores
/// items.
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 0x48)]
public unsafe partial struct Cabinet {
    [FieldOffset(0x00)] public int CabinetLoaded; // This becomes 2 for some reason, unsure why or what it means.
    [FieldOffset(0x04)] public fixed byte UnlockedItems[0x41];

    /// <summary>
    /// Check if an item is stored in the player's armoire.
    /// </summary>
    /// <param name="cabinetItemId">The armoire item entry ID to check against. This is not an item ID but a specific ID
    /// from the Cabinet table.</param>
    /// <returns>Returns true if the armoire contains the specified item.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 16 8B CB")]
    public partial bool IsItemInCabinet(int cabinetItemId);

    /// <summary>
    /// Check if the armoire is reporting as "loaded" from the server.
    /// </summary>
    /// <remarks>
    /// The armoire will only load when requested (so, when a player goes to an inn room and chooses to add/remove an
    /// item or performs certain glamour operations). As such, before any check can take place, a developer must first
    /// validate that the armoire is loaded. Generally, this will be when CabinetLoaded == 1, but for some reason this
    /// can have a value of 2 as well.
    /// </remarks>
    /// <returns>Returns true if the armoire has been retrieved.</returns>
    public bool IsCabinetLoaded() {
        return this.CabinetLoaded > 0;
    }
}