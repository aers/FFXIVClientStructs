using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonGatheringMasterpiece
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("GatheringMasterpiece")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0xBF8)]
public unsafe partial struct AddonGatheringMasterpiece {
    [FieldOffset(0x230)] public AtkComponentIcon* ItemIcon;
    [FieldOffset(0x238)] public AtkTextNode* ItemName;
    [FieldOffset(0x248)] public AtkTextNode* ObtainChance;

    [FieldOffset(0x2A0)] public AtkComponentDragDrop* ScourDragDrop;
    [FieldOffset(0x358)] public AtkComponentDragDrop* BrazenDragDrop;
    [FieldOffset(0x410)] public AtkComponentDragDrop* MeticulousDragDrop;
    [FieldOffset(0x4E0)] public AtkComponentDragDrop* ScrutinyDragDrop;
    [FieldOffset(0x5A0)] public AtkComponentDragDrop* CollectorsFocusDragDrop;
    [FieldOffset(0x690)] public AtkComponentDragDrop* PrimingTouchDragDrop;
    [FieldOffset(0x748)] public AtkComponentDragDrop* CollectDragDrop;

    [FieldOffset(0x848)] public AtkTextNode* GPLeftover;
    [FieldOffset(0x850)] public AtkTextNode* GPTotal;
    [FieldOffset(0x868)] public AtkTextNode* IntegrityLeftover;
    [FieldOffset(0x870)] public AtkComponentGaugeBar* IntegrityGauge;
    [FieldOffset(0x880)] public AtkTextNode* IntegrityTotal;

    [FieldOffset(0x908)] public Utf8String ScrutinyCheckboxTooltip;
    [FieldOffset(0x970)] public Utf8String CollectorsIntuitionTooltip;
    [FieldOffset(0x9D8)] public Utf8String CollectorsIntuitionCheckboxTooltip;
    [FieldOffset(0xA40)] public Utf8String CollectorsStandardTooltip;
    [FieldOffset(0xAA8)] public Utf8String CollectorsHighStandardTooltip;
    [FieldOffset(0xB10)] public Utf8String MeticulousEffectTooltip;
    [FieldOffset(0xB78)] public Utf8String QuestionMarkTooltip;


    // [FieldOffset(0xBE8)] public AddonMainCross* AddonMainCross;
}
