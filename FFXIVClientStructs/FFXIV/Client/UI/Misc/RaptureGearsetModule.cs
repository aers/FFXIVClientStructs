using System.Diagnostics.CodeAnalysis;
using FFXIVClientStructs.FFXIV.Client.System.String;
using UserFileEvent = FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager.UserFileEvent;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::RaptureGearsetModule
//   Client::UI::Misc::UserFileManager::UserFileEvent
// ctor "48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 48 89 7C 24 ?? 41 56 48 83 EC 20 45 33 F6 48 89 51 10 48 8D 05 ?? ?? ?? ?? 4C 89 71 08 49 8B D8"
[GenerateInterop]
[Inherits<UserFileEvent>]
[VirtualTable("48 8D 05 ?? ?? ?? ?? 4C 89 79 08 49 8B F8", 3)]
[StructLayout(LayoutKind.Explicit, Size = 0xB808)]
public unsafe partial struct RaptureGearsetModule {
    public static RaptureGearsetModule* Instance() => UIModule.Instance()->GetRaptureGearsetModule();

    [FieldOffset(0x48), FixedSizeArray] internal FixedSizeArray100<GearsetEntry> _entries;

    [FieldOffset(0xB5C8)] public int CurrentGearsetIndex;

    [FieldOffset(0xB79C), FixedSizeArray] internal FixedSizeArray100<byte> _enabledGearsetIndex2EntryIndex;
    [FieldOffset(0xB801)] public byte NumGearsets;

    /// <summary>
    /// Return a pointer to a <see cref="GearsetEntry"/> by index/ID.
    /// </summary>
    /// <param name="gearsetId">The index of the gearset to look up.</param>
    /// <returns>Returns a pointer to a GearsetEntry</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 48 8D 4F 02")]
    public partial GearsetEntry* GetGearset(int gearsetId);

    /// <summary>
    /// Find a <see cref="GearsetEntry"/> by name and return its ID.<br/>
    /// </summary>
    /// <remarks>
    /// The search is case-sensitive and returns the first gearset with a name beginning with the specified gearsetName.
    /// </remarks>
    /// <param name="gearsetName">The name of the gearset to look up.</param>
    /// <returns>Returns the index/ID of a GearsetEntry</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 8B D8 81 FB")]
    public partial int FindGearsetIdByName(Utf8String* gearsetName);

    /// <summary>
    /// Check if a gearset at a specific index is valid.
    /// </summary>
    /// <remarks>
    /// Will return <c>false</c> if the gearset index is higher than the player's max allowed gearset number.
    /// </remarks>
    /// <param name="gearsetId">The index of the gearset to look up.</param>
    /// <returns>Returns <c>true</c> if the gearset is valid, <c>false</c> otherwise.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 4D 8B EE 84 C0")]
    public partial bool IsValidGearset(int gearsetId);

    /// <summary>
    /// Attempt to equip a gearset, with certain safety checks in place.
    /// </summary>
    /// <param name="gearsetId">The gearset ID to attempt to equip.</param>
    /// <param name="glamourPlateId">The glamour plate to attempt to equip alongside this gearset. Passing 0 will use the
    /// linked gearset (if any).</param>
    /// <returns>Returns 0 if the equip succeeded, -1 otherwise.</returns>
    [MemberFunction("48 89 5C 24 ?? 48 89 74 24 ?? 57 48 83 EC 20 48 8B F9 41 0F B6 F0 48 8D 0D")]
    public partial int EquipGearset(int gearsetId, byte glamourPlateId = 0);

    /// <summary>
    /// Save the player's current inventory to a new gearset at the next possible ID.
    /// </summary>
    /// <returns>Returns the ID of the created gearset, or -1 if the creation attempt fails.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? EB 07 8B D5 E8 ?? ?? ?? ?? 8B E8")]
    public partial sbyte CreateGearset();

    /// <summary>
    /// Delete the gearset at the specified ID.
    /// </summary>
    /// <param name="gearsetId">The gearset ID to delete.</param>
    [MemberFunction("E8 ?? ?? ?? ?? 80 BF ?? ?? ?? ?? ?? 74 20 48 8B 17")]
    public partial void DeleteGearset(int gearsetId);

    /// <summary>
    /// Update the gearset at the specified ID with the currently equipped items.
    /// </summary>
    /// <param name="gearsetId">The gearset ID to delete.</param>
    [MemberFunction("48 89 6C 24 ?? 57 48 83 EC 20 48 8B F9 48 63 EA")]
    public partial int UpdateGearset(int gearsetId);

    /// <summary>
    /// Reassigns the ID of a gearset, effectively swapping the positions of two gearsets.
    /// </summary>
    /// <remarks>
    /// This method is used to change the order of gearsets, and is referred to as "Reassign Set Number" in the game.<br/>
    /// After calling this method, it is advisable to validate the returned gearset ID and, if the ID is valid, to
    /// call <see cref="RaptureHotbarModule.ReassignGearsetId"/> to update the hotbar slots.
    /// </remarks>
    /// <param name="gearsetId">The ID of the gearset to be switched.</param>
    /// <param name="newGearsetId">The ID to which the gearset should be reassigned.</param>
    /// <returns>
    /// Returns <c>-1</c> if either the original gearset ID or the new gearset ID is invalid, <c>-2</c> if the player
    /// is currently editing a portrait, otherwise it returns the ID of the original gearset that was moved to a new position.
    /// </returns>
    [MemberFunction("E8 ?? ?? ?? ?? 8B E8 83 F8 FE 0F 8E ?? ?? ?? ?? 80 BE ?? ?? ?? ?? ?? 74 20 48 8B 16")]
    public partial int ReassignGearsetId(int gearsetId, int newGearsetId);

    /// <summary>
    /// Link a glamour plate to a specific gearset.
    /// </summary>
    /// <param name="gearsetId">The gearset ID to link a glamour plate to </param>
    /// <param name="glamourPlateId">The glamour plate ID to link. 0 resets the linked glamour plate.</param>
    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 03 48 8B CB FF 50 20 41 C6 44 24")]
    public partial void LinkGlamourPlate(int gearsetId, byte glamourPlateId);

    /// <summary>
    /// Check if a specific gearset has a linked glamour plate.
    /// </summary>
    /// <param name="gearsetId">The ID of the gearset to check.</param>
    /// <returns>Returns <c>false</c> if a gearset is invalid or does not have a linked plate, <c>true</c> otherwise.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 75 0E 8B D3")]
    public partial bool HasLinkedGlamourPlate(int gearsetId);

    [MemberFunction("45 33 C0 83 FA 64")]
    public partial int GetClassJobIconForGearset(int gearsetId);

    /// <summary>
    /// Get the Banner index of a Gearset.
    /// </summary>
    /// <param name="gearsetId">The ID of the gearset.</param>
    /// <returns>The Banner index, or -1 if it was not linked.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 49 8B 4E 08 0F B6 D8")]
    public partial sbyte GetBannerIndex(byte gearsetId);

    /// <summary>
    /// Set the Banner index of a Gearset.
    /// </summary>
    /// <param name="gearsetId">The ID of the gearset.</param>
    /// <param name="bannerIndex">The Banner index, or -1 to unlink the Banner.</param>
    [MemberFunction("E8 ?? ?? ?? ?? EB 62 41 0F B6 D7")]
    public partial void SetBannerIndex(byte gearsetId, sbyte bannerIndex);

    /// <summary>
    /// Check if a specified gearset has a Banner linked to it.
    /// </summary>
    /// <param name="gearsetId">The ID of the gearset.</param>
    /// <returns>Returns <c>true</c> if the gearset has a Banner linked to it, <c>false</c> otherwise.</returns>
    /// <remarks>Equivalent to Flags.HasFlag(GearsetFlag.Exists) &amp;&amp; BannerIndex != 0.</remarks>
    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 4F 0F B6 D3")]
    public partial bool HasLinkedBanner(byte gearsetId);

    /// <summary>
    /// Resolves the index of a GearsetEntry array that only contains enabled gearsets to the index in the actual <see cref="Entries"/> array.
    /// </summary>
    /// <param name="enabledGearsetIndex">The position in the list.</param>
    /// <returns>The ID of the <see cref="GearsetEntry"/>.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 33 C9 83 F8 64")]
    public partial int ResolveIdFromEnabledIndex(byte enabledGearsetIndex);

    [Flags]
    public enum GearsetFlag : byte {
        None = 0,

        /// <summary>
        /// Is set when this gearset entry has been created.
        /// </summary>
        Exists = 0x01,

        Unknown02 = 0x02,

        /// <summary>
        /// Shows a red exclamation mark with message "The specified main arm was missing from your Armoury Chest."
        /// </summary>
        MainHandMissing = 0x04,

        /// <summary>
        /// Is set when "Display Headgear" is ticked.
        /// </summary>
        HeadgearVisible = 0x08,

        /// <summary>
        /// Is set when "Display Sheathed Arms" is ticked.
        /// </summary>
        WeaponsVisible = 0x10,

        /// <summary>
        /// Is set when "Manually adjust visor (select gear only)." is ticked.
        /// </summary>
        VisorEnabled = 0x20,

        Unknown40 = 0x40,
        Unknown80 = 0x80
    }

    [Flags]
    public enum GearsetItemFlag : byte {
        None = 0,

        /// <summary>
        /// Shows a yellow exclamation mark with message "One or more items were missing from your Armoury Chest."
        /// </summary>
        ItemMissing = 0x01,

        Unknown02 = 0x02,

        /// <summary>
        /// Shows a gray exclamation mark with message "One or more items were not the specified color."
        /// </summary>
        ColorDiffers = 0x04,

        /// <summary>
        /// Shows a gray exclamation mark with message "One or more items were not melded with the specified materia."
        /// </summary>
        MateriaDiffers = 0x08,

        /// <summary>
        /// Shows a gray exclamation mark with message "One or more items did not have the specified appearance."
        /// </summary>
        AppearanceDiffers = 0x10,

        Unknown20 = 0x20,
        Unknown40 = 0x40,
        Unknown80 = 0x80,
    }

    /// <summary>
    /// A helper enum for easier access of GearsetItems in the ItemsSpan.
    /// </summary>
    public enum GearsetItemIndex {
        MainHand = 0,
        OffHand,
        Head,
        Body,
        Hands,
        Belt,
        Legs,
        Feet,
        Ears,
        Neck,
        Wrists,
        RingRight,
        RingLeft, // aka RightLeft
        SoulStone,
    }

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = Size)]
    public partial struct GearsetItem {
        public const int Size = 0x1C;

        [FieldOffset(0x00)] public uint ItemId;
        [FieldOffset(0x04)] public uint GlamourId;
        [FieldOffset(0x08)] public byte Stain0Id;
        [FieldOffset(0x09)] public byte Stain1Id;
        [FieldOffset(0x0A), FixedSizeArray] internal FixedSizeArray5<ushort> _materia;
        [FieldOffset(0x14), FixedSizeArray] internal FixedSizeArray5<byte> _materiaGrades;
        [FieldOffset(0x19)] public GearsetItemFlag Flags;
    }

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x1C4)]
    public partial struct GearsetEntry {
        [FieldOffset(0x00)] public byte Id;    // This may actually be set number, which is not _quite_ ID.
        [FieldOffset(0x01), FixedSizeArray(isString: true)] internal FixedSizeArray48<byte> _name;
        [FieldOffset(0x31)] public byte ClassJob;
        [FieldOffset(0x32)] public byte GlamourSetLink;
        [FieldOffset(0x34)] public short ItemLevel;
        /// <remarks>This is the BannerIndex, but offset by 1. If it's 0, the gearset is not linked to a banner.</remarks>
        [FieldOffset(0x36)] public byte BannerIndex;
        [FieldOffset(0x37)] public GearsetFlag Flags;
        [FieldOffset(0x38), FixedSizeArray] internal FixedSizeArray14<GearsetItem> _items;
        [FieldOffset(0x1C0)] public ushort GlassesId;

        [UnscopedRef] public ref GearsetItem GetItem(GearsetItemIndex index) => ref Items[(int)index];

        /// <returns>Returns a pointer to the BannerModuleEntry* or null if the gearset is not linked to a banner.</returns>
        public BannerModuleEntry* GetBanner() {
            if (BannerIndex == 0)
                return null;

            var bannerModule = BannerModule.Instance();
            var bannerId = bannerModule->GetBannerIdByBannerIndex(BannerIndex - 1);
            if (bannerId == -1)
                return null;

            return bannerModule->GetBannerById(bannerId);
        }
    }
}
