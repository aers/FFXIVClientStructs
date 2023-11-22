using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Client.UI.Misc;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// 6.31 ctor 48 89 5C 24 ?? 48 89 74 24 ?? 57 48 83 EC 20 33 F6 C6 41 08 00 48 89 71 18
//      size 0xAD8

[Agent(AgentId.FreeCompany)]
[StructLayout(LayoutKind.Explicit, Size = 0xAD8)]
public unsafe partial struct AgentFreeCompany {
    [FieldOffset(0x000)] public AgentInterface AgentInterface;
    [FieldOffset(0x028)] public void* vtbl2;
    [FieldOffset(0x030)] public void* vtbl3;

    [FieldOffset(0x040)] public RaptureTextModule* RaptureTextModule;
    [FieldOffset(0x048)] public void* InfoProxy0;
    [FieldOffset(0x050)] public void* InfoProxy1;

    [FieldOffset(0x05E)] public byte CurrentMemberPageIndex;

    [FieldOffset(0x328)] public Utf8String Board;
    [FieldOffset(0x390)] private Utf8String board2;

    [FieldOffset(0x400)] public Utf8String Slogan;
    [FieldOffset(0x468)] private Utf8String slogan2;

    [FieldOffset(0x4D8)] public Utf8String ShortMessage;
    [FieldOffset(0x540)] private Utf8String shortMessage2;

    [FieldOffset(0xA90)] public FreeCompanyActionTimer ActionTimeRemaining;

    // This supports 3 company actions despite 2 being the current limit.
    // The UI also has a blank 3rd slot
    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public struct FreeCompanyActionTimer {
        [FieldOffset(0x00)] public uint TimeSinceUpdate;
        [FieldOffset(0x04)] public fixed uint TimeRemainingAtUpdate[3];

        public uint this[int index] {
            get {
                if (index is < 0 or > 2) return 0;
                return TimeRemainingAtUpdate[index] - TimeSinceUpdate;
            }
        }
    }
}
