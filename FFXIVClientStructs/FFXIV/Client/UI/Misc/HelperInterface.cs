namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe partial struct HelperInterface {
    [FieldOffset(0x8)] public UIModule* UIModule;

    [VirtualFunction(1)]
    public partial void OnLogin();

    [VirtualFunction(2)]
    public partial void OnLogout();

    [VirtualFunction(3)]
    public partial void Update();
}
