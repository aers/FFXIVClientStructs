using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonImage
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("_Image", "_Image3")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x2A8)]
public unsafe partial struct AddonImage {
    [FieldOffset(0x278)] public AtkResNode* ResNode1; // Both AtkResNode's appear to be the same node
    [FieldOffset(0x280)] public AtkResNode* ResNode2;
    [FieldOffset(0x288)] public AtkImageNode* ImageNode;

    [FieldOffset(0x294)] public ushort Width;
    [FieldOffset(0x298)] public ushort Height;

    [MemberFunction("48 89 5C 24 ?? 57 48 83 EC 30 48 8B D9 89 91")]
    public partial void SetImage(int iconId, IconSubFolder iconFolder, int sfxId);
}
