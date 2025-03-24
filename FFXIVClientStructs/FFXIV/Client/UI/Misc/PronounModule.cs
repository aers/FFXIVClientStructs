using FFXIVClientStructs.FFXIV.Client.Game.Object;
using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Common.Component.Excel;
using FFXIVClientStructs.FFXIV.Component.Text;
using ExcelModuleInterface = FFXIVClientStructs.FFXIV.Component.Excel.ExcelModuleInterface;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::PronounModule
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x3B0)]
public unsafe partial struct PronounModule {
    public static PronounModule* Instance() {
        var uiModule = UI.UIModule.Instance();
        return uiModule == null ? null : uiModule->GetPronounModule();
    }

    [FieldOffset(0x08)] public ExcelModuleInterface* ExcelModuleInterface;
    [FieldOffset(0x10)] public RaptureTextModule* RaptureTextModule;
    [FieldOffset(0x18)] public ExcelSheet* TextCommandParamSheet;
    [FieldOffset(0x20)] public Utf8String DecodedResult;
    [FieldOffset(0x88)] public Utf8String MacroCodeResult;
    [FieldOffset(0xF0)] public Utf8String EncodedResult;

    [FieldOffset(0x290)] public GameObject* UiMouseOverTarget;
    [FieldOffset(0x298)] public TextChecker TextChecker;
    [FieldOffset(0x390)] public UIModule* UIModule;

    [VirtualFunction(1)]
    public partial Utf8String* ProcessString(Utf8String* input, bool encode, int maxLength = 1023);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 5C 24 ?? EB 0C"), GenerateStringOverloads]
    public partial GameObject* ResolvePlaceholder(CStringPointer placeholder, byte unknown0, byte unknown1);
}
