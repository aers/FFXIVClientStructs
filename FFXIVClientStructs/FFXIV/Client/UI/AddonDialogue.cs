using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonDialogue
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
//   Component::GUI::AtkManagedInterface
[Addon("Dialogue")]
[GenerateInterop]
[Inherits<AtkUnitBase>, Inherits<AtkManagedInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x248)]
public unsafe partial struct AddonDialogue;
