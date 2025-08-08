using FFXIVClientStructs.FFXIV.Client.UI.Arrays.Common;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Arrays;

[CExportIgnore]
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 633 * 4)]
public unsafe partial struct PartyMemberListNumberArray {
    public static PartyMemberListNumberArray* Instance() {
        var numberArray = AtkStage.Instance()->GetNumberArrayData(NumberArrayType.PartyMemberList);
        return numberArray == null ? null : (PartyMemberListNumberArray*)numberArray->IntArray;
    }

    [FieldOffset(0 * 4), FixedSizeArray, CExportIgnore] internal FixedSizeArray633<int> _data;

    [FieldOffset(0 * 4), FixedSizeArray] internal FixedSizeArray48<SocialListMemberNumberArray> _partyMembers;
}
