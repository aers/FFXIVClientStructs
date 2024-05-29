namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// ctor inlined in "48 89 5C 24 ?? 48 89 74 24 ?? 57 48 83 EC 20 33 C0 48 8B FA"
[StructLayout(LayoutKind.Explicit, Size = 0x18)]
[GenerateInterop]
public unsafe partial struct CurrencySettingsHelper {
    [FieldOffset(0x8)] public UIModule* UIModule;
    [FieldOffset(0x10), FixedSizeArray] internal FixedSizeArray5<byte> _rotation;
    [FieldOffset(0x15)] public byte NumEntries;
    [FieldOffset(0x16)] public bool HasEntries;
}
