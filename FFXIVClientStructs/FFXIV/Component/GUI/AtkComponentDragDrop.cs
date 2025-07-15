using FFXIVClientStructs.FFXIV.Client.System.Memory;
using static FFXIVClientStructs.FFXIV.Component.GUI.AtkEventData;
using static FFXIVClientStructs.FFXIV.Component.GUI.AtkTooltipManager;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkComponentDragDrop
//   Component::GUI::AtkComponentBase
//     Component::GUI::AtkEventListener
// common CreateAtkComponent function "E8 ?? ?? ?? ?? 4C 8B F0 48 85 C0 0F 84 ?? ?? ?? ?? 49 8B 4D 08"
// type 17
[GenerateInterop]
[Inherits<AtkComponentBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x110)]
public unsafe partial struct AtkComponentDragDrop : ICreatable {
    [FieldOffset(0xC0)] public AtkDragDropInterface AtkDragDropInterface;
    [FieldOffset(0xF0)] public DragDropType AcceptedType;
    [FieldOffset(0xF8)] public AtkComponentIcon* AtkComponentIcon;
    [FieldOffset(0x108)] public DragDropVisibilityFlag VisibilityFlags;
    [FieldOffset(0x109)] public DragDropInputMode InputMode;
    [FieldOffset(0x10A)] public DragDropFlag Flags;

    [MemberFunction("33 D2 C7 81 ?? ?? ?? ?? ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 89 51 08 48 89 01 48 8D 05 ?? ?? ?? ??")]
    public partial void Ctor();

    [MemberFunction("E8 ?? ?? ?? ?? 83 F8 FF 74 40")]
    public partial int GetIconId();

    [MemberFunction("E8 ?? ?? ?? ?? 8D 47 49")]
    public partial bool LoadIcon(uint iconId);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B D0 48 8B CB E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 8D 46 F4")]
    public partial CStringPointer GetQuantityText();

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 8D 46 F4"), GenerateStringOverloads]
    public partial void SetQuantityText(CStringPointer quantityText);

    [MemberFunction("E8 ?? ?? ?? ?? 48 63 CF 48 83 C1 19")]
    public partial void SetQuantity(int quantity);

    [MemberFunction("E8 ?? ?? ?? ?? F2 41 0F 10 87")]
    public partial void AttachTooltip(AtkTooltipType type, ushort parentId, AtkResNode* targetNode, AtkTooltipArgs* tooltipArgs);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 03 49 8B CF")]
    public partial void DetachTooltip();

    [MemberFunction("E8 ?? ?? ?? ?? 8D 46 0B")]
    public partial void SetIconDisableState(bool disabled); // if true, sets MultiplyRed/Green/Blue to 50. 100 otherwise

    [MemberFunction("E8 ?? ?? ?? ?? EB 18 66 C7 44 24")]
    public partial void BeginDragDrop(AtkMouseData* mouseData);

    [MemberFunction("48 83 EC 68 33 C0 45 33 C0")]
    public partial bool DispatchCancelEvent(AtkMouseData* mouseData);
}

[Flags]
public enum DragDropVisibilityFlag : byte {
    None = 0,
    Unk1 = 0b0000_0001,
    HideAfterFlyBack = 0b0000_0010,
}

// checked in the function ReceiveEvent calls for AtkEventType.InputReceived
public enum DragDropInputMode : byte {
    None = 0,
    Unk1 = 1,
    Unk2 = 2,
    Unk3 = 3,
}

[Flags]
public enum DragDropFlag : byte {
    None = 0,

    /// <remarks> Checked in <see cref="AtkComponentDragDrop.ReceiveEvent"/> for <see cref="AtkEventType.DragDropCanAcceptCheck"/>. </remarks>
    SkipEnabledCheck = 0b0000_0001,

    /// <summary> Prevents the DragDrop from being started. </summary>
    Locked = 0b0000_0010,

    /// <summary> If set, a simple left click fires <see cref="AtkEventType.DragDropClick"/>. </summary>
    /// <remarks> Checked in <see cref="AtkDragDropInterface.HandleMouseUpEvent"/>. </remarks>
    Clickable = 0b0000_0100,

    Unk4 = 0b0000_1000,
    Unk5 = 0b0001_0000,
    Unk6 = 0b0010_0000,
    Unk7 = 0b0100_0000,

    [Obsolete("Renamed to Locked")] Unk2 = 0b0000_0010,
}
