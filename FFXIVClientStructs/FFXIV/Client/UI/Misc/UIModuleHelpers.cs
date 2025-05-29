namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

[StructLayout(LayoutKind.Explicit, Size = 0x38)]
public unsafe struct UIModuleHelpers {
    [FieldOffset(0x0), FixedSizeArray, CExportIgnore] internal FixedSizeArray7<Pointer<HelperInterface>> _helpers;
    [FieldOffset(0x0)] public CurrencySettingsHelper* CurrencySettingsHelper;
    [FieldOffset(0x8)] public BannerHelper* BannerHelper;
    [FieldOffset(0x10)] private HelperInterface* ReplaceActionHelper; // unsure, placeholder name
    [FieldOffset(0x18)] private HelperInterface* TofuHelper; // unsure, placeholder name
    [FieldOffset(0x20)] private HelperInterface* MKDInfoHelper; // unsure, placeholder name
    [FieldOffset(0x28)] private HelperInterface* MKDInfoHelper2; // unsure, placeholder name
    [FieldOffset(0x30)] private HelperInterface* ScreenInfoFrontHelper; // unsure, placeholder name
}
