using FFXIVClientStructs.FFXIV.Client.UI.Arrays.Common;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Arrays;

[CExportIgnore]
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 247 * 8)]
public unsafe partial struct PartyMemberListStringArray {
    public static PartyMemberListStringArray* Instance() => (PartyMemberListStringArray*)AtkStage.Instance()->GetStringArrayData(StringArrayType.PartyMemberList)->StringArray;

    [FieldOffset(0 * 8), FixedSizeArray, CExportIgnore] internal FixedSizeArray247<CStringPointer> _data;

    [FieldOffset(0 * 8), FixedSizeArray] internal FixedSizeArray48<SocialListMemberStringArray> _friends;
}
