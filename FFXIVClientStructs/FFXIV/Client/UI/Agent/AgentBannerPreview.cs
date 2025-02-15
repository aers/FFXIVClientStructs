using FFXIVClientStructs.FFXIV.Client.UI.Misc;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentBannerPreview
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.BannerPreview)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public unsafe partial struct AgentBannerPreview {
    [FieldOffset(0x28)] public AgentBannerPreviewState* State;
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x3F8)]
public unsafe partial struct AgentBannerPreviewState {
    [FieldOffset(0)] public BannerGearData GearData;
    [FieldOffset(0x64)] public BannerModuleEntry BannerModuleEntry;

    [FieldOffset(0xF8)] public AgentBannerPreview* AgentPtr;
    [FieldOffset(0x100)] public UIModule* UIModulePtr;
    [FieldOffset(0x108)] public CharaViewPortrait* CharaViewPortraitPtr;
}
