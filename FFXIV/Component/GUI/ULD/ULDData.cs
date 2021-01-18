using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Component.GUI.ULD
{
    // used in both addons (AtkUnitBase derived classes) and components (AtkComponontBase derived classes) to read data from uld files
    // this data is generally later copied out to specific fields in the addons/components
    [StructLayout(LayoutKind.Explicit, Size = 0x90)]
    public unsafe struct ULDData
    {
        [FieldOffset(0x00)] public ULDTexture* Textures; // array with size TextureCount, "ashd" (asset) header
        [FieldOffset(0x08)] public ULDPartsList* PartsList; // array with size PartsListcount, "tphd" header 
        [FieldOffset(0x10)] public ULDObjectInfo* Objects; // cast to ULDWidgetInfo or ULDComponentInfo depending on base type
        [FieldOffset(0x18)] public ULDComponentDataBase* ComponentData; // need to cast this to the appropriate one for your component type
        [FieldOffset(0x20)] public ushort TextureCount;
        [FieldOffset(0x22)] public ushort PartsListCount;
        [FieldOffset(0x24)] public ushort ObjectCount; 
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
