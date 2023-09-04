using FFXIVClientStructs.FFXIV.Client.Game.Object;
using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Component.Excel;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::PronounModule
// ctor "E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 48 8B D7 E8 ?? ?? ?? ?? 48 8B 44 24"
[StructLayout(LayoutKind.Explicit, Size = 0x3B0)]
public unsafe partial struct PronounModule {
    public static PronounModule* Instance() => Framework.Instance()->GetUiModule()->GetPronounModule();

    [FieldOffset(0x08)] public ExcelModuleInterface* ExcelModuleInterface;
    [FieldOffset(0x10)] public RaptureTextModule* RaptureTextModule;
    [FieldOffset(0x18)] public ExcelSheet* TextCommandParamSheet;

    [FieldOffset(0x290)] public GameObject* UiMouseOverTarget;
    //[FieldOffset(0x298)] public TextChecker TextChecker;
    [FieldOffset(0x390)] public UIModule* UiModule;

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 5C 24 ?? EB 0C")]
    [GenerateCStrOverloads]
    public partial GameObject* ResolvePlaceholder(byte* placeholder, byte unknown0, byte unknown1);
}
