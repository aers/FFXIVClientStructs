namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

public partial struct RaptureHotbarModule {
    public enum HotbarSlotType : byte {
        Empty = 0,
        Action = 1,
        Item = 2,
        /// <remarks>
        /// Special type for DragDrop situations. The id contains the InventoryType and slot index.<br/>
        /// When setting this to a HotbarSlot, the correct id is resolved and the type is changed to <see cref="Item" />.
        /// </remarks>
        InventoryItem = 3,
        EventItem = 4,
        /// <remarks>
        /// Special type for DragDrop situations. The id is the slot index in the KeyItems inventory container.<br/>
        /// When setting this to a HotbarSlot, the correct id is resolved and the type is changed to <see cref="EventItem" />.
        /// </remarks>
        KeyItem = 5,
        Emote = 6,
        Macro = 7,
        Marker = 8,
        CraftAction = 9,
        GeneralAction = 10,
        BuddyAction = 11,
        MainCommand = 12,
        Companion = 13,
        /// <remarks>
        /// Special type for DragDrop situations. The id is the slot index in the Crystals inventory container.<br/>
        /// When setting this to a HotbarSlot, the correct id is resolved and the type is changed to <see cref="Item" />.
        /// </remarks>
        Crystal = 14,
        GearSet = 15,
        PetAction = 16,
        Mount = 17,
        FieldMarker = 18,
        Unknown19 = 19,
        Recipe = 20,
        ChocoboRaceAbility = 21,
        ChocoboRaceItem = 22,
        /// <remarks> Seems to be a legacy type, possibly PvP related based on associated icon 000785 </remarks>
        Unknown23 = 23,
        ExtraCommand = 24,
        PvPQuickChat = 25,
        PvPCombo = 26,
        BgcArmyAction = 27,
        /// <remarks> Seems to be a legacy type, possibly performance instrument related based on associated icon 000782 </remarks>
        Unknown28 = 28,
        PerformanceInstrument = 29,
        McGuffin = 30,
        Ornament = 31,
        LostFindsItem = 32, // aka MYCTemporaryItem
        Glasses = 33,
        PhantomAction = 34,
        QuickPanel = 35,
    }
}
