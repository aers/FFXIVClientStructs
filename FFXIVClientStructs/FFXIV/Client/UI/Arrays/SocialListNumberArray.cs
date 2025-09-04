using FFXIVClientStructs.FFXIV.Client.UI.Arrays.Common;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Arrays;

[CExporterIgnore]
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 2403 * 4)]
public unsafe partial struct SocialListNumberArray {
    public static SocialListNumberArray* Instance() {
        var numberArray = AtkStage.Instance()->GetNumberArrayData(NumberArrayType.SocialList);
        return numberArray == null ? null : (SocialListNumberArray*)numberArray->IntArray;
    }

    [FieldOffset(0), FixedSizeArray, CExporterIgnore] internal FixedSizeArray2403<int> _data;

    [FieldOffset(0 * 4), FixedSizeArray] internal FixedSizeArray200<SocialListMemberNumberArray> _players;

    [FieldOffset(2400 * 4)] public int SocialListSize;
}
