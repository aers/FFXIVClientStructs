namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.Alarm)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0xF40)]
public unsafe partial struct AgentAlarm {
    [FieldOffset(0x28), FixedSizeArray] internal FixedSizeArray30<Alarm> _alarms;
    [FieldOffset(0xF28)] public byte NumActiveAlarms;
    [FieldOffset(0xF29)] public byte ContextMenuIndex; // index of the alarm for which the context menu was opened

    [FieldOffset(0xF2C)] public uint AlarmSettingsAddonId;
    [FieldOffset(0xF30)] public uint DeleteAllDialogAddonId; // SelectYesno: "Delete all saved alarms?"
    [FieldOffset(0xF34)] public uint DiscardDialogAddonId; // SelectYesno: "Close window and discard changes?"
    [FieldOffset(0xF38)] public Alarm* FirstAlarmPtr; // pointer to the alarm with index 0

    [MemberFunction("E8 ?? ?? ?? ?? 48 8D 96 ?? ?? ?? ?? 48 8B CE E8 ?? ?? ?? ?? C6 47")]
    public partial void DeleteAllAlarms();

    [MemberFunction("E8 ?? ?? ?? ?? 48 83 EF ?? 49 83 EC")]
    public partial void DeleteAlarm(byte index, bool printLogMessage = true);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B CF E8 ?? ?? ?? ?? 33 D2 4C 89 6D")]
    public partial void PlayAlarmSoundEffect(AlarmSoundEffect soundEffect);

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x80)]
    public partial struct Alarm {
        /// <remarks> Max length: 20 </remarks>
        [FieldOffset(0x00)] public Utf8String Name;
        [FieldOffset(0x68)] public AlarmClockTime ClockTime;
        [FieldOffset(0x6C)] public byte Index; // of this Alarm in the Alarms array
        [FieldOffset(0x6D)] public byte Hour;
        [FieldOffset(0x6E)] public byte Minute;
        /// <summary> A reminder, minutes ahead of alarm </summary>
        [FieldOffset(0x6F)] public byte Reminder;
        [FieldOffset(0x70)] public AlarmSoundEffect SoundEffect;

        [FieldOffset(0x74)] public int Timestamp;
        [FieldOffset(0x78)] public AlarmFlag Flags;
    }
}

public enum AlarmClockTime {
    LocalTime = 0,
    ServerTime = 1,
    EorzeaTime = 2,
}

public enum AlarmSoundEffect : byte {
    Bell = 0,
    MusicBox = 1,
    Prelude = 2,
    Chocobo = 3,
    LaNoscea = 4,
    Festival = 5,
}

[Flags]
public enum AlarmFlag : byte {
    /// <summary> Repeat Alarm, hourly if LocalTime/ServerTime, daily if EorzeaTime </summary>
    Repeat = 1 << 0,
    /// <summary> Mute sound while bound by duty </summary>
    MuteInDuties = 1 << 1,
}
