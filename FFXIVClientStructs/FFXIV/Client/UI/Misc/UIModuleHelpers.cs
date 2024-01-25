namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe struct UIModuleHelpers {
    [FieldOffset(0x0)] public CurrencySettingsHelper* CurrencySettingsHelper;
    // [FieldOffset(0x8)] public BannerModuleHelper* BannerModuleHelper;
}
