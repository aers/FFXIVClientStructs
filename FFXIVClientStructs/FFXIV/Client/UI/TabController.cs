using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::TabController
//   Component::GUI::AtkEventListener
[GenerateInterop]
[Inherits<AtkEventListener>]
[StructLayout(LayoutKind.Explicit, Size = 0xB0)]
public unsafe partial struct TabController {
    [FieldOffset(0x08)] public AtkStage* AtkStage;
    [FieldOffset(0x10)] public NodeInfoContainer NodeInfo;
    [FieldOffset(0x80)] public int TabIndex;
    [FieldOffset(0x84)] public int TabCount;
    [FieldOffset(0x88)] public bool IsInSearchTab;

    [FieldOffset(0x90)] public delegate* unmanaged<int, AtkUnitBase*, void> CallbackFunction; // (int tabIndex, AtkUnitBase* addon)
    [FieldOffset(0x98)] public AtkUnitBase* Addon;
    [FieldOffset(0xA0)] public AtkUnitBase* InputReceivedEventAddon;
    [FieldOffset(0xA8)] public bool Enabled;

    [MemberFunction("48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 57 48 83 EC 30 0F 10 02 48 8B F1")]
    public partial void Setup(NodeInfoContainer* nodeInfo);

    [MemberFunction("48 83 EC 38 48 89 91 ?? ?? ?? ?? 4C 8B C9")]
    public partial void RegisterInputReceivedEvent(AtkUnitBase* addon);

    [MemberFunction("E8 ?? ?? ?? ?? BB 72 00 00 00")]
    public partial void RegisterCallback(delegate* unmanaged<int, AtkUnitBase*, void> callbackFunction, AtkUnitBase* addon);

    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 83 ?? ?? ?? ?? 84 C0 74 ?? 39 B3")]
    public partial void SetTabCount(int tabCount);

    [MemberFunction("48 83 79 ?? ?? 74 ?? 3B 91")]
    public partial void SetTabIndex(int tabIndex);

    [MemberFunction("E8 ?? ?? ?? ?? 3B C7 7C ?? 8D 47")]
    public partial int GetTabIndex();

    [MemberFunction("83 B9 ?? ?? ?? ?? ?? 7E ?? 48 8B 41")]
    public partial AtkComponentButton* GetFirstButton();

    [MemberFunction("48 8B 41 ?? 48 85 C0 75 ?? 48 63 81")]
    public partial AtkComponentButton* GetLastButton();

    /// <remarks> Updates the enable status on all buttons. </remarks>
    [MemberFunction("40 56 48 83 EC 30 48 8B F1 48 8B 49")]
    public partial void UpdateButtons();

    /// <remarks> An internal function that's called on <see cref="AtkEventType.ButtonClick"/>. </remarks>
    [MemberFunction("48 89 5C 24 ?? 57 48 83 EC 20 48 83 79 ?? ?? 8B FA 48 8B D9 74 ?? 3B 91")]
    public partial void SetTabIndexAndCallBack(int tabIndex);

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x70)]
    public partial struct NodeInfoContainer {
        [FieldOffset(0x00)] public AtkResNode* ContainerNode;
        [FieldOffset(0x08), FixedSizeArray] internal FixedSizeArray9<Pointer<AtkComponentButton>> _tabButtons;
        [FieldOffset(0x50)] public AtkComponentButton* BackButton;
        [FieldOffset(0x58)] public AtkComponentButton* ForwardButton;
        [FieldOffset(0x60)] public AtkComponentButton* SearchButton;
        [FieldOffset(0x68)] public int UnkTimelineId1;
        [FieldOffset(0x6C)] public int UnkTimelineId2;
    }
}
