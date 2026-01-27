namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.WKSAnnounce)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public unsafe partial struct AgentWKSAnnounce {
    [FieldOffset(0x28)] public AnnounceData* Data;

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0xA8)]
    public partial struct AnnounceData {
        [FieldOffset(0x4)] public byte EmergencyInfoRowId;
        [FieldOffset(0x5)] public byte EmergencyInfoSubRowId;
        [FieldOffset(0xC), FixedSizeArray] internal FixedSizeArray2<uint> _emergencyProgress; // the game client indexes these individually and not as an array but this makes it easier to compare with the required value
        [FieldOffset(0x18)] public Utf8String FormattedString;

        [FieldOffset(0x80), FixedSizeArray] internal FixedSizeArray2<uint> _emergencyProgressRequired; // same as progress but the required value for completion progress for each mission area
        [FieldOffset(0x88)] private float UnkFloat88; // always -1.0f?
        /// <remarks>
        /// This is the end time in unix seconds
        /// </remarks>
        [FieldOffset(0x8C)] public uint EndTime;

        /// <summary>
        /// ClassJobTypeFlags >> 16 is the class job type flags for mission area 0
        /// ClassJobTypeFlags &amp; 0xFFFF is the class job type flags for mission area 1
        /// Remark maps the bitfields to class jobs
        /// </summary>
        /// <remarks>
        /// 0x1 = CRP
        /// 0x2 = BSM
        /// 0x4 = ARM
        /// 0x8 = GSM
        /// 0x10 = LTW
        /// 0x20 = WVR
        /// 0x40 = ACH
        /// 0x80 = CUL
        /// 0x100 = MIN
        /// 0x200 = BTN
        /// 0x400 = FSH
        /// </remarks>
        [FieldOffset(0x90)] public uint ClassJobTypeFlags;

        /// <summary>
        /// State == 8 => StateProgress / 125 = StateBars
        /// State == 2 => StateProgress / 25700 = Emergency Completion Total State
        /// </summary>
        [FieldOffset(0x94)] public uint StateProgress;
        [FieldOffset(0x98)] private uint Unk98;
        [FieldOffset(0x9C)] public uint DevGrade;

        /// <summary>
        /// 0 = MechOps commenced
        /// 1 = Red Alert Incoming
        /// 2 = Red Alert Progressing
        /// 3 = ???
        /// 4 = ???
        /// 5 = MechOps issued
        /// 6 = MechOps deploying
        /// 7 = ???
        /// 8 = Waiting for dev stage progress
        /// </summary>
        [FieldOffset(0xA0)] public byte State;

        /// <summary>
        /// 1 = Created
        /// 2 = Addon Ready
        /// </summary>
        [FieldOffset(0xA1)] public byte AddonState;

        [FieldOffset(0xA2)] public bool HasUpdate;
    }
}
