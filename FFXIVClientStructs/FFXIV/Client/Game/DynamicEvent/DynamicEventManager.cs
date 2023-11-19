namespace FFXIVClientStructs.FFXIV.Client.Game.DynamicEvent;

[StructLayout(LayoutKind.Explicit, Size = 0x1B28)]
public unsafe partial struct DynamicEventManager {
    [FixedSizeArray<DynamicEvent>(16)]
    [FieldOffset(0x08)] public unsafe fixed byte DynamicEvents[0x1B0 * 16];
    [FieldOffset(0x1B26)] public byte CurrentEventIndex; // 0xFF or index of registered/deployed DynamicEvent

    [MemberFunction("E8 ?? ?? ?? ?? 45 32 C9 4C 8B D0")]
    public static partial DynamicEventManager* Instance();
}
