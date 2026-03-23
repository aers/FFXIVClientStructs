using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonLimitBreak
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("_LimitBreak")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x2A8)]
public unsafe partial struct AddonLimitBreak {
    [FieldOffset(0x238), FixedSizeArray] internal FixedSizeArray3<GaugeNode> _gaugeNodes;
    [FieldOffset(0x280)] public AtkResNode* GaugeContainerNode;
    [FieldOffset(0x288)] public AtkTextNode* LimitBreakTextNode;

    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public struct GaugeNode {
        [FieldOffset(0x00)] public AtkImageNode* FrameLeftImageNode;
        [FieldOffset(0x08)] public AtkComponentBase* ProgressComponent;
        [FieldOffset(0x10)] public AtkImageNode* FrameRightImageNode;
    }
}
