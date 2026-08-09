using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonMateriaRetrieveDialog
//   Client::UI::AddonMateriaDialogBase
//     Component::GUI::AtkUnitBase
//       Component::GUI::AtkEventListener
[Addon("MateriaRetrieveDialog")]
[GenerateInterop]
[Inherits<AtkUnitBase>] // TODO: replace with AddonMateriaDialogBase
[StructLayout(LayoutKind.Explicit, Size = 0x238)]
public partial struct AddonMateriaRetrieveDialog;
