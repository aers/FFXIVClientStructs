using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Arrays;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 11 * 8)]
public unsafe partial struct CommonCurrenciesStringArray {
    public static CommonCurrenciesStringArray* Instance() {
        var stringArray = AtkStage.Instance()->GetStringArrayData(StringArrayType.CommonCurrencies);
        return stringArray == null ? null : (CommonCurrenciesStringArray*)stringArray->StringArray;
    }

    [FieldOffset(0), FixedSizeArray, CExporterIgnore] internal FixedSizeArray11<CStringPointer> _data;

    [FieldOffset(0 * 8)] public CStringPointer GilText;
    [FieldOffset(1 * 8)] public CStringPointer GrandCompanySealsText;
    [FieldOffset(2 * 8)] public CStringPointer GrandCompanySealsWithMaxText;
    [FieldOffset(3 * 8), FixedSizeArray] internal FixedSizeArray8<CStringPointer> _selfRepairDarkMatterText; // This is in the footer in the self-repair window
}
