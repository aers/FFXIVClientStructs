namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

[StructLayout(LayoutKind.Explicit, Size = 0x50)]
public unsafe struct UIModuleHelpers {
    [FieldOffset(0x0), FixedSizeArray, CExporterIgnore] internal FixedSizeArray10<Pointer<HelperInterface>> _helpers;
    [FieldOffset(0x0)] public CurrencySettingsHelper* CurrencySettingsHelper;
    [FieldOffset(0x8)] public BannerHelper* BannerHelper;
    [FieldOffset(0x10)] private HelperInterface* ReplaceActionHelper; // unsure, placeholder name
    [FieldOffset(0x18)] public TofuHelper* TofuHelper;
    [FieldOffset(0x20)] private HelperInterface* MKDInfoHelper; // unsure, placeholder name
    [FieldOffset(0x28)] private HelperInterface* MKDInfoHelper2; // unsure, placeholder name
    [FieldOffset(0x30)] private HelperInterface* ScreenInfoFrontHelper; // unsure, placeholder name
    [FieldOffset(0x38)] private HelperInterface* Unk38;
    [FieldOffset(0x40)] private HelperInterface* Unk40;
    [FieldOffset(0x48)] private HelperInterface* Unk48; // related to the TerritoryCandidates sheet
}
