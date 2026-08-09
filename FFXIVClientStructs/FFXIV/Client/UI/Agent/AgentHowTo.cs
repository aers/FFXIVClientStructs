using FFXIVClientStructs.FFXIV.Component.Excel;
using static FFXIVClientStructs.FFXIV.Common.Configuration.ConfigBase;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentHowTo
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
//   Common::Configuration::ConfigBase::ChangeEventInterface
[Agent(AgentId.HowTo)]
[GenerateInterop]
[Inherits<AgentInterface>, Inherits<ChangeEventInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x98)]
public unsafe partial struct AgentHowTo {
    [FieldOffset(0x40)] public uint RowId;
    [FieldOffset(0x44)] public HowToOpenType OpenType;
    [FieldOffset(0x48)] public bool OpenFocused;
    [FieldOffset(0x49)] public bool IsPadMode;

    // 0x50 stuff for pending HowToNotices

    [FieldOffset(0x78)] public uint Page;
    [FieldOffset(0x7C)] public uint PageCount;
    [FieldOffset(0x80)] public ExcelModuleInterface.ExcelLanguage Language;

    [FieldOffset(0x88), CExporterExcel("HowTo")] public nint HowToRow;
    [FieldOffset(0x90)] private uint Unk90;

    [MemberFunction("E9 ?? ?? ?? ?? 8B CB 48 8B C3")]
    public partial void OpenHowTo(uint rowId, HowToOpenType openType = HowToOpenType.HowTo, bool focus = true);

    [MemberFunction("E8 ?? ?? ?? ?? BA ?? ?? ?? ?? 48 8D 4D ?? 8B D8 E8 ?? ?? ?? ?? 89 5D ?? 48 8D 4D ?? 8B 9F")]
    public partial uint GetAdjustedHowToIconId([CExporterExcel("HowToPage")] void* rowPtr, byte startTown, byte grandCompany);

    [MemberFunction("E8 ?? ?? ?? ?? EB ?? BA ?? ?? ?? ?? C7 87")]
    public static partial CStringPointer GetAdjustedHowToText(UIModuleInterface* uiModuleInterface, [CExporterExcel("HowToPage")] void* rowPtr, byte startTown, byte grandCompany);
}

public enum HowToOpenType {
    HowTo = 0,
    HowToNotice = 1
}
