using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::Atk2DMap
//   Client::UI::Atk2DAreaMap
[GenerateInterop]
[Inherits<Atk2DMap>]
[StructLayout(LayoutKind.Explicit, Size = 0xA8)]
public unsafe partial struct Atk2DAreaMap {
    [FieldOffset(0x50)] public float SavedMarkerRadiusScale;
    /// <remarks> Center is 0. </remarks>
    [FieldOffset(0x54)] public float MapOffsetX;
    /// <remarks> Center is 0. </remarks>
    [FieldOffset(0x58)] public float MapOffsetY;
    /// <remarks> TelepotTown: 0.57 or 0.28 </remarks>
    [FieldOffset(0x5C)] public float MapScale;
    /// <remarks> Multiplier for DragCursorX/DragCursorY, calculated as <c>1.0 / MapScale</c> </remarks>
    [FieldOffset(0x60)] public float DragSpeed;
    [FieldOffset(0x64)] public float DragCursorX;
    [FieldOffset(0x68)] public float DragCursorY;
    [FieldOffset(0x6C)] public float PlayerMarkerX;
    [FieldOffset(0x70)] public float PlayerMarkerY;
    [FieldOffset(0x74)] public float FollowedPlayerMarkerX;
    [FieldOffset(0x78)] public float FollowedPlayerMarkerY;
    [FieldOffset(0x7C)] public float MapCenterX;
    [FieldOffset(0x80)] public float MapCenterY;

    [FieldOffset(0x88)] public AtkComponentMap* ComponentMap;
    [FieldOffset(0x90)] public AreaMapMarker* MarkerMemory; // struct of size 0x38 * MarkerMemorySize
    [FieldOffset(0x98)] public ushort MarkerMemorySize; // count for MarkerMemory
    [FieldOffset(0x9A)] private short Unk9A;
    [FieldOffset(0x9C)] private byte Unk9C;
    [FieldOffset(0x9D)] private byte Unk9D;
    [FieldOffset(0x9E), FixedSizeArray] internal FixedSizeArray5<ushort> _unkTimelineLabelIdsMaybe;

    public Span<AreaMapMarker> Markers => new(MarkerMemory, MarkerMemorySize);

    [MemberFunction("E8 ?? ?? ?? ?? 49 8D 4F ?? E8 ?? ?? ?? ?? 8B C8")]
    public partial void CreateMarkerArray(uint size);

    [MemberFunction("E8 ?? ?? ?? ?? 48 85 C0 74 ?? 44 38 70 ?? 74")]
    public partial AreaMapMarker* GetMarker(uint index);

    [MemberFunction("E8 ?? ?? ?? ?? 48 85 C0 74 ?? 48 8B C8 E8 ?? ?? ?? ?? 33 D2 48 8B C8 E8 ?? ?? ?? ?? FF C7")]
    public partial MapMarkerNodeContainer* GetMarkerNodeContainer(uint index);

    [MemberFunction("E8 ?? ?? ?? ?? 0F 28 B4 24 ?? ?? ?? ?? 49 8D 8F")]
    public partial void SetComponentMap(AtkComponentMap* component);

    /// <remarks> Makes sure <see cref="MapOffsetX"/> and <see cref="MapOffsetY"/> are between +/-<see cref="MapCenterX"/> and +/-<see cref="MapCenterY"/>. </remarks>
    [MemberFunction("E8 ?? ?? ?? ?? 8B 86 ?? ?? ?? ?? 0F 28 D6")]
    public partial bool ClampPosition();

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 43 ?? 45 32 E4")]
    public partial bool SetMarkerRadiusScale(float value);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 0F 28 F0 E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 0F B6 D8")]
    public partial void HandleDragPosition(float x, float y);

    [MemberFunction("E8 ?? ?? ?? ?? 8B 86 ?? ?? ?? ?? 89 86 ?? ?? ?? ?? 8B 86 ?? ?? ?? ?? 89 86 ?? ?? ?? ?? 48 8B 45")]
    public partial void CenterOnPlayer();

    [StructLayout(LayoutKind.Explicit, Size = 0x38)]
    public unsafe struct AreaMapMarker {
        [FieldOffset(0x00)] public MapMarkerNodeContainer* NodeContainer;

        [FieldOffset(0x0C)] public byte Type;

        [FieldOffset(0x14)] public short X;
        [FieldOffset(0x16)] public short Y;
    }
}
