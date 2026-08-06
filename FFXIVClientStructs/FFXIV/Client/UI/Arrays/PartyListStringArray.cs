using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Arrays;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 397 * 8)]
public unsafe partial struct PartyListStringArray {
    public static PartyListStringArray* Instance() {
        var stringArray = AtkStage.Instance()->GetStringArrayData(StringArrayType.PartyList);
        return stringArray == null ? null : (PartyListStringArray*)stringArray->StringArray;
    }
    
    [FieldOffset(0 * 8), FixedSizeArray, CExporterIgnore] internal FixedSizeArray397<CStringPointer> _data;
    
    [FieldOffset(0 * 8)] public CStringPointer EmnityMarker;
    
    [FieldOffset(3 * 8)] public CStringPointer ChocoboRemainingTime;
    [FieldOffset(4 * 8)] public CStringPointer PartyType;
    [FieldOffset(5 * 8)] public CStringPointer ExpBonusPercentage;
    
    [FieldOffset(6 * 8), FixedSizeArray, CExporterIgnore] internal FixedSizeArray8<PartyListMemberStringArray> _partyMembers;
    
    [FieldOffset(191 * 8), FixedSizeArray, CExporterIgnore] internal FixedSizeArray7<PartyListPetStringArray> _trustMembers;
    
    [FieldOffset(352 * 8), FixedSizeArray, CExporterIgnore] internal FixedSizeArray8<PartyListPetStringArray> _pets;
    
    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 23 * 8)]
    public partial struct PartyListMemberStringArray {
        [FieldOffset(0 * 8), FixedSizeArray, CExporterIgnore] internal FixedSizeArray23<CStringPointer> _data;

        [FieldOffset(0 * 8)] public CStringPointer PartyIndex;
        [FieldOffset(1 * 8)] public CStringPointer MemberNameAndLevel;
        [FieldOffset(2 * 8)] public CStringPointer CurrentCast;
        
        [FieldOffset(3 * 8), FixedSizeArray, CExporterIgnore] internal FixedSizeArray10<CStringPointer> _statusTimesLeft;
        [FieldOffset(13 * 8), FixedSizeArray, CExporterIgnore] internal FixedSizeArray10<CStringPointer> _statusTooltips;
    }
    
    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 22 * 8)]
    public partial struct PartyListPetStringArray {
        [FieldOffset(0 * 8), FixedSizeArray, CExporterIgnore] internal FixedSizeArray22<CStringPointer> _data;
        
        [FieldOffset(0 * 8)] public CStringPointer PetNameAndLevel;
        [FieldOffset(1 * 8)] public CStringPointer CurrentCast;
        
        [FieldOffset(2 * 8), FixedSizeArray, CExporterIgnore] internal FixedSizeArray10<CStringPointer> _statusTimesLeft;
        [FieldOffset(12 * 8), FixedSizeArray, CExporterIgnore] internal FixedSizeArray10<CStringPointer> _statusTooltips;
    }
}
