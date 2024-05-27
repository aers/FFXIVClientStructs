namespace FFXIVClientStructs.FFXIV.Component.SteamApi;

[StructLayout(LayoutKind.Explicit, Size = Size)]
public unsafe partial struct SteamCallbackBase {
    public const int Size = 0x10;

    [Flags]
    public enum SteamCallbackFlags : byte {
        Registered = 1 << 0,
        GameServer = 1 << 1,  // unused
    }

    [FieldOffset(0x0), CExportIgnore] public void** vtbl;
    [FieldOffset(0x8)] public SteamCallbackFlags Flags;
    [FieldOffset(0xC)] public int CallbackId;

    /// <remarks>
    /// This method just calls <see cref="Run"/> in virtually all cases. Additionally, thanks to some SteamAPI
    /// shenanigans, vf0 and vf1 may be swapped on occasion. This shouldn't realistically matter ever, but
    /// worth noting. Just use <see cref="Run"/>.
    /// </remarks>
    [VirtualFunction(0)]
    public partial void RunExtended(void* outCallbackParams, bool bIoFailure, long hSteamApiCall);

    [VirtualFunction(1)]
    public partial void Run(void* outCallbackParams);

    [VirtualFunction(2)]
    public partial nint GetSize();

    [VirtualFunction(3)]
    public partial void Dtor(bool freeMemory);

    public bool IsRegistered => Flags.HasFlag(SteamCallbackFlags.Registered);
}

