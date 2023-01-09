namespace FFXIVClientStructs.FFXIV.Component.GUI;
// Component::GUI::AtkUnitBase
//   Component::GUI::AtkEventListener

// base class for all AddonXXX classes (visible UI objects)

// size = 0x220
// ctor E8 ?? ?? ?? ?? 83 8B ?? ?? ?? ?? ?? 33 C0

[StructLayout(LayoutKind.Explicit, Size = 0x220)]
public unsafe partial struct AtkUnitBase
{
    [FieldOffset(0x0)] public AtkEventListener AtkEventListener;
    [FieldOffset(0x8)] public fixed byte Name[0x20];
    [FieldOffset(0x28)] public AtkUldManager UldManager;
    [FieldOffset(0xC8)] public AtkResNode* RootNode;
    [FieldOffset(0xD0)] public AtkCollisionNode* WindowCollisionNode;
    [FieldOffset(0xD8)] public AtkCollisionNode* WindowHeaderCollisionNode;
    [FieldOffset(0xE0)] public AtkResNode* CursorTarget; // Likely always AtkCollisionNode
    [FieldOffset(0x108)] public AtkComponentNode* WindowNode;
    [FieldOffset(0x160)] public AtkValue* AtkValues;
    [FieldOffset(0x1AC)] public float Scale;
    [FieldOffset(0x182)] public byte Flags;
    [FieldOffset(0x1B6)] public byte VisibilityFlags;
    [FieldOffset(0x1BC)] public short X;
    [FieldOffset(0x1BE)] public short Y;
    [FieldOffset(0x1CA)] public ushort AtkValuesCount;
    [FieldOffset(0x1CC)] public ushort ID;
    [FieldOffset(0x1CE)] public ushort ParentID;
    [FieldOffset(0x1D0)] public ushort UnknownID;
    [FieldOffset(0x1D2)] public ushort ContextMenuParentID;
    [FieldOffset(0x1D5)] public byte Alpha;

    [FieldOffset(0x1D8)] public AtkResNode**
        CollisionNodeList; // seems to be all collision nodes in tree, may be something else though

    [FieldOffset(0x1E0)] public uint CollisionNodeListCount;

    public bool IsVisible
    {
        get => (Flags & 0x20) == 0x20;
        set => Flags = value ? Flags |= 0x20 : Flags &= 0xDF;
    }

    [MemberFunction("E8 ?? ?? ?? ?? 0F BF CB 0F 28 F8")]
    public partial float GetScale();

    [MemberFunction("E8 ?? ?? ?? ?? 0F BF 45 00")]
    public partial float GetGlobalUIScale();

    [MemberFunction("E8 ?? ?? ?? ?? 4C 8D 34 ED")]
    public partial AtkResNode* GetNodeById(uint nodeId);
    
    [MemberFunction("E8 ?? ?? ?? ?? 8D 56 1E")]
    public partial AtkTextNode* GetTextNodeById(uint nodeId);

    [MemberFunction("E8 ?? ?? ?? ?? 8D 53 16")]
    public partial AtkImageNode* GetImageNodeById(uint nodeId);

    [MemberFunction("E9 ?? ?? ?? ?? 83 FB 15")]
    public partial byte FireCallbackInt(int callbackValue);

    [MemberFunction("E8 ?? ?? ?? ?? 8B 44 24 20 C1 E8 05")]
    public partial void FireCallback(int valueCount, AtkValue* values, void* a4 = null);

    [MemberFunction("E8 ?? ?? ?? ?? F6 46 40 0F")]
    public partial void UpdateCollisionNodeList(bool clearFocus);

    [MemberFunction("E8 ?? ?? ?? ?? 8D 77 02")]
    public partial bool SetFocusNode(AtkResNode* node, bool a3 = false, uint a4 = 0);

    [VirtualFunction(3)]
    public partial bool Show(int unkInt, bool unkBool = false);

    [VirtualFunction(4)]
    public partial bool Hide(bool unknown);

    [VirtualFunction(7)]
    public partial void SetPosition(short x, short y);

    [VirtualFunction(49)]
    public partial void OnUpdate(NumberArrayData** numberArrayData, StringArrayData** stringArrayData);

    [MemberFunction("E9 ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 8D 15")]
    [GenerateCStrOverloads]
    public partial bool LoadUldByName(byte* name, byte a3 = 0, uint a4 = 6);
}