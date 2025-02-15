namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public unsafe struct UIModuleHelpers {
    // Technically an array of 4 HelperInterface*
    [FieldOffset(0x0)] public CurrencySettingsHelper* CurrencySettingsHelper;
    [FieldOffset(0x8)] public BannerHelper* BannerHelper;
}
