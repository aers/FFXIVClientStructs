using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonEnemyList
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[StructLayout(LayoutKind.Explicit, Size = 0x278)]
public unsafe struct AddonEnemyList
{
    public const byte MaxEnemyCount = 8;

    [FieldOffset(0x0)] public AtkUnitBase AtkUnitBase;
    [FieldOffset(0x220)] public AtkComponentButton** EnemyOneComponent;

    [FieldOffset(0x272)] public byte EnemyCount;
    [FieldOffset(0x273)] public byte HoveredIndex;
    [FieldOffset(0x274)] public byte SelectedIndex;
}