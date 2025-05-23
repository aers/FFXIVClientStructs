using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonToDoList
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("_ToDoList")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x4D8)]
public unsafe partial struct AddonToDoList {

    [FieldOffset(0x238)] public ListPanel ListPanel;
    [FieldOffset(0x260)] public AtkTextNode* DutyTimerTextNode;
    [FieldOffset(0x268)] public AtkTextNode* FateTimerTextNode;
    [FieldOffset(0x270)] public StdVector<Pointer<AtkTextNode>> DutyFinderTextNodes;
    [FieldOffset(0x290)] public StdVector<ObjectiveTimerTextNodeData> ObjectiveTimerTextNodes;
    [FieldOffset(0x2A8)] public StdVector<FocusableNodeHolder> FocusableNodes;
    [FieldOffset(0x2C0)] public int FocusedRow;
    [FieldOffset(0x2C4)] public int FocusedColumn;

    // Second copy of focus details- the game duplicates writes to the first onto these
    [FieldOffset(0x2C8)] public int FocusedRow2;
    [FieldOffset(0x2CC)] public int FocusedColumn2;

    // Array of data entries that are used in click callbacks for various buttons
    [FieldOffset(0x2D0), FixedSizeArray] internal FixedSizeArray128<int> _actionData;
    [FieldOffset(0x4D0)] public uint ActionDataCount;

    [FieldOffset(0x4D4)] public ushort XPosition;
    [FieldOffset(0x4D7)] public bool RightAligned;

    [StructLayout(LayoutKind.Explicit, Size = 0x30)]
    public struct FocusableNodeHolder {
        // other space doesn't ever seem to be written to or read from??
        [FieldOffset(0x28)] public AtkCollisionNode* Node;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public struct ObjectiveTimerTextNodeData {
        [FieldOffset(0)] public AtkTextNode* Node;
        [FieldOffset(0x8)] public uint StringArrayIndex;
    }
}
