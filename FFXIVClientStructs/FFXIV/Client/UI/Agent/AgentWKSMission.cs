using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.WKSMission)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0xA8)]
public unsafe partial struct AgentWKSMission {
    [FieldOffset(0x28)] public MissionData* Data;
    [FieldOffset(0x30)] public uint SelectedEntry;
    [FieldOffset(0x34)] public byte SelectedTab;
    [FieldOffset(0x38)] public Utf8String MapTitle;

    [MemberFunction("40 53 48 83 EC ?? 8B DA E8 ?? ?? ?? ?? 48 85 C0 74 ?? E8 ?? ?? ?? ?? 48 83 B8 ?? ?? ?? ?? ?? 74 ?? E8 ?? ?? ?? ?? 0F B7 D3")]
    public partial void StartMission(ushort missionUnitId);

    [MemberFunction("0F B6 C2 83 F8 0A")]
    public partial byte JobIndexToClassJobId(byte jobIndex);

    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 D8 84 C0 74 ?? 49 8B 55")]
    public partial bool GetBasicMissions(StdVector<MissionEntry>* list);

    [MemberFunction("E8 ?? ?? ?? ?? EB ?? 48 81 C2")]
    public partial bool GetProvisionalMissions(StdVector<MissionEntry>* list);

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 0F B6 4A ?? 85 C9")]
    public partial bool GetMissionLog(StdVector<MissionEntry>* list);

    [StructLayout(LayoutKind.Explicit, Size = 0x120)]
    public struct MissionData {
        [FieldOffset(0x01)] public byte SelectedJobIndex;
        [FieldOffset(0x02)] public byte SelectedTabIndex;
        [FieldOffset(0x03)] public byte SelectedFilterIndex;

        [FieldOffset(0x08)] public uint SelectedMissionUnitId;
        [FieldOffset(0x0C)] public MissionFlags SelectedMissionFlags;
        [FieldOffset(0x10)] private int SelectedMissionIndex;
        [FieldOffset(0x14)] private uint ConfirmMissionId;
        [FieldOffset(0x18)] private uint ConfirmAddonId;
        [FieldOffset(0x1C)] private uint MapMissionId;
        [FieldOffset(0x20)] private int MapPlayerPosX;
        [FieldOffset(0x24)] private int MapPlayerPosY;
        [FieldOffset(0x28)] public Utf8String SelectedMissionTitle;
        [FieldOffset(0x90)] public Utf8String ItemLevelWarningText;
        [FieldOffset(0xF8)] public StdVector<MissionEntry> MissionList;

        [FieldOffset(0x118)] public byte UpdateFlags;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public struct MissionEntry {
        [FieldOffset(0x00)] public uint MissionUnitId;
        [FieldOffset(0x04)] public uint IconId;

        [FieldOffset(0x14)] public MissionFlags Flags; // maybe byte?
        /// <summary>
        /// 1,2,3,4 = D,C,B,A (LevelGroup)<br/>
        /// 12 = Weather-restricted<br/>
        /// 13 = Time-restricted<br/>
        /// 14 = Sequential (LockedBehind)<br/>
        /// 15 = Critical (IsSpecialQuest)<br/>
        /// </summary>
        [FieldOffset(0x18)] public byte MissionGroup;
    }

    [Flags]
    public enum MissionFlags {
        TimeRestricted = 1 << 0,
        /// <summary>Sequential or Critical</summary>
        Triggered = 1 << 1,
        Silver = 1 << 2,
        Gold = 1 << 3,
        WeatherRestricted = 1 << 4,
        Locked = 1 << 5
    }
}
