using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonImage3
//   Component::GUI::AddonScreenInfoChild
//     Component::GUI::AtkUnitBase
//       Component::GUI::AtkEventListener
[Addon("_Image3")]
[GenerateInterop]
[Inherits<AddonImage>] // TODO: copy fields from AddonImage(?) and inherit from AddonScreenInfoChild instead
[StructLayout(LayoutKind.Explicit, Size = 0x2B8)]
public partial struct AddonImage3 {
    [MemberFunction("48 89 5C 24 ?? 57 48 83 EC 30 48 8B D9 89 91")]
    public partial void SetImage(int iconId, IconSubFolder iconFolder, int sfxId);
}
