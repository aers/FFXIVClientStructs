using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkUnitBase
//   Component::GUI::AtkEventListener
// ctor "E8 ?? ?? ?? ?? 83 8B ?? ?? ?? ?? ?? 33 C0"
// base class for all AddonXXX classes (visible UI objects)
[StructLayout(LayoutKind.Explicit, Size = 0x220)]
public unsafe partial struct AtkUnitBase {
    [FieldOffset(0x0)] public AtkEventListener AtkEventListener;
    [FieldOffset(0x8)] public fixed byte Name[0x20];
    [FieldOffset(0x28)] public AtkUldManager UldManager;
    [FieldOffset(0xC8)] public AtkResNode* RootNode;
    [FieldOffset(0xD0)] public AtkCollisionNode* WindowCollisionNode;
    [FieldOffset(0xD8)] public AtkCollisionNode* WindowHeaderCollisionNode;
    [FieldOffset(0xE0)] public AtkResNode* CursorTarget; // Likely always AtkCollisionNode
    [FieldOffset(0x100)] public AtkComponentNode* CurrentDropDownOwnerNode;
    [FieldOffset(0x108)] public AtkComponentNode* WindowNode;
    [FieldOffset(0x110)] public AtkSimpleTween RootNodeTween; // used for open/close transitions
    [FieldOffset(0x160)] public AtkValue* AtkValues;
    [FieldOffset(0x182)] public byte Flags;
    [FieldOffset(0x194)] public uint OpenTransitionDuration;
    [FieldOffset(0x198)] public uint CloseTransitionDuration;
    [FieldOffset(0x1A1)] public byte NumOpenPopups; // used for dialogs and context menus to block inputs via ShouldIgnoreInputs
    [FieldOffset(0x1A4)] public float OpenTransitionScale;
    [FieldOffset(0x1A8)] public float CloseTransitionScale;
    [FieldOffset(0x1AC)] public float Scale;
    [FieldOffset(0x1B6)] public byte VisibilityFlags;
    [FieldOffset(0x1B8)] public ushort DrawOrderIndex;
    [FieldOffset(0x1BC)] public short X;
    [FieldOffset(0x1BE)] public short Y;
    [FieldOffset(0x1C0)] public short OpenTransitionOffsetX;
    [FieldOffset(0x1C2)] public short OpenTransitionOffsetY;
    [FieldOffset(0x1C4)] public short CloseTransitionOffsetX;
    [FieldOffset(0x1C6)] public short CloseTransitionOffsetY;
    [FieldOffset(0x1C8)] public short OpenSoundEffectId;
    [FieldOffset(0x1CA)] public ushort AtkValuesCount;
    [FieldOffset(0x1CC)] public ushort ID;
    [FieldOffset(0x1CE)] public ushort ParentID;
    [FieldOffset(0x1D0)] public ushort HostID; // for example, in CharacterProfile this holds the ID of the Character addon
    [Obsolete("Use HostID")]
    [FieldOffset(0x1D0)] public ushort UnknownID;
    [FieldOffset(0x1D2)] public ushort ContextMenuParentID;
    [FieldOffset(0x1D5)] public byte Alpha;
    [FieldOffset(0x1D6)] public byte ShowHideFlags;
    [FieldOffset(0x1D8)] public AtkResNode** CollisionNodeList; // seems to be all collision nodes in tree, may be something else though
    [FieldOffset(0x1E0)] public uint CollisionNodeListCount;

    public int DepthLayer => Flags & 0xF;

    public bool IsVisible {
        get => (Flags & 0x20) == 0x20;
        set => Flags = value ? Flags |= 0x20 : Flags &= 0xDF;
    }

    [MemberFunction("E8 ?? ?? ?? ?? 0F BF CB 0F 28 F8")]
    public partial float GetScale();

    [MemberFunction("E8 ?? ?? ?? ?? F2 0F 10 77")]
    public partial void SetSize(ushort width, ushort height);

    [MemberFunction("E8 ?? ?? ?? ?? 40 2A C7")]
    public partial float GetScaledWidth(bool getScaledWidth); // False returns unscaled width

    [MemberFunction("E8 ?? ?? ?? ?? 0F B7 57 5A")]
    public partial float GetScaledHeight(bool getScaledHeight); // False returns unscaled height

    [MemberFunction("E8 ?? ?? ?? ?? 0F BF 45 00")]
    public partial float GetGlobalUIScale();

    [MemberFunction("E8 ?? ?? ?? ?? 4C 8D 34 ED")]
    public partial AtkResNode* GetNodeById(uint nodeId);

    [MemberFunction("E8 ?? ?? ?? ?? 8D 56 1E")]
    public partial AtkTextNode* GetTextNodeById(uint nodeId);

    [MemberFunction("E8 ?? ?? ?? ?? 8D 53 16")]
    public partial AtkImageNode* GetImageNodeById(uint nodeId);

    [MemberFunction("E8 ?? ?? ?? ?? 8D 53 1B")]
    public partial AtkComponentButton* GetButtonNodeById(uint nodeId);

    [MemberFunction("E8 ?? ?? ?? ?? 41 B1 01 48 89 87")]
    public partial AtkComponentList* GetComponentListById(uint nodeId);

    [MemberFunction("E8 ?? ?? ?? ?? 8D 55 9F")]
    public partial AtkComponentNode* GetComponentNodeById(uint nodeId);

    [MemberFunction("E9 ?? ?? ?? ?? 83 FB 15")]
    public partial byte FireCallbackInt(int callbackValue);

    [MemberFunction("E8 ?? ?? ?? ?? 8B 44 24 20 C1 E8 05")]
    public partial void FireCallback(int valueCount, AtkValue* values, void* a4 = null); // TODO: a4 is a bool to hide/close the window (depends on flag +0x188 & 1)

    [MemberFunction("E8 ?? ?? ?? ?? F6 46 40 0F")]
    public partial void UpdateCollisionNodeList(bool clearFocus);

    [MemberFunction("E8 ?? ?? ?? ?? 8D 77 02")]
    public partial bool SetFocusNode(AtkResNode* node, bool a3 = false, uint a4 = 0);

    /// <param name="arrayType">0 for StringArrayData or 1 for NumberArrayData</param>
    /// <param name="arrayIndex">The index in AtkArrayDataHolder</param>
    [MemberFunction("E8 ?? ?? ?? ?? 44 8D 43 7A")]
    public partial void SubscribeAtkArrayData(byte arrayType, byte arrayIndex);

    /// <param name="arrayType">0 for StringArrayData or 1 for NumberArrayData</param>
    /// <param name="arrayIndex">The index in AtkArrayDataHolder</param>
    /// <param name="clean">Resets all values to default, also frees managed strings</param>
    [MemberFunction("E8 ?? ?? ?? ?? 45 33 C9 8D 56 01")]
    public partial void UnsubscribeAtkArrayData(byte arrayType, byte arrayIndex, bool clean = false);

    [VirtualFunction(2)]
    public partial void ReceiveEvent(AtkEventType eventType, int eventParam, AtkEvent* atkEvent, nint a5 = 0);

    [VirtualFunction(3)]
    public partial bool Open(uint depthLayer);

    [VirtualFunction(4)]
    public partial bool Close(bool fireCallback);

    [VirtualFunction(5)]
    public partial void Show(bool silenceOpenSoundEffect, uint unsetShowHideFlags);

    [VirtualFunction(6)]
    public partial void Hide(bool unkBool, bool callHideCallback, uint setShowHideFlags);

    [VirtualFunction(7)]
    public partial void SetPosition(short x, short y);

    [VirtualFunction(8)]
    public partial void SetX(short value);

    [VirtualFunction(9)]
    public partial void SetY(short value);

    [VirtualFunction(10)]
    public partial short GetX();

    [VirtualFunction(11)]
    public partial short GetY();

    [VirtualFunction(12)]
    public partial void GetPosition(short* outX, short* outY);

    [VirtualFunction(13)]
    public partial void SetAlpha(byte alpha);

    [VirtualFunction(14)]
    public partial void SetScale(float scale, bool a3);

    [VirtualFunction(15)]
    public partial void GetSize(short* outWidth, short* outHeight, bool scaled);

    [VirtualFunction(16)]
    public partial void Hide2();

    [VirtualFunction(17)]
    public partial sbyte SetScaleToHudLayoutScale();

    [VirtualFunction(18)]
    public partial bool ShouldCollideWithWindow(AtkCollisionNode* collisionNode);

    [VirtualFunction(22)]
    public partial bool ShouldIgnoreInputs();

    [VirtualFunction(23)]
    public partial AtkResNode* GetRootNode();

    [VirtualFunction(26)]
    public partial void GetWindowBounds(Bounds* outBounds); // tries to get it from WindowCollisionNode first, then from RootNode

    [VirtualFunction(29)]
    public partial void GetRootBounds(Bounds* outBounds);

    [VirtualFunction(36)]
    public partial void Focus();

    [VirtualFunction(40)]
    public partial void Initialize();

    /// <remarks>
    /// The name "Finalizer" is used instead of "Finalize" to avoid conflicts
    /// with the <see cref="System.Object.Finalize"/> method.
    /// </remarks>
    [VirtualFunction(41)]
    public partial void Finalizer();

    [VirtualFunction(42)]
    public partial void Update(float delta);

    [VirtualFunction(43)]
    public partial void Draw();

    [VirtualFunction(46)]
    public partial bool CheckWindowCollisionAtCoords(short x, short y);

    [VirtualFunction(48)]
    public partial void OnSetup(uint numValues, AtkValue* values);

    [VirtualFunction(50)]
    public partial void OnRefresh(uint numValues, AtkValue* values);

    [VirtualFunction(51)]
    public partial void OnUpdate(NumberArrayData** numberArrayData, StringArrayData** stringArrayData);

    [VirtualFunction(53)]
    public partial void FireCloseCallback();

    [VirtualFunction(61)]
    public partial void OnMouseOver();

    [VirtualFunction(62)]
    public partial void OnMouseOut();

    [MemberFunction("E9 ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 8D 15")]
    [GenerateCStrOverloads]
    public partial bool LoadUldByName(byte* name, byte a3 = 0, uint a4 = 6);

    [MemberFunction("E8 ?? ?? ?? ?? 8D 53 24")]
    public partial void SetOpenTransition(float duration, short offsetX, short offsetY, float scale);

    [MemberFunction("E8 ?? ?? ?? ?? 8D 55 06 48 8B CE")]
    public partial void SetCloseTransition(float duration, short offsetX, short offsetY, float scale);

    [MemberFunction("E8 ?? ?? ?? ?? 0F BF 8C 24 ?? ?? ?? ?? 01 8F")]
    public partial bool MoveDelta(short* xDelta, short* yDelta);
}
