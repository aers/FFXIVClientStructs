namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

// Client::Game::UI::Loot
//   Component::GUI::AtkModuleInterface::AtkEventInterface
// ctor "48 89 5C 24 ?? 48 89 74 24 ?? 57 48 83 EC 20 48 8B D9 C6 41 08 00"
[StructLayout(LayoutKind.Explicit, Size = 0x6A0)]
public unsafe partial struct Loot {
    [StaticAddress("48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 89 44 24 60", 3)]
    public static partial Loot* Instance();

    [FixedSizeArray<LootItem>(16)]
    [FieldOffset(0x10)] public fixed byte ItemArray[16 * 0x40]; // 16 * LootItem

    [FieldOffset(0x410)] public int SelectedIndex;
    [FieldOffset(0x418)] public uint UnkObjectId;
    [FieldOffset(0x678)] public uint UnkObjectId2;
}

[StructLayout(LayoutKind.Explicit, Size = 0x40)]
public unsafe struct LootItem {
    [FieldOffset(0x00)] public uint ChestObjectId;
    [FieldOffset(0x04)] public uint ChestItemIndex; // This loot item's index in the chest it came from
    [FieldOffset(0x08)] public uint ItemId;
    [FieldOffset(0x0C)] public ushort ItemCount;
    [FieldOffset(0x20)] public RollState RollState;
    [FieldOffset(0x24)] public RollResult RollResult;
    [FieldOffset(0x28)] public uint RollValue;
    [FieldOffset(0x2C)] public float Time;
    [FieldOffset(0x30)] public float MaxTime;
    [FieldOffset(0x38)] public LootMode LootMode;
}

public enum RollState {
    UpToNeed = 0, //Can roll up to Need
    UpToGreed = 1,//Can roll up to Gree
    UpToPass = 2, //Can only pass
    Rolled = 17,
    Unavailable = 21, //Lootmaster undecided?
    Unknown = 28, // Default value
}

public enum RollResult {
    UnAwarded = 0,
    Needed = 1,
    Greeded = 2,
    Passed = 5,
    Awarded = 6,
    Unknown = 7, // Default Value
}

public enum LootMode {
    Normal = 0,
    GreedOnly = 1,
    Unavailable = 2,
    LootMasterGreedOnly = 3,
    Unknown = 4, // Default Value
}
