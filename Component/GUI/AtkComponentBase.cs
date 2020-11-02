using System.Net.Configuration;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace FFXIVClientStructs.Component.GUI
{    public enum ComponentType
    { 
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
        // added since 2.3, no rtti, but derives from Button
        UnknownButton = 24
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x9)]
    public unsafe struct ComponentDataBase
    {
        [FieldOffset(0x0)] public byte Index;
        [FieldOffset(0x1)] public byte Up;
        [FieldOffset(0x2)] public byte Down;
        [FieldOffset(0x3)] public byte Left;
        [FieldOffset(0x4)] public byte Right;
        [FieldOffset(0x5)] public byte Cursor;
        [FieldOffset(0x6)] public byte OffsetX; // short in .uld file
        [FieldOffset(0x7)] public byte OffsetY; // short in .uld file
        [FieldOffset(0x8)] public byte Unk;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public unsafe struct ComponentDataButton
    {
        [FieldOffset(0x00)] public ComponentDataBase Base;
        [FieldOffset(0x0C)] public fixed uint Nodes[2];
        [FieldOffset(0x14)] public uint TextId;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x38)]
    public unsafe struct ComponentDataWindow
    {
        [FieldOffset(0x00)] public ComponentDataBase Base;
        [FieldOffset(0x0C)] public fixed uint Nodes[8];
        [FieldOffset(0x2C)] public uint TitleTextId;
        [FieldOffset(0x30)] public uint SubtitleTextId;
        [FieldOffset(0x34)] public byte ShowCloseButton;
        [FieldOffset(0x35)] public byte ShowConfigButton;
        [FieldOffset(0x36)] public byte ShowHelpButton;
        [FieldOffset(0x37)] public byte ShowHeader;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public unsafe struct ComponentInfo
    {
        [FieldOffset(0x0)] public uint Id;
        [FieldOffset(0x4)] public int NodeCount;
        [FieldOffset(0x8)] public AtkResNode** NodeList;
        [FieldOffset(0x10)] public byte ComponentType;
    }

    // seems to be the samne as the addon data in AtkUnitBase but there's a componentinfo pointer instead of widgetinfo
    // probably WidgetInfo/ComponentInfo share a base class and it is the same object here
    [StructLayout(LayoutKind.Explicit, Size = 0x90)]
    public unsafe struct ULDAddonDataComponent
    {
        [FieldOffset(0x00)] public TextureInfo* Textures; // array with size TextureCount
        [FieldOffset(0x08)] public TPInfo* TPs; // array with size TPCount
        [FieldOffset(0x10)] public ComponentInfo* Component; // ComponentCount is always 1
        [FieldOffset(0x18)] public ComponentDataBase* ComponentData; // need to cast this to the appropriate one for your component type
        [FieldOffset(0x20)] public ushort TextureCount;
        [FieldOffset(0x22)] public ushort TPCount;
        [FieldOffset(0x24)] public ushort ComponentCount; // always 1
        [FieldOffset(0x28)] public void* UldResourceHandle; // unlike with AtkUnitBase this pointer is not released
        [FieldOffset(0x42)] public ushort NodeListCount;
        [FieldOffset(0x48)] public void* AtkResourceRendererManager;
        [FieldOffset(0x50)] public AtkResNode** NodeList;
        [FieldOffset(0x78)] public AtkResNode* RootNode;
        [FieldOffset(0x80)] public ushort RootNodeWidth;
        [FieldOffset(0x82)] public ushort RootNodeHeight;
        [FieldOffset(0x86)] public byte Flags1; 
        [FieldOffset(0x89)] public byte LoadedState;
    }

    // Component::GUI::AtkComponentBase
    //   Component::GUI::AtkEventListener

    // base class for UI components that are more complicated than a single node

    // size = 0xC0
    // common CreateAtkComponent function 8B FA 33 DB E8 ? ? ? ? 
    // type 0
    [StructLayout(LayoutKind.Explicit, Size = 0xC0)]
    public unsafe struct AtkComponentBase
    {
        [FieldOffset(0x00)] public AtkEventListener AtkEventListener;
        [FieldOffset(0x08)] public ULDAddonDataComponent AddonData;
        [FieldOffset(0xA8)] public AtkComponentNode* OwnerNode;
    }
}
