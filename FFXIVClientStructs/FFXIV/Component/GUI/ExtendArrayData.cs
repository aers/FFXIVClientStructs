namespace FFXIVClientStructs.FFXIV.Component.GUI;

// ExtendArrayData 1 stores pointers to AgentMap.MapMarkers
[GenerateInterop, Inherits<AtkArrayData>]
[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public unsafe partial struct ExtendArrayData {
    [FieldOffset(0x20)] public void** DataArray;
}
