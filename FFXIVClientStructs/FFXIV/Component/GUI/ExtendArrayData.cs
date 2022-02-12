namespace FFXIVClientStructs.FFXIV.Component.GUI;

[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public unsafe struct ExtendArrayData
{
    [FieldOffset(0x0)] public AtkArrayData AtkArrayData;

    [FieldOffset(0x20)]
    public void** DataArray; // as far as I'm aware this can contain literally any data type they want, yay
}