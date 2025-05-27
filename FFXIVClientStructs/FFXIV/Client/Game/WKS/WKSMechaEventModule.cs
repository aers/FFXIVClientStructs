namespace FFXIVClientStructs.FFXIV.Client.Game.WKS;

// Client::Game::WKS::WKSMechaEventModule
//   Client::Game::WKS::WKSModuleBase
// MechaEvent
[GenerateInterop]
[Inherits<WKSModuleBase>]
[StructLayout(LayoutKind.Explicit, Size = 0xA130)]
public unsafe partial struct WKSMechaEventModule {
    [FieldOffset(0x30), FixedSizeArray] internal FixedSizeArray2<WKSMechaEvent> _events;
    [FieldOffset(0xA0F0)] public WKSMechaEvent* CurrentEvent;

    [FieldOffset(0xA104)] public WKSEventModuleFlag Flags;
}

[Flags]
public enum WKSEventModuleFlag : uint {
    HasCurrentEvent = 1 << 0,
    IsJoined = 1 << 7,
}
