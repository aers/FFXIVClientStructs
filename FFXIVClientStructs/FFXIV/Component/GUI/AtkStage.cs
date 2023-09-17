using FFXIVClientStructs.FFXIV.Client.UI;
using FFXIVClientStructs.FFXIV.Client.UI.Misc;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkStage
//   Component::GUI::AtkEventTarget
// ctor "E8 ?? ?? ?? ?? 48 8B F8 48 89 BE ?? ?? ?? ?? 48 8B 43 10"
[StructLayout(LayoutKind.Explicit, Size = 0x75DF8)]
public unsafe partial struct AtkStage {
    [FieldOffset(0x0)] public AtkEventTarget AtkEventTarget;
    [FieldOffset(0x18)] public AtkTextureResourceManager* AtkTextureResourceManager;
    [FieldOffset(0x20)] public RaptureAtkUnitManager* RaptureAtkUnitManager;
    [FieldOffset(0x20)] public nint AtkInputManager;
    [FieldOffset(0x38)] public AtkArrayDataHolder* AtkArrayDataHolder;
    [FieldOffset(0x60)] public RaptureTextModule* RaptureTextModule;
    [FieldOffset(0x78)] public AtkDragDropManager DragDropManager;
    [FieldOffset(0x168)] public AtkTooltipManager TooltipManager;
    [FieldOffset(0x338)] public AtkCursor AtkCursor;
    [FieldOffset(0x350)] public void* AtkEventDispatcher;
    [FieldOffset(0x868)] public AtkEvent* RegisteredEvents;

    [MemberFunction("E8 ?? ?? ?? ?? 0F BF D5")]
    public static partial AtkStage* GetSingleton();

    [MemberFunction("E8 ?? ?? ?? ?? 48 3B F0 0F 85")]
    public partial AtkResNode* GetFocus();

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 6C 24 ?? 80 BB")]
    public partial void ClearFocus();

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B CB 4C 8B 70 50")]
    public partial NumberArrayData** GetNumberArrayData();

    [MemberFunction("E8 ?? ?? ?? ?? 4C 8B 37")]
    public partial StringArrayData** GetStringArrayData();

    [MemberFunction("E8 ?? ?? ?? ?? 4C 8B 70 10")]
    public partial ExtendArrayData** GetExtendArrayData();
}
