using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[GenerateInterop(isInherited: true)]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public unsafe partial struct AgentDawnInterface {
    [FieldOffset(0x28)] public byte SelectedContentId;

    [MemberFunction("85 D2 74 ?? 53 48 83 EC 50")]
    public partial void PlayVoiceLine(uint id);

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x4DF0)]
    public partial struct DawnContentData {
        [FieldOffset(0x00)] public byte ContentEntryCount;
        [FieldOffset(0x01)] public byte SelectedContentEntry;
        [FieldOffset(0x02)] public byte ExpansionCount;
        [FieldOffset(0x03)] public byte SelectedExpansion;
        [FieldOffset(0x08), FixedSizeArray] internal FixedSizeArray5<DawnExpansionEntry> _expansions;
        [FieldOffset(0x68), FixedSizeArray] internal FixedSizeArray80<DawnContentEntry> _contentEntries;
        [FieldOffset(0x4B68), FixedSizeArray] internal FixedSizeArray80<Pointer<DawnContentEntry>> _contentList;
    }

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x5FAA8)]
    public partial struct DawnMemberData {
        [FieldOffset(0x00)] public byte DisplayMemberIndex;
        [FieldOffset(0x02)] public byte CurrentMembersIndex;
        [FieldOffset(0x03)] public byte MemberEntriesCount;
        [FieldOffset(0x05), FixedSizeArray] internal FixedSizeArray80<byte> _memberCounts;
        [FieldOffset(0x55), FixedSizeArray] internal FixedSizeArray80<byte> _memberFlags;
        [FieldOffset(0xA8), FixedSizeArray] internal FixedSizeArray960<DawnMemberEntry> _members; // this is a 80 * 12 2d array

        [MemberFunction("E8 ?? ?? ?? ?? 44 3A E8 72")]
        public partial byte GetMemberCount(byte index);

        [MemberFunction("E8 ?? ?? ?? ?? 40 3A 2C")]
        public partial DawnMemberEntry* GetMembers(byte index);
    }

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public partial struct DawnPartyData {
        [FieldOffset(0x00)] public byte PlayerClassJobId;
        [FieldOffset(0x01)] public byte MemberCount;
        [FieldOffset(0x02), FixedSizeArray] internal FixedSizeArray7<DawnPartyMember> _partyMembers;

        [MemberFunction("48 89 5C 24 ?? 0F B6 59 ?? 45 32 C9")]
        public partial bool IsPartyMember(byte memberIndex, byte* outRole = null);

        [MemberFunction("48 89 5C 24 ?? 48 89 7C 24 ?? 44 0F B6 51 ?? 32 C0")]
        public partial bool AddMember(byte memberIndex, DawnMemberEntry* member);

        [MemberFunction("32 C0 0F 1F 40 00 66 66 0F 1F 84 ?? 00 00 00 00 44 0F B6 C0 42 38 54")]
        public partial void RemoveMember(byte memberIndex);

        [MemberFunction("48 8D 41 ?? B9 07 00 00 00 0F 1F 80 00 00 00 00 C6 00 FF")]
        public partial void ClearParty();

        [MemberFunction("E8 ?? ?? ?? ?? 0F B6 F0 48 8B 7B")]
        public partial bool CanAddMember(byte memberIndex, DawnMemberEntry* member);

        [MemberFunction("44 0F B6 41 ?? 32 C0 45 84 C0 74 ?? 0F 1F 40 00")]
        public partial bool IsFull();
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x02)]
    public struct DawnPartyMember {
        [FieldOffset(0x00)] public byte MemberIndex;
        [FieldOffset(0x01)] public byte Role;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0xF0)]
    public struct DawnContentEntry {
        [FieldOffset(0x00)] public Utf8String Name;
        [FieldOffset(0x68)] public Utf8String LevelText;
        [FieldOffset(0xD0)] public uint ContentFinderConditionId;
        [FieldOffset(0xDC)] public ushort AvgItemLevel;
        [FieldOffset(0xDE)] public ushort ItemLevelSync;
        [FieldOffset(0xE0)] public ushort SortOrder;
        [FieldOffset(0xE2)] public byte DawnContentId;
        [FieldOffset(0xE3)] public byte Level;
        [FieldOffset(0xE4)] public byte MemberCount;
        [FieldOffset(0xE5)] public byte ExVersion;
        [FieldOffset(0xE6)] public bool IsSideQuest;
        [FieldOffset(0xE7)] public byte Index;
        [FieldOffset(0xE8)] public bool IsMemberSelectionAvailable;
        [FieldOffset(0xE9)] public bool IsTrustAvailable;
        [FieldOffset(0xEA)] public bool IsNotYetSupported;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public struct DawnExpansionEntry {
        [FieldOffset(0x00)] public byte ExVersion;
        [FieldOffset(0x01)] public byte ListOffset;
        [FieldOffset(0x02)] public byte ContentEntries;
        [FieldOffset(0x08)] public CStringPointer Name;
    }

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x198)]
    public partial struct DawnMemberEntry {
        [FieldOffset(0x00)] public byte MemberId;
        [FieldOffset(0x01), FixedSizeArray] internal FixedSizeArray3<byte> _memberIdVariants;
        [FieldOffset(0x04)] public byte DefaultMemberId; // memberid for default or -1
        [FieldOffset(0x05)] public byte Roles; // bits 0 tank,1 dps,2 heal
        [FieldOffset(0x06)] public byte BlockedRoles;
        [FieldOffset(0x07)] public byte ClassJob;
        [FieldOffset(0x08), FixedSizeArray] internal FixedSizeArray3<byte> _classJobVariants;
        [FieldOffset(0x0B)] public byte ClassJobIcon;
        [FieldOffset(0x0C), FixedSizeArray] internal FixedSizeArray3<byte> _classJobIconVariants;
        [FieldOffset(0x0F)] public byte CurrentGlamour; // index for the images

        [FieldOffset(0x14)] public ushort Level;
        [FieldOffset(0x16)] public byte Flags; // 1 init, 2 all-rounder, 4 ??
        [FieldOffset(0x18)] public uint Exp;
        [FieldOffset(0x1C)] public uint MaxExp;
        [FieldOffset(0x20), FixedSizeArray] internal FixedSizeArray4<uint> _selectImages;
        [FieldOffset(0x30), FixedSizeArray] internal FixedSizeArray4<uint> _portraitImages;
        [FieldOffset(0x40), FixedSizeArray] internal FixedSizeArray4<uint> _glamourUnlocks;
        [FieldOffset(0x50), FixedSizeArray] internal FixedSizeArray4<byte> _glamours;
        [FieldOffset(0x54)] public byte GlamourCount;
        [FieldOffset(0x58)] public uint VoiceLine;
        [FieldOffset(0x60)] public Utf8String Name;
        [FieldOffset(0xC8)] public Utf8String ClassName;
        [FieldOffset(0x130)] public Utf8String ClassNameJapanese;
    }
}
