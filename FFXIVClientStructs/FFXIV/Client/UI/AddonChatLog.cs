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

    [FieldOffset(0x260)] public AtkComponentTextInput* TextInput;
    [FieldOffset(0x270), FixedSizeArray] internal FixedSizeArray5<Pointer<AtkComponentTab>> _chatTabs;
    [FieldOffset(0x4B8)] public AtkComponentDropDownList* ChannelSelectDropDown;

    [FieldOffset(0x2B0), FixedSizeArray] internal FixedSizeArray5<Utf8String> _tabNames;

    [FieldOffset(0x508)] public AtkTextNode* CurrentChannelTextNode;
    [FieldOffset(0x510)] public AtkComponentNode* SettingsComponentNode;
    [FieldOffset(0x518)] public AtkComponentNode* NoviceNetworkComponentNode;
    [FieldOffset(0x518), Obsolete("Named incorrectly, use NoviceNetworkComponentNode.", true)] public AtkComponentNode* CloseComponentNode;
    [FieldOffset(0x520)] public AtkNineGridNode* BackgroundNode;
    [FieldOffset(0x528)] public AtkComponentButton* ResizeButton;
    [FieldOffset(0x530)] public AtkComponentNode* AddTabComponentNode;
    [FieldOffset(0x538)] public AtkImageNode* TabBarEndImageNode;
    [FieldOffset(0x540)] public AtkImageNode* TabBarStartImageNode;
    [FieldOffset(0x548)] public AtkCollisionNode* ControlsCollisionNode;
    [FieldOffset(0x568)] public AtkAddonControl AddonControl;
    [FieldOffset(0x598), Obsolete("Is actually a part of AddonControl, use that instead", true)] public AtkStage* AtkStage;

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 0F 85 ?? ?? ?? ?? 49 8B B6")]
    public partial bool IsZoomed();
}
