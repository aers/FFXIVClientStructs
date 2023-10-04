namespace FFXIVClientStructs.FFXIV.Client.Game;

// ctor "48 89 5C 24 ?? 57 48 83 EC 20 48 8B D9 C6 01 00 48 83 C1 04"
// note: data is cleared when switching zones
[StructLayout(LayoutKind.Explicit, Size = 0x1478)]
public unsafe partial struct MirageManager {
    [StaticAddress("48 8B 1D ?? ?? ?? ?? 48 85 DB 74 48", 3, isPointer: true)]
    public static partial MirageManager* Instance();

    [FieldOffset(0)] public bool IsApplyingGlamourPlate;

    [FieldOffset(0x4)] public fixed uint PrismBoxItemIds[800];
    [FieldOffset(0xC84)] public fixed byte PrismBoxStainIds[800];
    [FieldOffset(0xFA4)] public bool PrismBoxRequested;
    [FieldOffset(0xFA5)] public bool PrismBoxLoaded;

    [FixedSizeArray<GlamourPlate>(20)]
    [FieldOffset(0xFA8)] public fixed byte GlamourPlates[0x3C * 20];
    [FieldOffset(0x1458)] public bool GlamourPlatesRequested;
    [FieldOffset(0x1459)] public bool GlamourPlatesLoaded;

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

    [StructLayout(LayoutKind.Explicit, Size = 0x3C)]
    public struct GlamourPlate {
        [FieldOffset(0x00)] public fixed uint ItemIds[12];
        [FieldOffset(0x30)] public fixed byte StainIds[12];
    }
}
