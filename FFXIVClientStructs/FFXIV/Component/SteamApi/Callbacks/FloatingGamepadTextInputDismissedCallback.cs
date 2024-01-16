namespace FFXIVClientStructs.FFXIV.Component.SteamApi.Callbacks;

[StructLayout(LayoutKind.Explicit, Size = SteamCallbackBase.Size)]
public unsafe partial struct FloatingGamepadTextInputDismissedCallback {
    [FieldOffset(0x0)] public SteamCallbackBase SteamCallbackBase;

    /// <summary>
    /// Callback to fire when the floating gamepad text input was dismissed.
    /// </summary>
    /// <param name="outCallbackParams">Unused by this callback.</param>
    [VirtualFunction(1)]
    public partial void Run(void* outCallbackParams);
}
