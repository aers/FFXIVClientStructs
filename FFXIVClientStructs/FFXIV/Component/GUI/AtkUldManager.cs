using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

// used in both addons (AtkUnitBase derived classes) and components (AtkComponentBase derived classes) to read data from uld files
// also used to render UI components
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x90)]
public unsafe partial struct AtkUldManager {
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

    [FieldOffset(0x00)] public AtkUldAsset* Assets; // array with size AssetCount, "ashd" (asset) header
    [FieldOffset(0x08)] public AtkUldPartsList* PartsList; // array with size PartsListCount, "tphd" header 
    [FieldOffset(0x10)] public AtkUldObjectInfo* Objects; // cast to AtkUldWidgetInfo or AtkUldComponentInfo depending on base type
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
    [FieldOffset(0x86)] public byte Flags1;
    [FieldOffset(0x89)] public AtkLoadState LoadedState; // 3 is fully loaded

    [MemberFunction("40 53 48 83 EC 20 48 8B D9 E8 ?? ?? ?? ?? 45 33 C9 4C 8B C0")]
    public partial void InitializeResourceRendererManager();
    
    [MemberFunction("F6 81 ?? ?? ?? ?? ?? 44 8B CA 74 42")]
    public partial AtkResNode* SearchNodeById(uint id);

    [MemberFunction("E8 ?? ?? ?? ?? 4C 8B F0 48 85 C0 0F 84 ?? ?? ?? ?? 49 8B 4D 08")]
    public partial AtkComponentBase* CreateAtkComponent(ComponentType type);

    [MemberFunction("E8 ?? ?? ?? ?? 49 8B 55 08 48 89 04 13")]
    public partial AtkResNode* CreateAtkNode(NodeType type);

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

    [MemberFunction("E8 ?? ?? ?? ?? 49 8B 44 24 ?? 41 8B CF")]
    public partial void UpdateDrawNodeList();
}

public enum AtkLoadState : byte {
    Unloaded = 0,
    ResourceLoading = 1,
    TexturesLoading = 2,
    Loaded = 3,
    LoadError = 4
}
