using FFXIVClientStructs.FFXIV.Common.Component.Excel;

namespace FFXIVClientStructs.FFXIV.Client.Game;

// Client::Game::DomanEnclaveManager
// Manager for Doman Enclave Reconstruction
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0xA8)]
public unsafe partial struct DomanEnclaveManager {
    [StaticAddress("48 8B 15 ?? ?? ?? ?? 48 8B C8 48 83 C4 28", 3, isPointer: true)]
    public static partial DomanEnclaveManager* Instance();

    [FieldOffset(0x08)] public bool IsLoaded;
    [FieldOffset(0x10)] public ExcelSheetWaiter* DomaStoryProgressSheetWaiter; // size: 0x50
    [FieldOffset(0x18)] public ExcelSheet* DomaStoryProgressSheet;
    /// <remarks> RowIds of DomaStoryProgress sheet. </remarks>
    [FieldOffset(0x20), FixedSizeArray] internal FixedSizeArray128<byte> _milestones;
    [FieldOffset(0xA0)] public DomanEnclaveState State;

    [StructLayout(LayoutKind.Explicit, Size = 0x08)]
    public struct DomanEnclaveState {
        [FieldOffset(0x00)] public ushort Donated;
        /// <remarks> Index in the <see cref="Milestones" /> array. </remarks>
        [FieldOffset(0x02)] public byte CurrentMilestone;
        [FieldOffset(0x03)] public bool IsAcceptingDonations;
        /// <remarks> Add 100 to get the correct value. </remarks>
        [FieldOffset(0x04)] public byte Factor;
        [FieldOffset(0x06)] public ushort Allowance;
    }
}
