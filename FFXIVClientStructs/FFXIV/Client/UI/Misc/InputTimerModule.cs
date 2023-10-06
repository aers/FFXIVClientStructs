using FFXIVClientStructs.FFXIV.Client.System.Framework;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

[StructLayout(LayoutKind.Explicit, Size = 0x4F8)]
public unsafe partial struct InputTimerModule {
    public static InputTimerModule* Instance() => Framework.Instance()->GetUiModule()->GetInputTimerModule();
    [FieldOffset(0x08)] public UIModule* UiModule;
    [FieldOffset(0x10)] public float AfkTimer; // counts up if AutoAfk is enabled and negative if afk
    [FieldOffset(0x14)] public float ContentInputTimer;
    [FieldOffset(0x18)] public float InputTimer;
    [FieldOffset(0x1C)] public float Unk1C; // used in a couple different ways, no idea
    [FieldOffset(0x20)] public float AutoAfkTimeLimit; // -1 if disabled

    [FieldOffset(0x28)] public float InstanceContentAfkTimeLimit;
    [FieldOffset(0x2C)] public float PvpAfkTimeLimit;
    [FieldOffset(0x30)] public float MjiAfkTimeLimit; // Island

    [FieldOffset(0x38)] public float AfkTimeLimit;

    [FieldOffset(0x3C)] public int Status;

    [FieldOffset(0x42)] public ushort TerritoryTypeId;
    [FieldOffset(0x44)] public float NoviceNetworkAfkTimeLimit;

    [FieldOffset(0x4C)] public int LeftStickX;
    [FieldOffset(0x50)] public int LeftStickY;
    [FieldOffset(0x54)] public int RightStickX;
    [FieldOffset(0x58)] public int RightStickY;

    [FixedSizeArray<InputTimerData>(16)]
    [FieldOffset(0x5C)] public fixed byte ControllerInputTimers[16 * 0x38];
    [FixedSizeArray<InputTimerData>(5)]
    [FieldOffset(0x3DC)] public fixed byte MouseInputTimers[5 * 0x38];

    [StructLayout(LayoutKind.Explicit, Size = 0x38)]
    public struct InputTimerData {
        [FieldOffset(0x00)] public fixed float TimerHistory[10];
        [FieldOffset(0x28)] public float TotalHistoryTime;
        [FieldOffset(0x2C)] public int HistoryIndex;
        [FieldOffset(0x30)] public float Timer;
    }
}
