using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonScreenFrame
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
//   Component::GUI::AtkManagedInterface
/// <summary>
/// Covers the area outside the scaled UI viewport and positions its associated text at the screen edge.
/// </summary>
[Addon("ScreenFrame")]
[GenerateInterop]
[Inherits<AtkUnitBase>, Inherits<AtkManagedInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x270)]
public unsafe partial struct AddonScreenFrame {
    [FieldOffset(0x240)] public AtkTextNode* TextNode;
    [FieldOffset(0x248)] public AtkResNode* TopBorderNode;
    [FieldOffset(0x250)] public AtkResNode* BottomBorderNode;
    [FieldOffset(0x258)] public AtkResNode* LeftBorderNode;
    [FieldOffset(0x260)] public AtkResNode* RightBorderNode;
    [FieldOffset(0x268)] public short TextX;
    [FieldOffset(0x26A)] public short TextY;
}
