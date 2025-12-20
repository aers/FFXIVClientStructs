using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonImage3
//   Component::GUI::Image
//     Component::GUI::AddonScreenInfoChild
//       Component::GUI::AtkUnitBase
//         Component::GUI::AtkEventListener
[Addon("_Image3")]
[GenerateInterop]
[Inherits<AddonImage>]
[StructLayout(LayoutKind.Explicit, Size = 0x2B8)]
public unsafe partial struct AddonImage3;
