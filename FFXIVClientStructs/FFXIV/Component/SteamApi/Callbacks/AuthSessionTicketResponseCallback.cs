namespace FFXIVClientStructs.FFXIV.Component.SteamApi.Callbacks;

[StructLayout(LayoutKind.Explicit, Size = SteamCallbackBase.Size)]
public unsafe partial struct AuthSessionTicketResponseCallback {
    [FieldOffset(0x0)] public SteamCallbackBase SteamCallbackBase;

    [VirtualFunction(1)]
    public partial void Run(SteamTypes.AuthSessionTicketResponse* outCallbackParams);
}

