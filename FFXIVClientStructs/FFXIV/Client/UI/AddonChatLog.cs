using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonChatLog
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("ChatLog")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x638)]
public unsafe partial struct AddonChatLog {
    [FieldOffset(0x2AC)] public byte TabIndex;
    [FieldOffset(0x2AD)] public byte TabCount;

    [FieldOffset(0x2B0), FixedSizeArray] internal FixedSizeArray5<Utf8String> _tabNames;

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B CF 84 C0 74 07")]
    public partial bool IsZoomed();
}
