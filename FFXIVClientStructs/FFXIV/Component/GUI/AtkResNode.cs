using FFXIVClientStructs.FFXIV.Client.Graphics;
using FFXIVClientStructs.FFXIV.Client.System.Memory;
using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkResNode
//   Component::GUI::AtkEventTarget
// base class for all UI "nodes" which represent elements of the UI
[GenerateInterop(isInherited: true)]
[Inherits<AtkEventTarget>]
[StructLayout(LayoutKind.Explicit, Size = 0xC0)]
[VirtualTable("48 8D 05 ?? ?? ?? ?? ?? ?? ?? 33 C0 48 89 41 ?? 66 C7 81", 3, 3)]
public unsafe partial struct AtkResNode : ICreatable {
    [FieldOffset(0x8)] public uint NodeId;
    [FieldOffset(0x10)] public AtkTimeline* Timeline;

    [FieldOffset(0x18)] public AtkEventManager AtkEventManager; // holds events registered to this node

    // these are all technically union types with a node ID and a pointer but should be replaced by the loader always
    [FieldOffset(0x20)] public AtkResNode* ParentNode;
    [FieldOffset(0x28)] public AtkResNode* PrevSiblingNode;
    [FieldOffset(0x30)] public AtkResNode* NextSiblingNode;
    [FieldOffset(0x38)] public AtkResNode* ChildNode;
    [FieldOffset(0x40)] public NodeType Type;
    [FieldOffset(0x42)] public ushort ChildCount;
    [FieldOffset(0x44)] public float X; // X,Y converted to floats on load, file is int16
    [FieldOffset(0x48)] public float Y;
    [FieldOffset(0x4C)] public float ScaleX;
    [FieldOffset(0x50)] public float ScaleY;
    [FieldOffset(0x54)] public float Rotation; // radians (file is degrees)
    [FieldOffset(0x60)] public Matrix2x2 Transform;
    [FieldOffset(0x70)] public float ScreenX;
    [FieldOffset(0x74)] public float ScreenY;

    [FieldOffset(0x80)] public ByteColor Color;

    // not sure what the _2s are for, the regular ones are loaded from the file
    [FieldOffset(0x84)] public float Depth;
    [FieldOffset(0x88)] public float Depth_2;
    [FieldOffset(0x8C)] public short AddRed;
    [FieldOffset(0x8E)] public short AddGreen;
    [FieldOffset(0x90)] public short AddBlue;
    [FieldOffset(0x92)] public short AddRed_2;
    [FieldOffset(0x94)] public short AddGreen_2;
    [FieldOffset(0x96)] public short AddBlue_2;
    [FieldOffset(0x98)] public byte MultiplyRed;
    [FieldOffset(0x99)] public byte MultiplyGreen;
    [FieldOffset(0x9A)] public byte MultiplyBlue;
    [FieldOffset(0x9B)] public byte MultiplyRed_2;
    [FieldOffset(0x9C)] public byte MultiplyGreen_2;
    [FieldOffset(0x9D)] public byte MultiplyBlue_2;
    [FieldOffset(0x9E)] public byte Alpha_2;
    [FieldOffset(0x9F)] private byte UnkByte_1;
    [FieldOffset(0xA0)] public ushort Width;
    [FieldOffset(0xA2)] public ushort Height;
    [FieldOffset(0xA4)] public float OriginX;
    [FieldOffset(0xA8)] public float OriginY;

    // asm accesses these fields together so this is one 32bit field with priority+flags
    [FieldOffset(0xAC)] public ushort Priority;
    [FieldOffset(0xAE)] public NodeFlags NodeFlags;
    /// <summary>
    /// <term>Bit 1 [0x1]</term> Is dirty (has updates to be drawn)<br/>
    /// <term>Bit 2 [0x2]</term> Is undergoing timeline animation (?)<br/>
    /// <term>Bit 3 [0x4]</term> Calculate transformation<br/>
    /// <term>Bit 4 [0x10]</term> Stops rapid cursor navigation Up<br/>
    /// <term>Bit 5 [0x20]</term> Stops rapid cursor navigation Down<br/>
    /// <term>Bit 6 [0x40]</term> Stops rapid cursor navigation Left<br/>
    /// <term>Bit 7 [0x80]</term> Stops rapid cursor navigation Right<br/>
    /// <term>Bit 9 [0x100]</term> Don't make visible on new timeline label<br/>
    /// <term>Bits 10-17</term> ClipCount<br/>
    /// <term>Bit 21 [0x100000]</term> Change CursorType to Clickable on hover<br/>
    /// <term>Bit 23 [0x400000]</term> Change CursorType to TextInput on hover<br/>
    /// <term>Bit 24 [0x800000]</term> Use elliptical collision instead of rectangular
    /// </summary>
    [FieldOffset(0xB0)] public uint DrawFlags;

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B D8 48 83 C4 ?? 5B C3 33 DB")]
    public partial void Ctor();

    [MemberFunction("48 85 C9 74 14 0F B7 41 40")]
    public partial NodeType GetNodeType();

    [MemberFunction("E8 ?? ?? ?? ?? 45 39 B7")]
    public partial uint GetBaseNodeId();

    [MemberFunction("48 85 C9 74 0B 81 79")]
    public partial bool IsDuplicatedNode();

    #region Node getters

    [MemberFunction("E8 ?? ?? ?? ?? 8B 54 FB 04")]
    public partial AtkImageNode* GetAsAtkImageNode();

    [MemberFunction("E8 ?? ?? ?? ?? 45 6B E7")]
    public partial AtkTextNode* GetAsAtkTextNode();

    [MemberFunction("E8 ?? ?? ?? ?? B2 01 48 89 47 08")]
    public partial AtkNineGridNode* GetAsAtkNineGridNode();

    [MemberFunction("E8 ?? ?? ?? ?? 8D 0C BF 03 C9")]
    public partial AtkCounterNode* GetAsAtkCounterNode();

    [MemberFunction("E8 ?? ?? ?? ?? 48 6B CE 68")]
    public partial AtkCollisionNode* GetAsAtkCollisionNode();

    [MemberFunction("48 85 C9 74 0B 66 83 79 ?? 0A 75 04 48 8B C1 C3 33 C0 C3")]
    public partial AtkClippingMaskNode* GetAsAtkClippingMaskNode();

    #endregion

    #region Component getters

    [MemberFunction("E8 ?? ?? ?? ?? 44 8D 4F 30")]
    public partial AtkComponentNode* GetAsAtkComponentNode();

    [MemberFunction("E8 ?? ?? ?? ?? 49 63 DF")]
    public partial AtkComponentBase* GetComponent();

    [MemberFunction("E8 ?? ?? ?? ?? 48 89 43 D0")]
    public partial AtkComponentButton* GetAsAtkComponentButton();

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B B4 24 ?? ?? ?? ?? 48 8B FD")]
    public partial AtkComponentWindow* GetAsAtkComponentWindow();

    [MemberFunction("E8 ?? ?? ?? ?? 41 0F A3 DD")]
    public partial AtkComponentCheckBox* GetAsAtkComponentCheckBox();

    [MemberFunction("E8 ?? ?? ?? ?? 45 0F B6 EF")]
    public partial AtkComponentRadioButton* GetAsAtkComponentRadioButton();

    [MemberFunction("E8 ?? ?? ?? ?? 8B D5 48 89 87")]
    public partial AtkComponentGaugeBar* GetAsAtkComponentGaugeBar();

    [MemberFunction("E8 ?? ?? ?? ?? 8B 4C 3D 80")]
    public partial AtkComponentSlider* GetAsAtkComponentSlider();

    [MemberFunction("E8 ?? ?? ?? ?? 8D 55 0D 48 89 83")]
    public partial AtkComponentTextInput* GetAsAtkComponentTextInput();

    [MemberFunction("E8 ?? ?? ?? ?? 4C 8B E8 33 C0")]
    public partial AtkComponentNumericInput* GetAsAtkComponentNumericInput();

    [MemberFunction("E8 ?? ?? ?? ?? 44 0F B7 FF")]
    public partial AtkComponentList* GetAsAtkComponentList();

    [MemberFunction("E8 ?? ?? ?? ?? 8B 4C 35 97")]
    public partial AtkComponentDropDownList* GetAsAtkComponentDropdownList();

    [MemberFunction("E8 ?? ?? ?? ?? 49 89 07 48 8B F8 48 85 C0")]
    public partial AtkComponentTab* GetAsAtkComponentTab();

    [MemberFunction("E8 ?? ?? ?? ?? 49 89 86 ?? ?? ?? ?? 45 33 C9")]
    public partial AtkComponentTreeList* GetAsAtkComponentTreeList();

    [MemberFunction("E8 ?? ?? ?? ?? BA FB 01 00 00 48 89 83")]
    public partial AtkComponentScrollBar* GetAsAtkComponentScrollBar();

    [MemberFunction("E8 ?? ?? ?? ?? 0F B7 CF 49 89 44 CE")]
    public partial AtkComponentListItemRenderer* GetAsAtkComponentListItemRenderer();

    [MemberFunction("E8 ?? ?? ?? ?? 44 8D 7E")]
    public partial AtkComponentIcon* GetAsAtkComponentIcon();

    [MemberFunction("E8 ?? ?? ?? ?? FF C3 48 89 07 48 8D 7F 08 83 FB 10")]
    public partial AtkComponentIconText* GetAsAtkComponentIconText();

    [MemberFunction("E8 ?? ?? ?? ?? 8B 54 34 20")]
    public partial AtkComponentDragDrop* GetAsAtkComponentDragDrop();

    [MemberFunction("E8 ?? ?? ?? ?? 85 DB 7E 1E 49 8B 4F 28")]
    public partial AtkComponentGuildLeveCard* GetAsAtkComponentGuildLeveCard();

    [MemberFunction("E8 ?? ?? ?? ?? 41 8D 57 1B")]
    public partial AtkComponentTextNineGrid* GetAsAtkComponentTextNineGrid();

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 0B 41 B8 ?? ?? ?? ?? 48 89 83")]
    public partial AtkComponentJournalCanvas* GetAsAtkComponentJournalCanvas();

    [MemberFunction("48 85 C9 74 3D B8 ?? ?? ?? ?? 66 39 41 40 72 2C 48 8B 89 ?? ?? ?? ?? 48 85 C9 74 20 0F B6 81 ?? ?? ?? ?? 24 05 3C 05 75 13 80 B9 ?? ?? ?? ?? ?? 75 0A 48 8B 41 18 80 78 10 15")]
    public partial AtkComponentMultipurpose* GetAsAtkComponentMultipurpose();

    [MemberFunction("E8 ?? ?? ?? ?? 48 89 43 20 48 8D BB")]
    public partial AtkComponentMap* GetAsAtkComponentMap();

    [MemberFunction("E8 ?? ?? ?? ?? 41 8D 56 03 4A 89 84 2E")]
    public partial AtkComponentPreview* GetAsAtkComponentPreview();

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 8E ?? ?? ?? ?? BA ?? ?? ?? ?? 48 89 86 ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 8B 86")]
    public partial AtkComponentHoldButton* GetAsAtkComponentHoldButton();

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 0E BA ?? ?? ?? ?? 48 89 46 60")]
    public partial AtkComponentPortrait* GetAsAtkComponentPortrait();

    #endregion

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 75 48 32 DB")]
    public partial bool CheckCollisionAtCoords(short x, short y, bool inclusive);

    [MemberFunction("E8 ?? ?? ?? ?? C1 E7 0C")]
    public partial void AddEvent(AtkEventType eventType, uint eventParam, AtkEventListener* listener, AtkResNode* nodeParam, bool isGlobalEvent);

    [MemberFunction("E8 ?? ?? ?? ?? 44 38 7D 67")]
    public partial void RemoveEvent(AtkEventType eventType, uint eventParam, AtkEventListener* listener, bool isGlobalEvent);

    [MemberFunction("48 85 C9 0F 84 ?? ?? ?? ?? 48 89 74 24 ?? 41 56")]
    public partial void RemoveAllEventsFromListener(AtkEventListener* listener);

    [MemberFunction("48 85 C9 74 09 48 83 C1 18")]
    public partial void ClearEvents();

    [MemberFunction("E8 ?? ?? ?? ?? EB 96 CC")]
    public partial bool DispatchEvent(AtkEventDispatcher.Event* evt);

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 75 ?? 44 0F BF 83")]
    public partial bool IsEventRegistered(AtkEventType eventType);

    [MemberFunction("E8 ?? ?? ?? ?? 8B D8 3B C5")]
    public partial uint GetEventParam(AtkEventType eventType);

    [MemberFunction("E8 ?? ?? ?? ?? 8B 5C 24 2C")]
    public partial void GetBounds(Bounds* outBounds);

    [MemberFunction("48 85 C9 74 0B 8B 41 44")]
    public partial void GetPositionFloat(float* outX, float* outY);

    [MemberFunction("E8 ?? ?? ?? ?? 0F BF 47 30")]
    public partial void SetPositionFloat(float X, float Y);

    [MemberFunction("E8 ?? ?? ?? ?? 41 8B FC 4C 8D B5")]
    public partial void GetPositionShort(short* outX, short* outY);

    [MemberFunction("E8 ?? ?? ?? ?? 8B 4C BD ?? B8")]
    public partial void SetPositionShort(short X, short Y);

    [MemberFunction("48 85 C9 74 0B 8B 41 4C")]
    public partial void GetScale(float* outX, float* outY);

    [MemberFunction("E8 ?? ?? ?? ?? 0F 57 C9 8B C7")]
    public partial float GetScaleX();

    [MemberFunction("E8 ?? ?? ?? ?? 49 8D 7E 1E")]
    public partial float GetScaleY();

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 44 1E")]
    public partial void SetScale(float X, float Y);

    [MemberFunction("E9 ?? ?? ?? ?? F3 0F 5E CA")]
    public partial void SetScaleX(float x);

    [MemberFunction("E9 ?? ?? ?? ?? 48 8B 51 10")]
    public partial void SetScaleY(float y);

    [MemberFunction("E8 ?? ?? ?? ?? F3 0F 58 C7 0F 28 D6")]
    public partial float GetXFloat();

    [MemberFunction("E8 ?? ?? ?? ?? 0F BE 43 10")]
    public partial float GetYFloat();

    [MemberFunction("E8 ?? ?? ?? ?? 66 29 46")]
    public partial short GetXShort();

    [MemberFunction("E8 ?? ?? ?? ?? 41 2A C4")]
    public partial short GetYShort();

    [MemberFunction("E8 ?? ?? ?? ?? 41 0F B7 FF")]
    public partial void SetXFloat(float x);

    [MemberFunction("E8 ?? ?? ?? ?? 41 83 FE 1C")]
    public partial void SetYFloat(float y);

    [MemberFunction("E8 ?? ?? ?? ?? 4A 8B 9C E5")]
    public partial void SetXShort(short x);

    [MemberFunction("E8 ?? ?? ?? ?? 41 8B 54 9C")]
    public partial void SetYShort(short y);

    [MemberFunction("E8 ?? ?? ?? ?? 66 03 C0")]
    public partial ushort GetWidth();

    [MemberFunction("E8 ?? ?? ?? ?? 66 03 85")]
    public partial ushort GetHeight();

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 8D ?? ?? ?? ?? 0F BF C6")]
    public partial void SetWidth(ushort width);

    [MemberFunction("E8 ?? ?? ?? ?? 41 8B 17 48 8B CD")]
    public partial void SetHeight(ushort height);

    [MemberFunction("E8 ?? ?? ?? ?? 44 0F 28 8C 24 ?? ?? ?? ?? 48 8D 9F")]
    public partial float GetRotation();

    [MemberFunction("E8 ?? ?? ?? ?? 49 8B 45 ?? 44 0F 28 44 24")]
    public partial void SetRotation(float rotation);

    [MemberFunction("E8 ?? ?? ?? ?? EB ?? 0F 57 C0 F3 0F 59 C6")]
    public partial float GetRotationDegrees();

    [MemberFunction("E8 ?? ?? ?? ?? 4D 8D 7E 28")]
    public partial void SetRotationDegrees(float rotation);

    [MemberFunction("E8 ?? ?? ?? ?? 48 63 46 30")]
    public partial void SetAlpha(byte alpha);

    [MemberFunction("E8 ?? ?? ?? ?? 8B 4D ?? 0F B7 C0")]
    public partial ushort GetPriority();

    [MemberFunction("E8 ?? ?? ?? ?? 33 D2 48 8B 8C 24")]
    public partial void SetPriority(ushort priority);

    [MemberFunction("E8 ?? ?? ?? ?? 3C 01 75 7F")]
    public partial bool IsVisible();

    [MemberFunction("E8 ?? ?? ?? ?? 48 83 C7 08 48 83 EE 01 75 D5 48 8B 4C 24 ??")]
    public partial void ToggleVisibility(bool enable);

    [MemberFunction("E8 ?? ?? ?? ?? FF C3 3B DE 72 E6")]
    public partial void SetUseDepthBasedPriority(bool enable);

    [MemberFunction("E8 ?? ?? ?? ?? 41 0F 28 C9 8B 87")]
    public partial void SetOrigin(float originX, float originY);

    [MemberFunction("E8 ?? ?? ?? ?? 66 41 3B C4 75")]
    public partial ushort GetTimelineLabel();

    [MemberFunction("48 85 C9 74 12 48 8B 41 10")]
    public partial void EnableTimeline();

    [MemberFunction("E8 ?? ?? ?? ?? 33 FF 39 BD")]
    public partial void DisableTimeline();

    [MemberFunction("E8 ?? ?? ?? ?? 41 3A C6 74 22")]
    public partial bool IsAnimated();

    [VirtualFunction(1)]
    public partial void Destroy(bool free);

    [VirtualFunction(2)]
    public partial void UpdateFromTimeline();
}

// 'visible' will change visibility immediately, the rest rely on other stuff to happen so they dont do anything
// top and bottom assumed based on a scrollbar, lots of left-aligned text has AnchorLeft set
[Flags]
public enum NodeFlags : ushort {
    AnchorTop = 0x01,
    AnchorLeft = 0x02,
    AnchorBottom = 0x04,
    AnchorRight = 0x08,
    Visible = 0x10,
    Enabled = 0x20, // this is like, "button can be clicked" etc
    Clip = 0x40,
    Fill = 0x80,

    // set if node type == 8, might be "HasCollision", also set if Unk2 first bit is set
    // https://github.com/NotAdam/Lumina/blob/714a1d8b9c4e182b411e7c68330d49a5dfccb9bc/src/Lumina/Data/Parsing/Uld/UldRoot.cs#L273
    HasCollision = 0x100,
    RespondToMouse = 0x200, // this also gets set if the above flag is set
    Focusable = 0x400,
    Droppable = 0x800,
    IsTopNode = 0x1000,
    EmitsEvents = 0x2000,
    UseDepthBasedPriority = 0x4000,
    UnkFlag2 = 0x8000
}
