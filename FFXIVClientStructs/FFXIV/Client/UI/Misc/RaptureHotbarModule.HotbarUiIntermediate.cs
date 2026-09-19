namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

public partial struct RaptureHotbarModule {
    /// <summary>
    /// An intermediate struct used to translate from a <see cref="HotbarSlot"/> to the UI String/NumberArrays.
    /// </summary>
    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x43)]
    public unsafe partial struct HotbarUIIntermediate {
        [FieldOffset(0x00)] public CStringPointer PopUpHelpText; // ref to Client::UI::Misc::RaptureHotbarModule::HotbarSlot.PopUpHelp.StringPtr
        [FieldOffset(0x08)] public CStringPointer CostText; // ref to Client::UI::Misc::RaptureHotbarModule::HotbarSlot.CostText
        [FieldOffset(0x10), Obsolete($"Use {nameof(Type)}")] public uint IntermediateActionType; // to NumberArray idx slotBase + 0
        [FieldOffset(0x10)] public SlotType Type; // to NumberArray idx slotBase + 0
        [FieldOffset(0x14)] public uint ActionId; // to NumberArray idx slotBase + 3
        [FieldOffset(0x18)] public uint IconId; // to NumberArray idx slotBase + 4
        [FieldOffset(0x1C)] public uint CooldownMode; // to NumberArray idx slotBase + 7
        [FieldOffset(0x20)] public uint CooldownSeconds;
        [FieldOffset(0x24)] public uint CooldownPercent; // to NumberArray idx slotBase + 8
        [FieldOffset(0x28)] public uint LastCooldownPercent;
        [FieldOffset(0x2C)] public uint ChargePercent; // to NumberArray idx slotBase + 9
        [FieldOffset(0x30)] public uint LastChargePercent;
        [FieldOffset(0x34)] public uint CurrentCharges; // to NumberArray idx slotBase + 13
        [FieldOffset(0x38)] public uint CostValue; // to NumberArray idx slotBase + 10
        [FieldOffset(0x3C)] public byte CostType; // to NumberArray idx slotBase + 1
        [FieldOffset(0x3D)] public byte CostDisplayMode; // to NumberArray idx slotBase + 2
        [FieldOffset(0x3E)] public bool ActionAvailable1; // to NumberArray idx slotBase + 5
        [FieldOffset(0x3F)] public bool ActionAvailable2; // to NumberArray idx slotBase + 6
        [FieldOffset(0x40)] public bool ActionTargetSatisfied; // to NumberArray idx slotBase + 16
        [FieldOffset(0x41)] public bool DrawAnts; // to NumberArray idx slotBase + 14
        [FieldOffset(0x42)] public bool IsTransformationActionUsable; // to NumberArray idx slotBase + 15

        [MemberFunction("E8 ?? ?? ?? ?? 48 8B 45 ?? 4C 8D 44 24")]
        public partial HotbarUIIntermediate* Ctor();

        // These values tend to shift up when new forays or jobs are added.
        public enum SlotType {
            None = 0,

            Macro = 47,
            Action = 48,
            Emote = 49,
            Item = 50,
            InventoryItem = 51,
            EventItem = 52,
            KeyItem = 53,
            Crystal = 54,
            Marker = 55,
            CraftAction = 56,
            GeneralAction = 57,
            BuddyAction = 58,
            MainCommand = 59,
            Companion = 60,
            GearSet = 61,
            PetAction = 62,
            Mount = 63,
            FieldMarker = 64,
            Recipe = 65,
            ChocoboRaceAbility = 66,
            ChocoboRaceItem = 67,
            Unknown23 = 68,
            ExtraCommand = 69,
            PvPQuickChat = 70,
            PvPCombo = 71,
            BgcArmyAction = 72,
            Unknown28 = 73,
            PerformanceInstrument = 74,
            McGuffin = 75,
            Ornament = 76,
            LostFindsItem = 77,
            Glasses = 78,
            QuickPanel = 79,
            Unknown36 = 80, // XBM related (AgentXBMContentsMainHUD), maybe BeastMasterAction
        }
    }
}
