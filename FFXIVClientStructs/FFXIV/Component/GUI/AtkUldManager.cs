using FFXIVClientStructs.Attributes;
using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Component.GUI
{
    // used in both addons (AtkUnitBase derived classes) and components (AtkComponontBase derived classes) to read data from uld files
    // also used to render UI components
    [StructLayout(LayoutKind.Explicit, Size = 0x90)]
    public unsafe partial struct AtkUldManager
    {
        [FieldOffset(0x00)] public AtkUldAsset* Assets; // array with size AssetCount, "ashd" (asset) header
        [FieldOffset(0x08)] public AtkUldPartsList* PartsList; // array with size PartsListcount, "tphd" header 

        [FieldOffset(0x10)]
        public AtkUldObjectInfo* Objects; // cast to AtkUldWidgetInfo or AtkUldComponentInfo depending on base type

        [FieldOffset(0x18)]
        public AtkUldComponentDataBase*
            ComponentData; // need to cast this to the appropriate one for your component type

        [FieldOffset(0x20)] public ushort AssetCount;
        [FieldOffset(0x22)] public ushort PartsListCount;
        [FieldOffset(0x24)] public ushort ObjectCount;
        [FieldOffset(0x26)] public ushort UnknownCount; // not sure what but used alongside object count
        [FieldOffset(0x28)] public void* UldResourceHandle; // addons release this reference, components do not
        [FieldOffset(0x42)] public ushort NodeListCount;
        [FieldOffset(0x48)] public void* AtkResourceRendererManager;
        [FieldOffset(0x50)] public AtkResNode** NodeList;
        [FieldOffset(0x78)] public AtkResNode* RootNode;
        [FieldOffset(0x80)] public ushort RootNodeWidth;
        [FieldOffset(0x82)] public ushort RootNodeHeight;
        [FieldOffset(0x84)] public ushort NodeListSize; // this is the allocated size of nodelist, count is the amount of nodes it has
        [FieldOffset(0x86)] public byte Flags1;
        [FieldOffset(0x89)] public byte LoadedState; // 3 is fully loaded

        [MemberFunction("F6 81 ? ? ? ? ? 44 8B CA")]
        public partial AtkResNode* SearchNodeById(uint id);

        [MemberFunction("E8 ? ? ? ? 48 8B 4C 24 ? 48 8B 51 08")]
        public partial AtkResNode* CreateNodeByType(uint type);

        [MemberFunction("E8 ? ? ? ? 49 8B 4E 10 8B C5")]
        public partial void UpdateDrawNodeList();
    }
}