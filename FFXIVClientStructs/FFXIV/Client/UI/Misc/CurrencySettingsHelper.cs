namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// ctor inlined in "48 89 5C 24 ?? 48 89 74 24 ?? 57 48 83 EC 20 33 C0 48 8B FA"
[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public unsafe struct CurrencySettingsHelper {
    [FieldOffset(0)] public void* vtbl;
    [FieldOffset(0x8)] public UIModule* UIModule;
    [FieldOffset(0x10)] public fixed byte Rotation[5];
    [FieldOffset(0x15)] public byte NumEntries;
    [FieldOffset(0x16)] public bool HasEntries;
}
