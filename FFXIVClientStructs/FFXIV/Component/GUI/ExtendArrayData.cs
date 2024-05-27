namespace FFXIVClientStructs.FFXIV.Component.GUI;

[GenerateInterop, Inherits<AtkArrayData>]
[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public unsafe partial struct ExtendArrayData {
    [FieldOffset(0x20)] public void** DataArray; // as far as I'm aware this can contain literally any data type they want, yay
}
