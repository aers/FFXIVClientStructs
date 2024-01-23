namespace FFXIVClientStructs.FFXIV.Client.System.Input;

[StructLayout(LayoutKind.Explicit, Size = 0x08)]
public unsafe partial struct SoftKeyboardDevice {
    [FieldOffset(0x00), CExportIgnore] public void** vtbl;

    [VirtualFunction(0)] 
    public partial void Dtor(bool freeMemory);
    
    [VirtualFunction(1)]
    public partial bool Initialize();
    
    [VirtualFunction(3)]
    public partial nint Disable();

    [VirtualFunction(4)]
    public partial nint IsEnabled();

    [VirtualFunction(5)]
    public partial nint BindToInput(nint targetSoftKeyboardInputInterface);

    [VirtualFunction(6)]
    public partial void UnbindFromInput(); // called from AtkComponentTextInput#vf4 and AtkComponentTextInput#Finalize

    [VirtualFunction(7)]
    public partial void IsBoundToInput();
}
