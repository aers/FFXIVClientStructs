using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Client.UI.Info;
using FFXIVClientStructs.FFXIV.Client.UI.Misc;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentFreeCompany
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.FreeCompany)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0xAD8)]
public unsafe partial struct AgentFreeCompany {
    [FieldOffset(0x040)] public RaptureTextModule* RaptureTextModule;
    [FieldOffset(0x048)] public InfoProxyFreeCompany* InfoProxyFreeCompany;
    [FieldOffset(0x050)] public InfoProxyFreeCompanyMember* InfoProxyFreeCompanyMember;

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
    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public partial struct FreeCompanyActionTimer {
        [FieldOffset(0x00)] public uint TimeSinceUpdate;
        [FieldOffset(0x04), FixedSizeArray] internal FixedSizeArray3<uint> _timeRemainingAtUpdate;

        public uint this[int index] {
            get {
                if (index is < 0 or > 2) return 0;
                return TimeRemainingAtUpdate[index] - TimeSinceUpdate;
            }
        }
    }
}
