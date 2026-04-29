namespace FFXIVClientStructs.FFXIV.Client.Game.WKS;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x82C0)]
public unsafe partial struct WKSMechaEvent {
    [FieldOffset(0x0000)] private WKSMechaEventStageHandlerBase StageHandler1;
    [FieldOffset(0x0010)] private WKSMechaEventStageHandlerBase StageHandler2;
    [FieldOffset(0x0020)] private WKSMechaEventStageHandlerBase StageHandler3;
    [FieldOffset(0x0030)] private WKSMechaEventStageHandlerBase StageHandler4;
    [FieldOffset(0x0040)] private WKSMechaEventStageHandlerBase StageHandler5;
    [FieldOffset(0x0050)] private WKSMechaEventStageHandlerBase StageHandler6;
    [FieldOffset(0x0060)] private WKSMechaEventStageHandlerBase StageHandler7;

    [FieldOffset(0x62C0)] public StdVector<Pointer<WKSMechaEventMapMarker>> MapMarkerPtrs;
    [FieldOffset(0x62D8), FixedSizeArray] internal FixedSizeArray40<WKSMechaEventMapMarker> _mapMarkers;

    [FieldOffset(0x8240)] public uint YesNoAddonId;
    [FieldOffset(0x8244)] public uint YesNoShown;
    [FieldOffset(0x8248)] public WKSMechaEventStageHandlerBase* CurrentStateHandler;
    [FieldOffset(0x8250), CExporterExcel("WKSMechaEventData")] public nint WKSMechaEventDataRowPtr;
    [FieldOffset(0x8258)] public uint WKSMechaEventDataRowId;
    [FieldOffset(0x825C)] public WKSMechaEventFlag Flags;
    [FieldOffset(0x8260)] public int EventStartTimestamp;
    [FieldOffset(0x8264)] public int EventEndTimestamp;
    [FieldOffset(0x8268)] public int PilotRegistrationStartTimestamp;
    [FieldOffset(0x826C)] public int PilotRegistrationEndTimestamp;
    [FieldOffset(0x8270)] public int TeleportStartTimestamp; // for ground support

    [FieldOffset(0x8284)] public int EventProgress;
    [FieldOffset(0x8288)] public int EventProgressMax;
    [FieldOffset(0x828C)] public int Contribution;

    [FieldOffset(0x8294)] public int PersonalProgress;
    [FieldOffset(0x8298)] public int PersonalProgressMax;
    [FieldOffset(0x829C)] public bool EnabledAutoTargeting; // currently only true for WKSMechaEventDataRowId == 1
}

[Flags]
public enum WKSMechaEventFlag : uint {
    IsParticipating = 1 << 2,

    PilotRegistrationOpen = 1 << 8, // LogMessage#10830, is not unset when the time is over
    GroundSupportTeleportOpen = 1 << 9, // is not unset when the time is over
    IsEventActive = 1 << 10,
}
