namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public unsafe struct AreaInstance {
    // I am unsure why this is at 0x10 but all the functions that use it suggest its correct
    [FieldOffset(0x10)] public void* vtbl; 
    [FieldOffset(0x20)] public int Instance;
    
    // E8 ?? ?? ?? ?? 3C 01 75 0C 48 8D 0D
    // but is a sig really worth it for this...
    public bool IsInstancedArea() => Instance != 0;
}
