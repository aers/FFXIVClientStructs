namespace FFXIVClientStructs.FFXIV.Component.Text;

[StructLayout(LayoutKind.Explicit, Size = 0x60)]
public unsafe partial struct MacroDecoder {
    [FieldOffset(0x08)] public StdVector<nint> DecoderFuncs; // idx is the macro code byte
}
