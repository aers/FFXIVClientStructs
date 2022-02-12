using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonGathering
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[StructLayout(LayoutKind.Explicit, Size = 0x300)]
public unsafe struct AddonGathering
{
    [FieldOffset(0x0)] public AtkUnitBase AtkUnitBase;
    [FieldOffset(0x220)] public AtkResNode* UnkResNode220;
    [FieldOffset(0x228)] public AtkComponentCheckBox* GatheredItemComponentCheckBox1;
    [FieldOffset(0x230)] public AtkComponentCheckBox* GatheredItemComponentCheckBox2;
    [FieldOffset(0x238)] public AtkComponentCheckBox* GatheredItemComponentCheckBox3;
    [FieldOffset(0x240)] public AtkComponentCheckBox* GatheredItemComponentCheckBox4;
    [FieldOffset(0x248)] public AtkComponentCheckBox* GatheredItemComponentCheckBox5;
    [FieldOffset(0x250)] public AtkComponentCheckBox* GatheredItemComponentCheckBox6;
    [FieldOffset(0x258)] public AtkComponentCheckBox* GatheredItemComponentCheckBox7;
    [FieldOffset(0x260)] public AtkComponentCheckBox* GatheredItemComponentCheckBox8;
    [FieldOffset(0x268)] public AtkTextNode* InventoryQuantityTextNode;
    [FieldOffset(0x270)] public AtkResNode* UnkResNode270;
    [FieldOffset(0x278)] public AtkComponentCheckBox* QuickGatheringComponentCheckBox;
    [FieldOffset(0x280)] public AtkResNode* UnkResNode;
    [FieldOffset(0x288)] public ulong unk288;
    [FieldOffset(0x290)] public ulong unk290;
    [FieldOffset(0x298)] public ulong unk298;
    [FieldOffset(0x2A0)] public ulong unk2A0;
    [FieldOffset(0x2A8)] public ulong unk2A8;
    [FieldOffset(0x2B0)] public ulong unk2B0;
    [FieldOffset(0x2B8)] public ulong unk2B8;
    [FieldOffset(0x2C0)] public ulong unk2C0;
    [FieldOffset(0x2C8)] public uint GatheredItemId1;
    [FieldOffset(0x2CC)] public uint GatheredItemId2;
    [FieldOffset(0x2D0)] public uint GatheredItemId3;
    [FieldOffset(0x2D4)] public uint GatheredItemId4;
    [FieldOffset(0x2D8)] public uint GatheredItemId5;
    [FieldOffset(0x2DC)] public uint GatheredItemId6;
    [FieldOffset(0x2E0)] public uint GatheredItemId7;
    [FieldOffset(0x2E4)] public uint GatheredItemId8;
    [FieldOffset(0x2E8)] public ulong unk2E8;
    [FieldOffset(0x2F0)] public ulong unk2F0;
    [FieldOffset(0x2F8)] public int unk2F8;
    [FieldOffset(0x2FC)] public short unk2FC;
}