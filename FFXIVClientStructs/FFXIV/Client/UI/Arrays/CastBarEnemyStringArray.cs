using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Arrays;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 10 * 8)]
public unsafe partial struct CastBarEnemyStringArray {
    public static CastBarEnemyStringArray* Instance() {
        var stringArray = AtkStage.Instance()->GetStringArrayData(StringArrayType.CastBarEnemy);
        return stringArray == null ? null : (CastBarEnemyStringArray*)stringArray->StringArray;
    }

    [FieldOffset(0), FixedSizeArray] internal FixedSizeArray10<CStringPointer> _castBarStrings;
}
