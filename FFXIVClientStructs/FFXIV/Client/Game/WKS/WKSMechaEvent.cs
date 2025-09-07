namespace FFXIVClientStructs.FFXIV.Client.Game.WKS;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x5130)]
public unsafe partial struct WKSMechaEvent {
    [FieldOffset(0x0000)] private WKSMechaEventStageHandlerBase StageHandler1;
    [FieldOffset(0x0010)] private WKSMechaEventStageHandlerBase StageHandler2;
    [FieldOffset(0x0020)] private WKSMechaEventStageHandlerBase StageHandler3;
    [FieldOffset(0x0030)] private WKSMechaEventStageHandlerBase StageHandler4;
    [FieldOffset(0x0040)] private WKSMechaEventStageHandlerBase StageHandler5;
    [FieldOffset(0x0050)] private WKSMechaEventStageHandlerBase StageHandler6;
    [FieldOffset(0x0060)] private WKSMechaEventStageHandlerBase StageHandler7;

    [FieldOffset(0x3910)] public StdVector<Pointer<WKSMechaEventMapMarker>> MapMarkerPtrs;
    [FieldOffset(0x3928), FixedSizeArray] internal FixedSizeArray30<WKSMechaEventMapMarker> _mapMarkers;

    [FieldOffset(0x50C0)] public uint YesNoAddonId;
    [FieldOffset(0x50C4)] public uint YesNoShown;
    [FieldOffset(0x50C8)] public WKSMechaEventStageHandlerBase* CurrentStateHandler;
    [FieldOffset(0x50D0), CExporterExcel("WKSMechaEventData")] public nint WKSMechaEventDataRowPtr;
    [FieldOffset(0x50D8)] public uint WKSMechaEventDataRowId;
    [FieldOffset(0x50DC)] public WKSMechaEventFlag Flags;
    [FieldOffset(0x50E0)] public int EventStartTimestamp;
    [FieldOffset(0x50E4)] public int EventEndTimestamp;
    [FieldOffset(0x50E8)] public int PilotRegistrationStartTimestamp;
    [FieldOffset(0x50EC)] public int PilotRegistrationEndTimestamp;
    [FieldOffset(0x50F0)] public int TeleportStartTimestamp; // for ground support

    [FieldOffset(0x5104)] public int EventProgress;
    [FieldOffset(0x5108)] public int EventProgressMax;
    [FieldOffset(0x510C)] public int Contribution;

    [FieldOffset(0x5114)] public int PersonalProgress;
    [FieldOffset(0x5118)] public int PersonalProgressMax;
    [FieldOffset(0x511C)] public bool EnabledAutoTargeting; // currently only true for WKSMechaEventDataRowId == 1
}

[Flags]
public enum WKSMechaEventFlag : uint {
    IsParticipating = 1 << 2,

    PilotRegistrationOpen = 1 << 8, // LogMessage#10830, is not unset when the time is over
    GroundSupportTeleportOpen = 1 << 9, // is not unset when the time is over
    IsEventActive = 1 << 10,
}
