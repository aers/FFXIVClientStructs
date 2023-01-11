namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkModule
//   Component::GUI::AtkModuleInterface
[StructLayout(LayoutKind.Explicit, Size = 0x8240)]
public unsafe partial struct AtkModule
{
    [FieldOffset(0x0)] public void* vtbl;
    [FieldOffset(0x1B48)] public AtkArrayDataHolder AtkArrayDataHolder;

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 75 BA 40 84 FF")]
    public partial bool IsTextInputActive();
}
