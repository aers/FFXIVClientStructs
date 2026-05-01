namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::ListComponentCallBackInterface
[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x08)]
public unsafe partial struct ListComponentCallBackInterface {
    [VirtualFunction(0)]
    public partial ListComponentCallBackInterface* Dtor(byte freeFlags);
}
