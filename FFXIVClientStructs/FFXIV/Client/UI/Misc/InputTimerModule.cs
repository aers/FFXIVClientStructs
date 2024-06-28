using FFXIVClientStructs.FFXIV.Client.System.Framework;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::InputTimerModule
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x4F8)]
public unsafe partial struct InputTimerModule {
    public static InputTimerModule* Instance() => Framework.Instance()->GetUIModule()->GetInputTimerModule();

    [FieldOffset(0x08)] public UIModule* UIModule;
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

    [FieldOffset(0x5C), FixedSizeArray] internal FixedSizeArray16<InputTimerData> _controllerInputTimers;
    [FieldOffset(0x3DC), FixedSizeArray] internal FixedSizeArray5<InputTimerData> _mouseInputTimers;

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x38)]
    public partial struct InputTimerData {
        [FieldOffset(0x00), FixedSizeArray] internal FixedSizeArray10<float> _timerHistory;
        [FieldOffset(0x28)] public float TotalHistoryTime;
        [FieldOffset(0x2C)] public int HistoryIndex;
        [FieldOffset(0x30)] public float Timer;
    }
}
