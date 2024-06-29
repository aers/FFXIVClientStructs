using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonEnemyList
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("_EnemyList")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x288)]
public unsafe partial struct AddonEnemyList {
    public const byte MaxEnemyCount = 8;
    [FieldOffset(0x230)] public AtkComponentButton** EnemyOneComponent;

    [FieldOffset(0x282)] public byte EnemyCount;
    [FieldOffset(0x283)] public byte HoveredIndex;
    [FieldOffset(0x284)] public byte SelectedIndex;
}
