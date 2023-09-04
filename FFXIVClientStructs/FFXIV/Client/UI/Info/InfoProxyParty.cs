namespace FFXIVClientStructs.FFXIV.Client.UI.Info;
[InfoProxy(InfoProxyId.Party)]
[StructLayout(LayoutKind.Explicit, Size = 0x348)]
public unsafe partial struct InfoProxyParty {
    [FieldOffset(0x00)] public InfoProxyCommonList InfoProxyCommonList;
    [FieldOffset(0xE8)] public void* UnkE8;
    [FieldOffset(0x100)] public void* Unk100;
    //Classes/Structs seen in Ghidra at:
    //+118, 100, B8/C8 + D0/E0 mabybe some start/end pointers of Arrays with entry size 0x18


}
