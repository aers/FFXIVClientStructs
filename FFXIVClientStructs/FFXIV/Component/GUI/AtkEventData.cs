namespace FFXIVClientStructs.FFXIV.Component.GUI;

[CExporterStructUnion]
[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public unsafe partial struct AtkEventData {
    [FieldOffset(0x00)] public AtkMouseData MouseData;
    [FieldOffset(0x00)] public AtkInputData InputData;
    [FieldOffset(0x00)] public AtkFocusData FocusData;
    [FieldOffset(0x00)] public AtkValueData ValueData;
    [FieldOffset(0x00)] public AtkListItemData ListItemData;
    [FieldOffset(0x00)] public AtkDragDropData DragDropData;
    [FieldOffset(0x00)] public LinkData* LinkData;
    [FieldOffset(0x00)] public AtkAddonControlData AddonControlData;
    [FieldOffset(0x00)] public GUI.AtkInputData* RawInputData;
}

public partial struct AtkEventData {
    [StructLayout(LayoutKind.Explicit, Size = 0x28)]
    public struct AtkMouseData {
        [FieldOffset(0x00)] public short PosX;
        [FieldOffset(0x02)] public short PosY;
        [FieldOffset(0x04)] public short WheelDirection;
        [FieldOffset(0x06)] public byte ButtonId;
        [FieldOffset(0x07)] public ModifierFlag Modifier;
        [FieldOffset(0x08)] private int Unk8;
        [FieldOffset(0x0C)] private short UnkC;
        [FieldOffset(0x0E)] private short Unk0E;
        [FieldOffset(0x10)] private short Unk10;

        // different than the UIInputData one
        [Flags]
        public enum ModifierFlag : byte {
            None = 0,
            Ctrl = 1 << 0,
            Alt = 1 << 1,
            Shift = 1 << 2,

            Dragging = 1 << 4,
        }
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x28)]
    public struct AtkInputData {
        [FieldOffset(0x00)] public int InputId;
        [FieldOffset(0x04)] public InputState State;

        public enum InputState : byte {
            Down = 0,
            Up = 1,
            Held = 2,
            /// <remarks> For <see cref="AtkEventType.InputNavigation"/>. </remarks>
            Repeat = 3,
            [Obsolete("Renamed to Repeat")] Unk3 = 3,
        }
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x28)]
    public unsafe struct AtkFocusData {
        [FieldOffset(0x00)] public AtkResNode* ResNode;
        [FieldOffset(0x08)] public AtkCollisionNode* CollisionNode;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x28)]
    public unsafe struct AtkValueData {
        [FieldOffset(0x00)] public int LastValue;
        [FieldOffset(0x04)] public int NewValue;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x28)]
    public unsafe struct AtkListItemData {
        [FieldOffset(0x00)] public AtkComponentListItemRenderer* ListItemRenderer;
        [FieldOffset(0x08)] public AtkComponentTreeListItem* ListItem;
        [FieldOffset(0x10)] public int SelectedIndex; // HoveredItemIndex2
        [FieldOffset(0x14)] private short UnkListField15C;
        [FieldOffset(0x16)] public short HoveredItemIndex3;
        [FieldOffset(0x18)] public byte MouseButtonId;
        [FieldOffset(0x19)] public AtkMouseData.ModifierFlag MouseModifier;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x28)]
    public unsafe struct AtkDragDropData {
        [FieldOffset(0x00)] public AtkDragDropInterface* DragDropInterface;
        [FieldOffset(0x08)] public AtkComponentNode* ComponentNode;
        [FieldOffset(0x10)] public byte MouseButtonId;
        [FieldOffset(0x11)] public AtkMouseData.ModifierFlag MouseModifier;
        [FieldOffset(0x12)] private int Unk12;
        [FieldOffset(0x16)] private short Unk16;
        [FieldOffset(0x18)] private nint Unk18;
        [FieldOffset(0x20)] private nint Unk20;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x28)]
    public unsafe struct AtkAddonControlData {
        [FieldOffset(0x00)] public AtkUnitBase* UnitBase;
    }
}
