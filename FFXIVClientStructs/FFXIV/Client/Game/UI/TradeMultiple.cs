using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

// Client::Game::UI::TradeMultiple
//   Component::GUI::AtkModuleInterface::AtkEventInterface
// Materia Transmutation
[StructLayout(LayoutKind.Explicit, Size = 0x48)]
public unsafe struct TradeMultiple {
    [FieldOffset(0)] public AtkEventInterface AtkEventInterface;

    [FieldOffset(0x10)] public uint Unk10;
    [FieldOffset(0x14)] public uint Unk14;
    [FieldOffset(0x18)] public uint Unk18;
    [FieldOffset(0x1C)] public uint Unk1C;
    [FieldOffset(0x20)] public uint Unk20;
    [FieldOffset(0x24)] public ushort MateriaId1;
    [FieldOffset(0x26)] public ushort MateriaId2;
    [FieldOffset(0x28)] public ushort MateriaId3;
    [FieldOffset(0x2A)] public ushort MateriaId4;
    [FieldOffset(0x2C)] public ushort MateriaId5;

    [FieldOffset(0x30)] public ushort Quantity1;

    [FieldOffset(0x34)] public ushort Quantity2;

    [FieldOffset(0x38)] public ushort Quantity3;

    [FieldOffset(0x3C)] public ushort Quantity4;

    [FieldOffset(0x40)] public ushort Quantity5;

    [FieldOffset(0x44)] public uint Unk44;
}
