using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.Game;

// Client::Game::PvPDuelManager
//   Component::GUI::AtkModuleInterface::AtkEventInterface
[GenerateInterop]
[Inherits<AtkModuleInterface.AtkEventInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public partial struct PvPDuelManager {
    [FieldOffset(0x10)] public uint EnemyEntityId;
    [FieldOffset(0x14)] public uint AddonId;
    [FieldOffset(0x18)] public byte Flags;
}
