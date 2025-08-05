using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonRecipeMaterialList
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("RecipeMaterialList")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x2B8)]
public unsafe partial struct AddonRecipeMaterialList {
    [FieldOffset(0x238)] public AtkComponentTreeList* TreeList;
    [FieldOffset(0x240)] public AtkComponentButton* RefreshButton;

    [MemberFunction("E8 ?? ?? ?? ?? BA ?? ?? ?? ?? 48 8B CF E8 ?? ?? ?? ?? 45 33 C0 48 89 87")]
    public partial void SetWindowLock(bool locked);
}
