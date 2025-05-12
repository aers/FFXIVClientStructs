using FFXIVClientStructs.FFXIV.Client.System.Memory;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkComponentBase
//   Component::GUI::AtkEventListener
// common CreateAtkComponent function "E8 ?? ?? ?? ?? 4C 8B F0 48 85 C0 0F 84 ?? ?? ?? ?? 49 8B 4D 08"
// type 0
// base class for UI components that are more complicated than a single node
[GenerateInterop(isInherited: true)]
[Inherits<AtkEventListener>]
[StructLayout(LayoutKind.Explicit, Size = 0xC0)]
public unsafe partial struct AtkComponentBase : ICreatable {
    [FieldOffset(0x08)] public AtkUldManager UldManager;
    [FieldOffset(0xA0)] public AtkResNode* AtkResNode;
    [FieldOffset(0xA8)] public AtkComponentNode* OwnerNode;

    [MemberFunction("48 8D 05 ?? ?? ?? ?? C7 81 ?? ?? ?? ?? ?? ?? ?? ?? 48 89 01 33 C0 48 89 41 08")]
    public partial void Ctor();

    [MemberFunction("E8 ?? ?? ?? ?? 8B 54 B5 D7")]
    public partial AtkComponentBase* GetComponentById(uint id);

    [MemberFunction("E8 ?? ?? ?? ?? 49 63 D7")]
    public partial AtkResNode* GetTextNodeById(uint id);

    [MemberFunction("E8 ?? ?? ?? ?? 8D 53 47")]
    public partial AtkResNode* GetImageNodeById(uint id);

    [MemberFunction("E8 ?? ?? ?? ?? 8B 53 F8")]
    public partial AtkResNode* GetScrollBarNodeById(uint id);

    [MemberFunction("E8 ?? ?? ?? ?? 41 3A C6 74 22")]
    public partial bool IsAnimated();

    [VirtualFunction(3)]
    public partial void Initialize();

    [VirtualFunction(4)]
    public partial void Deinitialize();

    [VirtualFunction(5)]
    public partial void Update(float delta);

    [VirtualFunction(5), Obsolete("Renamed to Update")]
    public partial void OnUldUpdate(float delta);

    [VirtualFunction(7)]
    public partial void Draw();

    [VirtualFunction(8)]
    public partial void Setup();

    [VirtualFunction(10)]
    public partial void SetEnabledState(bool enabled);

    [VirtualFunction(17)]
    public partial void InitializeFromComponentData(void* data); // AtkUldComponentDataBase* ?
}
