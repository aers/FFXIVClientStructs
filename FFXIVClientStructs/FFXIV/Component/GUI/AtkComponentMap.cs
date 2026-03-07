using FFXIVClientStructs.FFXIV.Client.System.Memory;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkComponentMap
//   Component::GUI::AtkComponentBase
//     Component::GUI::AtkEventListener
// type 22
[GenerateInterop]
[Inherits<AtkComponentBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x420)]
public unsafe partial struct AtkComponentMap : ICreatable {
    [FieldOffset(0xE0)] public AtkImageNode* PlayerCone;
    [FieldOffset(0xE8)] public AtkComponentNode* MarkerTemplate5; // NodeId 5
    [FieldOffset(0xF0)] public AtkComponentNode* MarkerTemplate6; // NodeId 6
    [FieldOffset(0xF8)] public AtkComponentNode* MarkerTemplate4; // NodeId 4
    [FieldOffset(0x100)] public AtkComponentNode* MarkerTemplate3; // NodeId 3
    [FieldOffset(0x108)] public AtkComponentNode* MarkerTemplate2; // NodeId 2
    [FieldOffset(0x110)] public AtkComponentNode* MarkerTemplate8; // NodeId 8

    [FieldOffset(0x138)] public AtkResourceRendererManager ResourceRendererManager;
    [FieldOffset(0x250)] public DiscoveryRenderer m_DiscoveryRenderer;
    // [FieldOffset(0x268)] public AtkRenderTexture RenderTexture;

    [FieldOffset(0x374)] public float MapScale;

    [FieldOffset(0x384)] public float MapOffsetX;
    [FieldOffset(0x388)] public float MapOffsetY;
    [FieldOffset(0x38C)] public float MapWidth;
    [FieldOffset(0x390)] public float MapHeight;

    [FieldOffset(0x3AC)] public uint NumMarkersType0;
    [FieldOffset(0x3B0)] public uint NumMarkersType1;
    [FieldOffset(0x3B4)] public uint NumMarkersType2;
    [FieldOffset(0x3B8)] public uint NumMarkersType3;
    [FieldOffset(0x3BC)] public uint NumMarkersType4;
    [FieldOffset(0x3C0)] public MapMarkerNodeContainer* MarkerNodeContainerMemoryType0;
    [FieldOffset(0x3C8)] public MapMarkerNodeContainer* MarkerNodeContainerMemoryType1;
    [FieldOffset(0x3D0)] public MapMarkerNodeContainer* MarkerNodeContainerMemoryType2;
    [FieldOffset(0x3D8)] public MapMarkerNodeContainer* MarkerNodeContainerMemoryType3;
    [FieldOffset(0x3E0)] public MapMarkerNodeContainer* MarkerNodeContainerMemoryType4;
    [FieldOffset(0x3E8)] public AtkGrid Grid;

    [MemberFunction("48 89 5C 24 ?? 57 48 83 EC 20 33 FF C7 81 ?? ?? ?? ?? ?? ?? ?? ?? 48 8D 05")]
    public partial void Ctor();

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 4F ?? 0F 57 D2")]
    public partial void SetMapScale(float scale);

    /// <remarks> (0, 0) is the center of the map texture. </remarks>
    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 4F ?? 33 D2 48 8B 89")]
    public partial void SetMapOffset(float x, float y);

    [MemberFunction("E8 ?? ?? ?? ?? F3 41 0F 10 8E ?? ?? ?? ?? 48 8B CF")]
    public partial void SetMapSize(float width, float height);

    // Component::GUI::AtkComponentMap::DiscoveryRenderer
    //   Component::GUI::AtkImageNodeRenderer
    //     Component::GUI::AtkResourceRendererBase
    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public struct DiscoveryRenderer {
        [FieldOffset(0x10)] public AtkComponentMap* ComponentMap;
    }
}

[StructLayout(LayoutKind.Explicit, Size = 0x88)]
public unsafe struct MapMarkerNodeContainer {
    [FieldOffset(0x80)] private byte Unk80;
}
