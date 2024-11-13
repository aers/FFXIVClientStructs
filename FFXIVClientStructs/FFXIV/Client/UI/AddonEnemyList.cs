using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonEnemyList
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("_EnemyList")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x290)]
public unsafe partial struct AddonEnemyList {
    public const byte MaxEnemyCount = 8;
    [FieldOffset(0x238)] public AtkComponentButton** EnemyOneComponent;

    [FieldOffset(0x28A)] public byte EnemyCount;
    [FieldOffset(0x28B)] public byte HoveredIndex;
    [FieldOffset(0x28C)] public byte SelectedIndex;
}
