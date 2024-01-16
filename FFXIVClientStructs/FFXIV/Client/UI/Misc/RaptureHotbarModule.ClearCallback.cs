namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

public partial struct RaptureHotbarModule {
    [StructLayout(LayoutKind.Explicit, Size = 0x08)]
    public unsafe partial struct ClearCallback {
        [FieldOffset(0x0), CExportIgnore] public void** vtbl;

        [VirtualFunction(0)]
        public partial void Dtor(bool freeMemory);

        /// <summary>
        /// Resets <b>ALL</b> hotbars for the current player to their default states.
        /// </summary>
        /// <param name="raptureHotbarModule">An instance of RaptureHotbarModule.</param>
        /// <returns>Returns true</returns>
        [VirtualFunction(1)]
        public partial bool ResetAllHotbars(RaptureHotbarModule* raptureHotbarModule);

        /// <summary>
        /// Resets the PvE hotbars for the specified class at that class' current level.
        /// </summary>
        /// <param name="raptureHotbarModule">An instance of RaptureHotbarModule.</param>
        /// <param name="classJobId">The ClassJobID to reset.</param>
        /// <returns>Returns true.</returns>
        [VirtualFunction(2)]
        public partial bool ResetPvEHotbarsForClass(RaptureHotbarModule* raptureHotbarModule, int classJobId);

        /// <summary>
        /// Resets the PvP hotbars for the specified ClassJobId to their default values.
        /// Has no effect if the specified class job ID doesn't have PVP actions.
        /// </summary>
        /// <param name="classJobId">The ClassJobId to reset.</param>
        /// <param name="raptureHotbarModule">An instance of RaptureHotbarModule.</param>
        /// <returns>Returns true.</returns>
        [VirtualFunction(3)]
        public partial byte ResetPvPHotbarsForClass(RaptureHotbarModule* raptureHotbarModule, uint classJobId);
    }
}
