using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Arrays;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 131 * 8)]
public unsafe partial struct PvPMKSStringArray {
    public static PvPMKSStringArray* Instance() {
        var stringArray = AtkStage.Instance()->GetStringArrayData(StringArrayType.PvPMKS);
        return stringArray == null ? null : (PvPMKSStringArray*)stringArray->StringArray;
    }

    [FieldOffset(0 * 8), FixedSizeArray, CExporterIgnore] internal FixedSizeArray131<CStringPointer> _data;
    
    [FieldOffset(0 * 8)] public CStringPointer AstraLabel;
    [FieldOffset(1 * 8)] public CStringPointer UmbraLabel;
    [FieldOffset(2 * 8)] public CStringPointer AstraPercentageCappedLabel;
    [FieldOffset(3 * 8)] public CStringPointer UmbraPercentageCappedLabel;
    [FieldOffset(4 * 8)] public CStringPointer LocalPlayerMarker;
    
    [FieldOffset(5 * 8), FixedSizeArray, CExporterIgnore] internal FixedSizeArray5<PvPMKSPartyMemberStringArray> _astraMembers;
    [FieldOffset(70 * 8), FixedSizeArray, CExporterIgnore] internal FixedSizeArray5<PvPMKSPartyMemberStringArray> _umbraMembers;
    
    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 12 * 8)]
    public partial struct PvPMKSPartyMemberStringArray {
        [FieldOffset(0 * 8), FixedSizeArray, CExporterIgnore] internal FixedSizeArray12<CStringPointer> _data;
        
        [FieldOffset(0 * 8)] public CStringPointer MemberNameAndLevel;
        [FieldOffset(1 * 8)] public CStringPointer CurrentCast;
        
        [FieldOffset(2 * 8), FixedSizeArray, CExporterIgnore] internal FixedSizeArray10<CStringPointer> _statusTimesLeft;
    }
}
