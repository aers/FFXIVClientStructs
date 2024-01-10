namespace FFXIVClientStructs.FFXIV.Component.SteamApi;

[StructLayout(LayoutKind.Explicit, Size = Size)]
public unsafe partial struct SteamCallbackBase {
    public const int Size = 0x10;
    
    [Flags]
    public enum SteamCallbackFlags : byte {
        Registered = 1 << 0,
        GameServer = 2 << 0,  // unused
    }
        
    [FieldOffset(0x0)] public void** vtbl;
    [FieldOffset(0x8)] public SteamCallbackFlags Flags;
    [FieldOffset(0xC)] public int CallbackId;

    [VirtualFunction(0)]
    public partial void RunExtended(void* param, bool bIoFailure, long hSteamApiCall);

    [VirtualFunction(1)]
    public partial void Run(void* param);

    [VirtualFunction(2)]
    public partial nint GetSize();
        
    [VirtualFunction(3)]
    public partial void Dtor(bool freeMemory);

    public bool IsRegistered => Flags.HasFlag(SteamCallbackFlags.Registered);
}

