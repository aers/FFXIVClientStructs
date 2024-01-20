namespace FFXIVClientStructs.FFXIV.Client.System.Timer;

// Client::System::Timer::ClientTime
//   Common::Game::Time::GameTime
[StructLayout(LayoutKind.Explicit, Size = 0x40)]
public struct ClientTime {
    [FieldOffset(0x8)] public long EorzeaTime;
    [FieldOffset(0x10)] public float EorzeaTimeMilliseconds;

    [FieldOffset(0x30)] public long EorzeaTimeOverride;
    [FieldOffset(0x38)] public bool IsEorzeaTimeOverridden;
}
