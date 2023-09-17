using FFXIVClientStructs.FFXIV.Client.UI;
using FFXIVClientStructs.FFXIV.Component.Exd;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkModule
//   Component::GUI::AtkModuleInterface
[StructLayout(LayoutKind.Explicit, Size = 0x8250)]
public unsafe partial struct AtkModule {
    [FieldOffset(0x0)] public void* vtbl;

    [FieldOffset(0x128)] public AtkStage* AtkStage;

    [FieldOffset(0x228)] public int DefaultTextureVersion; // UiAssetType + 1

    [FieldOffset(0x230)] public ExdModule* ExdModule;

    [FieldOffset(0x268)] public RaptureAtkUnitManager* RaptureAtkUnitManager;

    [FieldOffset(0x1B10)] public AtkUnitBase* IntersectingAddon;
    [FieldOffset(0x1B18)] public AtkCollisionNode* IntersectingCollisionNode;

    [FieldOffset(0x1B48)] public AtkArrayDataHolder AtkArrayDataHolder;

    [FieldOffset(0x5C7C)] public byte ActiveColorThemeType;

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
