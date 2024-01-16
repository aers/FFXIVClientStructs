namespace FFXIVClientStructs.FFXIV.Component.SteamApi;

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
}
