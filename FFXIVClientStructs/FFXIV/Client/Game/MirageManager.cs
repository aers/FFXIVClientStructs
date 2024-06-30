namespace FFXIVClientStructs.FFXIV.Client.Game;

// Client::Game::MirageManager
// ctor "48 89 5C 24 ?? 57 48 83 EC 20 48 8B D9 C6 01 00 48 83 C1 04"
// Note: Data is cleared when switching zones
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x1888)]
public unsafe partial struct MirageManager {
    [StaticAddress("74 2C 48 8B 0D ?? ?? ?? ?? 48 85 C9", 5, isPointer: true)]
    public static partial MirageManager* Instance();

    [FieldOffset(0)] public bool IsApplyingGlamourPlate;

    [FieldOffset(0x4), FixedSizeArray] internal FixedSizeArray800<uint> _prismBoxItemIds;
    [FieldOffset(0xC84), FixedSizeArray] internal FixedSizeArray800<byte> _prismBoxStain0Ids;
    [FieldOffset(0xFA4), FixedSizeArray] internal FixedSizeArray800<byte> _prismBoxStain1Ids;
    [FieldOffset(0x12C4)] public bool PrismBoxRequested;
    [FieldOffset(0x12C5)] public bool PrismBoxLoaded;

    [FieldOffset(0x12C8), FixedSizeArray] internal FixedSizeArray20<GlamourPlate> _glamourPlates;
    [FieldOffset(0x1868)] public bool GlamourPlatesRequested;
    [FieldOffset(0x1869)] public bool GlamourPlatesLoaded;

    /// <summary>
    /// Restores an item from the Glamour Dresser and puts it back into the players inventory.
    /// </summary>
    /// <param name="itemIndex">The index of <see cref="PrismBoxItemIds"/> to restore.</param>
    /// <returns>
    /// Returns <c>true</c> if the command was sent to the server, or <c>false</c>
    /// if the player already possess a unique item or if inventory space is insufficient.
    /// </returns>
    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 0F 41 B0 01")]
    public partial bool RestorePrismBoxItem(uint itemIndex);

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x48)]
    public partial struct GlamourPlate {
        [FieldOffset(0x00), FixedSizeArray] internal FixedSizeArray12<uint> _itemIds;
        [FieldOffset(0x30), FixedSizeArray] internal FixedSizeArray12<byte> _stain0Ids;
        [FieldOffset(0x3C), FixedSizeArray] internal FixedSizeArray12<byte> _stain1Ids;
    }
}
