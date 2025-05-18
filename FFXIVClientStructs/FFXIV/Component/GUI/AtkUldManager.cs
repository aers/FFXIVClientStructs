using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

// used in both addons (AtkUnitBase derived classes) and components (AtkComponentBase derived classes) to read data from uld files
// also used to render UI components
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x90)]
public unsafe partial struct AtkUldManager {
    [FieldOffset(0x00)] public AtkUldAsset* Assets; // array with size AssetCount, "ashd" (asset) header
    [FieldOffset(0x08)] public AtkUldPartsList* PartsList; // array with size PartsListCount, "tphd" header
    /// <remarks>
    /// Needs to be cast to <see cref="AtkUldComponentInfo"/>* if <see cref="BaseType"/> is <see cref="AtkUldManagerBaseType.Component"/>,<br/>
    /// or to <see cref="AtkUldWidgetInfo"/>* if <see cref="BaseType"/> is <see cref="AtkUldManagerBaseType.Widget"/>.
    /// </remarks>
    [FieldOffset(0x10)] public AtkUldObjectInfo* Objects;
    [FieldOffset(0x18)] public AtkUldComponentDataBase* ComponentData; // need to cast this to the appropriate one for your component type
    [FieldOffset(0x20)] public ushort AssetCount;
    [FieldOffset(0x22)] public ushort PartsListCount;
    [FieldOffset(0x24)] public ushort ObjectCount;
    [FieldOffset(0x26)] public ushort DuplicateObjectCount; // duplicated components created by AtkUldManager::DuplicateNode post-load
    [FieldOffset(0x28)] public ResourceHandle* UldResourceHandle; // addons release this reference, components do not
    [FieldOffset(0x30)] public DuplicateNodeInfo* DuplicateNodeInfoList; // these are nodes duplicated by the loader during load
    [FieldOffset(0x38)] public AtkTimelineManager* TimelineManager;
    [FieldOffset(0x40)] public ushort DrawOrderIndex;
    [FieldOffset(0x42)] public ushort NodeListCount;
    [FieldOffset(0x48)] public AtkResourceRendererManager* ResourceRendererManager;
    [FieldOffset(0x50)] public AtkResNode** NodeList;
    [FieldOffset(0x58)] public StdLinkedList<Pointer<DuplicateObjectList>> DuplicateObjectsList; // linked list of lists of duplicates
    [FieldOffset(0x78)] public AtkResNode* RootNode;
    [FieldOffset(0x80)] public ushort RootNodeWidth;
    [FieldOffset(0x82)] public ushort RootNodeHeight;
    [FieldOffset(0x84)] public ushort NodeListSize; // this is the allocated size of nodelist, count is the amount of nodes it has
    [FieldOffset(0x86), Obsolete("Use ResourceFlags")] public byte Flags1;
    [FieldOffset(0x86)] public AtkUldManagerResourceFlag ResourceFlags;
    [FieldOffset(0x88)] public AtkUldManagerBaseType BaseType;
    [FieldOffset(0x89)] public AtkLoadState LoadedState; // 3 is fully loaded

    public Span<Pointer<AtkResNode>> Nodes => new(NodeList, NodeListCount);

    [MemberFunction("40 53 48 83 EC 20 48 8B D9 E8 ?? ?? ?? ?? 45 33 C9 4C 8B C0")]
    public partial void InitializeResourceRendererManager();

    [MemberFunction("F6 81 ?? ?? ?? ?? ?? 44 8B CA 74 42")]
    public partial AtkResNode* SearchNodeById(uint id);

    [MemberFunction("E8 ?? ?? ?? ?? 4C 8B F0 48 85 C0 0F 84 ?? ?? ?? ?? 49 8B 4D 08")]
    public partial AtkComponentBase* CreateAtkComponent(ComponentType type); // TODO: takes (u)int param but enum is byte

    [MemberFunction("E8 ?? ?? ?? ?? 49 8B 55 08 48 89 04 17")]
    public partial AtkResNode* CreateAtkNode(NodeType type); // TODO: takes uint param but enum is ushort

    public static AtkResNode* CreateAtkNodeStatic(NodeType type) => MemberFunctionPointers.CreateAtkNode(null, type);

    public static AtkResNode* CreateAtkResNode() {
        return CreateAtkNodeStatic(NodeType.Res);
    }

    public static AtkImageNode* CreateAtkImageNode() {
        return (AtkImageNode*)CreateAtkNodeStatic(NodeType.Image);
    }

    public static AtkTextNode* CreateAtkTextNode() {
        return (AtkTextNode*)CreateAtkNodeStatic(NodeType.Text);
    }

    public static AtkNineGridNode* CreateAtkNineGridNode() {
        return (AtkNineGridNode*)CreateAtkNodeStatic(NodeType.NineGrid);
    }

    public static AtkCounterNode* CreateAtkCounterNode() {
        return (AtkCounterNode*)CreateAtkNodeStatic(NodeType.Counter);
    }

    public static AtkCollisionNode* CreateAtkCollisionNode() {
        return (AtkCollisionNode*)CreateAtkNodeStatic(NodeType.Collision);
    }

    [MemberFunction("E8 ?? ?? ?? ?? 66 41 3B B7")]
    public partial void ExpandNodeListSize(ushort newNodeListSize);

    [MemberFunction("E8 ?? ?? ?? ?? 49 8B 44 24 ?? 41 8B CF")]
    public partial void UpdateDrawNodeList();

    [MemberFunction("40 57 48 83 EC 30 0F B6 81 ?? ?? ?? ?? 48 8B F9 A8 01")]
    public partial void Finalizer();

    [StructLayout(LayoutKind.Explicit, Size = 0x8)]
    public struct DuplicateNodeInfo {
        [FieldOffset(0x0)] public uint NodeId;
        [FieldOffset(0x4)] public uint Count;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public struct DuplicateObjectList {
        [FieldOffset(0x0)] public AtkComponentNode* NodeList;
        [FieldOffset(0x8)] public uint NodeCount;
    }
}

[Flags]
public enum AtkUldManagerResourceFlag : byte {
    None = 0,
    /// <summary> A flag to indicate UldManager itself is Initialized (Initialize from AtkUnitBase or AtkComponentBase was called). </summary>
    Initialized = 1 << 0,
    /// <summary> Keeps the UldResourceHandle after loading data from it, so duplicate nodes can read data later on. </summary>
    KeepUldResourceHandle = 1 << 1,
    /// <summary> Objects and NodeList were allocated. </summary>
    ArraysAllocated = 1 << 2,
    /// <summary> Set with <code>(*(_DWORD *)&amp;RootNode->Priority &amp; 0x400000) != 0</code> and is read for calling DrawUldFromDataClipped instead of DrawUldFromData. </summary>
    ClippedDraw = 1 << 3,
    /// <summary> Enables to check the ThemeSupportBitmask of a TextureEntry when loading assets. </summary>
    AssetsHaveThemeSupport = 1 << 4,
    ContainsClippingMaskNode = 1 << 5,
}

public enum AtkLoadState : byte {
    Unloaded = 0,
    ResourceLoading = 1,
    TexturesLoading = 2,
    Loaded = 3,
    LoadError = 4
}

public enum AtkUldManagerBaseType : byte {
    None = 0,
    Component = 1,
    Widget = 2,
}

public enum NodeType : ushort {
    Res = 1,
    Image = 2,
    Text = 3,
    NineGrid = 4,
    Counter = 5,

    Collision = 8,
    ClippingMask = 10,

    /// <remarks> Components are >=1000, but <see cref="AtkResNode.GetNodeType"/> returns 10000 for them. </remarks>
    Component = 10000
}

public enum ComponentType : byte {
    Base = 0,
    Button = 1,
    Window = 2,
    CheckBox = 3,
    RadioButton = 4,
    GaugeBar = 5,
    Slider = 6,
    TextInput = 7,
    NumericInput = 8,
    List = 9,
    DropDownList = 10,
    Tab = 11,
    TreeList = 12,
    ScrollBar = 13,
    ListItemRenderer = 14,
    Icon = 15,
    IconText = 16,
    DragDrop = 17,
    GuildLeveCard = 18,
    TextNineGrid = 19,
    JournalCanvas = 20,
    Multipurpose = 21,
    Map = 22,
    Preview = 23,
    HoldButton = 24,
    Portrait = 25,
}
