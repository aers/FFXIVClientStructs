using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonActionDetail
//   Client::UI::AddonActionDetailBase
[Addon("ActionDetail")]
[GenerateInterop]
[Inherits<AddonActionDetailBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x360)]
public unsafe partial struct AddonActionDetail {
    [MemberFunction("48 89 5C 24 ?? 55 56 57 41 54 41 55 41 56 41 57 48 83 EC 40 48 8B 42 28 4C 8B FA 48 8B F1 49 8B E8")]
    public partial void GenerateTooltip(NumberArrayData* numberArray, StringArrayData* stringArray);
}
