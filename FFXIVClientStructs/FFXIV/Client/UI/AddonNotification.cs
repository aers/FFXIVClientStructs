using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonNotification
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("_Notification")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x1078)]
public partial struct AddonNotification;
