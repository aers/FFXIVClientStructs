namespace FFXIVClientStructs.FFXIV.Component.SteamApi;

/// <summary>
/// Types provided by the Steam API, and are not native to the game itself. Used to provide reasonable
/// interop for a few things that would be annoying to process otherwise.
/// </summary>
public static class SteamTypes {
    [StructLayout(LayoutKind.Explicit, Size = 0x8)]
    public struct AuthSessionTicketResponse {
        [FieldOffset(0x0)] public uint HAuthTicket;
        [FieldOffset(0x4)] public int EResult; // really a Steam enum, not included for brevity's sake.
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x12)]
    public struct GamepadTextInputDismissedData {
        [FieldOffset(0x0)] public bool Submitted;
        [FieldOffset(0x4)] public uint SubmittedTextSize; // really "m_UnsubmittedText"
        [FieldOffset(0x8)] public uint AppId;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x8)]
    public struct CSteamId {
        [FieldOffset(0x0)] public ulong RawSteamId;

        public byte Universe => (byte)((RawSteamId >> 56) & 0xFF);
        public uint AccountId => (uint)(RawSteamId & 0xFFFFFFFF);
        public uint AccountType => (byte)((RawSteamId >> 52) & 0xF);
        public uint AccountInstance => (uint)((RawSteamId >> 32) & 0xFFFFF);
    }

    /// <summary>
    /// A structure that represents a Steam API context. This is used by <c>SteamInternal_ContextInit</c>
    /// to manage and maintain a pointer to an instance of an arbitrary Steam API type.
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = Size)]
    public unsafe struct SteamInterfaceContext {
        public const int Size = 0x18;

        [FieldOffset(0x0)] public delegate* unmanaged<void*, void*> FindOrCreateInterfaceFPtr;
        [FieldOffset(0x8)] public nuint Counter;
        [FieldOffset(0x10)] public void* CachedInterfacePtr;

        /// <summary>
        /// Gets a pointer to the Steam API instance stored in this context.
        /// This pointer is suitable for use in imported Steam API methods.
        /// </summary>
        public nint GetInterface() {
            fixed (SteamInterfaceContext* ptr = &this) {
                // ToDo: Actually call `SteamInternal_ContextInit(ctx)` here, rather than just returning the cached pointer.
                //       Needs some way to get the fptr for that method first. For now this is *probably fine* (and won't blow up)
                //       but isn't awesome.
                return (nint)ptr->CachedInterfacePtr;
            }
        }
    }
}
