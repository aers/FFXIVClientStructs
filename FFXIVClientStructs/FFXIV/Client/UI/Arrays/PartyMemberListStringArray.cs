using FFXIVClientStructs.FFXIV.Client.UI.Arrays.Common;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Arrays;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 247 * 8)]
public unsafe partial struct PartyMemberListStringArray {
    public static PartyMemberListStringArray* Instance() {
        var stringArray = AtkStage.Instance()->GetStringArrayData(StringArrayType.PartyMemberList);
        return stringArray == null ? null : (PartyMemberListStringArray*)stringArray->StringArray;
    }

    [FieldOffset(0 * 8), FixedSizeArray, CExporterIgnore] internal FixedSizeArray247<CStringPointer> _data;

    [FieldOffset(0 * 8), FixedSizeArray] internal FixedSizeArray48<SocialListMemberStringArray> _friends;
}
