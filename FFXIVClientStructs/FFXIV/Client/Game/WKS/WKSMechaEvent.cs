namespace FFXIVClientStructs.FFXIV.Client.Game.WKS;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x6570)]
public unsafe partial struct WKSMechaEvent {
    [FieldOffset(0x0000)] private WKSMechaEventStageHandlerBase StageHandler1;
    [FieldOffset(0x0010)] private WKSMechaEventStageHandlerBase StageHandler2;
    [FieldOffset(0x0020)] private WKSMechaEventStageHandlerBase StageHandler3;
    [FieldOffset(0x0030)] private WKSMechaEventStageHandlerBase StageHandler4;
    [FieldOffset(0x0040)] private WKSMechaEventStageHandlerBase StageHandler5;
    [FieldOffset(0x0050)] private WKSMechaEventStageHandlerBase StageHandler6;
    [FieldOffset(0x0060)] private WKSMechaEventStageHandlerBase StageHandler7;

    [FieldOffset(0x4D50)] public StdVector<Pointer<WKSMechaEventMapMarker>> MapMarkerPtrs;
    [FieldOffset(0x4D68), FixedSizeArray] internal FixedSizeArray30<WKSMechaEventMapMarker> _mapMarkers;

    [FieldOffset(0x6500)] public uint YesNoAddonId;
    [FieldOffset(0x6504)] public uint YesNoShown;
    [FieldOffset(0x6508)] public WKSMechaEventStageHandlerBase* CurrentStateHandler;
    [FieldOffset(0x6510), CExporterExcel("WKSMechaEventData")] public nint WKSMechaEventDataRowPtr;
    [FieldOffset(0x6518)] public uint WKSMechaEventDataRowId;
    [FieldOffset(0x651C)] public WKSMechaEventFlag Flags;
    [FieldOffset(0x6520)] public int EventStartTimestamp;
    [FieldOffset(0x6524)] public int EventEndTimestamp;
    [FieldOffset(0x6528)] public int PilotRegistrationStartTimestamp;
    [FieldOffset(0x652C)] public int PilotRegistrationEndTimestamp;
    [FieldOffset(0x6530)] public int TeleportStartTimestamp; // for ground support

    [FieldOffset(0x6544)] public int EventProgress;
    [FieldOffset(0x6548)] public int EventProgressMax;
    [FieldOffset(0x654C)] public int Contribution;

    [FieldOffset(0x6554)] public int PersonalProgress;
    [FieldOffset(0x6558)] public int PersonalProgressMax;
    [FieldOffset(0x655C)] public bool EnabledAutoTargeting; // currently only true for WKSMechaEventDataRowId == 1
}

[Flags]
public enum WKSMechaEventFlag : uint {
    IsParticipating = 1 << 2,

    PilotRegistrationOpen = 1 << 8, // LogMessage#10830, is not unset when the time is over
    GroundSupportTeleportOpen = 1 << 9, // is not unset when the time is over
    IsEventActive = 1 << 10,
}
