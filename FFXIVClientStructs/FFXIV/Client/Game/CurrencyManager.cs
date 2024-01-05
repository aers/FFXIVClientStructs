namespace FFXIVClientStructs.FFXIV.Client.Game;

[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public unsafe partial struct CurrencyManager {
    [StaticAddress("48 8B 1D ?? ?? ?? ?? 48 85 DB 74 15 48 8B CB E8 ?? ?? ?? ?? BA ?? ?? ?? ?? 48 8B CB E8 ?? ?? ?? ?? 33 D2", 3, isPointer: true)]
    public static partial CurrencyManager* Instance();

    /// <remarks>
    /// This bucket is known to contain the following items:<br/>
    /// <code>
    /// |-----------|--------|-------------------------|<br/>
    /// | SpecialId | ItemId | Item Name               |<br/>
    /// |-----------|--------|-------------------------|<br/>
    /// | 1         | 17833  | Yellow Crafters' Scrip  |<br/>
    /// | 2         | 25199  | White Crafters' Scrip   |<br/>
    /// | 3         | 17834  | Yellow Gatherers' Scrip |<br/>
    /// | 4         | 25200  | White Gatherers' Scrip  |<br/>
    /// | 5         | 10307  | Centurio Seal           |<br/>
    /// | 6         | 33913  | Purple Crafters' Scrip  |<br/>
    /// | 7         | 33914  | Purple Gatherers' Scrip |<br/>
    /// |-----------|--------|-------------------------|
    /// </code>
    /// </remarks>
    [FieldOffset(0x0)] public StdMap<uint, SpecialCurrencyItem> SpecialItemBucket;

    /// <remarks>
    /// This bucket is known to contain the following items:<br/>
    /// <code>
    /// |--------|-------------------------|<br/>
    /// | ItemId | Item Name               |<br/>
    /// |--------|-------------------------|<br/>
    /// | 30341  | Faux Leaf               |<br/>
    /// | 38534  | Sil'dihn Silver         |<br/>
    /// | 39885  | Shishu Coin             |<br/>
    /// | 21072  | Venture                 |<br/>
    /// | 21073  | Ixali Oaknot            |<br/>
    /// | 21074  | Vanu Whitebone          |<br/>
    /// | 21075  | Sylphic Goldleaf        |<br/>
    /// | 21076  | Steel Amalj'ok          |<br/>
    /// | 21077  | Rainbowtide Psashp      |<br/>
    /// | 21078  | Titan Cobaltpiece       |<br/>
    /// | 21079  | Black Copper Gil        |<br/>
    /// | 21080  | Carved Kupo Nut         |<br/>
    /// | 21081  | Kojin Sango             |<br/>
    /// | 28186  | Fae Fancy               |<br/>
    /// | 28187  | Qitari Compliment       |<br/>
    /// | 28188  | Hammered Frogment       |<br/>
    /// | 41629  | MGF                     |<br/>
    /// | 37854  | Omicron Omnitoken       |<br/>
    /// | 28063  | Skybuilders' Scrip      |<br/>
    /// | 26533  | Sack of Nuts            |<br/>
    /// | 38952  | Loporrit Carat          |<br/>
    /// | 21935  | Ananta Dreamstaff       |<br/>
    /// | 36656  | Trophy Crystal          |<br/>
    /// | 36657  | Arkasodara Pana         |<br/>
    /// | 21172  | Achievement Certificate |<br/>
    /// | 21173  |                         |<br/>
    /// | 26807  | Bicolor Gemstone        |<br/>
    /// | 41079  | Aloalo Coin             |<br/>
    /// | 22525  | Namazu Koban            |<br/>
    /// |--------|-------------------------|
    /// </code>
    /// </remarks>
    [FieldOffset(0x10)] public StdMap<uint, CurrencyItem> ItemBucket;

    /// <remarks>
    /// This bucket is known to contain the following items:<br/>
    /// <code>
    /// |--------|---------------------------|<br/>
    /// | ItemId | Item Name                 |<br/>
    /// |--------|---------------------------|<br/>
    /// | 31135  | Bozjan Cluster            |<br/>
    /// | 33138  |                           |<br/>
    /// | 37549  | Seafarer's Cowrie         |<br/>
    /// | 37550  | Islander's Cowrie         |<br/>
    /// | 37551  | Island Palm Leaf          |<br/>
    /// | 37552  | Island Apple              |<br/>
    /// | 37553  | Island Branch             |<br/>
    /// | 37554  | Island Stone              |<br/>
    /// | 37555  | Island Clam               |<br/>
    /// | 37556  | Island Laver              |<br/>
    /// | 37557  | Island Coral              |<br/>
    /// | 37558  | Islewort                  |<br/>
    /// | 37559  | Island Sand               |<br/>
    /// | 37560  | Island Log                |<br/>
    /// | 37561  | Island Palm Log           |<br/>
    /// | 37562  | Island Vine               |<br/>
    /// | 37563  | Island Sap                |<br/>
    /// | 37564  | Island Copper Ore         |<br/>
    /// | 37565  | Island Limestone          |<br/>
    /// | 37566  | Island Rock Salt          |<br/>
    /// | 37567  | Island Sugarcane          |<br/>
    /// | 37568  | Island Cotton Boll        |<br/>
    /// | 37569  | Island Hemp               |<br/>
    /// | 37570  | Island Clay               |<br/>
    /// | 37571  | Island Tinsand            |<br/>
    /// | 37572  | Island Iron Ore           |<br/>
    /// | 37573  | Island Quartz             |<br/>
    /// | 37574  | Island Leucogranite       |<br/>
    /// | 37575  | Islefish                  |<br/>
    /// | 37576  | Island Squid              |<br/>
    /// | 37577  | Island Jellyfish          |<br/>
    /// | 37578  | Island Alyssum            |<br/>
    /// | 37579  | Raw Island Garnet         |<br/>
    /// | 37580  | Island Spruce Log         |<br/>
    /// | 37581  | Island Hammerhead         |<br/>
    /// | 37582  | Island Silver Ore         |<br/>
    /// | 37583  | Island Popoto Set         |<br/>
    /// | 37584  | Island Cabbage Seeds      |<br/>
    /// | 37585  | Isleberry Seeds           |<br/>
    /// | 37586  | Island Pumpkin Seeds      |<br/>
    /// | 37587  | Island Onion Set          |<br/>
    /// | 37588  | Island Tomato Seeds       |<br/>
    /// | 37589  | Island Wheat Seeds        |<br/>
    /// | 37590  | Island Corn Seeds         |<br/>
    /// | 37591  | Island Parsnip Seeds      |<br/>
    /// | 37592  | Island Radish Seeds       |<br/>
    /// | 37593  | Island Popoto             |<br/>
    /// | 37594  | Island Cabbage            |<br/>
    /// | 37595  | Isleberry                 |<br/>
    /// | 37596  | Island Pumpkin            |<br/>
    /// | 37597  | Island Onion              |<br/>
    /// | 37598  | Island Tomato             |<br/>
    /// | 37599  | Island Wheat              |<br/>
    /// | 37600  | Island Corn               |<br/>
    /// | 37601  | Island Parsnip            |<br/>
    /// | 37602  | Island Radish             |<br/>
    /// | 37603  | Sanctuary Fleece          |<br/>
    /// | 37604  | Sanctuary Claw            |<br/>
    /// | 37605  | Sanctuary Fur             |<br/>
    /// | 37606  | Sanctuary Feather         |<br/>
    /// | 37607  | Sanctuary Egg             |<br/>
    /// | 37608  | Sanctuary Carapace        |<br/>
    /// | 37609  | Sanctuary Fang            |<br/>
    /// | 37610  | Sanctuary Horn            |<br/>
    /// | 37611  | Sanctuary Milk            |<br/>
    /// | 37612  | Island Sweetfeed          |<br/>
    /// | 37613  | Island Greenfeed          |<br/>
    /// | 37614  | Premium Island Greenfeed  |<br/>
    /// | 37615  | Makeshift Net             |<br/>
    /// | 37616  | Makeshift Restraint       |<br/>
    /// | 37617  | Makeshift Soporific       |<br/>
    /// | 39224  | Island Resin              |<br/>
    /// | 39225  | Island Coconut            |<br/>
    /// | 39226  | Island Beehive Chip       |<br/>
    /// | 39227  | Island Wood Opal          |<br/>
    /// | 39228  | Multicolored Isleblooms   |<br/>
    /// | 39229  | Island Paprika Seeds      |<br/>
    /// | 39230  | Island Leek Set           |<br/>
    /// | 39231  | Island Paprika            |<br/>
    /// | 39232  | Island Leek               |<br/>
    /// | 39887  | Island Coal               |<br/>
    /// | 39888  | Island Shale              |<br/>
    /// | 39889  | Island Glimshroom         |<br/>
    /// | 39890  | Island Marble             |<br/>
    /// | 39891  | Island Mythril Ore        |<br/>
    /// | 39892  | Island Effervescent Water |<br/>
    /// | 39893  | Island Spectrine          |<br/>
    /// | 39894  | Island Cave Shrimp        |<br/>
    /// | 39895  | Island Runner Bean Seeds  |<br/>
    /// | 39896  | Island Beet Seeds         |<br/>
    /// | 39897  | Island Eggplant Seeds     |<br/>
    /// | 39898  | Island Zucchini Seeds     |<br/>
    /// | 39899  | Island Runner Beans       |<br/>
    /// | 39900  | Island Beet               |<br/>
    /// | 39901  | Island Eggplant           |<br/>
    /// | 39902  | Island Zucchini           |<br/>
    /// | 41630  | Island Durium Sand        |<br/>
    /// | 41631  | Island Yellow Copper Ore  |<br/>
    /// | 41632  | Island Gold Ore           |<br/>
    /// | 41633  | Island Hawk's Eye Sand    |<br/>
    /// | 41634  | Island Crystal Formation  |<br/>
    /// | 41635  | Island Watermelon         |<br/>
    /// | 41636  | Island Sweet Popoto       |<br/>
    /// | 41637  | Island Broccoli           |<br/>
    /// | 41638  | Island Buffalo Beans      |<br/>
    /// | 41639  | Island Watermelon Seeds   |<br/>
    /// | 41640  | Island Sweet Popoto Set   |<br/>
    /// | 41641  | Island Broccoli Seeds     |<br/>
    /// | 41642  | Island Buffalo Bean Seeds |<br/>
    /// | 41643  | Flawless Net              |<br/>
    /// | 41644  | Flawless Restraints       |<br/>
    /// | 41645  | Flawless Soporifics       |<br/>
    /// | 41668  | Felicitous Token          |<br/>
    /// |--------|---------------------------|
    /// </code>
    /// </remarks>
    [FieldOffset(0x20)] public StdMap<uint, ContentCurrencyItem> ContentItemBucket;

    /// <remarks>
    /// Used for items in <see cref="SpecialItemBucket"/> only.
    /// </remarks>
    [MemberFunction("E8 ?? ?? ?? ?? 8B D8 EB 11")]
    public partial uint GetItemIdBySpecialId(byte specialId);

    [MemberFunction("E8 ?? ?? ?? ?? 3B C3 76 0A")]
    public partial uint GetItemCount(uint itemId);

    [MemberFunction("E8 ?? ?? ?? ?? 0F B7 CF 03 CB")]
    public partial uint GetItemMaxCount(uint itemId);

    /// <remarks>
    /// For limited items only.
    /// </remarks>
    [MemberFunction("E8 ?? ?? ?? ?? 39 06")]
    public partial uint GetItemCountRemaining(uint itemId); // returns maxCount - count

    /// <summary>
    /// Checks if the item is in any bucket.
    /// </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 41 8B CD")]
    public partial bool HasItem(uint itemId);

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 75 32 8B D7")]
    public partial bool IsItemLimited(uint itemId);

    /// <summary>
    /// Fills data for a currency item.
    /// </summary>
    /// <remarks>Only used in ProcessActorControlPacket.</remarks>
    /// <param name="specialId">
    /// If -1, <see cref="ContentItemBucket"/> is used.<br/>
    /// If 0, <see cref="ItemBucket"/> is used.<br/>
    /// Otherwise, <see cref="SpecialItemBucket"/> is used and this value is assigned to <see cref="SpecialCurrencyItem.SpecialId"/>.
    /// </param>
    /// <param name="itemId">The ID of the Item.</param>
    /// <param name="maxCount">The maximum amount of this currency a player can have.</param>
    /// <param name="count">The amount of this currency currently held by the player.</param>
    /// <param name="isUnlimited">Wether the currency has a limit or not.</param>
    [MemberFunction("48 89 5C 24 ?? 48 89 74 24 ?? 57 48 83 EC 40 41 8B D8")]
    public partial void SetItemData(sbyte specialId, uint itemId, uint maxCount, uint count, bool isUnlimited);

    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public struct SpecialCurrencyItem {
        [FieldOffset(0x0)] public byte SpecialId;
        [FieldOffset(0x4)] public uint MaxCount;
        [FieldOffset(0x8)] public uint Count;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public struct CurrencyItem {
        [FieldOffset(0x0)] public ushort MaxCount;
        [FieldOffset(0x2)] public ushort Count;
        [FieldOffset(0x4)] public bool IsUnlimited;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public struct ContentCurrencyItem {
        [FieldOffset(0x0)] public ushort MaxCount;
        [FieldOffset(0x4)] public ushort Count;
        [FieldOffset(0x8)] public bool IsUnlimited;
    }
}
