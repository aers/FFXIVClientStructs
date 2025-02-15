namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

[GenerateInterop]
[Inherits<HelperInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public unsafe partial struct CurrencySettingsHelper {
    [FieldOffset(0x10), FixedSizeArray] internal FixedSizeArray5<byte> _rotation;
    [FieldOffset(0x15)] public byte NumEntries;
    [FieldOffset(0x16)] public bool HasEntries;
}
