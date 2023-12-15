using FFXIVClientStructs.FFXIV.Client.UI;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkModule
//   Component::GUI::AtkModuleInterface
[StructLayout(LayoutKind.Explicit, Size = 0x82A0)]
public unsafe partial struct AtkModule {
    [FieldOffset(0x0), CExportIgnore] public void* vtbl;

    [FieldOffset(0x128)] public AtkStage* AtkStage;
    // [FieldOffset(0x130)] public AtkServer* AtkServer;

    [FieldOffset(0x250)] public AtkTextureResourceManager AtkTextureResourceManager;

    [FieldOffset(0x2A8)] public RaptureAtkUnitManager* RaptureAtkUnitManager;

    [FieldOffset(0x1B58)] public AtkUnitBase* IntersectingAddon;
    [FieldOffset(0x1B60)] public AtkCollisionNode* IntersectingCollisionNode;

    [FieldOffset(0x1B90)] public AtkArrayDataHolder AtkArrayDataHolder;

    [FieldOffset(0x5CC4)] public byte ActiveColorThemeType;

    [VirtualFunction(9)]
    public partial NumberArrayData* GetNumberArrayData(int index);

    [VirtualFunction(10)]
    public partial StringArrayData* GetStringArrayData(int index);

    [VirtualFunction(11)]
    public partial ExtendArrayData* GetExtendArrayData(int index);

    [VirtualFunction(26)]
    public partial bool IsAddonReady(uint addonId);

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 75 BA 40 84 FF")]
    public partial bool IsTextInputActive();
}
