namespace FFXIVClientStructs.FFXIV.Client.Game.Network;

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public struct PrepareZoningPacket {
    /// <remarks> If non-zero, inserts this message into the chat. Index into the LogMessage Excel sheet. </remarks>
    [FieldOffset(0x00)] public uint LogMessageId;
    /// <remarks> What territory is about to be loaded. Index into the TerritoryType Excel sheet. </remarks>
    [FieldOffset(0x04)] public ushort TerritoryTypeId;
    /// <remarks> If non-zero, plays this VFX on the player character. Index into the VFX Excel sheet. </remarks>
    [FieldOffset(0x06)] public ushort VfxId;
    /// <remarks> If non-zero, uses this VFX instead of the normal black background for the loading screen. Index into the VFX Excel sheet. </remarks>
    [FieldOffset(0x08)] public ushort LoadingScreenVfxId;
    /// <remarks> See <see cref="UI.WarpType"/> </remarks>
    [FieldOffset(0x0A)] public byte WarpType; // TODO: Change to WarpInfo's WarpType
    /// <remarks> Functionally a boolean as far as I can tell, but there's a third mode of an unknown purpose. Unsure if even used by retail. </remarks>
    [FieldOffset(0x0B)] public byte HideCharacter;
    /// <remarks> Unused by retail but what disassembly is left leads me to believe it controlled this at one point. If set to 0xFF (255) then the fade out never occurs. </remarks>
    [FieldOffset(0x0C)] public byte FadeOutDelay;
    /// <remarks> Miscellaneous flags like whether to hide the loading screen text. </remarks>
    [FieldOffset(0x0D)] public byte Flags;
}
