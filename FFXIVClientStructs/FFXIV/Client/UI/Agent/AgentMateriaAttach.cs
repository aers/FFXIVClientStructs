using FFXIVClientStructs.FFXIV.Client.Game;
using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentMateriaAttach
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.MateriaAttach)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x148)]
public unsafe partial struct AgentMateriaAttach {
    [FieldOffset(0x28)] public int SheetLoadStatus;
    [FieldOffset(0x2C)] public uint MateriaParamSheetId;

    [FieldOffset(0x38)] internal InventoryItem UnkItem0;
    [FieldOffset(0x80)] internal InventoryItem UnkItem1;

    [FieldOffset(0xD0)] public MateriaAttachData* Data;

    [FieldOffset(0xDC)] public int UpdateState;
    [FieldOffset(0xE0)] public uint AddonId0;
    [FieldOffset(0xE4)] public uint AddonId1;
    [FieldOffset(0xE8)] public uint AddonId2;
    [FieldOffset(0xEC)] public FilterCategory Category;
    [FieldOffset(0xF0)] public short ItemCount;
    [FieldOffset(0xF2)] public short MateriaCount;
    [FieldOffset(0xF4)] public short SelectedItemIndex;
    [FieldOffset(0xF6)] public short SelectedMateriaIndex;
    [FieldOffset(0xF8)] public short DisplayItemIndex;
    [FieldOffset(0xFA)] public short DisplayMateriaIndex;

    // [FieldOffset(0x118)] public MateriaAttachCallback* CallbackEventHandler;

    public enum FilterCategory {
        None = -1,
        Inventory = 0,
        ArmouryWeapon = 1,
        ArmouryHeadBodyHands = 2,
        ArmouryLegsFeet = 3,
        ArmouryNeckEars = 4,
        ArmouryWristRing = 5,
        Equipped = 6
    }

    [StructLayout(LayoutKind.Explicit, Size = 0xB8)]
    public struct MateriaAttachData {
        // [FieldOffset(0x00)] public StdVector<Utf8String> unk0;
        // [FieldOffset(0x18)] public StdVector<Utf8String> unk18;
        [FieldOffset(0x30)] public Utf8String ConfirmationText;
        [FieldOffset(0x98)] public MateriaAttachEntry** ItemArraySorted;
        [FieldOffset(0xA0)] public MateriaAttachEntry** MateriaArraySorted;
        [FieldOffset(0xA8)] public MateriaAttachEntry* ItemArray;
        [FieldOffset(0xB0)] public MateriaAttachEntry* MateriaArray;

        public Span<Pointer<MateriaAttachEntry>> ItemsSorted => new(ItemArraySorted, 140);
        public Span<Pointer<MateriaAttachEntry>> MateriaSorted => new(MateriaArraySorted, 140);
        public Span<MateriaAttachEntry> Items => new(ItemArray, 140);
        public Span<MateriaAttachEntry> Materia => new(ItemArray, 140);
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public struct MateriaAttachEntry {
        [FieldOffset(0x00)] public InventoryItem* Item;
        // [FieldOffset(0x08)] public uint Item_Column_0x8C_Unknown4;
        [FieldOffset(0x0C)] public short Index;
        [FieldOffset(0x0E)] public short ItemLevel;
    }
}
