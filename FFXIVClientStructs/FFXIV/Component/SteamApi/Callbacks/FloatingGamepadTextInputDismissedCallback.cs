namespace FFXIVClientStructs.FFXIV.Component.SteamApi.Callbacks;

[StructLayout(LayoutKind.Explicit, Size = SteamCallbackBase.Size)]
public unsafe partial struct FloatingGamepadTextInputDismissedCallback {
    [FieldOffset(0x0)] public SteamCallbackBase SteamCallbackBase;

    // doesn't actually send any data back - just called when closed.
    [VirtualFunction(1)]
    public partial void Run(void* outData);
}
