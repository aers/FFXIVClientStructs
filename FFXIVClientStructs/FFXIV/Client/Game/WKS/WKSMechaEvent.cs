namespace FFXIVClientStructs.FFXIV.Client.Game.WKS;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x5060)]
public unsafe partial struct WKSMechaEvent {
    [FieldOffset(0x0000)] private WKSMechaEventStageHandlerBase StageHandler1;
    [FieldOffset(0x0010)] private WKSMechaEventStageHandlerBase StageHandler2;
    [FieldOffset(0x0020)] private WKSMechaEventStageHandlerBase StageHandler3;
    [FieldOffset(0x0030)] private WKSMechaEventStageHandlerBase StageHandler4;
    [FieldOffset(0x0040)] private WKSMechaEventStageHandlerBase StageHandler5;
    [FieldOffset(0x0050)] private WKSMechaEventStageHandlerBase StageHandler6;
    [FieldOffset(0x0060)] private WKSMechaEventStageHandlerBase StageHandler7;

    [FieldOffset(0x3850)] public StdVector<Pointer<WKSMechaEventMapMarker>> MapMarkerPtrs;
    [FieldOffset(0x3868), FixedSizeArray] internal FixedSizeArray30<WKSMechaEventMapMarker> _mapMarkers;

    [FieldOffset(0x5000)] public uint YesNoAddonId;
    [FieldOffset(0x5004)] public uint YesNoShown;
    [FieldOffset(0x5008)] public WKSMechaEventStageHandlerBase* CurrentStateHandler;
    [FieldOffset(0x5010), CExporterExcel("WKSMechaEventData")] public nint WKSMechaEventDataRowPtr;
    [FieldOffset(0x5018)] public uint WKSMechaEventDataRowId;
    [FieldOffset(0x501C)] public WKSMechaEventFlag Flags;
    [FieldOffset(0x5020)] public int EventStartTimestamp;
    [FieldOffset(0x5024)] public int EventEndTimestamp;
    [FieldOffset(0x5028)] public int PilotRegistrationStartTimestamp;
    [FieldOffset(0x502C)] public int PilotRegistrationEndTimestamp;
    [FieldOffset(0x5030)] public int TeleportStartTimestamp;

    [FieldOffset(0x5044)] public int EventProgress;
    [FieldOffset(0x5048)] public int EventProgressMax;
    [FieldOffset(0x504C)] public int Contribution;

    [FieldOffset(0x5054)] public int PersonalProgress;
    [FieldOffset(0x5058)] public int PersonalProgressMax;
    [FieldOffset(0x505C)] public bool EnabledAutoTargeting; // currently only true for WKSMechaEventDataRowId == 1
}

[Flags]
public enum WKSMechaEventFlag : uint {
    // Each stage of the event has a flag

    IsEventActive = 1 << 7
}
