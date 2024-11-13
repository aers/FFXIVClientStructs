using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonGatheringMasterpiece
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("GatheringMasterpiece")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0xC00)]
public unsafe partial struct AddonGatheringMasterpiece {
    [FieldOffset(0x238)] public AtkComponentIcon* ItemIcon;
    [FieldOffset(0x240)] public AtkTextNode* ItemName;
    [FieldOffset(0x250)] public AtkTextNode* ObtainChance;

    [FieldOffset(0x2A8)] public AtkComponentDragDrop* ScourDragDrop;
    [FieldOffset(0x360)] public AtkComponentDragDrop* BrazenDragDrop;
    [FieldOffset(0x418)] public AtkComponentDragDrop* MeticulousDragDrop;
    [FieldOffset(0x4E8)] public AtkComponentDragDrop* ScrutinyDragDrop;
    [FieldOffset(0x5A8)] public AtkComponentDragDrop* CollectorsFocusDragDrop;
    [FieldOffset(0x698)] public AtkComponentDragDrop* PrimingTouchDragDrop;
    [FieldOffset(0x750)] public AtkComponentDragDrop* CollectDragDrop;

    [FieldOffset(0x850)] public AtkTextNode* GPLeftover;
    [FieldOffset(0x858)] public AtkTextNode* GPTotal;
    [FieldOffset(0x870)] public AtkTextNode* IntegrityLeftover;
    [FieldOffset(0x878)] public AtkComponentGaugeBar* IntegrityGauge;
    [FieldOffset(0x888)] public AtkTextNode* IntegrityTotal;

    [FieldOffset(0x910)] public Utf8String ScrutinyCheckboxTooltip;
    [FieldOffset(0x978)] public Utf8String CollectorsIntuitionTooltip;
    [FieldOffset(0x9E0)] public Utf8String CollectorsIntuitionCheckboxTooltip;
    [FieldOffset(0xA48)] public Utf8String CollectorsStandardTooltip;
    [FieldOffset(0xAB0)] public Utf8String CollectorsHighStandardTooltip;
    [FieldOffset(0xB18)] public Utf8String MeticulousEffectTooltip;
    [FieldOffset(0xB80)] public Utf8String QuestionMarkTooltip;


    // [FieldOffset(0xBF0)] public AddonMainCross* AddonMainCross;
}
