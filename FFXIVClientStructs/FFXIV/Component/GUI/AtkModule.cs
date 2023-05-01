namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkModule
//   Component::GUI::AtkModuleInterface
[StructLayout(LayoutKind.Explicit, Size = 0x8240)]
public unsafe partial struct AtkModule
{
    [FieldOffset(0x1B10)] public AtkUnitBase* IntersectingAddon;
    [FieldOffset(0x1B18)] public AtkCollisionNode* IntersectingCollisionNode;

    [FieldOffset(0x1B48)] public AtkArrayDataHolder AtkArrayDataHolder;

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
