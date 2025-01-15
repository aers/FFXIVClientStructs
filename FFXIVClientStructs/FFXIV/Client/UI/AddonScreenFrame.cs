using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonScreenFrame
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
//   Component::GUI::AtkManagedInterface
[Addon("ScreenFrame")]
[GenerateInterop]
[Inherits<AtkUnitBase>, Inherits<AtkManagedInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x270)]
public unsafe partial struct AddonScreenFrame;
