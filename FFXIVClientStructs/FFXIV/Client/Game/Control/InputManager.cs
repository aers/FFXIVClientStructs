namespace FFXIVClientStructs.FFXIV.Client.Game.Control; 

[StructLayout(LayoutKind.Explicit, Size = 0x8)]
public unsafe partial struct InputManager {
    
    [MemberFunction("E8 ?? ?? ?? ?? 3A C3 74 0C")]
    public static partial bool IsAutoRunning();
}
