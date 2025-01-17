using FFXIVClientStructs.FFXIV.Client.Game.Character;

namespace FFXIVClientStructs.FFXIV.Client.Game;

// Client::System::Configuration::CharamakeAvatarSaveDataContainer
[StructLayout(LayoutKind.Explicit, Size = 0x9EB8)]
public partial struct CharamakeAvatarSaveDataContainer {
    [FieldOffset(0x0000)] public FixedContainer Release;       // FFXIV_CHARA_
    [FieldOffset(0x3218)] public FixedContainer Beta;          // FFXIV_CHARA_BETA
    [FieldOffset(0x6430)] public FixedContainer Benchmark;     // FFXIV_CHARA_BENCH
    [FieldOffset(0x9648)] public FreeTrialContainer FreeTrial; // FFXIV_CHARA_FT
    [FieldOffset(0x9E18)] public VariableContainer Variable;   // files in FINAL FANTASY XIV\user\00000000 ?!

    [GenerateInterop(isInherited: true)]
    [StructLayout(LayoutKind.Explicit, Size = 0x08)]
    public unsafe partial struct ContainerInterface {
        [VirtualFunction(1)]
        public partial bool IsSlotValid(byte slotIndex);

        [VirtualFunction(2)]
        public partial SavedAppearanceSlot* GetSlot(byte slotIndex);

        // [VirtualFunction(3)]
        // public partial SavedFreeTrialAppearanceSlot* GetFreeTrialSlot(byte slotIndex);

        [VirtualFunction(4)]
        public partial uint GetValidSlotCount();

        [VirtualFunction(5)]
        public partial uint UpdateValidSlotCount();

        [VirtualFunction(6)]
        public partial uint GetMaxSlotCount();
    }

    // Client::System::Configuration::CharamakeAvatarSaveDataContainer::FixedContainer
    //   Client::System::Configuration::CharamakeAvatarSaveDataContainer::ContainerInterface
    [GenerateInterop]
    [Inherits<ContainerInterface>]
    [StructLayout(LayoutKind.Explicit, Size = 0x3218)]
    public partial struct FixedContainer {
        [FieldOffset(0x08), FixedSizeArray] internal FixedSizeArray40<SavedAppearanceSlot> _slots;
    }

    // Client::System::Configuration::CharamakeAvatarSaveDataContainer::FreeTrialContainer
    //   Client::System::Configuration::CharamakeAvatarSaveDataContainer::ContainerInterface
    [GenerateInterop]
    [Inherits<ContainerInterface>]
    [StructLayout(LayoutKind.Explicit, Size = 0x7D0)]
    public partial struct FreeTrialContainer;

    // Client::System::Configuration::CharamakeAvatarSaveDataContainer::VariableContainer
    //   Client::System::Configuration::CharamakeAvatarSaveDataContainer::ContainerInterface
    [GenerateInterop]
    [Inherits<ContainerInterface>]
    [StructLayout(LayoutKind.Explicit, Size = 0x30)]
    public partial struct VariableContainer;

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x140)]
    public partial struct SavedAppearanceSlot {
        [FieldOffset(0x00)] public uint Magic; // Should be 0x2013_FF14
        [FieldOffset(0x04)] public uint Version;
        [FieldOffset(0x08)] public uint CustomizeDataHash;

        [FieldOffset(0x10)] public CustomizeData CustomizeData;

        [FieldOffset(0x2C)] public int Timestamp;
        [FieldOffset(0x30), FixedSizeArray(isString: true)] internal FixedSizeArray64<byte> _label;

        [FieldOffset(0x134)] public SavedAppearanceSlotStatus Status;

        [FieldOffset(0x13C)] public byte SlotIndex;
    }
}

public enum SavedAppearanceSlotStatus {
    Empty = 0,
    Valid = 1,
    InvalidVersion = 2, // when Version is > 8
    InvalidCustomizeData = 3, // when CustomizeDataHash doesn't match
}
