using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Component.GUI
{
    // used in both addons (AtkUnitBase derived classes) and components (AtkComponontBase derived classes) to read data from uld files
    // also used to render UI components
    [StructLayout(LayoutKind.Explicit, Size = 0x90)]
    public unsafe struct AtkUldManager
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
        [FieldOffset(0x86)] public byte Flags1;
        [FieldOffset(0x89)] public byte LoadedState; // 3 is fully loaded
    }
}