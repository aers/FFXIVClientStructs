using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonAlliance48
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("Alliance48")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x8C8)]
public unsafe partial struct AddonAlliance48 {
    [FieldOffset(0x238), FixedSizeArray] internal FixedSizeArray5<Alliance48Struct> _alliances;

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x150)]
    public unsafe partial struct Alliance48Struct {
        [FieldOffset(0x00), FixedSizeArray] internal FixedSizeArray8<Alliance48MemberStruct> _members;
        [FieldOffset(0x140)] public AtkComponentBase* ComponentBase;
        [FieldOffset(0x148)] public AtkTextNode* HeaderText;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x28)]
    public unsafe partial struct Alliance48MemberStruct {
        [FieldOffset(0x00)] public AtkComponentBase* AtkComponentBase;
        [FieldOffset(0x08)] public AtkImageNode* ClassJobImageNode;
        [FieldOffset(0x18)] public AtkResNode* AtkResNode;
    }
}
