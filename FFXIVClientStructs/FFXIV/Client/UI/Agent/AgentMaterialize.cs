using FFXIVClientStructs.FFXIV.Client.Game;
using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentMaterialize
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.Materialize)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0xE8)]
public unsafe partial struct AgentMaterialize {
    [FieldOffset(0x2C)] public int UpdateState;

    [FieldOffset(0x38)] public InventoryItem* SelectedItem;
    [FieldOffset(0x40)] public uint AddonId0;
    [FieldOffset(0x44)] public uint AddonId1;
    [FieldOffset(0x48)] public int Category;
    [FieldOffset(0x4C)] public int ItemCount;
    [FieldOffset(0x50)] public MaterializeEntry** ItemArraySorted;
    [FieldOffset(0x58)] public MaterializeEntry* ItemArray;
    [FieldOffset(0x60)] public Utf8String ConfirmationText;
    //[FieldOffset(0xC8)] public StdVector<Utf8String> unkC8;

    public Span<Pointer<MaterializeEntry>> ItemsSorted => new(ItemArraySorted, 140);
    public Span<MaterializeEntry> Items => new(ItemArray, 140);

    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public struct MaterializeEntry {
        [FieldOffset(0x00)] public InventoryItem* Item;
        [FieldOffset(0x0C)] public short ItemLevel;
        [FieldOffset(0x0E)] public short Spiritbond;
        [FieldOffset(0x12)] public short Index;
    }
}
