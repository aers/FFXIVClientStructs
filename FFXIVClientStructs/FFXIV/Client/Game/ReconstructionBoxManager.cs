namespace FFXIVClientStructs.FFXIV.Client.Game;

// Client::Game::ReconstructionBoxManager
// Doman Enclave Reconstruction Box
[GenerateInterop]
[Obsolete("Use DomanEnclaveManager instead.", true)]
[StructLayout(LayoutKind.Explicit, Size = 0xA8)]
public unsafe partial struct ReconstructionBoxManager {
    [Obsolete("Use DomanEnclaveManager instead.", true)]
    public static ReconstructionBoxManager* Instance() => (ReconstructionBoxManager*)DomanEnclaveManager.Instance();

    [FieldOffset(0x8)] public bool Loaded;

    [FieldOffset(0xA0)] public ushort Donated;
    [FieldOffset(0xA2)] public ushort Progress;

    /// <remarks> Add 100 to get the correct value. </remarks>
    [FieldOffset(0xA4)] public byte Factor;

    [FieldOffset(0xA6)] public ushort Allowance;
}
