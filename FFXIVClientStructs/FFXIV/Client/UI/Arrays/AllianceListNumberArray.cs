using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Arrays;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 296 * 4)]
public unsafe partial struct AllianceListNumberArray {
    public static AllianceListNumberArray* Instance() {
        var numberArray = AtkStage.Instance()->GetNumberArrayData(NumberArrayType.AllianceList);
        return numberArray == null ? null : (AllianceListNumberArray*)numberArray->IntArray;
    }

    [FieldOffset(0), FixedSizeArray, CExporterIgnore] internal FixedSizeArray296<int> _data;

    [FieldOffset(0 * 4)] public int MemberCount;
    [FieldOffset(3 * 4)] public int PartyCount;
    [FieldOffset(4 * 4), FixedSizeArray] internal FixedSizeArray5<AllianceListGroupNumberArray> _groups;
    [FieldOffset(0x126 * 4)] public uint TargetedEntityId;
    [FieldOffset(0x127 * 4)] public uint SoftTargetEntityId;

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 58 * 4)]
    public partial struct AllianceListGroupNumberArray {
        [FieldOffset(0), FixedSizeArray, CExporterIgnore] internal FixedSizeArray58<int> _data;

        [FieldOffset(0 * 4)] public int MemberCount;
        [FieldOffset(1 * 4)] public int AggroMemberIndex;
        [FieldOffset(2 * 4), FixedSizeArray] internal FixedSizeArray8<AllianceListMemberNumberArray> _members;
    }

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 7 * 4)]
    public partial struct AllianceListMemberNumberArray {
        [FieldOffset(0), FixedSizeArray, CExporterIgnore] internal FixedSizeArray7<int> _data;

        [FieldOffset(0 * 4)] public int CurrentHealthPercent;
        [FieldOffset(1 * 4)] public int ClassJobIconId;
        [FieldOffset(3 * 4)] public uint EntityId;
        [FieldOffset(4 * 4)] public bool HasDebuff;
        [FieldOffset(6 * 4)] public bool IsTargetable;
    }
}
